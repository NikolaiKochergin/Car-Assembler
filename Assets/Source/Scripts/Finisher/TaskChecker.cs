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
            foreach (var task in tasks)
            {
                var feature = GetValueBy(task.FeatureType, car);

                if (feature < task.TargetValue)
                {
                    CurrentFinisher = _finisherInterfaces[0];
                    return _finisherInterfaces[0];
                }
            }
            
            return _finisherInterfaces[1];
        }

        private int GetValueBy(FeatureType type, Car car)
        {
            switch (type)
            {
                case FeatureType.Speed:
                    return car.Features.Speed;
                case FeatureType.FuelEconomy:
                    return car.Features.FuelEconomy;
                case FeatureType.Coolness:
                    return car.Features.Coolness;
                case FeatureType.Comfort:
                    return car.Features.Comfort;
                case FeatureType.Airplane:
                    return car.Features.Airplane;
                case FeatureType.Kindness:
                    return car.Features.Kindness;
                case FeatureType.Boat:
                    return car.Features.Boat;
                case FeatureType.Angry:
                    return car.Features.Angry;
                case FeatureType.Elephant:
                    return car.Features.Elephant;
                case FeatureType.FireTrack:
                    return car.Features.FireTrack;
                case FeatureType.Fish:
                    return car.Features.Fish;
                case FeatureType.Offroad:
                    return car.Features.Offroad;
                case FeatureType.Spring:
                    return car.Features.Spring;
                case FeatureType.Power:
                    return car.Features.Power;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}