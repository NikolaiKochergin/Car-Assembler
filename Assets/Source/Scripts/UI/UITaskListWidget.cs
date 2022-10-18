using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITaskListWidget : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UITaskWidget _taskWidgetPrefab;

        [Header("Task Icons")] 
        [SerializeField] private Sprite _speedIcon;
        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _powerIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;

        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();

        private void Awake()
        {
            InitIconsMap();
        }

        public void Initialize(IReadOnlyList<Task> tasks)
        {
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_taskWidgetPrefab, _content);
                spawnedWidget.Initialize(_iconsMap[task.FeatureType], task.TargetValue.ToString());
            }
        }

        private void InitIconsMap()
        {
            _iconsMap.Add(FeatureType.Speed, _speedIcon);
            _iconsMap.Add(FeatureType.FuelEconomy, _fuelEconomyIcon);
            _iconsMap.Add(FeatureType.Power, _powerIcon);
            _iconsMap.Add(FeatureType.Coolness, _coolnessIcon);
            _iconsMap.Add(FeatureType.Comfort, _comfortIcon);
        }
    }
}