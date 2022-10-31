using UnityEngine;

namespace CarAssembler
{
    public class RaceState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Player _player;
        private readonly TaskChecker _checker;
        private readonly MainCameraContainer _mainCameraContainer;

        private float _defaultSpeed;

        public RaceState(PlayerStateMachine playerStateMachine, UI ui, TaskChecker checker, MainCameraContainer mainCameraContainer)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _player = playerStateMachine.Player;
            _checker = checker;
            _mainCameraContainer = mainCameraContainer;
        }
        
        public void Enter()
        {
            _playerStateMachine.Player.ParticleContainer.PlayFogCarParticle();
            _ui.RaceMenu.Show();
            _playerStateMachine.SetNonControlledState();
            _playerStateMachine.Player.YokeEventTaken += OnYokeEventTaken;
            _playerStateMachine.Player.YokeEventEnded += OnYokeEventEnded;
            _ui.RaceMenu.CountDownView.ShowCountDown();
            _checker.CurrentFinisher.Race.StartRace();
            _defaultSpeed = _player.PlayerMover.SplineFollower.followSpeed;
            _mainCameraContainer.SetRacePosition();
        }

        public void Exit()
        {
            _ui.RaceMenu.Hide();
            _player.PlayerMover.StartMove();
            _playerStateMachine.Player.YokeEventTaken -= OnYokeEventTaken;
            _playerStateMachine.Player.YokeEventEnded -= OnYokeEventEnded;
        }

        private void OnYokeEventTaken()
        {
            _ui.RaceMenu.YokeButton.gameObject.SetActive(true);
            _ui.RaceMenu.Yoke.gameObject.SetActive(true);
            
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);
            
            _ui.RaceMenu.YokeButton.onClick.AddListener(OnClicked);
        }

        private void OnYokeEventEnded()
        {
            _ui.RaceMenu.YokeButton.onClick.RemoveListener(OnClicked);
            
            _ui.RaceMenu.YokeButton.gameObject.SetActive(false);
            _ui.RaceMenu.Yoke.gameObject.SetActive(false);

            if (_player.Car.CurrentWheels != null)
            {
                _player.ChangeRotationWheels(_player.PlayerMover.MoveSpeed);
            }
        }

        private void OnClicked()
        {
            var speedMultiplier = _ui.RaceMenu.Yoke.InputValue;
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * speedMultiplier);
            
            OnYokeEventEnded();
        }
    }
}
