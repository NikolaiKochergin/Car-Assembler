using UnityEngine;

namespace CarAssembler
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private PlayMenu _playMenu;
        [SerializeField] private FinisherMenu _finisherMenu;
        [SerializeField] private EndLevelMenu _endLevelMenu;

        public MainMenu MainMenu => _mainMenu;
        public PlayMenu PlayMenu => _playMenu;
        public FinisherMenu FinisherMenu => _finisherMenu;
        public EndLevelMenu EndLevelMenu => _endLevelMenu;
    }
}
