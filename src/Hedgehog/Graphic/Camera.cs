namespace Hedgehog.Graphic
{
    public class Camera
    {
        public Position3D Position { get; set; }
        public Rotation3D Rotation { get; set; }
        public float FieldOfView { get; set; }
        public float ViewDistance { get; set; }

        public Camera(Position3D position, Rotation3D rotation, float fieldOfView, float viewDistance)
        {
            Position = position;
            Rotation = rotation;
            FieldOfView = fieldOfView;
            ViewDistance = viewDistance;
        }
    }
}
