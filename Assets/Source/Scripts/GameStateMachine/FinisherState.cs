namespace CarAssembler
{
    public class FinisherState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly TaskChecker _taskChecker;
        private readonly UI _ui;
        private readonly Player _player;

        public FinisherState(GameStateMachine gameStateMachine, PlayerStateMachine playerStateMachine, UI ui,
            TaskChecker taskChecker, Player player)
        {
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _taskChecker = taskChecker;
            _player = player;
        }


        public void Enter()
        {
            _player.TaskListWidget.Hide();
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