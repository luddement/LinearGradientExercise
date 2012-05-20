using System;

namespace LinearGradientExercise.Utils
{
    public class ColorTransparencyHelper
    {
        public double CalculateTransparentColor(int color, int opacityColor, double opacity)
        {
            if (opacity < 0.0 || opacity > 1.0)
            {
                throw new ArgumentException("opacity should be between 0 and 1");
            }

            return Math.Round(color * opacity + opacityColor * (1 - opacity));
        }
    }
}