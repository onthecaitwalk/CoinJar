using System;

namespace CoinJarAPI.BusinessLayer
{
    public class Penny : Coin
    {
        public Penny()
        {
            Amount = 0.01m;
            Volume = CalculateVolume(19.05, 1.52);
        }
    }
}
