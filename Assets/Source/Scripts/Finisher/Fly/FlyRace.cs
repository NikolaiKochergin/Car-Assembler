using System;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CarAssembler
{
    public class FlyRace : MonoBehaviour, IRace
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;
        [SerializeField] [Min(0)] private float _speedReductionMultiplier = 0.5f;
        [SerializeField] private Vector3 _modelOffset;

        [SerializeField] private FlyMover _playerFlyMover;
        [SerializeField] private FlyMover _rivalFlyMover;

        private float _defaultSpeed;
        private bool _isControlled;
        private bool _isOnQuickTimeEvent;

        private MainCameraContainer _mainCameraContainer;
        private Player _player;
        private float _speedMultiplier;
        private UI _ui;

        private float _rivalChangeDirectionTimer;
        private bool _isRivalMoveUp;

        private void Awake()
        {
            Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        private void Update()
        {
            if (_isControlled)
            {
                if (Input.GetMouseButton(0))
                    _playerFlyMover.MoveUp();
                else
                    _playerFlyMover.MoveDown();

                if (_rivalChangeDirectionTimer <= 0)
                {
                    if (_isRivalMoveUp)
                        _rivalFlyMover.MoveUp();
                    else
                        _rivalFlyMover.MoveDown();

                    _rivalChangeDirectionTimer = Random.Range(0.1f, 1f);
                    
                    _isRivalMoveUp = !_isRivalMoveUp;
                }

                _rivalChangeDirectionTimer -= Time.deltaTime;
            }
        }

        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            _player = player;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;
            _playerFlyMover.Initialize(_player.PlayerMover.SplineFollower);
            _rivalFlyMover.Initialize(_rival.Follower);

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
                _player.PlayerMover.StartMove();
                _playerFlyMover.Enable();
                _rivalFlyMover.Enable();
                //_player.StartRotationWheels();
                _rival.StartMove();
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
            _playerFlyMover.MoveToZero();
            _rivalFlyMover.MoveToZero();
            _isControlled = false;
        }

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();
            _playerFlyMover.Disable();
            _rivalFlyMover.Disable();

            _player.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded -= OnQuickTimeEventEnded;

            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();

            RaceEnded?.Invoke();
        }

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * _speedReductionMultiplier);
        }

        private void OnQuickTimeEventEnded()
        {
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
        }
    }
}