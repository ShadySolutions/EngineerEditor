using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;

namespace Engineer.Draw
{
    public class ShaderRenderer : Renderer
    {
        protected ShaderManager _Manager;
        protected ShaderManager Manager
        {
            get
            {
                return _Manager;
            }

            set
            {
                _Manager = value;
            }
        }
        public ShaderRenderer() : base()
        {
            
        }
        public byte[] ConvertToByteArray(float[] Array)
        {
            byte[] ByteArray = new byte[Array.Length * 4];
            Buffer.BlockCopy(Array, 0, ByteArray, 0, ByteArray.Length);
            return ByteArray;
        }
        public byte[] ConvertToByteArray(List<Vertex> Vertices, int Relevant)
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
        protected virtual void SetUpShader(string ID, string[] ShaderCodes)
        {
            _Manager.AddShader(ID);
            _Manager.ActivateShader(ID);
            _Manager.Active.Attributes.SetDefinition("V_Vertex", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_Normal", 3 * sizeof(float), "vec3");
            _Manager.Active.Attributes.SetDefinition("V_TextureUV", 2 * sizeof(float), "vec2");

            this._NumLights = 1;
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Color", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Position", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Attenuation", 12, "vec3");
            _Manager.Active.Uniforms.SetDefinition("Lights[0].Intensity", 4, "float");

            _Manager.Active.Uniforms.SetDefinition("CameraPosition", 12, "vec3");

            _Manager.CompileShader(ID, ShaderCodes[0], ShaderCodes[1], ShaderCodes[2], ShaderCodes[3], ShaderCodes[4]);
        }
        protected virtual void RefreshActiveShader(string Name, string OldValue, string NewValue)
        {
            string Replaced = OldValue + "/*" + Name + "*/";
            string ReplaceWith = NewValue + "/*" + Name + "*/";
            if (_Manager.Active.VertexShader_Code != null)
                _Manager.Active.VertexShader_Code = _Manager.Active.VertexShader_Code.Replace(Replaced, ReplaceWith);
            if (_Manager.Active.FragmentShader_Code != null)
                _Manager.Active.FragmentShader_Code = _Manager.Active.FragmentShader_Code.Replace(Replaced, ReplaceWith);
            if (_Manager.Active.GeometryShader_Code != null)
                _Manager.Active.GeometryShader_Code = _Manager.Active.GeometryShader_Code.Replace(Replaced, ReplaceWith);
            if (_Manager.Active.TessellationControl_Code != null)
                _Manager.Active.TessellationControl_Code = _Manager.Active.TessellationControl_Code.Replace(Replaced, ReplaceWith);
            if (_Manager.Active.TessellationEvaluation_Code != null)
                _Manager.Active.TessellationEvaluation_Code = _Manager.Active.TessellationEvaluation_Code.Replace(Replaced, ReplaceWith);
            _Manager.Active.ReCompile();
        }
        public override void SetSurface(float[] Color)
        {
            if (!_Manager.Active.Uniforms.Exists("Color")) _Manager.Active.Uniforms.SetDefinition("Color", 4 * sizeof(float), "vec4");
            _Manager.Active.Uniforms.SetData("Color", ConvertToByteArray(Color));
        }
        public override void SetMaterial(object MaterialData, bool Update)
        {
            string[] ShaderData = (string[])MaterialData;
            if (!_Manager.ShaderExists(ShaderData[0]) || Update) SetUpShader(ShaderData[0], new string[5] { ShaderData[1], ShaderData[2], ShaderData[3], ShaderData[4], ShaderData[5] });
            _Manager.ActivateShader(ShaderData[0]);
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
        public override void SetCameraPosition(Vertex CameraPosition)
        {
            _Manager.Active.Uniforms.SetData("CameraPosition", ConvertToByteArray(new float[3] { CameraPosition.X, CameraPosition.Y, CameraPosition .Z}));
        }
        public override void SetViewLight(Vertex[] LightParameters)
        {
            while(this._LightCounter >= this._NumLights)
            {
                RefreshActiveShader("NumLights", this._NumLights.ToString(), (this._NumLights + 1).ToString());
                _Manager.Active.Uniforms.SetDefinition("Lights[" + _LightCounter + "].Color", 12, "vec3");
                _Manager.Active.Uniforms.SetDefinition("Lights[" + _LightCounter + "].Position", 12, "vec3");
                _Manager.Active.Uniforms.SetDefinition("Lights[" + _LightCounter + "].Attenuation", 12, "vec3");
                _Manager.Active.Uniforms.SetDefinition("Lights[" + _LightCounter + "].Intensity", 4, "float");
                this._NumLights++;
            }
            _Manager.Active.Uniforms.SetData("Lights[" + _LightCounter + "].Color", ConvertToByteArray(new float[3] { LightParameters[0].X, LightParameters[0].Y, LightParameters[0].Z }));
            _Manager.Active.Uniforms.SetData("Lights[" + _LightCounter + "].Position", ConvertToByteArray(new float[3] { LightParameters[1].X, LightParameters[1].Y, LightParameters[1].Z }));
            _Manager.Active.Uniforms.SetData("Lights[" + _LightCounter + "].Attenuation", ConvertToByteArray(new float[3] { LightParameters[2].X, LightParameters[2].Y, LightParameters[2].Z }));
            _Manager.Active.Uniforms.SetData("Lights[" + _LightCounter + "].Intensity", BitConverter.GetBytes(LightParameters[3].X));
            this._LightCounter++;
        }
        public override void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces, bool Update)
        {
            if (Update || (!_Manager.Active.Attributes.BufferExists))
            {
                _Manager.Active.Attributes.SetData("V_Vertex", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Vertices, 3));
                _Manager.Active.Attributes.SetData("V_Normal", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Normals, 3));
                _Manager.Active.Attributes.SetData("V_TextureUV", Vertices.Count * 2 * sizeof(float), ConvertToByteArray(TexCoords, 2));
            }
            _Manager.SetDrawMode(GraphicDrawMode.Triangles);
            _Manager.Draw();
        }
        public virtual ShaderProgram CurrentShader()
        {
            return _Manager.Active;
        }
    }
}
