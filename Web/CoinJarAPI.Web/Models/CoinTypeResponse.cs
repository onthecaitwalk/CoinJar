using System.Collections.Generic;
using System.Linq;
using CoinJarAPI.BusinessLayer.Extensions;

namespace CoinJarAPI.Web.Models
{
    public class CoinTypeResponse
    {
        public int CoinType { get; set; }
        public string Description { get; set; }

        public static IList<CoinTypeResponse> CastCoinTypeResponses()
        {
            var coinTypes = EnumExtensions.GetEnumList<CoinType>();
            var coinTypeResponses = new List<CoinTypeResponse>();
            coinTypes.ToList().ForEach(coinType =>
            {
                coinTypeResponses.Add(CastCoinTypeResponse(coinType));
            });

            return coinTypeResponses;
        }

        public static CoinTypeResponse CastCoinTypeResponse(CoinType coinType) =>
            new CoinTypeResponse
            {
                CoinType = (int)coinType,
                Description = coinType.GetDescription()
            };
    }
}
