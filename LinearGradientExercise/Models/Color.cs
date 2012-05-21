using LinearGradientExercise.Utils;

namespace LinearGradientExercise.Models
{
    public class Color
    {
        private readonly ColorTransparencyResolver colorTransparencyResolver;
        
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Color(string hexColor)
        {
            colorTransparencyResolver = new ColorTransparencyResolver();

            string redHex = hexColor.Substring(0, 2);
            string greenHex = hexColor.Substring(2, 2);
            string blueHex = hexColor.Substring(4);

            Red = HexDecimalConverter.ConvertHexToDecimal(redHex);
            Green = HexDecimalConverter.ConvertHexToDecimal(greenHex);
            Blue = HexDecimalConverter.ConvertHexToDecimal(blueHex);
        }

        public string ToTransparencyAgainsWhite(double opacity)
        {
            const int whiteColor = 255;

            return ToTransparency(whiteColor, opacity);
        }

        public string ToTransparencyAgainsBlack(double opacity)
        {
            const int blackColor = 0;

            return ToTransparency(blackColor, opacity);
        }

        private string ToTransparency(int backColor, double opacity)
        {
            var red = colorTransparencyResolver.CalculateTransparentColor(Red, backColor, opacity);
            var green = colorTransparencyResolver.CalculateTransparentColor(Green, backColor, opacity);
            var blue = colorTransparencyResolver.CalculateTransparentColor(Blue, backColor, opacity);

            var redHex = HexDecimalConverter.ConvertDecimalToHex(red);
            var greenHex = HexDecimalConverter.ConvertDecimalToHex(green);
            var blueHex = HexDecimalConverter.ConvertDecimalToHex(blue);

            return redHex + greenHex + blueHex;
        }
    }
}