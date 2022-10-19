using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class StandUI : MonoBehaviour
    {
        [SerializeField] private StandFeatureView FeatureViewPrefab;
        [SerializeField] private Transform _content;

        [Header("Task Icons")] [SerializeField]
        private Sprite _speedIcon;

        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _powerIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;

        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();
        private readonly List<StandFeatureView> _featureViews = new();

        private void Awake()
        {
            InitIconsMap();
            Hide();
        }

        public void Initialize(Detail detail)
        {
            CreateFreatureView(FeatureType.Speed, detail.Features.Speed);
            CreateFreatureView(FeatureType.FuelEconomy, detail.Features.FuelEconomy);
            CreateFreatureView(FeatureType.Power, detail.Features.Power);
            CreateFreatureView(FeatureType.Coolness, detail.Features.Coolness);
            CreateFreatureView(FeatureType.Comfort, detail.Features.Comfort);
        }

        private void CreateFreatureView(FeatureType type, int value)
        {
            var view = Instantiate(FeatureViewPrefab, _content);
            view.Initialize(type, _iconsMap[type], value);
            _featureViews.Add(view);
        }


        public void ShowWith(IReadOnlyList<Task> tasks)
        {
            gameObject.SetActive(true);
            
            foreach (var task in tasks)
            {
                foreach (var view in _featureViews)
                {
                    if(task.FeatureType == view.Type) view.Show();
                }
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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