using System;
using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class DirtRace : MonoBehaviour, IRace
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;
        [SerializeField] private AnimationCurve _changeSpeedCurve;
        [SerializeField] [Min(0)] private float _changeSpeedDuration = 1;

        private Coroutine _changeSpeedCoroutine;

        private float _defaultSpeed;
        private bool _isOnQuickTimeEvent;
        private MainCameraContainer _mainCameraContainer;

        private Player _player;
        private float _speedMultiplier;
        private UI _ui;

        private void Awake()
        {
            //Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        private void Update()
        {
            if (_isOnQuickTimeEvent == false) return;

            if (Input.GetMouseButtonDown(0)) 
                _changeSpeedCoroutine ??= StartCoroutine(ChangSpeedCoroutine());
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
            _isOnQuickTimeEvent = true;
            
            _ui.RaceMenu.TapMessage.Show();

            _speedMultiplier = 1;

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);
            _rival.SetSpeedMultiplier(0.5f);

        }

        private void OnQuickTimeEventEnded()
        {
            _isOnQuickTimeEvent = false;

            if (_changeSpeedCoroutine != null)
            {
                StopCoroutine(_changeSpeedCoroutine);
                _changeSpeedCoroutine = null;
            }
            
            _ui.RaceMenu.TapMessage.Hide();

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _rival.SetSpeedMultiplier(1);

            if (_player.Car.CurrentWheels != null) 
                _player.ChangeRotationWheels(_player.PlayerMover.MoveSpeed);

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

        private IEnumerator ChangSpeedCoroutine()
        {
            for (float t = 0; t < 1; t += Time.deltaTime / _changeSpeedDuration)
            {
                _player.PlayerMover.SetFollowSpeed(_defaultSpeed * (_changeSpeedCurve.Evaluate(t)- 0.8f));
                _rival.SetSpeedMultiplier(_changeSpeedCurve.Evaluate(t) - 0.8f);

                yield return null;
            }

            _changeSpeedCoroutine = null;
        }
    }
}