using System;

namespace CarAssembler
{
    [Serializable]
    public class Data
    {
        public int Level;
        public int Coins;

        public Data()
        {
            Level = 1;
            Coins = 0;
        }
    }
}