using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITaskListWidget : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UITaskWidget _taskWidgetPrefab;

        [Header("Task Icons")] [SerializeField]
        private Sprite _speedIcon;

        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _powerIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;

        private readonly List<UITaskWidget> _taskWidgets = new();
        private CarFeatures _carFeatures;

        public Dictionary<FeatureType, Sprite> IconMap { get; } = new();

        private void Awake()
        {
            InitIconsMap();
            Hide();
        }

        private void OnDestroy()
        {
            if (_carFeatures != null)
                _carFeatures.CarFeaturesChanged -= OnCarFeaturesChanged;
        }

        public void Initialize(IReadOnlyList<Task> tasks, CarFeatures carFeatures)
        {
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_taskWidgetPrefab, _content);
                spawnedWidget.Initialize(IconMap[task.FeatureType], task.FeatureType);
                _taskWidgets.Add(spawnedWidget);
            }

            _carFeatures = carFeatures;
            _carFeatures.CarFeaturesChanged += OnCarFeaturesChanged;
            OnCarFeaturesChanged(_carFeatures);
        }

        private void InitIconsMap()
        {
            IconMap.Add(FeatureType.Speed, _speedIcon);
            IconMap.Add(FeatureType.FuelEconomy, _fuelEconomyIcon);
            IconMap.Add(FeatureType.Power, _powerIcon);
            IconMap.Add(FeatureType.Coolness, _coolnessIcon);
            IconMap.Add(FeatureType.Comfort, _comfortIcon);
        }

        private void OnCarFeaturesChanged(CarFeatures carFeatures)
        {
            foreach (var widget in _taskWidgets) widget.SetValueBy(carFeatures);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}