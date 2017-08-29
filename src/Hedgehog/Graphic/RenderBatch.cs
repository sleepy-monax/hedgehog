using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Hedgehog.Graphic
{
    public class RenderBatch
    {

        Dictionary<Material, Dictionary<Mesh, Transform3D>> batch;

        public RenderBatch(Game game)
        {

        }

        public void Begin(Camera camera)
        {
        }

        public void Draw(Transform3D transform, Mesh mesh, Material material)
        {
        }

        public void End()
        {
            GL.Enable(EnableCap.DepthTest);

        }

    }
}
