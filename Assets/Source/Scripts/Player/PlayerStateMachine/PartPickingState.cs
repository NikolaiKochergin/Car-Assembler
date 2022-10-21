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
            _player.Stand.Button.Clicked += OnClicked;
        }

        public void Exit()
        {
            _player.Stand.Button.Clicked -= OnClicked;
        }

        public void Update()
        {
            if(!_player.Stand.Button.IsPointerOnButton && _player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }

        private void OnClicked()
        {
            var detail = _player.Stand.GetDetail();
            _player.Car.TakeDetail(detail);
        }
    }
}