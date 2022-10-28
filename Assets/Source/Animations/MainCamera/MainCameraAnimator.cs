using UnityEngine;

namespace CarAssembler
{
    public class MainCameraAnimator : MonoBehaviour
    {
        private const string MoveToPlayStateAnimation = nameof(MoveToPlayStateAnimation);
        private const string CameraRide = nameof(CameraRide);
        
        [SerializeField] private Animator _animator;

        public void ShowMoveToPlayStateAnimation()
        {
            _animator.Play(MoveToPlayStateAnimation);
        }
        
        public void ShowMoveToFinishStateAnimation()
        {
            _animator.Play(CameraRide);
        }

        public void Disable()
        {
            _animator.enabled = false;
        }
    }
}