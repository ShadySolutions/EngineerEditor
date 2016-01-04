using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Engineer.Mathematics;

namespace Engineer.Draw.OpenGL.GLSL
{
    public class GLSLShaderRenderer : ShaderRenderer
    {
        public GLSLShaderRenderer() : base()
        {
            _Manager = new GLSLShaderManager();
            _Manager.AddShader("Default");
            _Manager.ActivateShader("Default");
            _Manager.Active.Attributes.SetDefinition("V_Vertex", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_Normal", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_TextureUV", 2 * sizeof(float), "vec2");
            _Manager.CompileShader("Default", global::Engineer.Draw.OpenGL.Shaders.Default_Vertex, global::Engineer.Draw.OpenGL.Shaders.Default_Fragment, null, null, null);
        }
        public byte [] ConvertToByteArray(float[] Array)
        {
            byte [] ByteArray = new byte[Array.Length * 4];
            Buffer.BlockCopy(Array, 0, ByteArray, 0, ByteArray.Length);
            return ByteArray;
        }
        public byte [] ConvertToByteArray(List<Vertex> Vertices, int Relevant)
        {
            byte[] ByteArray;
            List<byte> ByteList = new List<byte>(Vertices.Count * Relevant * sizeof(float));
            for (int i = 0; i < Vertices.Count; i++)
            {
                ByteArray = BitConverter.GetBytes(Vertices[i].X);
                ByteList.AddRange(ByteArray);
                if (Relevant > 1)
                {
                    ByteArray = BitConverter.GetBytes(Vertices[i].Y);
                    ByteList.AddRange(ByteArray);
                }
                if (Relevant > 2)
                {
                    ByteArray = BitConverter.GetBytes(Vertices[i].Z);
                    ByteList.AddRange(ByteArray);
                }
            }
            return ByteList.ToArray();
        }
        public override void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
        public override void SetSurface(float[] Color)
        {
            if (!_Manager.Active.Uniforms.Exists("Color")) _Manager.Active.Uniforms.SetDefinition("Color", 4 * sizeof(float), "vec4");
            _Manager.Active.Uniforms.SetData("Color", ConvertToByteArray(Color));
        }
        public override void SetProjectionMatrix(float[] Matrix)
        {
            if (!_Manager.Active.Uniforms.Exists("Projection")) _Manager.Active.Uniforms.SetDefinition("Projection", 16 * sizeof(float), "mat4");
            _Manager.Active.Uniforms.SetData("Projection", ConvertToByteArray(Matrix));
        }
        public override void SetModelViewMatrix(float[] Matrix)
        {
            if (!_Manager.Active.Uniforms.Exists("ModelView")) _Manager.Active.Uniforms.SetDefinition("ModelView", 16 * sizeof(float), "mat4");
            _Manager.Active.Uniforms.SetData("ModelView", ConvertToByteArray(Matrix));
        }
        public override void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces)
        {
            _Manager.Active.Attributes.SetData("V_Vertex", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Vertices, 3));
            _Manager.Active.Attributes.SetData("V_Normal", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Normals, 3));
            _Manager.Active.Attributes.SetData("V_TextureUV", Vertices.Count * 2 * sizeof(float), ConvertToByteArray(TexCoords, 2));
            _Manager.SetDrawMode(GraphicDrawMode.Triangles);
            _Manager.Draw();
        }
    }
}
