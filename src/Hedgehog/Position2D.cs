namespace Hedgehog
{
    public class Position2D
    {
        public float X { get; set; } = 0f;
        public float Y { get; set; } = 0f;

        public Position2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float[] ToArray()
        {
            return new float[] { X, Y };
        }
    }
}
