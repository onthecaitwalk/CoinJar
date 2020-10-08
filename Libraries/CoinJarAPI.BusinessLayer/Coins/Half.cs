using System;

namespace CoinJarAPI.BusinessLayer
{
    public class Half : Coin
    {
        public Half()
        {
            Amount = 0.50m;
            Volume = CalculateVolume(30.61, 2.15);
        }
    }
}
