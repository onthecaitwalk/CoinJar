using System;

namespace CoinJarAPI.BusinessLayer
{
    public class Nickel : Coin
    {
        public Nickel()
        {
            Amount = 0.05m;
            Volume = CalculateVolume(21.21, 1.95);
        }
    }
}
