using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private PlayMenu _playMenu;
        [SerializeField] private RaceMenu _raceMenu;
        [SerializeField] private FinisherMenu _finisherMenu;
        [SerializeField] private EndLevelMenu _endLevelMenu;

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
        [SerializeField] private Sprite _powerIcon;

        [Header("Broken Icons")] 
        
        [SerializeField] private Sprite _speedBrokenIcon;
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

        [Header("Feature Names")] 
        
        [SerializeField] private string _speedName;
        [SerializeField] private string _fuelEconomyName;
        [SerializeField] private string _coolnessName;
        [SerializeField] private string _comfortName;
        [SerializeField] private string _airplaneName;
        [SerializeField] private string _angelName;
        [SerializeField] private string _boatName;
        [SerializeField] private string _devilName;
        [SerializeField] private string _elephantName;
        [SerializeField] private string _fireTrackName;
        [SerializeField] private string _fishName;
        [SerializeField] private string _offroadName;
        [SerializeField] private string _springName;
        [SerializeField] private string _powerName;
        
        private readonly Dictionary<FeatureType, Sprite> _iconsMap = new();
        private readonly Dictionary<FeatureType, Sprite> _brokenIconsMap = new();
        private readonly Dictionary<FeatureType, string> _namesOfFeatureMap = new();

        public MainMenu MainMenu => _mainMenu;
        public PlayMenu PlayMenu => _playMenu;
        public RaceMenu RaceMenu => _raceMenu;
        public FinisherMenu FinisherMenu => _finisherMenu;
        public EndLevelMenu EndLevelMenu => _endLevelMenu;

        public IReadOnlyDictionary<FeatureType, Sprite> IconsMap => _iconsMap;
        public IReadOnlyDictionary<FeatureType, Sprite> BrokenIconsMap => _brokenIconsMap;
        public IReadOnlyDictionary<FeatureType, string> NamesOfFeatureMap => _namesOfFeatureMap;

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
            _iconsMap.Add(FeatureType.Kindness, _angelIcon);
            _iconsMap.Add(FeatureType.Boat, _boatIcon);
            _iconsMap.Add(FeatureType.Angry, _devilIcon);
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
            _brokenIconsMap.Add(FeatureType.Kindness, _angelBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Boat, _boatBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Angry, _devilBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Elephant, _elephantBrokenIcon);
            _brokenIconsMap.Add(FeatureType.FireTrack, _fireTrackBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Fish, _fishBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Offroad, _offroadBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Spring, _springBrokenIcon);
            _brokenIconsMap.Add(FeatureType.Power, _powerBrokenIcon);
            
            _namesOfFeatureMap.Add(FeatureType.Speed, _speedName);
            _namesOfFeatureMap.Add(FeatureType.FuelEconomy, _fuelEconomyName);
            _namesOfFeatureMap.Add(FeatureType.Coolness, _coolnessName);
            _namesOfFeatureMap.Add(FeatureType.Comfort, _comfortName);
            _namesOfFeatureMap.Add(FeatureType.Airplane, _airplaneName);
            _namesOfFeatureMap.Add(FeatureType.Kindness, _angelName);
            _namesOfFeatureMap.Add(FeatureType.Boat, _boatName);
            _namesOfFeatureMap.Add(FeatureType.Angry, _devilName);
            _namesOfFeatureMap.Add(FeatureType.Elephant, _elephantName);
            _namesOfFeatureMap.Add(FeatureType.FireTrack, _fireTrackName);
            _namesOfFeatureMap.Add(FeatureType.Fish, _fishName);
            _namesOfFeatureMap.Add(FeatureType.Offroad, _offroadName);
            _namesOfFeatureMap.Add(FeatureType.Spring, _springName);
            _namesOfFeatureMap.Add(FeatureType.Power, _powerName);
        }
    }
}