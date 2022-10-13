using System;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class Task
    {
        [SerializeField] private Sprite _taskIcon;
        [SerializeField] private FeatureType _carType;

        public Sprite TaskIcon => _taskIcon;
        public FeatureType CarType => _carType;
    }
}