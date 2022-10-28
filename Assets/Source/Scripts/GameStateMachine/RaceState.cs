namespace CarAssembler
{
    public class RaceState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Player _player;
        private readonly TaskChecker _checker;

        private float _defaultSpeed;

        public RaceState(PlayerStateMachine playerStateMachine, UI ui, TaskChecker checker)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _player = playerStateMachine.Player;
            _checker = checker;
        }
        
        public void Enter()
        {
            _ui.RaceMenu.Show();
            _playerStateMachine.SetNonControlledState();
            _playerStateMachine.Player.YokeEventTaken += OnYokeEventTaken;
            _checker.CurrentFinisher.Race.StartRace();
            _defaultSpeed = _player.PlayerMover.SplineFollower.followSpeed;
        }

        public void Exit()
        {
            _ui.RaceMenu.Hide();
            _player.PlayerMover.StartMove();
            _playerStateMachine.Player.YokeEventTaken -= OnYokeEventTaken;
        }

        private void OnYokeEventTaken()
        {
            _ui.RaceMenu.YokeButton.gameObject.SetActive(true);
            _ui.RaceMenu.Yoke.gameObject.SetActive(true);
            
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);

            _ui.RaceMenu.YokeButton.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            _ui.RaceMenu.YokeButton.onClick.RemoveListener(OnClicked);
            
            _ui.RaceMenu.YokeButton.gameObject.SetActive(false);
            _ui.RaceMenu.Yoke.gameObject.SetActive(false);

            var speedMultiplier = _ui.RaceMenu.Yoke.InputValue;
            
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * speedMultiplier);
        }
    }
}
