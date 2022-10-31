namespace CarAssembler
{
    public class RaceState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Player _player;
        private readonly TaskChecker _checker;
        private readonly MainCameraContainer _mainCameraContainer;

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
            _ui.RaceMenu.Show();
            _checker.CurrentFinisher.Race.Initialize(_playerStateMachine.Player, _ui, _mainCameraContainer);
            _playerStateMachine.SetNonControlledState();
            
            _checker.CurrentFinisher.Race.StartRace();
        }

        public void Exit()
        {
            _ui.RaceMenu.Hide();
            //_player.PlayerMover.StartMove();
        }
    }
}
