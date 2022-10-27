using System;
using System.Collections.Generic;

namespace CarAssembler
{
    public class CarFeatures
    {
        public CarFeatures()
        {
            Speed = 0;
            FuelEconomy = 0;
            Coolness = 0;
            Comfort = 0;
            Airplane = 0;
            Angel = 0;
            Boat = 0;
            Devil = 0;
            Elephant = 0;
            FireTrack = 0;
            Fish = 0;
            Offroad = 0;
            Spring = 0;
            Power = 0;
        }

        public int Speed { get; private set; }
        public int FuelEconomy { get; private set; }
        public int Coolness { get; private set; }
        public int Comfort { get; private set; }
        public int Airplane { get; private set; }
        public int Angel { get; private set; }
        public int Boat { get; private set; }
        public int Devil { get; private set; }
        public int Elephant { get; private set; }
        public int FireTrack { get; private set; }
        public int Fish { get; private set; }
        public int Offroad { get; private set; }
        public int Spring { get; private set; }
        public int Power { get; private set; }

        public event Action<CarFeatures> CarFeaturesChanged;

        public void CalculateCarFeatures(IReadOnlyList<Detail> details)
        {
            Speed = 0;
            FuelEconomy = 0;
            Coolness = 0;
            Comfort = 0;
            Airplane = 0;
            Angel = 0;
            Boat = 0;
            Devil = 0;
            Elephant = 0;
            FireTrack = 0;
            Fish = 0;
            Offroad = 0;
            Spring = 0;
            Power = 0;
            foreach (var detail in details)
            {
                Speed += detail.Features.Speed;
                FuelEconomy += detail.Features.FuelEconomy;
                Coolness += detail.Features.Coolness;
                Comfort += detail.Features.Comfort;
                Airplane += detail.Features.Airplane;
                Angel += detail.Features.Angel;
                Boat += detail.Features.Boat;
                Devil += detail.Features.Devil;
                Elephant += detail.Features.Elephant;
                FireTrack += detail.Features.FireTrack;
                Fish += detail.Features.Fish;
                Offroad += detail.Features.Offroad;
                Spring += detail.Features.Spring;
                Power += detail.Features.Power;
            }
            
            CarFeaturesChanged?.Invoke(this);
        }

        public void CalculateCarFeatures(IReadOnlyList<Detail> details, Detail detail)
        {
            CalculateCarFeatures(details);

            Speed += detail.Features.Speed;
            FuelEconomy += detail.Features.FuelEconomy;
            Coolness += detail.Features.Coolness;
            Comfort += detail.Features.Comfort;
            Airplane += detail.Features.Airplane;
            Angel += detail.Features.Angel;
            Boat += detail.Features.Boat;
            Devil += detail.Features.Devil;
            Elephant += detail.Features.Elephant;
            FireTrack += detail.Features.FireTrack;
            Fish += detail.Features.Fish;
            Offroad += detail.Features.Offroad;
            Spring += detail.Features.Spring;
            Power += detail.Features.Power;
            
            CarFeaturesChanged?.Invoke(this);
        }
    }
}