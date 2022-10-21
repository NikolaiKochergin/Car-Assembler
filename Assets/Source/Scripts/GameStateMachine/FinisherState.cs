using UnityEngine;

namespace CarAssembler
{
    public class FinisherState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly TaskChecker _taskChecker;
        private readonly UI _ui;
        private readonly MainCameraContainer _mainCameraContainer;

        public FinisherState(GameStateMachine gameStateMachine, PlayerStateMachine playerStateMachine, UI ui,
            TaskChecker taskChecker, MainCameraContainer mainCameraContainer)
        {
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _taskChecker = taskChecker;
            _mainCameraContainer = mainCameraContainer;
        }


        public void Enter()
        {
            _playerStateMachine.Player.TaskListWidget.Hide();
            var finisher = _taskChecker.GetFinisherBy(_playerStateMachine.Player.Tasks, _playerStateMachine.Player.Car);

            if (finisher is MonoBehaviour mono)
            {
                Transform transformFinisher = mono.transform;
                _mainCameraContainer.Follower.ChangeTarget(transformFinisher);
            }

            finisher.Show(() => { _gameStateMachine.SetEndLevelState(); });


            _ui.FinisherMenu.Show();
        }

        public void Exit()
        {
            _ui.FinisherMenu.Hide();
        }
    }
}