namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;

        public InitialState(PlayerStateMachine playerStateMachine, UI ui)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
        }

        public void Enter()
        {
            _ui.MainMenu.Show();
            _playerStateMachine.SetNonControlledState();
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
        }
    }
}