using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class TaskChecker : MonoBehaviour, ITaskChecker
    {
        [SerializeField] private MonoBehaviour _finisher;
        private IFinisher Finisher => (IFinisher) _finisher;

        private void OnValidate()
        {
            if (_finisher && !(_finisher is IFinisher))
            {
                Debug.LogError(nameof(_finisher) + " needs to implement " + nameof(IFinisher));
                _finisher = null;
            }
        }

        public IFinisher GetFinisherBy(IReadOnlyList<Task> tasks, Car car)
        {
            return Finisher;
        }
    }
}