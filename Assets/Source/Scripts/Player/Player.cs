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
        [SerializeField] private AnimatorContainer _animator;
        [SerializeField] private ParticleContainer _particleContainer;

        public ConveyorAnimator ConveyorAnimator => _conveyorAnimator;
        public AnimatorContainer animatorContainer => _animator;
        public PlayInput PlayInput => _playInput;
        public PlayerMover PlayerMover => _playerMover;
        public UITaskListWidget TaskListWidget => _taskListWidget;
        public Car Car { get; private set; }
        public Stand Stand { get; private set; }
        public IReadOnlyList<Task> Tasks { get; private set; }
        public ParticleContainer ParticleContainer => _particleContainer;

        public event Action NonControlledStateBegining;
        public event Action NonControlledStateEnding;
        public event Action<QuickTimeEvent> QuickTimeEventTaken;
        public event Action QuickTimeEventEnded;

        private void OnEnable()
        {
            _collisionHandler.StandTaken += OnStandTaken;
            _collisionHandler.StandLost += OnStandLost;
            _collisionHandler.ObstacleTaken += OnObstacleTaken;
            _collisionHandler.BarrierTaken += OnBarrierTaken;
            _collisionHandler.QuickTimeEventTaken += OnQuickTimeEventTaken;
            _collisionHandler.QuickTimeEventEnded += OnQuickTimeEventEnded;
        }

        private void OnDisable()
        {
            _collisionHandler.StandTaken -= OnStandTaken;
            _collisionHandler.StandLost -= OnStandLost;
            _collisionHandler.ObstacleTaken -= OnObstacleTaken;
            _collisionHandler.BarrierTaken -= OnBarrierTaken;
            _collisionHandler.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _collisionHandler.QuickTimeEventEnded -= OnQuickTimeEventEnded;
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
            StartCoroutine(ObstacleTakeShowing(obstacle));
            obstacle.Disable();
        }

        private void OnBarrierTaken(Barrier barrier)
        {
            StartCoroutine(BarrierTakeShowing(barrier));
        }

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            QuickTimeEventTaken?.Invoke(quickTimeEvent);
        }

        private void OnQuickTimeEventEnded()
        {
            QuickTimeEventEnded?.Invoke();
        }

        private IEnumerator ObstacleTakeShowing(Obstacle obstacle)
        {
            if(obstacle.PenaltyDetail)
                Car.TakeDetail(obstacle.PenaltyDetail);
            
            var defaultSpeed = _playerMover.MoveSpeed;
            
            _collider.enabled = false;
            NonControlledStateBegining?.Invoke();
            _playerMover.StartMove();
            _playerMover.SetFollowSpeed(obstacle.MoveSpeed);

            yield return new WaitForSeconds(obstacle.MoveDuration);
            
            _playerMover.SetFollowSpeed(defaultSpeed);
            _playerMover.StopMove();
            NonControlledStateEnding?.Invoke();
            _collider.enabled = true;
        }

        private IEnumerator BarrierTakeShowing(Barrier barrier)
        {
            if(barrier.PenaltyDetail)
                Car.TakeDetail(barrier.PenaltyDetail);

            var defaultSpeed = _playerMover.MoveSpeed;
            
            _collider.enabled = false;
            NonControlledStateBegining?.Invoke();
            _playerMover.SetBackwardMove();
            _playerMover.SetFollowSpeed(barrier.MoveSpeed);
            _playerMover.StartMove();

            yield return new WaitForSeconds(barrier.MoveDuration);
            
            _playerMover.SetForwardMove();
            _playerMover.SetFollowSpeed(defaultSpeed);
            _playerMover.StopMove();
            NonControlledStateEnding?.Invoke();
            _collider.enabled = true;
        }

        public void ChangeRotationWheels(float multiplierSpeed)
        {
            for (int i = 0; i < Car.CurrentWheels.Count; i++)
            {
                Car.CurrentWheels[i].ChangeSpeedRotation(multiplierSpeed);
            }
        }
        
        public void StopRotationWheels()
        {
            for (int i = 0; i < Car.CurrentWheels.Count; i++)
            {
                Car.CurrentWheels[i].Disable();
            }
        }

        public void StartRotationWheels()
        {
            for (int i = 0; i < Car.CurrentWheels.Count; i++)
            {
                Car.CurrentWheels[i].Enable();
            }
        }
    }
}