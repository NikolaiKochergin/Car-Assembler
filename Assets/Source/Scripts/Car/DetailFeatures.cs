using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class DetailFeatures
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private FeatureType[] _features;

        public SlotType Slot => _slotType;
        public IReadOnlyList<FeatureType> Features => _features;
    }
}
