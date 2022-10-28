using UnityEngine;
using UnityEngine.Serialization;

namespace CarAssembler
{
    [SelectionBase]
    public class Barrier : MonoBehaviour, IDisableable
    {
        [SerializeField] private Detail _penaltyDetailPrefab;
        [SerializeField] [Min(0)] private float _moveSpeed;
        [SerializeField] [Min(0)] private float _moveDuration;
        [SerializeField] private AnimatorContainer _animatorContainer;
        [SerializeField] private Collider _collider;

        public Detail PenaltyDetail => _penaltyDetailPrefab;
        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;
        public AnimatorContainer animatorContainer => _animatorContainer;
        public Collider Collider => _collider;

        public void Disable()
        {
            Debug.Log("Disable");
            _collider.enabled = false;
            _animatorContainer.Enable();
            //gameObject.SetActive(false);
        }
    }
}
