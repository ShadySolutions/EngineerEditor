using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Engineer.Draw.OpenGL.FixedGL
{
    public class GLRenderer : Renderer
    {
        private void GLPerspective(double FieldOfView, double Aspect, double ZNear, double ZFar)
        {
            double Top = Math.Tan(FieldOfView / 360 * Math.PI) * ZNear;
            double Bottom = -Top;
            double Right = Top * Aspect;
            double Left = -Right;
            GL.Frustum(Left, Right, Bottom, Top, ZNear, ZFar);
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
            side = Vector3.Cross(forward, up);
            side.Normalize();
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
        public override void Transform2D(int Width, int Height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Width, Height, 0, -1.0, 1.0);
            GL.Viewport(0, 0, Width, Height);
        }
        public override void TransformOrtho(int Left, int Right, int Bottom, int Top)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(Left, Right, Bottom, Top, -1.0, 1.0);
            GL.Viewport(0, 0, Right - Left, Bottom - Top);
        }
        public override void TransformPerspective(int Width, int Height, int Angle)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GLPerspective(Angle, Width * 1.0 / Height, 0.001, 100000000);
        }
        public override void TransformView(Vertex Eye, Vertex Sight)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GLLookAt(0, 1, 1, 0, 0, 0, 0, 1, 0);
        }
        public override void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces)
        {
            if (Faces[0].Vertices.Count > 3) GL.Begin(PrimitiveType.Quads);
            else GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < Faces.Count; i++)
            {
                for (int j = 0; j < Faces[i].Vertices.Count; j++)
                {
                    GL.Vertex3(Vertices[Faces[i].Vertices[j]].X, Vertices[Faces[i].Vertices[j]].Y, Vertices[Faces[i].Vertices[j]].Z);
                    //GL.Normal3(Vertices[Faces[i].Normals[j]].X, Vertices[Faces[i].Normals[j]].Y, Vertices[Faces[i].Normals[j]].Z);
                    //GL.TexCoord3(Vertices[Faces[i].TexCoords[j]].X, Vertices[Faces[i].TexCoords[j]].Y, Vertices[Faces[i].TexCoords[j]].Z);
                }
            }
            GL.End();
        }
    }
}
