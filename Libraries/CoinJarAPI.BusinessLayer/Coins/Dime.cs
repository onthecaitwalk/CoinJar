using System;

namespace CoinJarAPI.BusinessLayer
{
    public class Dime : Coin
    {
        public Dime()
        {
            Amount = 0.10m;
            Volume = CalculateVolume(17.91, 1.35);
        }
    }
}
