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
            _player.TakingDetailTimer.StartTimer(() =>
            {
                var detail = _player.FactoryMachine.GetDetail();
                _player.Car.TakeDetail(detail);
                _playerStateMachine.SetIdleState();
            });
        }

        public void Exit()
        {
            _player.TakingDetailTimer.StopTimer();
        }

        public void Update()
        {
            if(_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }
    }
}