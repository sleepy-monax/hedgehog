using Hedgehog.Graphic;
using Hedgehog.Graphic.OpenGL;
using Hedgehog.Json;
using System.IO;

namespace Hedgehog.Sample
{
    class SampleGame : Game
    {
        public ShaderProgram sampleProgram;
        public RenderBatch renderBatch;
        public Mesh bunnyMesh;

        public override void Load()
        {
            renderBatch = new RenderBatch(this);
            bunnyMesh = Mesh.CreateFromObjFile("./Assets/Bunny.obj");
            bunnyMesh.ReloadVertexArray();
            File.WriteAllText("test.json", bunnyMesh.Vertex.ToJson());
        }

        public override void Destroy()
        {
            bunnyMesh.Destroy();
        }

        public override void Draw()
        {
            ClearWindow(new Color3(0, 0, 0));
            bunnyMesh.VertexArray.Bind();

            bunnyMesh.VertexArray.Draw();

            bunnyMesh.VertexArray.Unbind();
            SwapBuffer();
        }

        public override void Update(float deltaTime)
        {

        }
    }
}