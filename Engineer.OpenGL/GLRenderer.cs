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
        public override void SetProjectionMatrix(float[] Matrix)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(Matrix);
        }
        public override void SetModelViewMatrix(float[] Matrix)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(Matrix);
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
