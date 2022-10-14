using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Detail : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _appearParticles;
        [SerializeField] private SlotType _slotType;
        [SerializeField] private FeatureType _feature;
        [SerializeField] [Min(0)] private int _price;

        public SlotType SlotType => _slotType;
        public FeatureType Feature => _feature;
        public int Price => _price;

        public void SetPrice(int value)
        {
            _price = value;
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

    public enum FeatureType
    {
        Empty,
        Sport,
        Common,
        SUV
    }
}