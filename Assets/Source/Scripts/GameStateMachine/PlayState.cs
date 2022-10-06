using CarAssembler;

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
        // Если концепция снова изменится и нужно будет включить деньги, то раскоментить.
        //_playerStateMachine.Player.MoneyWidget.Enable();
        _playerStateMachine.SetIdleState();
    }

    public void Exit()
    {
        _playerStateMachine.Player.MoneyWidget.Disable();
        _ui.PlayMenu.Hide();
    }
}