using UnityEngine;

namespace CarAssembler
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] [Min(0)] private float _followSpeed;
        [SerializeField] [Min(0)] private float _rotateSpeed;

        private void Update()
        {
            transform.position =
                Vector3.Lerp(transform.position, _target.transform.position, _followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _target.transform.rotation,
                _rotateSpeed * Time.deltaTime);
        }
    }
}