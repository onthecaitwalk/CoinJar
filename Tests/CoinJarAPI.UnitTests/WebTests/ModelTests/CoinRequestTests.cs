using System;
using System.Linq;
using CoinJarAPI.BusinessLayer;
using CoinJarAPI.Web.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NUnit.Framework;

namespace CoinJarAPI.UnitTests.WebTests.ModelTests
{
    [TestFixture]
    public class CoinRequestTests
    {
        [Test]
        public void CastToCoin_CoinRequestContainsPenny_ReturnsPenny()
        {
            var request = new CoinRequest { CoinType = CoinType.Penny };
            var result = request.CastToCoin();

            Assert.IsInstanceOf<Penny>(result, "Should return penny.");
        }

        [Test]
        public void CastToCoin_CoinRequestContainsNickel_ReturnsNickel()
        {
            var request = new CoinRequest { CoinType = CoinType.Nickel };
            var result = request.CastToCoin();

            Assert.IsInstanceOf<Nickel>(result, "Should return nickel.");
        }

        [Test]
        public void CastToCoin_CoinRequestContainsDime_ReturnsDime()
        {
            var request = new CoinRequest { CoinType = CoinType.Dime };
            var result = request.CastToCoin();

            Assert.IsInstanceOf<Dime>(result, "Should return dime.");
        }

        [Test]
        public void CastToCoin_CoinRequestContainsQuarter_ReturnsQuarter()
        {
            var request = new CoinRequest { CoinType = CoinType.Quarter };
            var result = request.CastToCoin();

            Assert.IsInstanceOf<Quarter>(result, "Should return quarter.");
        }

        [Test]
        public void CastToCoin_CoinRequestContainsHalf_ReturnsHalf()
        {
            var request = new CoinRequest { CoinType = CoinType.Half };
            Coin result = request.CastToCoin();

            Assert.IsInstanceOf<Half>(result, "Should return half dollar.");
        }

        [Test]
        public void CastToCoin_CoinRequestContainsInvalidCoinType_ThrowsArgumentException()
        {
            var request = new CoinRequest { CoinType = (CoinType)6 };

            Assert.Throws<ArgumentException>(() =>
            {
                var result = request.CastToCoin();
            }, "Should throw ArgumentException when invalid coin type.");
        }

        [Test]
        [TestCase(CoinType.Penny)]
        [TestCase(CoinType.Nickel)]
        [TestCase(CoinType.Dime)]
        [TestCase(CoinType.Quarter)]
        [TestCase(CoinType.Half)]
        public void Validate_CoinTypeIsValid_DoesNotAddError(CoinType coinType)
        {
            var modelState = new ModelStateDictionary();
            var request = new CoinRequest
            {
                CoinType = coinType
            };

            request.Validate(modelState);

            var error = modelState.FirstOrDefault(e => e.Key == nameof(CoinType));
            Assert.IsNull(error.Value, "Should not add error message if valid coin type.");
        }

        [Test]
        public void Validate_CoinTypeIsInvalid_AddsError()
        {
            var modelState = new ModelStateDictionary();
            var request = new CoinRequest
            {
                CoinType = (CoinType)6
            };

            request.Validate(modelState);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(modelState.Count, 1);
                var error = modelState.FirstOrDefault(e => e.Key == nameof(CoinType));
                Assert.IsNotNull(error.Value, "Should add error message if invalid coin type.");
            });
        }
    }
}
