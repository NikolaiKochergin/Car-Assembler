namespace CarAssembler
{
    public class PartPickingState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public PartPickingState(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _player = playerStateMachine.Player;
        }

        public void Enter()
        {
            _player.StartPickingDetail();
            _player.PlayInput.Disable();
        }

        public void Exit()
        {
            var detail = _player.Stand.GetDetail();
            _player.Car.TryTakeDetail(detail);
            
            _player.PlayInput.Enable();
        }

        public void Update()
        {
        }
    }
}