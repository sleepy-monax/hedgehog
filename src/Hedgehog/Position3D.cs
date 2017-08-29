namespace Hedgehog
{
    public class Position3D
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Position3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }
    }
}
