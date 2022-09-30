namespace CarAssembler
{
    public class MoveState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public MoveState(Player player, PlayerStateMachine playerStateMachine)
        {
            _player = player;
            _playerStateMachine = playerStateMachine;
        }

        public void Enter()
        {
            _player.PlayerMover.StartMove();
            _player.Conveyor.Enable();
        }

        public void Exit()
        {
            _player.PlayerMover.StopMove();
            _player.Conveyor.Disable();
        }

        public void Update()
        {
            if (_player.PlayInput.IsMoving == false)
                _playerStateMachine.SetIdleState();
        }
    }
}