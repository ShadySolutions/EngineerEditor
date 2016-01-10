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
        /// Temp
        private void DefaultShader()
        {
            _Manager = new GLSLShaderManager();
            _Manager.AddShader("Default");
            _Manager.ActivateShader("Default");
            _Manager.Active.Attributes.SetDefinition("V_Vertex", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_Normal", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_TextureUV", 2 * sizeof(float), "vec2");
            _Manager.CompileShader("Default", global::Engineer.Draw.OpenGL.Shaders.Default_Vertex, global::Engineer.Draw.OpenGL.Shaders.Default_Fragment, null, null, null);
        }
        private void ExampleShader()
        {
            _Manager = new GLSLShaderManager();
            _Manager.AddShader("Example");
            _Manager.ActivateShader("Example");
            _Manager.Active.Attributes.SetDefinition("V_Vertex", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_Normal", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_TextureUV", 2 * sizeof(float), "vec2");

            _Manager.Active.Uniforms.SetDefinition("Lights[0].Enabled", 4, "bool");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Position", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Ambient", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Diffuse", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Attenuation", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("CurrentMaterial.Shininess", 4, "float");
            _Manager.Active.Uniforms.SetDefinition("CurrentMaterial.Specular", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("CurrentMaterial.Ambient", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("EnabledLighting", 4, "bool");
            _Manager.Active.Uniforms.SetDefinition("CameraPosition", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Color", 16, "vec4");

            _Manager.CompileShader("Example", global::Engineer.Draw.OpenGL.Shaders.Example_Vertex, global::Engineer.Draw.OpenGL.Shaders.Example_Fragment, null, null, null);
        }
        /// Temp

        public GLSLShaderRenderer() : base()
        {
            _Manager = new GLSLShaderManager();
            GL.Enable(EnableCap.DepthTest);
            //DefaultShader();
            ExampleShader();
        }
        public override void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
        public override void ClearColor(float[] Color)
        {
            GL.ClearColor(Color[0], Color[1], Color[2], Color[3]);
        }
    }
}
