using Hedgehog.Graphic.OpenGL;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Hedgehog.Graphic
{
    public class Mesh
    {
        public VertexArray VertexArray { get; private set; }
        public Vertex[] Vertex { get; set; }
        public int[] VertexIndex { get; set; }

        public Mesh(Vertex[] vertex, int[] vertexIndex)
        {
            Vertex = vertex;
            VertexIndex = vertexIndex;
            VertexArray = new VertexArray();
            ReloadVertexArray();
        }

        public void Destroy()
        {
            VertexArray.Destroy();
            Vertex = null;
            VertexIndex = null;
        }

        public void ReloadVertexArray() {
            VertexArray.StoreVertex(Vertex, VertexIndex);
        }

        public void Bind()
        {
            VertexArray.Bind();
        }

        public void UnBind()
        {
            VertexArray.Unbind();
              
        }

        public static Mesh CreateFromObjFile(string filePath)
        {

            Vertex[] vertex = null;

            List<Position3D> position = new List<Position3D>(); 
            List<Vector3D> normal     = new List<Vector3D>();
            List<Position2D> texture  = new List<Position2D>();
            List<int> vertexIndex     = new List<int>();

            foreach (string line in File.ReadLines(filePath))
            {
                // Split and cleanup.
                if (!(string.IsNullOrWhiteSpace(line) || line.StartsWith("#")))
                {

                    string[] lineData = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                    switch (lineData[0])
                    {
                        case "v": // Vertex Position.
                            position.Add(new Position3D(lineData[1].ToFloat(),
                                                        lineData[2].ToFloat(),
                                                        lineData[3].ToFloat()
                                                        ));
                            break;

                        case "vt": // vertex Texture coordinate.
                            texture.Add(new Position2D(lineData[1].ToFloat(),
                                                       lineData[2].ToFloat()
                                                       ));
                            break;

                        case "vn": // vertex normal vector.
                            normal.Add(new Vector3D(lineData[1].ToFloat(),
                                                    lineData[2].ToFloat(),
                                                    lineData[3].ToFloat()
                                                    ));
                            break;
                        case "f": // Face
                            for (int i = 0; i < 3; i++)
                            {
                                int[] indices = lineData[1 + i].Split('/').ToInts();
                                
                                if (vertex is null)
                                {
                                    vertex = new Vertex[position.Count];
                                }
                                else
                                {
                                    if (vertex[indices[0] - 1] == null)
                                    {
                                        vertex[indices[0] - 1] = new Vertex(position[indices[0] - 1],
                                                                            normal[indices[2] - 1],
                                                                            texture[indices[1] - 1]
                                                                            );
                                    }
                                }

                                vertexIndex.Add(indices[0] - 1);
                            }
                            break;
                        default:
                            break;
                    }

                }
            }

            return new Mesh(vertex, vertexIndex.ToArray());
        }
    }
}
