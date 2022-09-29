using CarAssembler;

public class EndLevelState : IGameState
{
    private readonly PlayerStateMachine _playerStateMachine;
    private readonly UI _ui;
    private readonly Data _data;

    public EndLevelState(PlayerStateMachine playerStateMachine, UI ui, Data data)
    {
        _playerStateMachine = playerStateMachine;
        _ui = ui;
        _data = data;
    }

    public void Enter()
    {
        _ui.EndLevelMenu.Show();
    }

    public void Exit()
    {
        _ui.EndLevelMenu.Hide();
    }
}