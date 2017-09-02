using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Hedgehog.Graphic
{
    public class RenderBatch
    {

        Dictionary<DiffuseMaterial, Dictionary<Mesh, Transform3D>> batch;

        public RenderBatch(Game game)
        {

        }

        public void Begin(Camera camera)
        {
        }

        public void Draw(Transform3D transform, Mesh mesh, DiffuseMaterial material)
        {
        }

        public void End()
        {
            GL.Enable(EnableCap.DepthTest);

        }

    }
}
