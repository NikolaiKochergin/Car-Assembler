using UnityEngine;

namespace CarAssembler
{
    public class Barrier : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _moveSpeed;
        [SerializeField] [Min(0)] private float _moveDuration;

        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;
    }
}
