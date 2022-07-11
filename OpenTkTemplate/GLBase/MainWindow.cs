using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTkTemplate.GLBase
{
    public class MainWindow : GameWindow
    {
        readonly GameContext gc = new GameContext();

        public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            gc.camera = new Camera(Vector3.UnitZ * 8, Size.X / (float)Size.Y);

            gc.renderer.textureManager.AddSpriteSheetTexture("Resources/sprites.png", "floor", new int[] { 23, 75, 16, 16 });
            gc.renderer.textureManager.AddSpriteSheetTexture("Resources/sprites.png", "wall", new int[] { 45, 75, 16, 16 });
            gc.renderer.textureManager.AddSpriteSheetTexture("Resources/sprites.png", "stairs", new int[] { 66, 75, 16, 16 });
            gc.renderer.Load();
            gc.logic.Load();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            gc.renderer.StartFrame();
            gc.renderer.Render();

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            gc.frametime = (float)e.Time;
            gc.logic.Logic(KeyboardState);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
            gc.camera.AspectRatio = Size.X / (float)Size.Y;
        }
    }
}

