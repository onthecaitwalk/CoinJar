using System;
using System.Collections.Generic;
using System.Text;

namespace CoinJarAPI.BusinessLayer
{
    public static class Constants
    {
        public const decimal CoinJarAPIMaxVolume = 42;

        // 1 cubic meter is equal to 1000000 milliliter, or 33814.022558919 ounce [US, liquid].
        public const decimal CubicMmInAnOunce = 3.3814022558919e-5m;
    }
}
