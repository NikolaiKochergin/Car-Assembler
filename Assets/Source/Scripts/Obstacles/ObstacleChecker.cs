using UnityEngine;

namespace CarAssembler
{
    public abstract class ObstacleChecker : MonoBehaviour
    {
        protected bool _isOpen = false;

        public bool IsOpen => _isOpen;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
                StartOpening();
        }

        protected abstract void StartOpening();
    }
}