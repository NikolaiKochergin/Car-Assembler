using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UICustomerCloud _uiCustomerCloud;
        [SerializeField] private Button _takeDetailButton;
        [SerializeField] private UITaskListWidget _taskListWidget;

        public UICustomerCloud CustomerCloud => _uiCustomerCloud;
        public Button TakeDetailButton => _takeDetailButton;
        public UITaskListWidget TaskListWidget => _taskListWidget;
    }
}