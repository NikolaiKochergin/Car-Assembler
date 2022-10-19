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
            _player.Stand.UI.ShowWith(_player.Tasks);
            _player.Stand.Button.Clicked += OnClicked;
        }

        public void Exit()
        {
            _player.Stand.Button.Clicked -= OnClicked;
            _player.Stand.UI.Hide();
        }

        public void Update()
        {
            if(_player.PlayInput.IsMoving)
                _playerStateMachine.SetMoveState();
        }

        private void OnClicked()
        {
            var detail = _player.Stand.GetDetail();
            _player.Car.TryTakeDetail(detail);
        }
    }
}