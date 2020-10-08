using System;

namespace CoinJarAPI.BusinessLayer
{
    public abstract class Coin : ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }

        public decimal CalculateVolume(double diameterInMm, double thicknessInMm)
        {
            var radius = diameterInMm / 2;
            var volumeInCubedMm = Math.PI * Math.Pow(radius, 2) * thicknessInMm;
            var ounces = (decimal)volumeInCubedMm * Constants.CubicMmInAnOunce;
            return decimal.Round(ounces, 16);
        }
    }
}
