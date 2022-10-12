using CarAssembler;
using UnityEngine.SceneManagement;

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
        SaveGame();
    }

    public void Exit()
    {
        _ui.EndLevelMenu.Hide();
    }

    private void SaveGame()
    {
        Data data = Storage.Load();

        data.Level = SceneManager.GetActiveScene().buildIndex + 1;
        Storage.Save(data);
    }
}