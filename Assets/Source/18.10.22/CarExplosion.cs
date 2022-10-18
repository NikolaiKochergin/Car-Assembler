using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class CarExplosion : MonoBehaviour, IPhysics
    {
        [SerializeField] private ParticleSystem[] _explosionParticlies;//Max

        private IPhysics _physics;//Max

        public void Explode(List<Rigidbody> rigidbodies)
        {
            _physics.MakePhysics(rigidbodies);
            for (int i = 0; i < _explosionParticlies.Length; i++)
            {
                _explosionParticlies[i].Play();
            }

        }
    }
}
