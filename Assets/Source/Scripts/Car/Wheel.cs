using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public abstract class Wheel : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float StartSpeed { get; private set; }
        public float Speed => _speed;

        public abstract void Update();

        public void Initialize()
        {
            Disable();
            StartSpeed = _speed;
        }

        public void ChangeSpeedRotation(float multiplierSpeed)
        {
            _speed *= (multiplierSpeed * 0.19f);//MAGIC INT
        }
        
        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            //_speed = StartSpeed;
            enabled = false;
        }
    }
}
