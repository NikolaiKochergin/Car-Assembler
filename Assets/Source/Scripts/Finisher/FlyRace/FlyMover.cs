using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class FlyMover : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _moveSpeedY = 6;
        [SerializeField] [Min(0)] private float _rotationSpeed = 8;
        [SerializeField] [Min(0)] private float _maxAngle = 30;
        [SerializeField] private float _maxPositionY = 5;
        [SerializeField] private float _minPositionY = -1;

        private SplineFollower _follower;
        private float _targetOffsetY;
        private float _targetRotationX;

        private void Awake()
        {
            Disable();
        }

        private void Update()
        {
            if (_targetOffsetY - _follower.motion.offset.y > 0)
                _targetRotationX = -_maxAngle;
            else if (_targetOffsetY - _follower.motion.offset.y < 0)
                _targetRotationX = _maxAngle;
            else
                _targetRotationX = 0f;

            _follower.motion.offset = Vector2.MoveTowards(_follower.motion.offset,
                new Vector2(0, _targetOffsetY), _moveSpeedY * Time.deltaTime);

            _follower.motion.rotationOffset = Vector3.Lerp(_follower.motion.rotationOffset,
                new Vector3(_targetRotationX, 0, 0), _rotationSpeed * Time.deltaTime);
        }

        public void Initialize(SplineFollower follower)
        {
            _follower = follower;
            _targetOffsetY = _follower.motion.offset.y;
            _targetRotationX = _follower.motion.rotationOffset.x;
        }

        public void MoveUp()
        {
            _targetOffsetY = _maxPositionY;
        }

        public void MoveDown()
        {
            _targetOffsetY = _minPositionY;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}