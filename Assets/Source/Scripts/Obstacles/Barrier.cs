using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Barrier : MonoBehaviour, IDisableable
    {
        [SerializeField] private Detail _penaltyDetailPrefab;
        [SerializeField] [Min(0)] private float _moveSpeed;
        [SerializeField] [Min(0)] private float _moveDuration;

        public Detail PenaltyDetail => _penaltyDetailPrefab;
        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
