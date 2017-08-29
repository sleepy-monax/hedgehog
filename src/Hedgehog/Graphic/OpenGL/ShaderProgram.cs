using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Hedgehog.Graphic.OpenGL
{
    public class ShaderProgram
    {
        public int Handle { get; private set; } = -1;
        private Dictionary<string, int> UniformVariableHandleCache = new Dictionary<string, int>();

        public ShaderProgram(Shader[] shader)
        {
            Handle = GL.CreateProgram();

            foreach (var s in shader)
            {
                GL.AttachShader(Handle, s.Handle);
            }

            GL.LinkProgram(Handle);
            GL.ValidateProgram(Handle);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public void Stop()
        {
            GL.UseProgram(0);
        }

        public void Destroy()
        {
            GL.DeleteProgram(Handle);
        }

        // Uniform ------------------------------------------------------------
        private int GetUniformVariable(string name)
        {
            if (!UniformVariableHandleCache.ContainsKey(name))
            {
                UniformVariableHandleCache[name] = GL.GetUniformLocation(Handle, name);
            }

            return UniformVariableHandleCache[name];
        }

        #region UNIFORM1
        public void SetUniform(string Name, int value) 
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform1(uniformHandle, value);
        }

        public void SetUniform(string Name, float value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform1(uniformHandle, value);
        }

        public void SetUniform(string Name, double value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform1(uniformHandle, value);
        }
        #endregion

        #region UNIFORM2
        public void SetUniform(string Name, Position2D value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform2(uniformHandle, value.X, value.Y);
        }
        #endregion

        #region UNIFORM3
        public void SetUniform(string Name, Color3 value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform3(uniformHandle, value.Red / 255f, value.Green / 255f, value.Blue / 255f);
        }

        public void SetUniform(string Name, Position3D value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform3(uniformHandle, value.X, value.Y , value.Z);
        }
        #endregion

        #region UNIFORM4
        public void SetUniform(string Name, Color4 value)
        {
            int uniformHandle = GetUniformVariable(Name);
            GL.Uniform4(uniformHandle, value.Red / 255f, value.Green / 255f, value.Blue / 255f, value.Alpha / 255f);
        }
        #endregion
    }
}
