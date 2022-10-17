using UnityEngine;

namespace CarAssembler
{
    public class Detail : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _appearParticles;
        [SerializeField] private DetailFeatures _features;

        public DetailFeatures Features => _features;

        public void SetDetailFeatures(DetailFeatures features)
        {
            if (features != null)
                _features = features;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            if (_appearParticles != null)
                _appearParticles.Play();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}