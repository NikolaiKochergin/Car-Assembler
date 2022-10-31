using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class Rival : MonoBehaviour
    {
        [SerializeField] private SplineFollower _splineFollower;
        [SerializeField] private List<Wheel> _wheels;

        private float _defaultSpeed;

        private void Awake()
        {
            StopRotationWheels();//refactoring
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
        
        public void StopRotationWheels()
        {
            for (int i = 0; i < _wheels.Count; i++)
            {
                _wheels[i].Disable();
            }
        }

        public void StartRotationWheels()
        {
            for (int i = 0; i < _wheels.Count; i++)
            {
                _wheels[i].Enable();
            }
        }
    }
}