namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Data _data;

        public InitialState(PlayerStateMachine playerStateMachine, UI ui, Data data)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _data = data;
        }

        public void Enter()
        {
            _ui.PlayMenu.ProgressWidget.Initialize(_data.GetDisplayedLevelNumber(), _playerStateMachine.Player);
            _ui.MainMenu.Show();
            _playerStateMachine.SetNonControlledState();
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
        }
    }
}