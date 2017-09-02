using Hedgehog.Graphic.OpenGL;

namespace Hedgehog.Graphic
{
    public class DiffuseMaterial : IMaterial
    {
        ShaderProgram shaderProgram;

        public DiffuseMaterial(ShaderProgram shaderProgram)
        {

        }

        public static DiffuseMaterial LoadFromFile(string filePath)
        {
            return null;
        }

        public void Use()
        {

        }

        public void Stop()
        {

        }
    }
}
