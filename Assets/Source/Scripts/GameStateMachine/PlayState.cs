namespace CarAssembler
{
    public class PlayState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;

        public PlayState(GameStateMachine gameStateMachine)
        {
            _playerStateMachine = gameStateMachine.PlayerStateMachine;
            _ui = gameStateMachine.UI;
        }

        public void Enter()
        {
            _ui.PlayMenu.Show();
            _playerStateMachine.SetIdleState();
        }

        public void Exit()
        {
            _ui.PlayMenu.Hide();
            _playerStateMachine.Player.TaskListWidget.Hide();
        }
    }
}