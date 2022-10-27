using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private PlayMenu _playMenu;
        [SerializeField] private FinisherMenu _finisherMenu;
        [SerializeField] private EndLevelMenu _endLevelMenu;

        [Header("Task Icons")] [SerializeField]
        private Sprite _speedIcon;

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
        [SerializeField] private Sprite _powerIcon;

        [Header("Broken Icons")] [SerializeField]
        private Sprite _speedBrokenIcon;

        [SerializeField] private Sprite _fuelEconomyBrokenIcon;
        [SerializeField] private Sprite _coolnessBrokenIcon;
        [SerializeField] private Sprite _comfortBrokenIcon;
        [SerializeField] private Sprite _airplaneBrokenIcon;
        [SerializeField] private Sprite _angelBrokenIcon;
        [SerializeField] private Sprite _boatBrokenIcon;
        [SerializeField] private Sprite _devilBrokenIcon;
        [SerializeField] private Sprite _elephantBrokenIcon;
        [SerializeField] private Sprite _fireTrackBrokenIcon;
        [SerializeField] private Sprite _fishBrokenIcon;
        [SerializeField] private Sprite _offroadBrokenIcon;
        [SerializeField] private Sprite _springBrokenIcon;
        [SerializeField] private Sprite _powerBrokenIcon;

        private readonly Dictionary<FeatureType, Sprite> _brokenIconsMap = new();

        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();

        public MainMenu MainMenu => _mainMenu;
        public PlayMenu PlayMenu => _playMenu;
        public FinisherMenu FinisherMenu => _finisherMenu;
        public EndLevelMenu EndLevelMenu => _endLevelMenu;

        public IReadOnlyDictionary<FeatureType, Sprite> IconsMap => _iconsMap;
        public IReadOnlyDictionary<FeatureType, Sprite> BrokenIconsMap => _brokenIconsMap;

        private void Awake()
        {
            InitIconsMap();
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
            _iconsMap.Add(FeatureType.Power, _powerIcon);

            _brokenIconsMap.Add(FeatureType.Speed, _speedBrokenIcon);
            _brokenIconsMap.Add(FeatureType.FuelEconomy, _fuelEconomyBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Coolness, _coolnessBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Comfort, _comfortBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Airplane, _airplaneBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Angel, _angelBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Boat, _boatBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Devil, _devilBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Elephant, _elephantBrokenIcon);
            _brokenIconsMap.Add(FeatureType.FireTrack, _fireTrackBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Fish, _fishBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Offroad, _offroadBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Spring, _springBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Power, _powerBrokenIcon);
        }
    }
}