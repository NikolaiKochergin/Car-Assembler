using CarAssembler;
using UnityEngine.SceneManagement;

public class EndLevelState : IGameState
{
    private readonly PlayerStateMachine _playerStateMachine;
    private readonly UI _ui;
    private readonly MainCameraContainer _mainCameraContainer;

    public EndLevelState(PlayerStateMachine playerStateMachine, UI ui, MainCameraContainer mainCameraContainer)
    {
        _playerStateMachine = playerStateMachine;
        _ui = ui;
        _mainCameraContainer = mainCameraContainer;
    }

    public void Enter()
    {
        _ui.EndLevelMenu.Show();
        _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();
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