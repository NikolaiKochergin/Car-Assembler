namespace CarAssembler
{
    public class PartPickingState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public PartPickingState(Player player, PlayerStateMachine playerStateMachine)
        {
            _player = player;
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