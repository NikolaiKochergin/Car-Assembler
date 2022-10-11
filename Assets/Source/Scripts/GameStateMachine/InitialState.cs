using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly string TaskListsPath = "LevelTaskLists/";

        public InitialState(PlayerStateMachine playerStateMachine, UI ui)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
        }

        public void Enter()
        {
            //_ui.PlayMenu.ProgressWidget.Initialize(_data.GetDisplayedLevelNumber(), _playerStateMachine.Player);
            _ui.MainMenu.Show();
            _playerStateMachine.SetNonControlledState();
            _playerStateMachine.Player.MoneyWidget.Disable();

            var taskList = GetTaskList();
            //_playerStateMachine.Player.SetTaskList(taskList);
            //_ui.PlayMenu.TasksListWidget.Initialize(_playerStateMachine.Player.TaskList);
            //_ui.PlayMenu.TaskProgressWidget.Initialize(_playerStateMachine.Player.TaskList);
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
            // Если концепция снова изменится и нужно будет включить деньги, то раскоментить.
            //_playerStateMachine.Player.MoneyWidget.Enable();
        }

        private TaskList GetTaskList()
        {
            var taskLists = Resources.LoadAll<TaskList>(TaskListsPath);

            if (taskLists.Length == 0)
                throw new ArgumentOutOfRangeException(
                    $"Task Lists not created by path Assets/Resources/{TaskListsPath}");

            var index = SceneManager.GetActiveScene().buildIndex - 1;
            index = Mathf.Clamp(index, 0, taskLists.Length - 1);

            return taskLists[index];
        }
    }
}