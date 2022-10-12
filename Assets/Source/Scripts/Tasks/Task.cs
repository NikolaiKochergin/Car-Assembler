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

        public SlotType SlotType => _slotType;
        public FeatureType Feature => _feature;
        public bool IsDone { get; private set; }

        public virtual bool CheckTask(Car car)
        {
            

            return IsDone;
        }
    }
}