using System;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class SpeedRace : MonoBehaviour, IRace
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;
        private QuickTimeEvent _currentQuickTimeEvent;

        private float _defaultSpeed;
        private MainCameraContainer _mainCameraContainer;

        private Player _player;
        private float _speedMultiplier;
        private UI _ui;

        private void Awake()
        {
            Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            _player = player;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;

            _player.QuickTimeEventTaken += OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded += OnYokeEventEnded;
        }

        public void StartRace()
        {

            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _player.transform.SetPositionAndRotation(
                _playerStartPoint.position,
                _playerStartPoint.rotation);

            _mainCameraContainer.SetRacePosition();
            _mainCameraContainer.transform.position = _player.transform.position;
            
            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _player.PlayerMover.StartMove();
                _player.StartRotationWheels();
                _rival.StartMove();
                _rival.StartRotationWheels();
            });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            _currentQuickTimeEvent = quickTimeEvent;

            _ui.RaceMenu.YokeButton.gameObject.SetActive(true);
            _ui.RaceMenu.Yoke.gameObject.SetActive(true);

            _speedMultiplier = 1;

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);
            _rival.SetSpeedMultiplier(0.5f);

            _ui.RaceMenu.YokeButton.onClick.AddListener(OnClicked);
        }

        private void OnYokeEventEnded()
        {
            _currentQuickTimeEvent.Hide();

            _ui.RaceMenu.YokeButton.onClick.RemoveListener(OnClicked);

            _ui.RaceMenu.YokeButton.gameObject.SetActive(false);
            _ui.RaceMenu.Yoke.gameObject.SetActive(false);

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * _speedMultiplier);
            _rival.SetSpeedMultiplier(3.6f - _speedMultiplier);

            if (_player.Car.CurrentWheels != null) _player.ChangeRotationWheels(_player.PlayerMover.MoveSpeed);
        }

        private void OnClicked()
        {
            _speedMultiplier = _ui.RaceMenu.Yoke.InputValue;

            OnYokeEventEnded();
        }

        public void SetRivalSpeedMultiplier(float value)
        {
            _rival.SetSpeedMultiplier(value);
        }

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();

            _player.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded -= OnYokeEventEnded;
            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();

            _player.StopRotationWheels();
            _rival.StopRotationWheels();

            RaceEnded?.Invoke();
        }
    }
}