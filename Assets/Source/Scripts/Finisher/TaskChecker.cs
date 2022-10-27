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
            if (car.Features.Speed >= tasks[0].TargetValue)
            {
                CurrentFinisher = _finisherInterfaces[1];
                return _finisherInterfaces[1];
            }
            
            return _finisherInterfaces[0];
        }
    }
}