namespace CarAssembler
{
    public class PartPickingState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public PartPickingState(PlayerStateMachine playerStateMachine)
        {
            _player = playerStateMachine.Player;
            _playerStateMachine = playerStateMachine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            if (_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }
    }
}