using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    [CreateAssetMenu(menuName = "LevelSetup/NewLevelSetup", fileName = "_LevelSetup")]
    public class LevelSetup : ScriptableObject
    {
        [SerializeField] private Car _car;
        [SerializeField] private List<Task> _tasks;

        public Car Car => _car;
        public IReadOnlyList<Task> Tasks => _tasks;
    }
}
