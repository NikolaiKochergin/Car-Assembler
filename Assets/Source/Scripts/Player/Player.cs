using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private CollisionHandler _collisionHandler;
        [SerializeField] private PlayInput _playInput;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private ConveyorAnimator _conveyorAnimator;
        [SerializeField] private UITaskListWidget _taskListWidget;
        [SerializeField] private ContainerAnimator _animator;

        public ConveyorAnimator ConveyorAnimator => _conveyorAnimator;
        public ContainerAnimator containerAnimator => _animator;
        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public UITaskListWidget TaskListWidget => _taskListWidget;
        public Car Car { get; private set; }
        public Stand Stand { get; private set; }
        public IReadOnlyList<Task> Tasks { get; private set; }

        public event Action NonControlledStateBegining;
        public event Action NonControlledStateEnding;

        private void OnEnable()
        {
            _collisionHandler.StandTaken += OnStandTaken;
            _collisionHandler.StandLost += OnStandLost;
            _collisionHandler.ObstacleTaken += OnObstacleTaken;
            _collisionHandler.BarrierTaken += OnBarrierTaken;
        }

        private void OnDisable()
        {
            _collisionHandler.StandTaken -= OnStandTaken;
            _collisionHandler.StandLost -= OnStandLost;
            _collisionHandler.ObstacleTaken -= OnObstacleTaken;
            _collisionHandler.BarrierTaken -= OnBarrierTaken;
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
        
        private void OnObstacleTaken(Obstacle obstacle)
        {
            StartCoroutine(ObstacleTakeShowing());
            obstacle.Disable();
        }

        private void OnBarrierTaken(Barrier barrier)
        {
            StartCoroutine(BarrierTakeShowing());
        }

        private IEnumerator ObstacleTakeShowing()
        {
            _collider.enabled = false;
            NonControlledStateBegining?.Invoke();
            _playerMover.StartMove();
            _playerMover.SetFollowSpeed(20f);

            yield return new WaitForSeconds(0.2f);
            
            _playerMover.SetFollowSpeed(5f);
            _playerMover.StopMove();
            NonControlledStateEnding?.Invoke();
            _collider.enabled = true;
        }

        private IEnumerator BarrierTakeShowing()
        {
            _collider.enabled = false;
            NonControlledStateBegining?.Invoke();
            _playerMover.StartMove();
            _playerMover.SetBackwardMove();
            _playerMover.SetFollowSpeed(10f);

            yield return new WaitForSeconds(2f);
            
            _playerMover.SetForwardMove();
            _playerMover.SetFollowSpeed(5f);
            _playerMover.StopMove();
            NonControlledStateEnding?.Invoke();
            _collider.enabled = true;
        }
    }
}