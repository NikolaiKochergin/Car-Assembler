using System;

namespace CarAssembler
{
    public interface IRace
    {
        public event Action RaceEnded;
        
        public void StartRace();
    }
}