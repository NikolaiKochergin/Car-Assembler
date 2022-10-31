using UnityEngine;

namespace CarAssembler
{
    public class MainCameraAnimator : MonoBehaviour
    {
        private const string MoveToPlayStateAnimation = nameof(MoveToPlayStateAnimation);
        private const string CameraRide = nameof(CameraRide);
        private const string CameraMoveToEndLevelPositionAnimation = nameof(CameraMoveToEndLevelPositionAnimation);
        
        [SerializeField] private Animator _animator;

        public void ShowMoveToPlayStateAnimation()
        {
            _animator.Play(MoveToPlayStateAnimation);
        }
        
        public void ShowMoveToFinishStateAnimation()
        {
            _animator.Play(CameraRide);
        }

        public void ShowEndLevelAnimation()
        {
            _animator.enabled = true;
            _animator.Play(CameraMoveToEndLevelPositionAnimation);
        }

        public void Disable()
        {
            _animator.enabled = false;
        }
    }
}