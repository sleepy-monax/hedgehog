namespace Hedgehog
{
    public class Vertex
    {
        public Position3D Position { get; private set; }
        public Vector3D Normal { get; private set; }
        public Position2D Texture { get; private set; }

        public Vertex(Position3D position, Vector3D normal, Position2D texture)
        {
            Position = position;
            Normal = normal;
            Texture = texture;
        }
    }
}