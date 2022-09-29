using UnityEngine;

namespace CarAssembler
{
    public class MainMenu : MenuBase
    {
        [SerializeField] private StartButton _startButton;

        public StartButton StartButton => _startButton;
    }
}