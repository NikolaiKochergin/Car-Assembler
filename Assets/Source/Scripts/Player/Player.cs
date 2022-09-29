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

        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public TakingDetailTimer TakingDetailTimer => _takingDetailTimer;

        public Car Car => _currentCar;
        public FactoryMachine FactoryMachine { get; private set; }

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

        private void OnFactoryMachineTaken(FactoryMachine factoryMachine)
        {
            if (FactoryMachine != null)
                FactoryMachine.OffHighlight();

            FactoryMachine = factoryMachine;
            FactoryMachine.OnHighlight();
        }

        private void OnFactoryMachineLost(FactoryMachine factoryMachine)
        {
            if (factoryMachine == FactoryMachine)
                FactoryMachine = null;
        }

        private void OnPriceChanged(int value)
        {
            _uiMoneyWidget.ShowMoney(_currentCar.Price);
        }
    }
}