using System;

namespace LinearGradientExercise.Utils
{
    public static class HexDecimalConverter
    {
        public static int ConvertHexToDecimal(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        public static string ConvertDecimalToHex(double dec)
        {
            return ((int)dec).ToString("X2");
        }
    }
}