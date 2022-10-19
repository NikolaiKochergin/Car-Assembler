using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UICustomerCloud : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private UICloudTaskWidget _cloudTaskWidgetPrefab;

        [SerializeField] private UITaskListWidget _uiTaskListWidget;
        
        public void Initialize(IReadOnlyList<Task> tasks)
        {
            foreach (var task in tasks)
            {
                var spawnedWidget = Instantiate(_cloudTaskWidgetPrefab, _content);
                spawnedWidget.Initialize(_uiTaskListWidget.IconMap[task.FeatureType], task.FeatureType.ToString());
            }
        }
    }
}