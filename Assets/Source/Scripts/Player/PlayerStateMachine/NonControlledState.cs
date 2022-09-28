namespace CarAssembler
{
    public class NonControlledState : IPlayerState
    {
        private readonly Player _player;

        public NonControlledState(Player player)
        {
            _player = player;
        }

        public void Enter()
        {
            _player.PlayInput.Disable();
        }

        public void Exit()
        {
            _player.PlayInput.Enable();
        }

        public void Update()
        {
        }
    }
}