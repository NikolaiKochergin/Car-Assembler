using CarAssembler;

public class FinisherState : IGameState
{
    private readonly PlayerStateMachine _playerStateMachine;
    private readonly UI _ui;

    public FinisherState(PlayerStateMachine playerStateMachine, UI ui)
    {
        _playerStateMachine = playerStateMachine;
        _ui = ui;
    }


    public void Enter()
    {
        _ui.FinisherMenu.Show();
    }

    public void Exit()
    {
        _ui.FinisherMenu.Hide();
    }
}