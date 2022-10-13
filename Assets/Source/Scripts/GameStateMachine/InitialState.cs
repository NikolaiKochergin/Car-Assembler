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
            _ui.MainMenu.Show();
            _playerStateMachine.SetNonControlledState();

            var taskList = GetTaskList();
            _ui.PlayMenu.MainTaskWidget.Initialize(taskList.Tasks[0].TaskIcon);
            _ui.PlayMenu.TaskProgressWidget.Initialize(_playerStateMachine.Player);
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
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