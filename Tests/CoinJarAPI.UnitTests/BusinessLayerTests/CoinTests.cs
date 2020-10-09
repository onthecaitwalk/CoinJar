using CoinJarAPI.BusinessLayer;
using NUnit.Framework;

namespace CoinJarAPI.UnitTests
{
    [TestFixture]
    public class CoinTests
    {
        [Test]
        public void CalculateVolume_Penny_ReturnsVolumeInOunces()
        {
            var coin = new Penny();
            Assert.AreEqual(0.0146494145002743m, coin.Volume);
        }

        [Test]
        public void CalculateVolume_Nickel_ReturnsVolumeInOunces()
        {
            var coin = new Nickel();
            Assert.AreEqual(0.0232971431283759m, coin.Volume);
        }

        [Test]
        public void CalculateVolume_Dime_ReturnsVolumeInOunces()
        {
            var coin = new Dime();
            Assert.AreEqual(0.0115003659362315m, coin.Volume);
        }

        [Test]
        public void CalculateVolume_Quarter_ReturnsVolumeInOunces()
        {
            var coin = new Quarter();
            Assert.AreEqual(0.0273530879047509m, coin.Volume);
        }

        [Test]
        public void CalculateVolume_Half_ReturnsVolumeInOunces()
        {
            var coin = new Half();
            Assert.AreEqual(0.0534997605859751m, coin.Volume);
        }
    }
}
