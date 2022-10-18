namespace CarAssembler
{
    public class PlayState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;

        public PlayState(PlayerStateMachine playerStateMachine, UI ui)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
        }

        public void Enter()
        {
            _ui.PlayMenu.Show();
            _ui.PlayMenu.TakeDetailButton.onClick.AddListener(OnTakeDetailButtonClicked);
            _playerStateMachine.SetIdleState();
            _playerStateMachine.Player.DetailPicking += OnDetailPicking;
        }

        public void Exit()
        {
            _ui.PlayMenu.Hide();
            _playerStateMachine.Player.DetailPicking -= OnDetailPicking;
            _ui.PlayMenu.TakeDetailButton.onClick.RemoveListener(OnTakeDetailButtonClicked);
        }

        private void OnDetailPicking()
        {
            _ui.PlayMenu.TakeDetailButton.gameObject.SetActive(true);
        }

        private void OnTakeDetailButtonClicked()
        {
            _ui.PlayMenu.TakeDetailButton.gameObject.SetActive(false);
            _playerStateMachine.SetIdleState();
        }
    }
}