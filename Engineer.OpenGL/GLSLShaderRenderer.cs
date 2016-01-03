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
            _Manager.CompileShader("Default", global::Engineer.Draw.OpenGL.Shaders.Default_Vertex, global::Engineer.Draw.OpenGL.Shaders.Default_Fragment, null, null, null);
            _Manager.ActivateShader("Default");
        }
        public override void SetProjectionMatrix(float[] Matrix)
        {
        }
        public override void SetModelViewMatrix(float[] Matrix)
        {
        }
    }
}
