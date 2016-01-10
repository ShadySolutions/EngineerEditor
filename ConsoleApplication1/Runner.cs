#define FixedPipeline
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Engineer.Mathematics;
using Engineer.Data;
using Engineer.Draw;
using Engineer.Draw.OpenGL;
using Engineer.Draw.OpenGL.FixedGL;
using Engineer.Draw.OpenGL.GLSL;
using Engineer.Engine;

namespace Engineer.Runner
{
    public class Runner : OpenTK.GameWindow
    {
        private Scene _Scene;
        private DrawEngine _Engine;
        public Runner(int width, int height, GraphicsMode mode, string title) : base(width, height, mode, title)
        {
            _Engine = new DrawEngine();
            #if FixedPipeline
            GLRenderer Render = new GLRenderer();
            #else
            GLSLShaderRenderer Render = new GLSLShaderRenderer();
            #endif
            Render.RenderDestination = this;
            _Engine.CurrentRenderer = Render;
            SetUpScene();
        }
        private void SetUpScene()
        {
            OBJContainer OBJ = new OBJContainer();
            OBJ.Load("storm.obj", null);
            OBJ.Repack();
            Actor NewActor = new Actor(OBJ);
            NewActor.Scale = new Vertex(0.15f, 0.15f, 0.15f);
            Camera NewCamera = new Camera();
            NewCamera.Translation = new Vertex(0, 1, 1);
            NewCamera.Rotation = new Vertex(45, 0, 0);
            _Scene = new Scene();
            _Scene.Actors.Add(NewActor);
            _Scene.Cameras.Add(NewCamera);
            _Scene.ActiveCamera = 0;
        }
        protected override void OnResize(EventArgs e)
        {
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _Engine.DrawScene(_Scene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            SwapBuffers();
        }
    }
}
