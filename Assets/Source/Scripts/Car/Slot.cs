using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private Detail _sportPart;
        [SerializeField] private Detail _commonPart;
        [SerializeField] private Detail _SUVPart;

        private Dictionary<FeatureType, Detail> _partsMap;

        public SlotType SlotType => _slotType;
        public Detail Content { get; private set; }

        private void Awake()
        {
            _partsMap = new Dictionary<FeatureType, Detail>
            {
                {FeatureType.Sport, _sportPart},
                {FeatureType.Common, _commonPart},
                {FeatureType.SUV, _SUVPart}
            };
        }

        private void OnValidate()
        {
            gameObject.name = _slotType + "Slot";
        }

        public void TakeOrReplace(Stand stand)
        {
            if (Content)
                Content.Hide();

            if (stand.DetailFeature == FeatureType.Empty)
                Debug.Log("У подбираемой детали выстывлено свойство Empty");
            else
            {
                Content = _partsMap[stand.DetailFeature];
                Content.SetPrice(stand.DetailPrice);
            }
            
            Content.Show();
        }
    }

    public enum SlotType
    {
        Empty,
        Frame,
        Doors,
        Windows,
        Wheels,
        Spoiler,
        Engine,
        Tuning,
        Bumper
    }
}