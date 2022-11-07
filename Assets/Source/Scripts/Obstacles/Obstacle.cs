using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Detail _penaltyDetailPrefab;
        [SerializeField] [Min(0)] private float _moveSpeed = 20f;
        [SerializeField] [Min(0)] private float _moveDuration = 0.2f;
        [SerializeField] private ParticleSystem _disappearParticles;

        public Detail PenaltyDetail => _penaltyDetailPrefab;
        public float MoveSpeed => _moveSpeed;
        public float MoveDuration => _moveDuration;

        public void Disable()
        {
            PlayDisappearParticles();
            gameObject.SetActive(false);
        }

        private void PlayDisappearParticles()
        {
            if (_disappearParticles)
            {
                _disappearParticles.transform.parent = null;
                _disappearParticles.Play();
            }
        }
    }
}