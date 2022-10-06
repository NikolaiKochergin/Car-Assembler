using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class Task
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private FeatureType _feature;

        public FeatureType Feature => _feature;
        public bool IsDone { get; private set; }

        public virtual bool CheckTask(IReadOnlyList<Slot> carSlots)
        {
            IsDone = carSlots
                .Where(slot => slot.Content != null)
                .Where(slot => _slotType == SlotType.Empty || slot.Content.SlotType == _slotType)
                .Any(slot => slot.Content.Features.Any(feature => feature == _feature));

            return IsDone;
        }
    }
}