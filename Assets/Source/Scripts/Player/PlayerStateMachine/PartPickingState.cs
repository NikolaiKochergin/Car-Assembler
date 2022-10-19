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
            _player.PlayInput.Disable();
            _player.Stand.UI.ShowWith(_player.Tasks);
        }

        public void Exit()
        {
            var detail = _player.Stand.GetDetail();
            _player.Car.TryTakeDetail(detail);
            
            _player.PlayInput.Enable();
            _player.Stand.UI.Hide();
        }

        public void Update()
        {
        }
    }
}