using LinearGradientExercise.Utils;
using NUnit.Framework;
using System;

namespace LinearGradientExerciseTests.UnitTests.Utils
{
    [TestFixture]
    public class ColorTransparencyResolverTests
    {
        private readonly ColorTransparencyResolver colorTransparencyResolver;
        private const int WhiteColor = 255;
        private const int BlackColor = 0;

        private const int MedianColor = 255/2;

        public ColorTransparencyResolverTests()
        {
            colorTransparencyResolver = new ColorTransparencyResolver();
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_0_Opacity_0_5_ShouldIncreaseTheColor()
        {
            var lighterColor = colorTransparencyResolver.CalculateTransparentColor(0, WhiteColor, 0.5);
            
            Assert.That(lighterColor > 0);
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_0_Opacity_0_5_ShouldDecreaseTheColorWithHalf()
        {
            var darkerColor = colorTransparencyResolver.CalculateTransparentColor(0, WhiteColor, 0.5);

            Assert.That((int)darkerColor, Is.InRange(MedianColor - 1, MedianColor + 1));
        }

        [Test]
        public void CalculateTransparentColor_WithWhiteOpacityColor_Color_255_Opacity_0_5_ShouldNotGoOverMaxColor_255()
        {
            var lighterColor = colorTransparencyResolver.CalculateTransparentColor(255, WhiteColor, 0.5);

            Assert.That(lighterColor <= 255);
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_255_Opacity_0_5_ShouldDecreaseTheColor()
        {
            var darkerColor = colorTransparencyResolver.CalculateTransparentColor(255, BlackColor, 0.5);

            Assert.That(darkerColor < 255);
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_255_Opacity_0_5_ShouldIncreaseTheColorWithHalf()
        {
            var lighterColor = colorTransparencyResolver.CalculateTransparentColor(255, BlackColor, 0.5);

            Assert.That((int)lighterColor, Is.InRange(MedianColor - 1, MedianColor + 1));
        }

        [Test]
        public void CalculateTransparentColor_WithBlackOpacityColor_Color_0_Opacity_0_5_ShouldNotGoUnderMinColor_0()
        {
            var lighterColor = colorTransparencyResolver.CalculateTransparentColor(0, BlackColor, 0.5);

            Assert.That(lighterColor >= 0);
        }

        [Test]
        public void CalculateTransparentColor_WithOpacityLessThan_0_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => colorTransparencyResolver.CalculateTransparentColor(0, WhiteColor, -0.1));
        }

        [Test]
        public void CalculateTransparentColor_WithOpacityHigherThan_1_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => colorTransparencyResolver.CalculateTransparentColor(0, WhiteColor, 1.1));
        }
    }

}