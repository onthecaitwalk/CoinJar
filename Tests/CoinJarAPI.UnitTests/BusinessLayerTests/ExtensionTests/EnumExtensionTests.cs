using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoinJarAPI.BusinessLayer.Extensions;
using NUnit.Framework;

namespace CoinJarAPI.UnitTests.BusinessLayerTests.ExtensionTests
{
    [TestFixture]
    public class EnumExtensionTests
    {
        private enum TestValues
        {
            NoAttributes = 0,

            [Required]
            RequiredAttribute = 1,

            [Required]
            [StringLength(2)]
            StringLengthAttribute = 2,

            [System.ComponentModel.Description("description")]
            DescriptionAttribute = 3
        }

        [Test]
        public void GetDescription_WhenDescriptionPresent_ReturnsDescription()
        {
            var description = TestValues.DescriptionAttribute.GetDescription();
            Assert.AreEqual("description", description, "The description attribute value did not match.");
        }

        [Test]
        public void GetEnumList_WhenEnumIsNotFlags_ReturnsList()
        {
            var result = EnumExtensions.GetEnumList<TestValues>();
            Assert.AreEqual(4, result.Count(), "Expected full TestValues list to be returned.");
        }
    }
}
