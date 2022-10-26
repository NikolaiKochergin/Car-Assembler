using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Barrier : MonoBehaviour, IDisableable
    {
        [SerializeField] [Min(0)] private float _moveSpeed;
        [SerializeField] [Min(0)] private float _moveDuration;

        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
