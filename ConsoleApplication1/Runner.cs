#define FixedPipeline
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Engineer.Data;
using Engineer.Draw;
using Engineer.Draw.FixedGL;
using Engineer.Draw.GLSL;

namespace Engineer.Runner
{
    public class Runner : OpenTK.GameWindow
    {
        private OBJContainer OBJ;
        private DrawEngine _Engine;
        private void GLPerspective(double fovY, double aspect, double zNear, double zFar)
        {
            const double pi = 3.1415926535897932384626433832795;
            double fW, fH;
            fH = Math.Tan(fovY / 360 * pi) * zNear;
            fW = fH * aspect;
            GL.Frustum(-fW, fW, -fH, fH, zNear, zFar);
        }
        private void GLLookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz)
        {
            Vector3 forward, side, up;
            Matrix4 m;
            forward.X = (float)(centerx - eyex);
            forward.Y = (float)(centery - eyey);
            forward.Z = (float)(centerz - eyez);
            up.X = (float)upx;
            up.Y = (float)upy;
            up.Z = (float)upz;
            forward.Normalize();
            /* Side = forward x up */
            side = Vector3.Cross(forward, up);
            side.Normalize();
            /* Recompute up as: up = side x forward */
            up = Vector3.Cross(side, forward);
            m = Matrix4.Identity;
            m.M11 = side.X;
            m.M21 = side.Y;
            m.M31 = side.Z;
            m.M12 = up.X;
            m.M22 = up.Y;
            m.M32 = up.Z;
            m.M13 = -forward.X;
            m.M23 = -forward.Y;
            m.M33 = -forward.Z;
            GL.MultMatrix(ref m);
            GL.Translate(-eyex, -eyey, -eyez);
        }
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
            /*GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(this.ClientRectangle.Left, this.ClientRectangle.Right,
                this.ClientRectangle.Bottom, this.ClientRectangle.Top, -1.0, 1.0);
            GL.Viewport(this.ClientRectangle.Size);*/

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GLPerspective(45, this.ClientRectangle.Width * 1.0 / this.ClientRectangle.Height, 0.001, 100000000);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GLLookAt(0, 1, 1, 0, 0, 0, 0, 1, 0);
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
