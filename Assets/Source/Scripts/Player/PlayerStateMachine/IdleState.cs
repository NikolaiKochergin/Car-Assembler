namespace CarAssembler
{
    public class IdleState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public IdleState(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _player = _playerStateMachine.Player;
        }

        public void Enter()
        {
            _player.TaskListWidget.Show();
            if(_player.Stand != null && _player.Stand.IsEnable)
                _playerStateMachine.SetPartPickingState();
        }

        public void Exit()
        {
        }

        public void Update()
        {
            if(_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }
    }
}