using UnityEngine;

namespace CarAssembler
{
    public class UIFollower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        private void Update()
        {
            transform.position = _targetTransform.position;
        }
    }
}
