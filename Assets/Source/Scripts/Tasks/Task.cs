using System;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class Task
    {
        [SerializeField] private FeatureType _featureType;

        public FeatureType FeatureType => _featureType;
    }
}