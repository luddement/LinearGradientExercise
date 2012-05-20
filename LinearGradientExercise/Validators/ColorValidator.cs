using System.Text.RegularExpressions;

namespace LinearGradientExercise.Validators
{
    public class ColorValidator
    {
        public bool IsHexadecimalRgbColor(string color)
        {
            return new Regex(@"^[A-Fa-f0-9]*$").IsMatch(color)
                && color.Length == 6;
        }
    }
}