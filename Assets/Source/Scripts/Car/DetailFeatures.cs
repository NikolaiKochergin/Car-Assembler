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
        [SerializeField] private int _power;
        [SerializeField] private int _coolness;
        [SerializeField] private int _comfort;
        [SerializeField] private int _price;

        public SlotType Slot => _slotType;
        public int Speed => _speed;
        public int FuelEconomy => _fuelEconomy;
        public int Power => _power;
        public int Coolness => _coolness;
        public int Comfort => _comfort;
        public int Price => _price;
    }

    public enum FeatureType
    {
        Speed,
        FuelEconomy,
        Power,
        Coolness,
        Comfort
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