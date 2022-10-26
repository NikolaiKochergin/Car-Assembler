using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _moveSpeed = 20f;
        [SerializeField] [Min(0)] private float _moveDuration = 0.2f;

        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}