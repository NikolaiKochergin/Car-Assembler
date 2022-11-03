using UnityEngine;

namespace CarAssembler
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] [Min(0)] private float _followSpeed;
        [SerializeField] [Min(0)] private float _rotateSpeed;
        [SerializeField] private bool _lockYAxisMovement;

        private void Update()
        {
            var currentPosition =
                Vector3.Lerp(transform.position, _target.transform.position, _followSpeed * Time.deltaTime);

            if (_lockYAxisMovement)
                currentPosition = new Vector3(currentPosition.x, 0, currentPosition.z);
            
            transform.position = currentPosition;
            
            transform.rotation = Quaternion.Lerp(transform.rotation, _target.transform.rotation,
                _rotateSpeed * Time.deltaTime);
        }

        public void ChangeTarget(Transform newTarget)
        {
            _target = newTarget;
        }
    }
}