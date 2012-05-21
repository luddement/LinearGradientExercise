using LinearGradientExercise.Utils;
using NUnit.Framework;

namespace LinearGradientExerciseTests.UnitTests.Utils
{
    [TestFixture]
    public class HexDecimalConverterTests
    {
        [Test]
        public void ConvertHexToDecimal_WhenHexIs_00_DecimalShouldBe_1()
        {
            string hex = "00";

            int dec = HexDecimalConverter.ConvertHexToDecimal(hex);

            Assert.That(dec == 0);
        }

        [Test]
        public void ConvertHexToDecimal_WhenHexIs_FF_DecimalShouldBe_255()
        {
            string hex = "FF";

            int dec = HexDecimalConverter.ConvertHexToDecimal(hex);

            Assert.That(dec == 255);
        }

        [Test]
        public void ConvertDecimalToHex_WhenDecIs_0_HexShouldBe_00()
        {
            int dec = 0;

            string hex = HexDecimalConverter.ConvertDecimalToHex(dec);

            Assert.That(hex == "00");
        }

        [Test]
        public void ConvertDecimalToHex_WhenDecIs_255_HexShouldBe_FF()
        {
            int dec = 255;

            string hex = HexDecimalConverter.ConvertDecimalToHex(dec);

            Assert.That(hex == "FF");
        }
    }
}