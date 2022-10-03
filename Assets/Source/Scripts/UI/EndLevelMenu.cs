using UnityEngine;

namespace CarAssembler
{
    public class EndLevelMenu : MenuBase
    {
        [SerializeField] private UIMoneyWidget _uiMoneyWidget;

        public UIMoneyWidget MoneyWidget => _uiMoneyWidget;
    }
}