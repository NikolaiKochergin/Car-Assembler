using System;

namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private Player _player;
        private UI _ui;

        public InitialState(Player player, UI ui)
        {
            _player = player;
            _ui = ui;
        }

        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}