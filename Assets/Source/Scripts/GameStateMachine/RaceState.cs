namespace CarAssembler
{
    public class RaceState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Player _player;
        private readonly TaskChecker _checker;
        private readonly MainCameraContainer _mainCameraContainer;

        public RaceState(GameStateMachine gameStateMachine, UI ui, TaskChecker checker, MainCameraContainer mainCameraContainer)
        {
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = gameStateMachine.PlayerStateMachine;
            _ui = ui;
            _player = gameStateMachine.PlayerStateMachine.Player;
            _checker = checker;
            _mainCameraContainer = mainCameraContainer;
        }
        
        public void Enter()
        {
            _ui.RaceMenu.Show();
            _checker.CurrentFinisher.Race.Initialize(_player, _ui, _mainCameraContainer);
            _playerStateMachine.SetNonControlledState();

            _checker.CurrentFinisher.Race.RaceEnded += OnRaceEnded;
            _checker.CurrentFinisher.Race.StartRace();
        }

        public void Exit()
        {
            _checker.CurrentFinisher.Race.RaceEnded -= OnRaceEnded;
            _ui.RaceMenu.Hide();
        }

        private void OnRaceEnded()
        {
            _gameStateMachine.SetEndLevelState();
        }
    }
}
