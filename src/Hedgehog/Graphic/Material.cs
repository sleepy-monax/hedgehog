using Hedgehog.Graphic.OpenGL;

namespace Hedgehog.Graphic
{
    public class Material
    {
        public ShaderProgram ShaderProgram { get; private set; }

        public Material(ShaderProgram shaderProgram)
        {

        }

        public static Material LoadFromFile(string filePath)
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
