using UnityEngine;

namespace CarAssembler
{
    public class MainCameraContainer : MonoBehaviour
    {
        [SerializeField] private MainCameraAnimator _mainCameraAnimator;
        [SerializeField] private Follower _follower;
        [SerializeField] private Transform _racePoint;

        public MainCameraAnimator CameraAnimator => _mainCameraAnimator;
        public Follower Follower => _follower;

        [ContextMenu("SetRacePosition")]
        public void SetRacePosition()
        {
            _mainCameraAnimator.Disable();
            
            Camera.main.transform.localPosition = _racePoint.localPosition;
            Camera.main.transform.localRotation = _racePoint.localRotation;
        }
    }
}