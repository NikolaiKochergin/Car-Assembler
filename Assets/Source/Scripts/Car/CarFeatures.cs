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
        }

        public int Speed { get; private set; }
        public int FuelEconomy { get; private set; }
        public int Coolness { get; private set; }
        public int Comfort { get; private set; }

        public event Action<CarFeatures> CarFeaturesChanged;

        public void CalculateCarFeatures(IReadOnlyList<Detail> details)
        {
            Speed = 0;
            FuelEconomy = 0;
            Coolness = 0;
            Comfort = 0;
            foreach (var detail in details)
            {
                Speed += detail.Features.Speed;
                FuelEconomy += detail.Features.FuelEconomy;
                Coolness += detail.Features.Coolness;
                Comfort += detail.Features.Comfort;
            }
            
            CarFeaturesChanged?.Invoke(this);
        }
    }
}