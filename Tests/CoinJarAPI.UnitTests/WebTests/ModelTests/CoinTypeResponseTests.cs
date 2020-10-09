using System;
using System.Linq;
using CoinJarAPI.Web.Models;
using NUnit.Framework;

namespace CoinJarAPI.UnitTests.WebTests.ModelTests
{
    [TestFixture]
    public class CoinTypeResponseTests
    {
        [Test]
        public void CastCoinTypeResponse_PennyCoinType_CastsToPennyCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Penny);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result);
                Assert.AreEqual(0, result.CoinType);
            });
        }

        [Test]
        public void CastCoinTypeResponse_NickelCoinType_CastsToNickelCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Nickel);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result);
                Assert.AreEqual(1, result.CoinType);
            });
        }

        [Test]
        public void CastCoinTypeResponse_DimeCoinType_CastsToDimeCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Dime);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result);
                Assert.AreEqual(2, result.CoinType);
            });
        }


        [Test]
        public void CastCoinTypeResponse_QuarterCoinType_CastsToQuarterCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Quarter);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result);
                Assert.AreEqual(3, result.CoinType);
            });
        }


        [Test]
        public void CastCoinTypeResponse_HalfCoinType_CastsToHalfCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Half);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result);
                Assert.AreEqual(4, result.CoinType);
            });
        }

        [Test]
        public void CastCoinTypeResponse_InvalidCoinType_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                CoinTypeResponse.CastCoinTypeResponse((CoinType)6);
            });
        }

        [Test]
        public void CastCoinTypeResponses_ReturnsAllCoinTypesAsListOfCoinTypeResponses()
        {
            var result = CoinTypeResponse.CastCoinTypeResponses();

            Assert.Multiple(() =>
            {
                var penny = result.First(r => r.CoinType == 0);
                var nickel = result.First(r => r.CoinType == 1);
                var dime = result.First(r => r.CoinType == 2);
                var quarter = result.First(r => r.CoinType == 3);
                var half = result.First(r => r.CoinType == 4);
                Assert.AreEqual(5, result.Count);
                Assert.AreEqual("Penny", penny.Description);
                Assert.AreEqual("Nickel", nickel.Description);
                Assert.AreEqual("Dime", dime.Description);
                Assert.AreEqual("Quarter Dollar", quarter.Description);
                Assert.AreEqual("Half Dollar", half.Description);
            });
        }
    }
}
