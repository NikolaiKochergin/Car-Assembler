using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIProgressWidget _uiProgressWidget;
        [SerializeField] private UITasksListWidget _uiTasksListWidget;

        public UIProgressWidget ProgressWidget => _uiProgressWidget;
        public UITasksListWidget TasksListWidget => _uiTasksListWidget;
    }
}