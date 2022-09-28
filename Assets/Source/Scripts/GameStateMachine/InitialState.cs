namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private Player _player;
        private readonly UI _ui;

        public InitialState(Player player, UI ui)
        {
            _player = player;
            _ui = ui;
        }

        public void Enter()
        {
            _ui.MainMenu.Show();
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
        }
    }
}