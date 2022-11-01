using UnityEngine.SceneManagement;

namespace CarAssembler
{
    public class EndLevelState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly MainCameraContainer _mainCameraContainer;

        public EndLevelState(GameStateMachine gameStateMachine)
        {
            _playerStateMachine = gameStateMachine.PlayerStateMachine;
            _ui = gameStateMachine.UI;
            _mainCameraContainer = gameStateMachine.MainCameraContainer;
        }

        public void Enter()
        {
            _ui.EndLevelMenu.Show();
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
}