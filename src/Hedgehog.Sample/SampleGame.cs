using Hedgehog.Graphic;
using Hedgehog.Graphic.OpenGL;

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
            bunnyMesh = Mesh.LoadFromObjFile("./Assets/Bunny.obj");
            bunnyMesh.Load();
        }

        public override void Destroy()
        {

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