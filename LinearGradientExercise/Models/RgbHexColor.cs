using LinearGradientExercise.Utils;
namespace LinearGradientExercise.Models
{
    public class RgbHexColor
    {
        private readonly ColorTransparencyHelper colorTransparencyHelper;

        public RgbHexColor(string rgbHexColor)
        {
            colorTransparencyHelper = new ColorTransparencyHelper();

            string redHex = rgbHexColor.Substring(0, 2);
            string greenHex = rgbHexColor.Substring(2, 2);
            string blueHex = rgbHexColor.Substring(4);

            Red = HexDecimalConverter.ConvertHexToDecimal(redHex);
            Green = HexDecimalConverter.ConvertHexToDecimal(greenHex);
            Blue = HexDecimalConverter.ConvertHexToDecimal(blueHex);
        }

        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public string TransparencyToWhiteHexColor(double opacity)
        {
            const int whiteColor = 255;

            return ToTransparentHexColor(whiteColor, opacity);
        }

        public string TransparencyToBlackHexColor(double opacity)
        {
            const int blackColor = 0;

            return ToTransparentHexColor(blackColor, opacity);
        }

        private string ToTransparentHexColor(int backColor, double opacity)
        {
            var red = colorTransparencyHelper.CalculateTransparentColor(Red, backColor, opacity);
            var green = colorTransparencyHelper.CalculateTransparentColor(Green, backColor, opacity);
            var blue = colorTransparencyHelper.CalculateTransparentColor(Blue, backColor, opacity);

            var redHex = HexDecimalConverter.ConvertDecimalToHex(red);
            var greenHex = HexDecimalConverter.ConvertDecimalToHex(green);
            var blueHex = HexDecimalConverter.ConvertDecimalToHex(blue);

            return redHex + greenHex + blueHex;
        }
    }
}