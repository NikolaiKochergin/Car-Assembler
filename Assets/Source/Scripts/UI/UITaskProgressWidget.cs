using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskProgressWidget : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private ParticleSystem _engryParticleSystem;
        [SerializeField] private ParticleSystem _goodParticleSystem;

        private TaskList _taskList;

        private void OnDestroy()
        {
            if (_taskList != null)
                _taskList.TaskListUpdated -= OnTaskListUpdated;
        }

        public void Initialize(TaskList taskList)
        {
            SetValue(0);
            _taskList = taskList;
            _taskList.TaskListUpdated += OnTaskListUpdated;
        }

        private void OnTaskListUpdated(IReadOnlyList<Task> taskList)
        {
            var doneTaskCount = 0;

            foreach (var task in taskList)
                if (task.IsDone)
                    doneTaskCount += 1;

            var doneTaskPercent = (float) doneTaskCount / taskList.Count;

            SetValue(doneTaskPercent);
        }

        private void SetValue(float value)
        {
            if(_filler.fillAmount > value && _engryParticleSystem != null)
                _engryParticleSystem.Play();
            if (_filler.fillAmount < value && _goodParticleSystem != null)
                _goodParticleSystem.Play();

            _filler.fillAmount = value;
        }
    }
}