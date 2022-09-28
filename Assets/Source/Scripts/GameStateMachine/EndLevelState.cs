using System;
using CarAssembler;

public class EndLevelState : IGameState
{
    private Player _player;
    private UI _ui;

    public EndLevelState(Player player, UI ui)
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