using UnityEngine;

namespace CarAssembler
{
    public class ConveyorAnimator : MonoBehaviour
    {
        [SerializeField] private Animator[] _animators;

        private void Start()
        {
            Disable();
        }

        public void Enable()
        {
            foreach (var animator in _animators) animator.enabled = true;
        }

        public void Disable()
        {
            foreach (var animator in _animators) animator.enabled = false;
        }
    }
}