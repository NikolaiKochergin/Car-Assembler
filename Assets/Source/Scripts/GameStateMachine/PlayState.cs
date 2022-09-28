using CarAssembler;

public class PlayState : IGameState
{
    private Player _player;
    private readonly UI _ui;

    public PlayState(Player player, UI ui)
    {
        _player = player;
        _ui = ui;
    }

    public void Enter()
    {
        _ui.PlayMenu.Show();
    }

    public void Exit()
    {
        _ui.PlayMenu.Hide();
    }
}