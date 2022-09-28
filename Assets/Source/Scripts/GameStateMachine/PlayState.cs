using System;
using CarAssembler;

public class PlayState : IGameState
{
    private Player _player;
    private UI _ui;

    public PlayState(Player player, UI ui)
    {
        _player = player;
        _ui = ui;
    }

    public void Enter()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}