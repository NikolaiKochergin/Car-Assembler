namespace CarAssembler
{
    public class NonControlledState : IPlayerState
    {
        private readonly Player _player;
        private readonly PlayerStateMachine _playerStateMachine;

        public NonControlledState(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _player = playerStateMachine.Player;
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