using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class ParticleContainer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _fogCarParticle;

        public void PlayFogCarParticle()
        {
            _fogCarParticle.Play();
        }
    }
}
