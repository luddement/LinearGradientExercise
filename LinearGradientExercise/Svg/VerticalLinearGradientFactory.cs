using System.Collections.Generic;
using LinearGradientExercise.Models;

namespace LinearGradientExercise.Svg
{
    public class VerticalLinearGradientFactory
    {
        public IEnumerable<SvgStop> CreateSvgStops(RgbHexColor rgbHexColor)
        {
            yield return new SvgStop(0, rgbHexColor.TransparencyToWhiteHexColor(0.2));
            yield return new SvgStop(5, rgbHexColor.TransparencyToWhiteHexColor(0.4));
            yield return new SvgStop(45, rgbHexColor.TransparencyToWhiteHexColor(0.6));

            rgbHexColor = new RgbHexColor(rgbHexColor.TransparencyToWhiteHexColor(0.6));
            yield return new SvgStop(50, rgbHexColor.TransparencyToBlackHexColor(0.95));
            yield return new SvgStop(100, rgbHexColor.TransparencyToBlackHexColor(0.6));
        }
    }
}