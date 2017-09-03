using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;

namespace Hedgehog
{

    public abstract class Game
    {
        GameWindow window;
        bool started = false;

        public abstract void Load();
        public abstract void Draw();
        public abstract void Update(float deltaTime);
        public abstract void Destroy();

        public Game()
        {
            window = new GameWindow(800, 600, GraphicsMode.Default, "Hedgehog Framework");

            window.UpdateFrame += delegate (object sender, FrameEventArgs e) { Update((float)e.Time); };
            window.RenderFrame += delegate (object sender, FrameEventArgs e) { Draw();                };
            window.Load        += delegate (object sender, EventArgs e)      { Load();                };
            window.Unload      += delegate (object sender, EventArgs e)      { Destroy();             };
        }

        public void Start(double frameRate)
        {
            if (!started)
            {
                started = true;
                window.Run(frameRate);
            }
            else
            {
                throw new Exception("Games already started.");
            }
        }

        public void Stop()
        {
            if (started)
            {
                window.Close();
            }
        }

        public void SwapBuffer()
        {
            window.SwapBuffers();
        }

        public void ClearWindow(Color3 clearColor)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(clearColor.ToSystemColor());
        }

        public float GetWindowAspectRatio()
        {
            return window.Height / (float)window.Width;
        }
    }
}
