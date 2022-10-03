using System;
using UnityEngine;

namespace CarAssembler
{
    public class Detail : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _appearParticles;
        [SerializeField] private SlotType _slotType;
        [SerializeField] [Min(0)] private int _price;

        public SlotType SlotType => _slotType;
        public int Price => _price;

        public void SetPrice(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _price = value;
        }
        
        public void Show()
        {
            _appearParticles.Play();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}