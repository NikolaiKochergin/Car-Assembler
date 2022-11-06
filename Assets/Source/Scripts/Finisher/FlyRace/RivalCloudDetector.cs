using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class RivalCloudDetector : MonoBehaviour
    {
        [SerializeField] private SplineFollower _rivalFollower;
        [SerializeField] [Min(0)] private float _speedReductionMultiplier = 0.5f;

        private float _defaultSpeed;

        private void Start()
        {
            _defaultSpeed = _rivalFollower.followSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            var cloud = other.GetComponent<QuickTimeEvent>();

            if (cloud)
                _rivalFollower.followSpeed = _defaultSpeed * _speedReductionMultiplier;
        }

        private void OnTriggerExit(Collider other)
        {
            var cloud = other.GetComponent<QuickTimeEvent>();

            if (cloud)
                _rivalFollower.followSpeed = _defaultSpeed;
        }
    }
}
