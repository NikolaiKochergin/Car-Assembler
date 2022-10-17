namespace CarAssembler
{
    public class MoveState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public MoveState(PlayerStateMachine playerStateMachine)
        {
            _player = playerStateMachine.Player;
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