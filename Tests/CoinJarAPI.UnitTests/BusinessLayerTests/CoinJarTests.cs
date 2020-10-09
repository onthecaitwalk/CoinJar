using System;
using AutoFixture;
using CoinJarAPI.BusinessLayer;
using Moq;
using NUnit.Framework;

namespace CoinJarAPI.UnitTests
{
    [TestFixture]
    public class CoinJarTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void AddCoin_CoinVolumePlusTotalVolumeIsGreaterThanJarMaxVolume_ThrowsInvalidException()
        {
            var cache = new CoinJarCache
            {
                TotalVolume = 41m
            };
            var jar = new CoinJar(cache);

            var mockCoin = new Mock<ICoin>();
            mockCoin.SetupGet(c => c.Volume).Returns(2m);

            Assert.Throws<InvalidOperationException>(() =>
            {
                jar.AddCoin(mockCoin.Object);
            });
        }

        [Test]
        public void AddCoin_CoinVolumePlusTotalVolumeIsLessThanJarMaxVolume_AddsCoinVolueToTotalVolume()
        {
            var cache = new CoinJarCache
            {
                TotalVolume = 31m
            };
            var jar = new CoinJar(cache);

            var mockCoin = new Mock<ICoin>();
            mockCoin.SetupGet(c => c.Volume).Returns(2m);

            jar.AddCoin(mockCoin.Object);

            Assert.AreEqual(33, cache.TotalVolume);
        }

        [Test]
        public void AddCoin_CoinVolumePlusTotalVolumeEqualsJarMaxVolume_AddsCoinVolueToTotalVolume()
        {
            var cache = new CoinJarCache
            {
                TotalVolume = 40m
            };
            var jar = new CoinJar(cache);

            var mockCoin = new Mock<ICoin>();
            mockCoin.SetupGet(c => c.Volume).Returns(2m);

            jar.AddCoin(mockCoin.Object);

            Assert.AreEqual(42, cache.TotalVolume);
        }

        [Test]
        public void AddCoin_AddsCoinAmountToTotalAmount()
        {
            var cache = new CoinJarCache
            {
                TotalAmount = 40m
            };
            var jar = new CoinJar(cache);

            var mockCoin = new Mock<ICoin>();
            mockCoin.SetupGet(c => c.Amount).Returns(2m);

            jar.AddCoin(mockCoin.Object);

            Assert.AreEqual(42, cache.TotalAmount);
        }

        [Test]
        public void GetTotalAmount_ReturnsTotalAmount()
        {
            var cache = new CoinJarCache
            {
                TotalAmount = 40m
            };
            var jar = new CoinJar(cache);

            var result = jar.GetTotalAmount();

            Assert.AreEqual(40, result);
        }

        [Test]
        public void Reset_SetsTotalAmountAndVolumeToZero()
        {
            var cache = new CoinJarCache
            {
                TotalAmount = _fixture.Create<decimal>(),
                TotalVolume = _fixture.Create<decimal>()
            };
            var jar = new CoinJar(cache);

            jar.Reset();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, cache.TotalAmount);
                Assert.AreEqual(0, cache.TotalVolume);
            });
        }
    }
}
