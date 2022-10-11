using UnityEngine;

namespace CarAssembler
{
    public class MainCameraContainer : MonoBehaviour
    {
        [SerializeField] private MainCameraAnimator _mainCameraAnimator;
        [SerializeField] private Follower _follower;

        public MainCameraAnimator CameraAnimator => _mainCameraAnimator;
        public Follower Follower => _follower;
    }
}