using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class TaskChecker : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _finishers;

        private readonly List<IFinisher> Finishers = new();

        private void OnValidate()
        {
            Finishers.Clear();
            foreach (var finisher in _finishers)
                if (finisher && !(finisher is IFinisher))
                {
                    Debug.LogError(nameof(finisher) + " needs to implement " + nameof(IFinisher));
                    _finishers.Remove(finisher);
                }
                else
                {
                    Finishers.Add((IFinisher) finisher);
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