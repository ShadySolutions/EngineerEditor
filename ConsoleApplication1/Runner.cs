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
using Engineer.Draw.OpenGL.FixedGL;
using Engineer.Draw.OpenGL.GLSL;

namespace Engineer.Runner
{
    public class Runner : OpenTK.GameWindow
    {
        private OBJContainer OBJ;
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
            OBJ = new OBJContainer();
            OBJ.Load("storm.obj", null);
        }
        protected override void OnResize(EventArgs e)
        {
            _Engine.CurrentRenderer.TransformPerspective(this.ClientRectangle.Width, this.ClientRectangle.Height, 45);
            _Engine.CurrentRenderer.TransformView(new Vertex(0, 1, 1), new Vertex(0, 0, 0));
            GL.Scale(0.15, 0.15, 0.15);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Color3(System.Drawing.Color.Aqua);
            _Engine.CurrentRenderer.RenderGeometry(OBJ.Geometries[0].Vertices, OBJ.Geometries[0].Normals, OBJ.Geometries[0].TexCoords, OBJ.Geometries[0].Faces);
            SwapBuffers();
        }
    }
}
