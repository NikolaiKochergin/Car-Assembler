using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class TaskChecker : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _finishers;

        private List<IFinisher> Finishers;

        private void Start()
        {
            Finishers = new List<IFinisher>();
            
            foreach (var finisher in _finishers)
            {
                Finishers.Add((IFinisher)finisher);
            }
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
                //Debug.Log("Finishers[0]");
                return Finishers[1];
            }
            else
            {
               // Debug.Log("Finishers[1]");
                return Finishers[0];
            }

            //return Finishers[0];
        }
    }
}