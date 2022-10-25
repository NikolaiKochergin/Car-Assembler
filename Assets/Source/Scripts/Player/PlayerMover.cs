using System;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private SplineFollower _splineFollower;

        private void Start()
        {
            _splineFollower.follow = false;
        }

        private void OnEnable()
        {
            _splineFollower.onEndReached += OnEndLevelReached;
        }

        private void OnDisable()
        {
            _splineFollower.onEndReached -= OnEndLevelReached;
        }

        public event Action EndLevelReached;

        public void StartMove()
        {
            _splineFollower.follow = true;
        }

        public void StopMove()
        {
            _splineFollower.follow = false;
        }

        [ContextMenu("SetBackwardMove")]
        public void SetBackwardMove()
        {
            _splineFollower.motion.applyRotationY = false;
            _splineFollower.direction = Spline.Direction.Backward;
        }

        [ContextMenu("SetForwardMove")]
        public void SetForwardMove()
        {
            _splineFollower.direction = Spline.Direction.Forward;
            _splineFollower.motion.applyRotationY = true;
        }

        public void SetFollowSpeed(float value)
        {
            _splineFollower.followSpeed = value;
        }

        public float GetLevelProgress()
        {
            return (float) _splineFollower.GetPercent();
        }

        private void OnEndLevelReached(double _)
        {
            EndLevelReached?.Invoke();
        }
    }
}