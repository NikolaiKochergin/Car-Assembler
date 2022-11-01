using System;
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

        private Player _player;
        private UI _ui;
        private MainCameraContainer _mainCameraContainer;

        private float _defaultSpeed;
        private float _speedMultiplier;
        
        private void Awake()
        {
            //Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            _player = player;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;
        }

        public void StartRace()
        {
            _mainCameraContainer.SetRacePosition();
            
            
            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _player.transform.SetPositionAndRotation(_playerStartPoint.position,_playerStartPoint.rotation);
            
            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _player.PlayerMover.StartMove();
                //_player.StartRotationWheels();
                _rival.StartMove();
                _rival.StartRotationWheels();
            });
        }

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();
            
            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();
            
            RaceEnded?.Invoke();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}