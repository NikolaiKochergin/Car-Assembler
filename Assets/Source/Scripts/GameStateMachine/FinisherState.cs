namespace CarAssembler
{
    public class FinisherState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly TaskChecker _taskChecker;
        private readonly UI _ui;

        public FinisherState(GameStateMachine gameStateMachine, PlayerStateMachine playerStateMachine, UI ui,
            TaskChecker taskChecker)
        {
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _taskChecker = taskChecker;
        }


        public void Enter()
        {
            var finisher = _taskChecker.GetFinisherBy(_playerStateMachine.Player.Tasks, _playerStateMachine.Player.Car);

            finisher.Show(() => { _gameStateMachine.SetEndLevelState(); });


            _ui.FinisherMenu.Show();
        }

        public void Exit()
        {
            _ui.FinisherMenu.Hide();
        }
    }
}