namespace Hedgehog
{
    public class Vertex
    {
        public Position3D V { get; private set; }
        public Vector3D Vn { get; private set; }
        public Position2D Uv { get; private set; }

        public Vertex(Position3D position, Vector3D normal, Position2D texture)
        {
            V = position;
            Vn = normal;
            Uv = texture;
        }
    }
}