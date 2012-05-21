using NUnit.Framework;
using LinearGradientExercise.Validators;

namespace LinearGradientExerciseTests.ValidatiorTests
{
    [TestFixture]
    public class ColorValidatorTests
    {
        [Test]
        [TestCase("000000")]
        [TestCase("FF0000")]
        [TestCase("FFFF00")]
        [TestCase("ffffff")]
        [TestCase("DDDDDD")]
        [TestCase("AABBCC")]
        [TestCase("aabbcc")]
        public void ValidateHexadecimalRgbColor_WhenValidHexColor_ReturnsTrue(string validHexColor)
        {
            var colorValidator = new ColorValidator();

            bool isColor = colorValidator.IsHexadecimalRgbColor(validHexColor);

            Assert.True(isColor);
        }

        [Test]
        [TestCase("")]
        [TestCase("xx")]
        [TestCase("FFFF0")]
        [TestCase("FFFFFG")]
        [TestCase("ffff08jpfffff")]
        [TestCase("fds")]
        public void ValidateHexadecimalRgbColor_WhenInvalidHexColor_ReturnsFalse(string invalidHexColor)
        {
            var colorValidator = new ColorValidator();

            bool isColor = colorValidator.IsHexadecimalRgbColor(invalidHexColor);

            Assert.False(isColor);
        }
    }
}
