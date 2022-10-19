using System;
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
        
        [Header("Task Icons")] 
        
        [SerializeField] private Sprite _speedIcon;
        [SerializeField] private Sprite _fuelEconomyIcon;
        [SerializeField] private Sprite _powerIcon;
        [SerializeField] private Sprite _coolnessIcon;
        [SerializeField] private Sprite _comfortIcon;
        
        private Dictionary<FeatureType, Sprite> _iconsMap = new();

        public MainMenu MainMenu => _mainMenu;
        public PlayMenu PlayMenu => _playMenu;
        public FinisherMenu FinisherMenu => _finisherMenu;
        public EndLevelMenu EndLevelMenu => _endLevelMenu;

        public IReadOnlyDictionary<FeatureType, Sprite> IconsMap => _iconsMap;

        private void Awake()
        {
            InitIconsMap();
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
