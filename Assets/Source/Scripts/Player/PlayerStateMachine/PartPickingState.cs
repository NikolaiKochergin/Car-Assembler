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
                var detail = _player.Stand.GetDetail();

                if (detail is Car car)
                    _player.SetCar(car);
                else if (_player.Car.TryTakeDetail(_player.Stand))
                    _player.AddDetailPrice(_player.Stand.DetailPrice);
                _playerStateMachine.SetIdleState();
            });
        }

        public void Exit()
        {
            _player.TakingDetailTimer.StopTimer();
        }

        public void Update()
        {
            if (_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }
    }
}