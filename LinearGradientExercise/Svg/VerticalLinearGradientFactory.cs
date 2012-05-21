using System.Collections.Generic;
using LinearGradientExercise.Models;

namespace LinearGradientExercise.Svg
{
    public class VerticalLinearGradientFactory
    {
        public IEnumerable<SvgStop> CreateSvgStops(Color color)
        {
            string hexColor = color.ToTransparencyAgainsWhite(0.2);
            yield return new SvgStop(0, hexColor);

            hexColor = color.ToTransparencyAgainsWhite(0.4);
            yield return new SvgStop(5, hexColor);

            hexColor = color.ToTransparencyAgainsWhite(0.6);
            yield return new SvgStop(45, hexColor);


            //Reset the color to the last color with white opacity
            //for a smoother transitiion
            color = new Color(hexColor);

            hexColor = color.ToTransparencyAgainsBlack(0.95);
            yield return new SvgStop(50, hexColor);

            hexColor = color.ToTransparencyAgainsBlack(0.6);
            yield return new SvgStop(100, hexColor);
        }
    }
}