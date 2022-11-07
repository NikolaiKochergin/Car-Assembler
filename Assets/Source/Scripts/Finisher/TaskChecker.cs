using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class TaskChecker : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _finishers;

        private List<IFinisher> _finisherInterfaces;
        
        public IFinisher CurrentFinisher { get; private set; }

        private void Start()
        {
            _finisherInterfaces = new List<IFinisher>();
            foreach (var finisher in _finishers) _finisherInterfaces.Add((IFinisher) finisher);
            
            CurrentFinisher = _finisherInterfaces[0];
        }

        private void OnValidate()
        {
            foreach (var finisher in _finishers.Where(finisher => finisher && finisher is not IFinisher))
            {
                Debug.LogError(nameof(finisher) + " needs to implement " + nameof(IFinisher));
                _finishers.Remove(finisher);
            }
        }

        public IFinisher GetFinisherBy(IReadOnlyList<Task> tasks, Car car)
        {
            int feature = 0;
            
            // if (car.Features.Speed >= tasks[0].TargetValue)
            // {
            //     CurrentFinisher = _finisherInterfaces[1];
            //     return _finisherInterfaces[1];
            // }

            switch (tasks[0].FeatureType)
            {
                case FeatureType.Speed:
                    feature = car.Features.Speed;
                    break;
                case FeatureType.FuelEconomy:
                    feature = car.Features.FuelEconomy;
                    break;
                case FeatureType.Coolness:
                    feature = car.Features.Coolness;
                    break;
                case FeatureType.Comfort:
                    feature = car.Features.Comfort;
                    break;
                case FeatureType.Airplane:
                    feature = car.Features.Airplane;
                    break;
                case FeatureType.Kindness:
                    feature = car.Features.Kindness;
                    break;
                case FeatureType.Boat:
                    feature = car.Features.Boat;
                    break;
                case FeatureType.Angry:
                    feature = car.Features.Angry;
                    break;
                case FeatureType.Elephant:
                    feature = car.Features.Elephant;
                    break;
                case FeatureType.FireTrack:
                    feature = car.Features.FireTrack;
                    break;
                case FeatureType.Fish:
                    feature = car.Features.Fish;
                    break;
                case FeatureType.Offroad:
                    feature = car.Features.Offroad;
                    break;
                case FeatureType.Spring:
                    feature = car.Features.Spring;
                    break;
                case FeatureType.Power:
                    feature = car.Features.Power;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            if (feature >= tasks[0].TargetValue)
            {
                CurrentFinisher = _finisherInterfaces[1];
                return _finisherInterfaces[1];
            }
            
            return _finisherInterfaces[0];
        }
    }
}