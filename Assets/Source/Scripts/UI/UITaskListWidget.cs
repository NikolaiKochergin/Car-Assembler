using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UITaskListWidget : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UITaskWidget _taskWidgetPrefab;

        private readonly List<UITaskWidget> _taskWidgets = new();
        private CarFeatures _carFeatures;

        private IReadOnlyDictionary<FeatureType, Sprite> _iconsMap;
        private IReadOnlyDictionary<FeatureType, Sprite> _brokenIconsMap;

        private void Awake()
        {
            Hide();
        }

        private void OnDestroy()
        {
            if (_carFeatures != null)
                _carFeatures.CarFeaturesChanged -= OnCarFeaturesChanged;
        }

        public void Initialize(IReadOnlyList<Task> tasks, CarFeatures carFeatures, IReadOnlyDictionary<FeatureType, Sprite> iconsMap, IReadOnlyDictionary<FeatureType, Sprite> brokenIconsMap)
        {
            _iconsMap = iconsMap;
            _brokenIconsMap = brokenIconsMap;
            
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_taskWidgetPrefab, _content);
                spawnedWidget.Initialize(_iconsMap[task.FeatureType], _brokenIconsMap[task.FeatureType], task.FeatureType);
                _taskWidgets.Add(spawnedWidget);
            }

            _carFeatures = carFeatures;
            _carFeatures.CarFeaturesChanged += OnCarFeaturesChanged;
            OnCarFeaturesChanged(_carFeatures);
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