using UnityEngine;

namespace CarAssembler
{
    public class MainCameraAnimator : MonoBehaviour
    {
        private const string MoveToPlayStateAnimation = nameof(MoveToPlayStateAnimation);
        
        [SerializeField] private Animator _animator;

        public void ShowMoveToPlayStateAnimation()
        {
            _animator.Play(MoveToPlayStateAnimation);
        }
    }
}