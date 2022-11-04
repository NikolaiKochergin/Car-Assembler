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
            Debug.Log("Включи камеру");
            //Camera.main.transform.SetLocalPositionAndRotation(_racePoint.localPosition, _racePoint.localRotation);
        }
    }
}