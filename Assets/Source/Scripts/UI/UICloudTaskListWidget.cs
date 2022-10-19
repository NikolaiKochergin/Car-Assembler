using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UICloudTaskListWidget : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UICloudTaskWidget _cloudTaskWidgetPrefab;

        private IReadOnlyDictionary<FeatureType, Sprite> _iconsMap;
        
        public void Initialize(IReadOnlyList<Task> tasks, IReadOnlyDictionary<FeatureType, Sprite> iconsMap)
        {
            _iconsMap = iconsMap;
            
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_cloudTaskWidgetPrefab, _content);
                spawnedWidget.Initialize(_iconsMap[task.FeatureType], task.TargetValue.ToString());
            }
        }
    }
}
