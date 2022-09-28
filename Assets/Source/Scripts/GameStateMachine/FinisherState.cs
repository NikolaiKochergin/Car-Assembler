using CarAssembler;

public class FinisherState : IGameState
{
    private Player _player;
    private readonly UI _ui;

    public FinisherState(Player player, UI ui)
    {
        _player = player;
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