using UnityEngine;

namespace CarAssembler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Car _currentCar;
        [SerializeField] private CollisionHandler CollisionHandler;
        [SerializeField] private UIMoneyWidget _uiMoneyWidget;

        [SerializeField] private PlayInput _playInput;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private TakingDetailTimer _takingDetailTimer;

        [SerializeField] private Conveyor _conveyor;

        [SerializeField] private TaskList _taskList;
        
        public Conveyor Conveyor => _conveyor;
        public TaskList TaskList => _taskList;
        public UIMoneyWidget MoneyWidget => _uiMoneyWidget;

        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public TakingDetailTimer TakingDetailTimer => _takingDetailTimer;

        public Car Car => _currentCar;
        public Stand Stand { get; private set; }


        public void SetTaskList(TaskList taskList)
        {
            _taskList = taskList;
            taskList.UpdateTasksList(_currentCar.Slots);
        }

        private void OnEnable()
        {
            CollisionHandler.StandTaken += OnStandTaken;
            CollisionHandler.StandLost += OnStandLost;
            _currentCar.PriceChanged += OnPriceChanged;
        }

        private void OnDisable()
        {
            CollisionHandler.StandTaken -= OnStandTaken;
            CollisionHandler.StandLost -= OnStandLost;
            _currentCar.PriceChanged -= OnPriceChanged;
        }

        private void OnStandTaken(Stand _stand)
        {
            if (Stand != null)
                Stand.OffHighlight();

            Stand = _stand;
            Stand.OnHighlight();
        }

        private void OnStandLost(Stand _stand)
        {
            if (_stand == Stand)
            {
                Stand.OffHighlight();
                Stand = null;
            }
        }

        private void OnPriceChanged(int value)
        {
            _uiMoneyWidget.SetMoneyText(_currentCar.Price);
        }
    }
}