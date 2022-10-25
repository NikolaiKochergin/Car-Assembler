namespace CarAssembler
{
    public class NonControlledState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public NonControlledState(PlayerStateMachine playerStateMachine, Player player)
        {
            _playerStateMachine = playerStateMachine;
            _player = player;
        }

        public void Enter()
        {
            _player.PlayInput.Disable();
            _player.NonControlledStateEnding += OnNonControlledStateEnding;
        }

        public void Exit()
        {
            _player.PlayInput.Enable();
            _player.NonControlledStateEnding += OnNonControlledStateEnding;
        }

        public void Update()
        {
        }

        private void OnNonControlledStateEnding()
        {
            _playerStateMachine.SetIdleState();
        }
    }
}