using System;
using UnityEngine;

namespace CarAssembler
{
    [Serializable]
    public class DetailFeatures
    {
        [SerializeField] private SlotType _slotType;
        [SerializeField] private int _speed;
        [SerializeField] private int _fuelEconomy;
        [SerializeField] private int _coolness;
        [SerializeField] private int _comfort;
        [SerializeField] private int _airplane;
        [SerializeField] private int _angel;
        [SerializeField] private int _boat;
        [SerializeField] private int _devil;
        [SerializeField] private int _elephant;
        [SerializeField] private int _fireTrack;
        [SerializeField] private int _fish;
        [SerializeField] private int _offroad;
        [SerializeField] private int _spring;

        public SlotType Slot => _slotType;
        public int Speed => _speed;
        public int FuelEconomy => _fuelEconomy;
        public int Coolness => _coolness;
        public int Comfort => _comfort;
        public int Airplane => _airplane;
        public int Angel => _angel;
        public int Boat => _boat;
        public int Devil => _devil;
        public int Elephant => _elephant;
        public int FireTrack => _fireTrack;
        public int Fish => _fish;
        public int Offroad => _offroad;
        public int Spring => _spring;
    }

    public enum FeatureType
    {
        Speed,
        FuelEconomy,
        Coolness,
        Comfort,
        Airplane,
        Angel,
        Boat,
        Devil,
        Elephant,
        FireTrack,
        Fish,
        Offroad,
        Spring
    }

    public enum SlotType
    {
        Empty,
        Frame,
        Doors,
        Windows,
        Wheels,
        Spoiler,
        Engine,
        Tuning,
        FrontBumper
    }
}