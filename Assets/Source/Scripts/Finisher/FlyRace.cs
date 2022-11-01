using System;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class FlyRace : MonoBehaviour, IRace
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;
        [SerializeField] private AnimationCurve _changeSpeedCurve;
        [SerializeField] [Min(0)] private float _changeSpeedDuration = 1;

        private float _defaultSpeed;
        private bool _isOnQuickTimeEvent;

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
            _player.QuickTimeEventEnded += OnQuickTimeEventEnded;
        }

        public void StartRace()
        {
            _mainCameraContainer.SetRacePosition();

            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _player.transform.SetPositionAndRotation(_playerStartPoint.position, _playerStartPoint.rotation);

            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _player.PlayerMover.StartMove();
                //_player.StartRotationWheels();
                _rival.StartMove();
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

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();

            _player.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded -= OnQuickTimeEventEnded;

            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();

            RaceEnded?.Invoke();
        }

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            Debug.Log("Тут что то должно происходить на вроде в триггер");
        }

        private void OnQuickTimeEventEnded()
        {
            Debug.Log("Тут что то должно происходить на выходе из триггера");
        }
    }
}