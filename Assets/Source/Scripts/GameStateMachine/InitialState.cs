using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private readonly Data _data;

        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly string TaskListsPath = "LevelTaskLists/";

        public InitialState(PlayerStateMachine playerStateMachine, UI ui, Data data)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
            _data = data;
        }

        public void Enter()
        {
            _ui.PlayMenu.ProgressWidget.Initialize(_data.GetDisplayedLevelNumber(), _playerStateMachine.Player);
            _ui.MainMenu.Show();
            _playerStateMachine.SetNonControlledState();
            _playerStateMachine.Player.MoneyWidget.Disable();

            var taskList = GetTaskList();
            _playerStateMachine.Player.SetTaskList(taskList);
            _ui.PlayMenu.TaskWidget.Initialize(_playerStateMachine.Player.TaskList);
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
            _playerStateMachine.Player.MoneyWidget.Enable();
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