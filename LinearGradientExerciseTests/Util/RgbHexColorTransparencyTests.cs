using LinearGradientExercise.Utils;
using NUnit.Framework;

namespace LinearGradientExerciseTests.Util
{
    [TestFixture]
    public class ColorTransparencyHelperTests
    {
        private readonly ColorTransparencyHelper colorTransparencyHelper;
        private const int WhiteColor = 255;
        private const int BlackColor = 0;

        private const int MedianColor = 255/2;

        public ColorTransparencyHelperTests()
        {
            colorTransparencyHelper = new ColorTransparencyHelper();
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_0_Opacity_0_5_ShouldIncreaseTheColor()
        {
            var lighterColor = colorTransparencyHelper.CalculateTransparentColor(0, WhiteColor, 0.5);
            
            Assert.That(lighterColor > 0);
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_0_Opacity_0_5_ShouldDecreaseTheColorWithHalf()
        {
            var darkerColor = colorTransparencyHelper.CalculateTransparentColor(0, WhiteColor, 0.5);

            Assert.That((int)darkerColor, Is.InRange(MedianColor - 1, MedianColor + 1));
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_255_Opacity_0_5_ShouldNotGoOverMaxColor_255()
        {
            var lighterColor = colorTransparencyHelper.CalculateTransparentColor(255, WhiteColor, 0.5);

            Assert.That(lighterColor <= 255);
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_255_Opacity_0_5_ShouldDecreaseTheColor()
        {
            var darkerColor = colorTransparencyHelper.CalculateTransparentColor(255, BlackColor, 0.5);

            Assert.That(darkerColor < 255);
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_255_Opacity_0_5_ShouldIncreaseTheColorWithHalf()
        {
            var lighterColor = colorTransparencyHelper.CalculateTransparentColor(255, BlackColor, 0.5);

            Assert.That((int)lighterColor, Is.InRange(MedianColor - 1, MedianColor + 1));
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_0_Opacity_0_5_ShouldNotGoUnderMinColor_0()
        {
            var lighterColor = colorTransparencyHelper.CalculateTransparentColor(0, BlackColor, 0.5);

            Assert.That(lighterColor >= 0);
        }
    }

}