using UnityEngine;

namespace CarAssembler
{
    public class LowrideRaceRivalAnimator : MonoBehaviour
    {
        private const string Idle = nameof(Idle);
        private const string Lowride = nameof(Lowride);
        private const string LowrideValue = nameof(LowrideValue);
        
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            Disable();
        }

        public void ShowIdle()
        {
            _animator.SetTrigger(Idle);
        }

        public void ShowLowride()
        {
            _animator.SetTrigger(Lowride);
        }
        
        public void BlendLowride(float value)
        {
            _animator.SetFloat(LowrideValue, value);
        }

        public void Enable()
        {
            _animator.enabled = true;
        }

        public void Disable()
        {
            _animator.enabled = false;
        }
    }
}
