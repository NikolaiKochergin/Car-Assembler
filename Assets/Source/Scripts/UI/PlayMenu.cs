using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UICustomerCloud _uiCustomerCloud;
        [SerializeField] private Button _takeDetailButton;

        public UICustomerCloud CustomerCloud => _uiCustomerCloud;
        public Button TakeDetailButton => _takeDetailButton;
    }
}