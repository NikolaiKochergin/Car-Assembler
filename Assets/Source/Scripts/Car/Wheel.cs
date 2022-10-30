using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public abstract class Wheel : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;

        public abstract void Update();

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = true;
        }
    }
}
