namespace LinearGradientExercise.Models
{
    public class SvgStop
    {
        public SvgStop(int offset, string stopColor)
        {
            Offset = offset;
            StopColor = stopColor;
        }

        public int Offset { get; private set; }
        public string StopColor { get; private set; }
    }
}