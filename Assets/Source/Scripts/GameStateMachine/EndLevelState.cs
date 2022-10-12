using CarAssembler;

public class EndLevelState : IGameState
{
    private readonly PlayerStateMachine _playerStateMachine;
    private readonly UI _ui;

    public EndLevelState(PlayerStateMachine playerStateMachine, UI ui)
    {
        _playerStateMachine = playerStateMachine;
        _ui = ui;
    }

    public void Enter()
    {
        _ui.EndLevelMenu.Show();
        _ui.EndLevelMenu.MoneyWidget.Enable();
    }

    public void Exit()
    {
        _ui.EndLevelMenu.Hide();
    }
}