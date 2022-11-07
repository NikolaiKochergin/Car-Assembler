using UnityEngine;

namespace CarAssembler
{
    public class ParticleContainer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _fogCarParticles;
        [SerializeField] private ParticleSystem _dirtFallParticle;

        public void PlayFogCarParticle()
        {
            
            //_fogCarParticles.Play();
        }

        public void PlayDirtFall()
        {
            if (_dirtFallParticle)
            {
                _dirtFallParticle.Play();
            }
        }

        public void StopDirtFall()
        {
            if (_dirtFallParticle)
            {
                _dirtFallParticle.Stop();
            }
        }
    }
}
