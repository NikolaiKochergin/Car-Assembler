namespace CarAssembler
{
    public class RaceState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly Player _player;

        public RaceState(PlayerStateMachine playerStateMachine, UI ui)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _player = playerStateMachine.Player;
        }
        
        public void Enter()
        {
            _playerStateMachine.Player.YokeEventTeken += OnYokeEventTeken;
        }

        public void Exit()
        {
            _playerStateMachine.Player.YokeEventTeken -= OnYokeEventTeken;
        }

        private void OnYokeEventTeken()
        {
            var speed = _player.PlayerMover.MoveSpeed;
            _player.PlayerMover.SetFollowSpeed(speed * 0.5f);
        }
    }
}
