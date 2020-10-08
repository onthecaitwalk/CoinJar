using System;

namespace CoinJarAPI.BusinessLayer
{
    public class Quarter : Coin
    {
        public Quarter()
        {
            Amount = 0.25m;
            Volume = CalculateVolume(24.26, 1.75);
        }
    }
}
