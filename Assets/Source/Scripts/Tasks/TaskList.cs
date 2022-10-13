using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    [CreateAssetMenu(menuName = "TaskList/NewLevelTaskList", fileName = "_LevelTaskList")]
    public class TaskList : ScriptableObject
    {
        [SerializeField] private List<Task> _tasks;

        public List<Task> Tasks => _tasks;
    }
}
