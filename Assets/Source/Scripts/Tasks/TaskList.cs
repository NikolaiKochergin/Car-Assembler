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

        public void UpdateTasksList(IReadOnlyList<Slot> slots)
        {
            foreach (var task in _tasks)
            {
                task.CheckTask(slots);
            }
            TaskListUpdated?.Invoke(Tasks);
        }
    }
}
