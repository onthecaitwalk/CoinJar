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
                Assert.IsInstanceOf<CoinTypeResponse>(result, "Should return coin type response");
                Assert.AreEqual(0, result.CoinType, "Should be penny coin type.");
            });
        }

        [Test]
        public void CastCoinTypeResponse_NickelCoinType_CastsToNickelCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Nickel);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result, "Should return coin type response");
                Assert.AreEqual(1, result.CoinType, "Should be nickel coin type.");
            });
        }

        [Test]
        public void CastCoinTypeResponse_DimeCoinType_CastsToDimeCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Dime);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result, "Should return coin type response");
                Assert.AreEqual(2, result.CoinType, "Should be dime coin type.");
            });
        }


        [Test]
        public void CastCoinTypeResponse_QuarterCoinType_CastsToQuarterCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Quarter);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result, "Should return coin type response");
                Assert.AreEqual(3, result.CoinType, "Should be quarter coin type.");
            });
        }


        [Test]
        public void CastCoinTypeResponse_HalfCoinType_CastsToHalfCoinTypeResponse()
        {
            var result = CoinTypeResponse.CastCoinTypeResponse(CoinType.Half);

            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<CoinTypeResponse>(result, "Should return coin type response");
                Assert.AreEqual(4, result.CoinType, "Should be half dollar coin type.");
            });
        }

        [Test]
        public void CastCoinTypeResponse_InvalidCoinType_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                CoinTypeResponse.CastCoinTypeResponse((CoinType)6);
            }, "Should throw NullReferenceException when invalid coin type.");
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
                Assert.AreEqual(5, result.Count, "Should contain all five coin types in response.");
                Assert.AreEqual("Penny", penny.Description, "Should contain penny.");
                Assert.AreEqual("Nickel", nickel.Description, "Should contain nickel.");
                Assert.AreEqual("Dime", dime.Description, "Should contain dime.");
                Assert.AreEqual("Quarter Dollar", quarter.Description, "Should contain quarter.");
                Assert.AreEqual("Half Dollar", half.Description, "Should contain half dollar.");
            });
        }
    }
}
