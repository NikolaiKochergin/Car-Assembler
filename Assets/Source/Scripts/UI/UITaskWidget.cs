using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        private TaskList _taskList;

        private void OnDestroy()
        {
            if (_taskList != null)
                _taskList.TaskListUpdated -= OnTaskListUpdated;
        }

        public void Initialize(TaskList taskList)
        {
            _taskList = taskList;
            _taskList.TaskListUpdated += OnTaskListUpdated;
        }

        private void OnTaskListUpdated(IReadOnlyList<Task> tasks)
        {
            foreach (var task in _taskList.Tasks) Debug.Log(task.IsDone);
        }
    }
}