using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Engineer.Mathematics;

namespace Engineer.Draw.GLSL
{
    public class GLSLShaderRenderer : ShaderRenderer
    {
        public GLSLShaderRenderer() : base()
        {
            _Manager = new GLSLShaderManager();
            _Manager.AddShader("Default");
            _Manager.CompileShader("Default", global::Engineer.Draw.GLSL.Shaders.Default_Vertex, global::Engineer.Draw.GLSL.Shaders.Default_Fragment, null, null, null);
            _Manager.ActivateShader("Default");
        }
        public override void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces)
        {
            
        }
    }
}
