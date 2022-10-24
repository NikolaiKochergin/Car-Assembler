using UnityEngine.Playables;

namespace CarAssembler
{
    public class KatSceneState : IGameState
    {
        private readonly PlayableDirector _enterKatScene;
        private readonly GameStateMachine _gameStateMachine;
        private readonly UI _ui;
        private readonly MainCameraContainer _mainCameraContainer;

        public KatSceneState(GameStateMachine gameStateMachine, PlayableDirector director, UI ui, MainCameraContainer mainCameraContainer)
        {
            _gameStateMachine = gameStateMachine;
            _enterKatScene = director;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;
        }

        public void Enter()
        {
            _enterKatScene.Play();
            _ui.MainMenu.StartButton.ButtonPressedDown += OnButtonPressedDown;
        }

        public void Exit()
        {
            _enterKatScene.Stop();
            _ui.MainMenu.StartButton.ButtonPressedDown += OnButtonPressedDown;
        }


        private void OnButtonPressedDown()
        {
            _mainCameraContainer.CameraAnimator.ShowMoveToPlayStateAnimation();
            _ui.PlayMenu.CustomerCloud.gameObject.SetActive(false);
            _ui.MainMenu.Hide();
            _gameStateMachine.SetPlayState();
        }
    }
}