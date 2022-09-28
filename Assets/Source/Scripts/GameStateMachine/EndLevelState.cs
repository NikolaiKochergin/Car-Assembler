using CarAssembler;

public class EndLevelState : IGameState
{
    private Player _player;
    private readonly UI _ui;

    public EndLevelState(Player player, UI ui)
    {
        _player = player;
        _ui = ui;
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