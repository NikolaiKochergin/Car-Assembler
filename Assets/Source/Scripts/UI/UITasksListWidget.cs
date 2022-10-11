using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITasksListWidget : MonoBehaviour
    {
        [SerializeField] private UITaskWidget _uiTaskWidgetPrefab;
        [SerializeField] private Transform _content;
        [SerializeField] private IconsMap _iconsMap;
        [SerializeField] [Min(0)] private float _appearDuration = 0.1f;

        private TaskList _taskList;
        private List<UITaskWidget> _taskViews;

        private void OnEnable()
        {
            StartCoroutine(ShowAppear());
        }

        private void OnDestroy()
        {
            if (_taskList != null)
                _taskList.TaskListUpdated -= OnTaskListUpdated;
        }

        public void Initialize(TaskList taskList)
        {
            _taskList = taskList;
            _taskList.TaskListUpdated += OnTaskListUpdated;
            _taskViews = new List<UITaskWidget>();

            foreach (var task in _taskList.Tasks)
            {
                var taskView = Instantiate(_uiTaskWidgetPrefab, _content);
                var icon = _iconsMap.GetIconBy(task.SlotType, task.Feature);
                taskView.Initialize(icon);
                taskView.Hide();
                _taskViews.Add(taskView);
            }

            OnTaskListUpdated(taskList.Tasks);
        }

        private void OnTaskListUpdated(IReadOnlyList<Task> tasks)
        {
            for (var i = 0; i < _taskList.Tasks.Count; i++)
            {
                _taskViews[i].MarkCompleted(_taskList.Tasks[i].IsDone);
                // if(!_taskList.Tasks[i].IsDone)
                //     _taskViews[i].ShowFalse();
            }
        }

        private IEnumerator ShowAppear()
        {
            yield return new WaitForSeconds(_appearDuration);

            for (var i = _taskViews.Count - 1; i >= 0; i--)
            {
                _taskViews[i].Show();
                yield return new WaitForSeconds(_appearDuration);
            }
        }
    }
}