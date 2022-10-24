using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CarAssembler;

namespace CarAssembler
{
    public class CarFinishReaction : MonoBehaviour, IPhysics
    {
        [SerializeField] private ParticleSystem[] _explosionParticlies;//Max
        [SerializeField] private ParticleSystem[] _speedParticles;

        private IPhysics _physics = new CarPhysics();

        public void Explode(IReadOnlyList<Rigidbody> rigidbodies)
        {
            _physics.MakePhysics(rigidbodies);
            for (int i = 0; i < _explosionParticlies.Length; i++)
            {
                _explosionParticlies[i].Play();
            }
        }

        public void Slip()
        {
            for (int i = 0; i < _speedParticles.Length; i++)
            {
                _speedParticles[i].Play();
            }
        }
    }
}
