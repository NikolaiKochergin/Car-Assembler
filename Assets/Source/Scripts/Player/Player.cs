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

        public Conveyor Conveyor => _conveyor;
        public TaskList TaskList { get; private set; }

        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public TakingDetailTimer TakingDetailTimer => _takingDetailTimer;

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

        public void SetCar(Car car)
        {
            Destroy(_currentCar.gameObject);
            var spawnedCar = Instantiate(car, transform.position, Quaternion.identity, transform);
            
            _currentCar = spawnedCar;
        }

        public void SetTaskList(TaskList taskList)
        {
            TaskList = taskList;
            taskList.UpdateTasksList(_currentCar.Slots);
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