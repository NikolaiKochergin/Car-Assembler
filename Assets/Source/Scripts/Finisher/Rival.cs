using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class Rival : MonoBehaviour
    {
        [SerializeField] private SplineFollower _splineFollower;

        private float _defaultSpeed;

        private void Awake()
        {
            _defaultSpeed = _splineFollower.followSpeed;
        }

        public void StartMove()
        {
            _splineFollower.follow = true;
        }

        public void StopMove()
        {
            _splineFollower.follow = false;
        }

        public void SetSpeedMultiplier(float value)
        {
            _splineFollower.followSpeed = _defaultSpeed * value;
        }
    }
}