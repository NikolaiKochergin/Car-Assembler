using System;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class Task
    {
        [SerializeField] private FeatureType _featureType;
        [SerializeField] private int _targetValue;

        public FeatureType FeatureType => _featureType;
        public int TargetValue => _targetValue;
    }
}