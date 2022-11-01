using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class RaceMenu : MenuBase
    {
        [SerializeField] private UIYoke _uiYoke;
        [SerializeField] private Button _yokeButton;
        [SerializeField] private CountDownView _countDownView;
        [SerializeField] private UITapMessage _uiTapMessage;

        public UIYoke Yoke => _uiYoke;
        public Button YokeButton => _yokeButton;
        public CountDownView CountDownView => _countDownView;
        public UITapMessage TapMessage => _uiTapMessage;
    }
}