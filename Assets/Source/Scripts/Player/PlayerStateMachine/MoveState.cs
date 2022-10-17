namespace CarAssembler
{
    public class MoveState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public MoveState(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _player = _playerStateMachine.Player;
        }

        public void Enter()
        {
            _player.PlayerMover.StartMove();
            _player.ConveyorAnimator.Enable();
        }

        public void Exit()
        {
            _player.PlayerMover.StopMove();
            _player.ConveyorAnimator.Disable();
        }

        public void Update()
        {
            if (_player.PlayInput.IsMoving == false)
                _playerStateMachine.SetIdleState();
        }
    }
}