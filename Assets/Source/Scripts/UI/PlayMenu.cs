using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIMainTaskWidget _uiMainTasksListWidget;
        [SerializeField] private UICustomerCloud _uiCustomerCloud;

        public UIMainTaskWidget MainTaskWidget => _uiMainTasksListWidget;
        public UICustomerCloud CustomerCloud => _uiCustomerCloud;
    }
}