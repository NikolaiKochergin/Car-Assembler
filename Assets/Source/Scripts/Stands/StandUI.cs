using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class StandUI : MonoBehaviour
    {
        [SerializeField] private StandFeatureView FeatureViewPrefab;
        [SerializeField] private Transform _content;
        [SerializeField] private StandButton _button;
        [SerializeField] private Animator _animator;

        [Header("Task Icons")]
        
        [SerializeField] private Sprite _speedIcon;
        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;
        [SerializeField] private Sprite _airplaneIcon;
        [SerializeField] private Sprite _angelIcon;
        [SerializeField] private Sprite _boatIcon;
        [SerializeField] private Sprite _devilIcon;
        [SerializeField] private Sprite _elephantIcon;
        [SerializeField] private Sprite _fireTrackIcon;
        [SerializeField] private Sprite _fishIcon;
        [SerializeField] private Sprite _offroadIcon;
        [SerializeField] private Sprite _springIcon;

        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();
        private readonly List<StandFeatureView> _featureViews = new();

        public StandButton Button => _button;
        public Animator Animator => _animator;

        private void Awake()
        {
            InitIconsMap();
        }

        public void Initialize(Detail detail)
        {
            CreateFreatureView(FeatureType.Speed, detail.Features.Speed);
            CreateFreatureView(FeatureType.FuelEconomy, detail.Features.FuelEconomy);
            CreateFreatureView(FeatureType.Coolness, detail.Features.Coolness);
            CreateFreatureView(FeatureType.Comfort, detail.Features.Comfort);
            CreateFreatureView(FeatureType.Airplane, detail.Features.Airplane);
            CreateFreatureView(FeatureType.Angel, detail.Features.Angel);
            CreateFreatureView(FeatureType.Boat, detail.Features.Boat);
            CreateFreatureView(FeatureType.Devil, detail.Features.Devil);
            CreateFreatureView(FeatureType.Elephant, detail.Features.Elephant);
            CreateFreatureView(FeatureType.FireTrack, detail.Features.FireTrack);
            CreateFreatureView(FeatureType.Fish, detail.Features.Fish);
            CreateFreatureView(FeatureType.Offroad, detail.Features.Offroad);
            CreateFreatureView(FeatureType.Spring, detail.Features.Spring);
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
            _animator.SetTrigger("Appear");
        }

        public void Hide()
        {
            _animator.SetTrigger("Disappear");
        }

        private void InitIconsMap()
        {
            _iconsMap.Add(FeatureType.Speed, _speedIcon);
            _iconsMap.Add(FeatureType.FuelEconomy, _fuelEconomyIcon);
            _iconsMap.Add(FeatureType.Coolness, _coolnessIcon);
            _iconsMap.Add(FeatureType.Comfort, _comfortIcon);
            _iconsMap.Add(FeatureType.Airplane, _airplaneIcon);
            _iconsMap.Add(FeatureType.Angel, _angelIcon);
            _iconsMap.Add(FeatureType.Boat, _boatIcon);
            _iconsMap.Add(FeatureType.Devil, _devilIcon);
            _iconsMap.Add(FeatureType.Elephant, _elephantIcon);
            _iconsMap.Add(FeatureType.FireTrack, _fireTrackIcon);
            _iconsMap.Add(FeatureType.Fish, _fishIcon);
            _iconsMap.Add(FeatureType.Offroad, _offroadIcon);
            _iconsMap.Add(FeatureType.Spring, _springIcon);
        }
    }
}