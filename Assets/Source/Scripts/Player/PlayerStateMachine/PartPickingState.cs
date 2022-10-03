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
            _player.MoneyWidget.Disable();
            _player.TakingDetailTimer.StartTimer(() =>
            {
                var detail = _player.Stand.GetDetail();
                _player.Car.TryTakeDetail(detail);
                _playerStateMachine.SetIdleState();
            });
        }

        public void Exit()
        {
            _player.MoneyWidget.Enable();
            _player.TakingDetailTimer.StopTimer();
        }

        public void Update()
        {
            if(_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }
    }
}