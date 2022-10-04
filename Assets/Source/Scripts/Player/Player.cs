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
        public Conveyor Conveyor => _conveyor;
        public UIMoneyWidget MoneyWidget => _uiMoneyWidget;

        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public TakingDetailTimer TakingDetailTimer => _takingDetailTimer;

        public Car Car => _currentCar;
        public Stand Stand { get; private set; }

        private void OnEnable()
        {
            CollisionHandler.FactoryMachineTaken += OnFactoryMachineTaken;
            CollisionHandler.FactoryMachineLost += OnFactoryMachineLost;
            _currentCar.PriceChanged += OnPriceChanged;
        }

        private void OnDisable()
        {
            CollisionHandler.FactoryMachineTaken -= OnFactoryMachineTaken;
            CollisionHandler.FactoryMachineLost -= OnFactoryMachineLost;
            _currentCar.PriceChanged -= OnPriceChanged;
        }

        private void OnFactoryMachineTaken(Stand _stand)
        {
            if (Stand != null)
                Stand.OffHighlight();

            Stand = _stand;
            Stand.OnHighlight();
        }

        private void OnFactoryMachineLost(Stand _stand)
        {
            if (_stand == Stand)
            {
                Stand.OffHighlight();
                Stand = null;
            }
        }

        private void OnPriceChanged(int value)
        {
            _uiMoneyWidget.ShowMoney(_currentCar.Price);
        }
    }
}