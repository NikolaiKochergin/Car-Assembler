using UnityEngine;

namespace CarAssembler
{
    public class PlayMenu : MenuBase
    {
        [SerializeField] private UIProgressWidget _uiProgressWidget;

        public UIProgressWidget ProgressWidget => _uiProgressWidget;
    }
}