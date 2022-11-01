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

        public FinisherState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = gameStateMachine.PlayerStateMachine;
            _ui = gameStateMachine.UI;
            _taskChecker = gameStateMachine.TaskChecker;
            _mainCameraContainer = gameStateMachine.MainCameraContainer;
        }


        public void Enter()
        {
            _ui.FinisherMenu.Show();
            
            var finisher = _taskChecker.GetFinisherBy(_playerStateMachine.Player.Tasks, _playerStateMachine.Player.Car);

            finisher.Race.Show();
            
            if (finisher is MonoBehaviour mono)
            {
                Transform transformFinisher = mono.transform;
                _mainCameraContainer.Follower.ChangeTarget(transformFinisher);
            }

            finisher.Show(_gameStateMachine.SetRaceState);
        }
        
        public void Exit()
        {
            _mainCameraContainer.Follower.ChangeTarget(_playerStateMachine.Player.transform);
            _mainCameraContainer.transform.position = _playerStateMachine.Player.transform.position;
            _ui.FinisherMenu.Hide();
        }
    }
}