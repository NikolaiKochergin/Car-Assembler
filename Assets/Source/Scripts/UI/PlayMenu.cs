using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIProgressWidget _uiProgressWidget;
        [SerializeField] private UITasksListWidget _uiTasksListWidget;
        [SerializeField] private UITaskProgressWidget _uiTaskProgressWidget;

        public UIProgressWidget ProgressWidget => _uiProgressWidget;
        public UITasksListWidget TasksListWidget => _uiTasksListWidget;
        public UITaskProgressWidget TaskProgressWidget => _uiTaskProgressWidget;
    }
}