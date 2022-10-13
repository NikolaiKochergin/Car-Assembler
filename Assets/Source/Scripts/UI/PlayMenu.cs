using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIMainTaskWidget _uiMainTasksListWidget;
        [SerializeField] private UICustomerCloud _uiCustomerCloud;
        [SerializeField] private UITaskProgressWidget _uiTaskProgressWidget;

        public UIMainTaskWidget MainTaskWidget => _uiMainTasksListWidget;
        public UICustomerCloud CustomerCloud => _uiCustomerCloud;
        public UITaskProgressWidget TaskProgressWidget => _uiTaskProgressWidget;
    }
}