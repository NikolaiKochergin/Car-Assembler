using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CollisionHandler CollisionHandler;
        [SerializeField] private PlayInput _playInput;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private ConveyorAnimator _conveyorAnimator;
        [SerializeField] private UITaskListWidget _taskListWidget;

        public ConveyorAnimator ConveyorAnimator => _conveyorAnimator;
        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public UITaskListWidget TaskListWidget => _taskListWidget;
        public Car Car { get; private set; }
        public Stand Stand { get; private set; }
        public IReadOnlyList<Task> Tasks { get; private set; }

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

        public void Initialize(Car car, IReadOnlyList<Task> tasks)
        {
            SetCar(car);
            Tasks = tasks;
        }

        private void SetCar(Car car)
        {
            var spawnedCar = Instantiate(car, transform);
            Car = spawnedCar;
            Car.Show();
        }

        public void ExplodeCar()
        {
            for (int i = 0; i < Car.RigidbodiesDetails.Count; i++)
            {
                Debug.Log(Car.RigidbodiesDetails[i]);
                
            }
            Car.CarExplosion.Explode(Car.RigidbodiesDetails);
        }

        public void SlipCar()
        {
            Car.CarExplosion.Slip();
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