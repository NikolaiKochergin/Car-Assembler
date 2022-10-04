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
        var money = _playerStateMachine.Player.Car.Price;
        money += _data.GetMoney();
        
        _ui.EndLevelMenu.MoneyWidget.SetMoneyText(money);
        _data.SetMoney(money);
        
        _ui.EndLevelMenu.Show();
        _ui.EndLevelMenu.MoneyWidget.Enable();
    }

    public void Exit()
    {
        _ui.EndLevelMenu.Hide();
    }
}