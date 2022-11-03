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
        [SerializeField] private float _minPositionY = -1;
        [SerializeField] private float _maxPositionY = 5;
        [SerializeField] private Vector3 _modelOffset;

        private float _defaultSpeed;
        private bool _isControlled;
        private bool _isInRace;
        private bool _isOnQuickTimeEvent;

        private MainCameraContainer _mainCameraContainer;
        private Player _player;
        private float _speedMultiplier;
        private float _targetOffsetY;
        private float _targetRotationX;
        private UI _ui;

        private void Awake()
        {
            Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        private void Update()
        {
            if (_isInRace == false) return;

            if (_isControlled)
                if (Input.GetMouseButton(0))
                    _targetOffsetY = _maxPositionY;
                else
                    _targetOffsetY = _minPositionY;


            if (_targetOffsetY - _player.PlayerMover.SplineFollower.motion.offset.y > 0)
                _targetRotationX = -30f;
            else if (_targetOffsetY - _player.PlayerMover.SplineFollower.motion.offset.y < 0)
                _targetRotationX = 30f;
            else
                _targetRotationX = 0f;

            _player.PlayerMover.SplineFollower.motion.offset = Vector2.MoveTowards(
                _player.PlayerMover.SplineFollower.motion.offset,
                new Vector2(0, _targetOffsetY), 6 * Time.deltaTime);

            _player.PlayerMover.SplineFollower.motion.rotationOffset = Vector3.Lerp(
                _player.PlayerMover.SplineFollower.motion.rotationOffset,
                new Vector3(_targetRotationX, 0, 0), 8 * Time.deltaTime);
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
            
            _player.Model.transform.localPosition = _modelOffset;

            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _targetOffsetY = _player.PlayerMover.SplineFollower.motion.offset.y;
                _targetRotationX = _player.PlayerMover.SplineFollower.motion.rotationOffset.x;
                _player.PlayerMover.StartMove();
                //_player.StartRotationWheels();
                _rival.StartMove();
                _isInRace = true;
                _isControlled = true;
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
        public void PrepareToStopRace()
        {
            _targetOffsetY = 0;
            _isControlled = false;
        }

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();

            _player.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded -= OnQuickTimeEventEnded;

            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();
            _isInRace = false;

            RaceEnded?.Invoke();
        }

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);
        }

        private void OnQuickTimeEventEnded()
        {
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
        }
    }
}