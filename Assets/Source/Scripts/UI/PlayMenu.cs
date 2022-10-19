using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UICustomerCloud _uiCustomerCloud;

        public UICustomerCloud CustomerCloud => _uiCustomerCloud;
    }
}