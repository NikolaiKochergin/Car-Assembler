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