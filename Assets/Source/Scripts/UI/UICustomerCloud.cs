using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UICustomerCloud : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UICloudTaskWidget _cloudTaskWidgetPrefab;

        private IReadOnlyDictionary<FeatureType, Sprite> _iconsMap;
        private IReadOnlyDictionary<FeatureType, string> _namesMap;

        public void Initialize(IReadOnlyList<Task> tasks, IReadOnlyDictionary<FeatureType, Sprite> iconsMap, IReadOnlyDictionary<FeatureType, string> namesMap)
        {
            _iconsMap = iconsMap;
            _namesMap = namesMap;
            
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_cloudTaskWidgetPrefab, _content);
                spawnedWidget.Initialize(_iconsMap[task.FeatureType], namesMap[task.FeatureType]);
            }
        }
    }
}