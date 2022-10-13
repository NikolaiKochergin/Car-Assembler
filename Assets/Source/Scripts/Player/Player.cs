using System;
using UnityEngine;

namespace CarAssembler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Car _currentCar;
        [SerializeField] private CollisionHandler CollisionHandler;
        [SerializeField] private PlayInput _playInput;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private TakingDetailTimer _takingDetailTimer;
        [SerializeField] private Conveyor _conveyor;
        [SerializeField] [Min(0)] private int _defaultCarPrice = 50;

        private int _carPrice;

        public Conveyor Conveyor => _conveyor;
        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public TakingDetailTimer TakingDetailTimer => _takingDetailTimer;
        public Car Car => _currentCar;
        public Stand Stand { get; private set; }

        public int CarPrice
        {
            get => _carPrice;
            private set
            {
                _carPrice = value;
                CarPriceChanged?.Invoke(value);
            }
        }

        private void Awake()
        {
            CarPrice = _defaultCarPrice;
        }

        private void OnEnable()
        {
            CollisionHandler.StandTaken += OnStandTaken;
            CollisionHandler.StandLost += OnStandLost;
        }

        private void OnDisable()
        {
            CollisionHandler.StandTaken -= OnStandTaken;
            CollisionHandler.StandLost -= OnStandLost;
        }

        public event Action<int> CarPriceChanged;

        public void SetCar(Car car)
        {
            Destroy(_currentCar.gameObject);
            var spawnedCar = Instantiate(car, transform.position, Quaternion.identity, transform);
            _currentCar = spawnedCar;
            _currentCar.Show();
            CarPrice += car.Price;
        }

        public void AddDetailPrice(int value)
        {
            CarPrice += value;
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
    }
}