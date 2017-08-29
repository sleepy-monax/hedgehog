using OpenTK.Graphics.OpenGL4;
using System;

namespace Hedgehog.Graphic.OpenGL
{
    public enum ShaderType
    {
        FragmentShader = 35632,
        VertexShader = 35633,
        GeometryShader = 36313,
        TessEvaluationShader = 36487,
        TessControlShader = 36488,
        ComputeShader = 37305
    }

    public class Shader
    {
        public int Handle { get; private set; } = -1;
        public string Code { get; private set; }
        public ShaderType Type { get; private set; }

        public Shader(string code, ShaderType type)
        {
            Code = code;
            Type = type;

            if (string.IsNullOrEmpty(code))
            {
                throw new Exception("Shader code is null or Empty.");
            }
            else
            {
                Handle = GL.CreateShader((OpenTK.Graphics.OpenGL4.ShaderType)type);
                GL.ShaderSource(Handle, code);
                GL.CompileShader(Handle);
            }
        }

        public string GetInfoLog()
        {
            return GL.GetShaderInfoLog(Handle);
        }

        public void Destroy()
        {
            GL.DeleteShader(Handle);
        }
    }
}
