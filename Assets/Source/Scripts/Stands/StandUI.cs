using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class StandUI : MonoBehaviour
    {
        [SerializeField] private StandFeatureView FeatureViewPrefab;
        [SerializeField] private Transform _content;
        [SerializeField] private StandButton _button;

        [Header("Task Icons")]
        
        [SerializeField] private Sprite _speedIcon;
        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;

        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();
        private readonly List<StandFeatureView> _featureViews = new();

        public StandButton Button => _button;

        private void Awake()
        {
            InitIconsMap();
            Hide();
        }

        public void Initialize(Detail detail)
        {
            CreateFreatureView(FeatureType.Speed, detail.Features.Speed);
            CreateFreatureView(FeatureType.FuelEconomy, detail.Features.FuelEconomy);
            CreateFreatureView(FeatureType.Coolness, detail.Features.Coolness);
            CreateFreatureView(FeatureType.Comfort, detail.Features.Comfort);
        }

        private void CreateFreatureView(FeatureType type, int value)
        {
            var view = Instantiate(FeatureViewPrefab, _content);
            view.Initialize(type, _iconsMap[type], value);
            _featureViews.Add(view);
            if(value == 0) view.Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void InitIconsMap()
        {
            _iconsMap.Add(FeatureType.Speed, _speedIcon);
            _iconsMap.Add(FeatureType.FuelEconomy, _fuelEconomyIcon);
            _iconsMap.Add(FeatureType.Coolness, _coolnessIcon);
            _iconsMap.Add(FeatureType.Comfort, _comfortIcon);
        }
    }
}