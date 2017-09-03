using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;

namespace Hedgehog.Graphic.OpenGL
{
    public class VertexArray
    {
        public int VertexCount { get; private set; }
        public int Handle { get; private set; } = -1;
        public int IndexBufferHandle { get; private set; } = -1;

        private List<int> VertexBufferHandle;
        private List<int> AttributeBufferIndex;


        public VertexArray()
        {
            Handle = GL.GenVertexArray();
            VertexBufferHandle = new List<int>();
            AttributeBufferIndex = new List<int>();
        }

        public void SetIndexBuffer(int[] index)
        {
            GL.BindVertexArray(Handle);
            int IndexBufferHandle = GL.GenBuffer();
            VertexBufferHandle.Add(IndexBufferHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferHandle);

            GL.BufferData(BufferTarget.ElementArrayBuffer, index.Length * sizeof(int), index, BufferUsageHint.StaticCopy);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void StoreAttribute(int AttributeIndex, float[] data, int size = 3)
        {
            AttributeBufferIndex.Add(AttributeIndex);
            GL.BindVertexArray(Handle);
            int VBO = GL.GenBuffer();
            VertexBufferHandle.Add(VBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.DynamicDraw);
            GL.VertexAttribPointer(AttributeIndex, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        public void StoreVertex(Vertex[] vertex, int[] index)
        {
            float[] positionData = new float[vertex.Length * 3];
            float[] normalData = new float[vertex.Length * 3];
            float[] textureData = new float[vertex.Length * 2];

            int offset = 0;
            foreach (var v in vertex)
            {
                positionData.Insert(v.V.ToArray(), offset * 3);
                normalData.Insert(v.Vn.ToArray(), offset * 3);
                textureData.Insert(v.Uv.ToArray(), offset * 2);

                offset += 1;
            }

            StoreAttribute(0, positionData, 3);
            StoreAttribute(1, normalData, 3);
            StoreAttribute(2, textureData, 2);

            SetIndexBuffer(index);
            VertexCount = vertex.Length;
        }

        public void Bind()
        {
            GL.BindVertexArray(Handle);
            foreach (var a in AttributeBufferIndex)
            {
                GL.EnableVertexAttribArray(a);
            }
        }

        public void Unbind()
        {
            foreach (var a in AttributeBufferIndex)
            {
                GL.DisableVertexAttribArray(a);
            }
            GL.BindVertexArray(0);
        }

        public void Destroy()
        {
            foreach (var vbo in VertexBufferHandle)
            {
                GL.DeleteBuffer(vbo);
            }

            if (IndexBufferHandle != -1) GL.DeleteBuffer(IndexBufferHandle);
            GL.DeleteVertexArray(Handle);
        }

        public void Draw()
        {
            GL.DrawElements(BeginMode.Triangles, VertexCount, DrawElementsType.UnsignedInt, 0);
        }
    }
}
