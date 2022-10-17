using UnityEngine;

namespace CarAssembler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CollisionHandler CollisionHandler;
        [SerializeField] private PlayInput _playInput;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private Conveyor _conveyor;
        
        private Car _currentCar;

        public Conveyor Conveyor => _conveyor;
        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public Car Car => _currentCar;
        public Stand Stand { get; private set; }

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

        public void Initialize(Car car)
        {
            SetCar(car);
        }

        private void SetCar(Car car)
        {
            var spawnedCar = Instantiate(car, transform);
            _currentCar = spawnedCar;
            _currentCar.Show();
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
            if (Equals(_stand, Stand))
            {
                Stand.OffHighlight();
                Stand = null;
            }
        }
    }
}