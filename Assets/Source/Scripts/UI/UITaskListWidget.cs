using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITaskListWidget : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UITaskWidget _taskWidgetPrefab;

        private readonly List<UITaskWidget> _taskWidgets = new();
        private IReadOnlyDictionary<FeatureType, Sprite> _brokenIconsMap;
        private CarFeatures _carFeatures;

        private IReadOnlyDictionary<FeatureType, Sprite> _iconsMap;
        private CarFeatures _preliminaryCarFeatures;

        private void Awake()
        {
            Hide();
        }

        private void OnDestroy()
        {
            if (_carFeatures != null)
                _carFeatures.CarFeaturesChanged -= OnCarFeaturesChanged;

            if (_preliminaryCarFeatures != null)
                _preliminaryCarFeatures.CarFeaturesChanged -= OnPreliminatyCarFeaturesChanged;
        }

        public void Initialize(IReadOnlyList<Task> tasks, CarFeatures carFeatures, CarFeatures preliminaryCarFeatures,
            IReadOnlyDictionary<FeatureType, Sprite> iconsMap, IReadOnlyDictionary<FeatureType, Sprite> brokenIconsMap)
        {
            _iconsMap = iconsMap;
            _brokenIconsMap = brokenIconsMap;

            SpawnWidget(FeatureType.Speed);
            SpawnWidget(FeatureType.FuelEconomy);
            SpawnWidget(FeatureType.Coolness);
            SpawnWidget(FeatureType.Comfort);
            SpawnWidget(FeatureType.Airplane);
            SpawnWidget(FeatureType.Angel);
            SpawnWidget(FeatureType.Boat);
            SpawnWidget(FeatureType.Devil);
            SpawnWidget(FeatureType.Elephant);
            SpawnWidget(FeatureType.FireTrack);
            SpawnWidget(FeatureType.Fish);
            SpawnWidget(FeatureType.Offroad);
            SpawnWidget(FeatureType.Spring);
            SpawnWidget(FeatureType.Power);

            for (int i = tasks.Count - 1 ; i >= 0; i--)
            {
                foreach (var widget in _taskWidgets)
                {
                    if (widget.Type == tasks[i].FeatureType)
                    {
                        widget.Show();
                        widget.transform.SetSiblingIndex(1);
                        widget.MakeItMainTask();
                    }
                }
            }

            _carFeatures = carFeatures;
            _preliminaryCarFeatures = preliminaryCarFeatures;
            _carFeatures.CarFeaturesChanged += OnCarFeaturesChanged;
            _preliminaryCarFeatures.CarFeaturesChanged += OnPreliminatyCarFeaturesChanged;
            OnCarFeaturesChanged(_carFeatures);
        }

        private void SpawnWidget(FeatureType type)
        {
            var spawnedWidget = Instantiate(_taskWidgetPrefab, _content);
            spawnedWidget.Initialize(_iconsMap[type], _brokenIconsMap[type], type);
            spawnedWidget.Hide();
            _taskWidgets.Add(spawnedWidget);
        }

        private void OnCarFeaturesChanged(CarFeatures carFeatures)
        {
            foreach (var widget in _taskWidgets) widget.SetValueBy(carFeatures);
        }

        private void OnPreliminatyCarFeaturesChanged(CarFeatures carFeatures)
        {
            foreach (var widget in _taskWidgets)
            {
                widget.SetValueBy(carFeatures);
                widget.OnHighlight();
            }
        }

        public void OffWidgetsHighlight()
        {
            foreach (var widget in _taskWidgets) widget.OffHighlight();

            OnCarFeaturesChanged(_carFeatures);
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