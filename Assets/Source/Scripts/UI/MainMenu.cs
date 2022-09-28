using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class MainMenu : MenuBase
    {
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;
    }
}