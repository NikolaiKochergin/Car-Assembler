using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIProgressWidget _uiProgressWidget;
        [SerializeField] private UITaskWidget _uiTaskWidget;

        public UIProgressWidget ProgressWidget => _uiProgressWidget;
        public UITaskWidget TaskWidget => _uiTaskWidget;
    }
}