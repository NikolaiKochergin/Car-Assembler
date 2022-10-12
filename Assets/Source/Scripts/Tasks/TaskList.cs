using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    [CreateAssetMenu(menuName = "TaskList/NewLevelTaskList", fileName = "_LevelTaskList")]
    public class TaskList : ScriptableObject
    {
        [SerializeField] private List<Task> _tasks;

        public List<Task> Tasks => _tasks;

        public event Action<IReadOnlyList<Task>> TaskListUpdated;

        public void UpdateTasksList(Car car)
        {
            foreach (var task in _tasks)
            {
                task.CheckTask(car);
            }
            TaskListUpdated?.Invoke(Tasks);
        }
    }
}
