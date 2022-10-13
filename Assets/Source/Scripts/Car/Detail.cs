using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Detail : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _appearParticles;
        [SerializeField] private SlotType _slotType;
        [SerializeField] private FeatureType[] _features;
        [SerializeField] [Min(0)] private int _price;

        public SlotType SlotType => _slotType;
        public IReadOnlyList<FeatureType> Features => _features;
        public int Price => _price;

        public void Show()
        {
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
        SUV,
        Yellow,
        Green,
        Blue,
        Grade1,
        Grade2,
        Grade3
    }
}