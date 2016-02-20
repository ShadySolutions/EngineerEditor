﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;
using System.Drawing;
using System.IO;

namespace Engineer.Draw
{

    public class ShaderRenderer : Renderer
    {
        private string _PushedID;
        private int _GridSize;
        private byte[] _GridVertices;
        private byte[] _SpriteVertices;
        private byte[] _SpriteUV;
        protected ShaderUniformPackage _Globals;
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
            this._PushedID = "";
            this._Globals = new ShaderUniformPackage();
            this._GridSize = -1;
            _Globals.SetDefinition("CameraPosition", 3 * sizeof(float), "vec3");
            _Globals.SetDefinition("Projection", 16 * sizeof(float), "mat4");
            _Globals.SetDefinition("ModelView", 16 * sizeof(float), "mat4");
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
            if (ShaderCodes[1].Contains("F_Normal"))
            {
                _Manager.Active.Attributes.SetDefinition("V_Normal", 3 * sizeof(float), "vec3");
            }
            if (ShaderCodes[1].Contains("F_TextureUV"))
            {
                _Manager.Active.Attributes.SetDefinition("V_TextureUV", 2 * sizeof(float), "vec2");
            }

            this._NumLights = 0;

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
            if (!_Globals.Exists("Color")) _Globals.SetDefinition("Color", 4 * sizeof(float), "vec4");
            _Globals.SetData("Color", ConvertToByteArray(Color));
        }
        public override bool IsMaterialReady(string ID)
        {
            return this._Manager.ShaderExists(ID);
        }
        public override void SetMaterial(object[] MaterialData, bool Update)
        {
            string[] ShaderData = (string[])MaterialData[0];
            if (!_Manager.ShaderExists(ShaderData[0]) || Update) SetUpShader(ShaderData[0], new string[5] { ShaderData[1], ShaderData[2], ShaderData[3], ShaderData[4], ShaderData[5] });
            _Manager.ActivateShader(ShaderData[0]);
            if(MaterialData[2] != null)
            {
                int TextureNumber = (int)MaterialData[1];
                byte[] Textures = (byte[])MaterialData[2];
                _Manager.Active.Textures.SetData(TextureNumber, Textures);
            }
        }
        public override void UpdateMaterial()
        {
            for(int i = _NumLights; _Manager.Active.Uniforms.Exists("Lights[" + i + "].Color"); i++)
            {
                _Manager.Active.Uniforms.Delete("Lights[" + i + "].Color");
                _Manager.Active.Uniforms.Delete("Lights[" + i + "].Position");
                _Manager.Active.Uniforms.Delete("Lights[" + i + "].Attenuation");
                _Manager.Active.Uniforms.Delete("Lights[" + i + "].Intensity");
            }
            _Manager.Active.Uniforms.Update(_Globals);
        }
        public override void SetProjectionMatrix(float[] Matrix)
        { 
            _Globals.SetData("Projection", ConvertToByteArray(Matrix));
        }
        public override void SetModelViewMatrix(float[] Matrix)
        {
            _Globals.SetData("ModelView", ConvertToByteArray(Matrix));
        }
        public override void SetCameraPosition(Vertex CameraPosition)
        {
            _Globals.SetData("CameraPosition", ConvertToByteArray(new float[3] { CameraPosition.X, CameraPosition.Y, CameraPosition .Z}));
        }
        public override bool SetViewLight(int Index, Vertex[] LightParameters)
        {
            bool Update = false;
            while(Index >= this._NumLights)
            {
                _Globals.SetDefinition("Lights[" + Index + "].Color", 12, "vec3");
                _Globals.SetDefinition("Lights[" + Index + "].Position", 12, "vec3");
                _Globals.SetDefinition("Lights[" + Index + "].Attenuation", 12, "vec3");
                _Globals.SetDefinition("Lights[" + Index + "].Intensity", 4, "float");
                RefreshActiveShader("NumLights", this._NumLights.ToString(), (this._NumLights + 1).ToString());
                this._NumLights++;
                Update = true;
            }
            _Globals.SetData("Lights[" + Index + "].Color", ConvertToByteArray(new float[3] { LightParameters[0].X, LightParameters[0].Y, LightParameters[0].Z }));
            _Globals.SetData("Lights[" + Index + "].Position", ConvertToByteArray(new float[3] { LightParameters[1].X, LightParameters[1].Y, LightParameters[1].Z }));
            _Globals.SetData("Lights[" + Index + "].Attenuation", ConvertToByteArray(new float[3] { LightParameters[2].X, LightParameters[2].Y, LightParameters[2].Z }));
            _Globals.SetData("Lights[" + Index + "].Intensity", BitConverter.GetBytes(LightParameters[3].X));
            return Update;
        }
        private byte[] PackTextures(List<Bitmap> TextureBitmaps)
        {
            List<byte> Textures = new List<byte>();
            for (int i = 0; i < TextureBitmaps.Count; i++)
            {
                TextureBitmaps[i] = new Bitmap(TextureBitmaps[i], new Size(256, 256));
                Textures.AddRange(ShaderMaterialTranslator.ImageToByte(TextureBitmaps[i]));
            }
            return Textures.ToArray();
        }
        public override void Render2DGrid()
        {
            if (!this.IsMaterialReady("Grid2D"))
            {
                string Vertex2D = File.ReadAllText("GLSL\\Generator\\Vertex2DGrid.shader");
                string Fragment2D = File.ReadAllText("GLSL\\Generator\\Fragment2DGrid.shader");
                this.SetMaterial(new object[3] { new string[6] { "Grid2D", Vertex2D, Fragment2D, null, null, null }, null, null }, true);
            }
            else this.SetMaterial(new object[3] { new string[6] { "Grid2D", null, null, null, null, null }, null, null }, false);

            int GridWidth= 100;
            if (_GridSize == -1)
            {
                List<Vertex> Vertices = new List<Vertex>();
                for (int i = -10; i <= 10; i++)
                {
                    for (int j = -10; j <= 10; j++)
                    {
                        Vertices.Add(new Vertex(GridWidth * +i, GridWidth * j, 0));
                        Vertices.Add(new Vertex(GridWidth * -i, GridWidth * j, 0));
                        Vertices.Add(new Vertex(GridWidth * i, GridWidth * +j, 0));
                        Vertices.Add(new Vertex(GridWidth * i, GridWidth * -j, 0));
                    }
                }
                Vertices.Add(new Vertex(-50, -50, 0));
                Vertices.Add(new Vertex(50, -50, 0));
                Vertices.Add(new Vertex(50, -50, 0));
                Vertices.Add(new Vertex(50, 50, 0));
                Vertices.Add(new Vertex(50, 50, 0));
                Vertices.Add(new Vertex(-50, 50, 0));
                Vertices.Add(new Vertex(-50, 50, 0));
                Vertices.Add(new Vertex(-50, -50, 0));

                _GridSize = Vertices.Count;
                _GridVertices = ConvertToByteArray(Vertices, 3);
            }

            SetSurface(new float[4] {0.3f,0.3f,0.3f,1});

            _Manager.Active.Attributes.SetData("V_Vertex", _GridSize * 3 * sizeof(float), _GridVertices);

            _Manager.Active.Uniforms.SetData("Index", BitConverter.GetBytes(-1));

            _Manager.SetDrawMode(GraphicDrawMode.Lines);
            _Manager.Draw();
        }
        public override void RenderSprite(string ID, List<Bitmap> Textures, int CurrentIndex, bool Update)
        {
            if (!this.IsMaterialReady(ID) || Update)
            {
                this._Manager.ActivateShader("2D");
                this.SetMaterial(new object[3] { new string[6] { ID, this._Manager.Active.VertexShader_Code, this._Manager.Active.FragmentShader_Code, null, null, null }, Textures.Count, PackTextures(Textures) }, true);
            }
            else this.SetMaterial(new object[3] { new string[6] { ID, null, null, null, null, null }, null, null }, false);

            if (_SpriteVertices == null)
            {
                List<Vertex> Vertices = new List<Vertex>();
                Vertices.Add(new Vertex(0, 0, 0));
                Vertices.Add(new Vertex(100, 0, 0));
                Vertices.Add(new Vertex(0, 100, 0));
                Vertices.Add(new Vertex(0, 100, 0));
                Vertices.Add(new Vertex(100, 0, 0));
                Vertices.Add(new Vertex(100, 100, 0));
                _SpriteVertices = ConvertToByteArray(Vertices, 3);

                List<Vertex> UV = new List<Vertex>();
                UV.Add(new Vertex(0, 0, 0));
                UV.Add(new Vertex(1, 0, 0));
                UV.Add(new Vertex(0, 1, 0));
                UV.Add(new Vertex(0, 1, 0));
                UV.Add(new Vertex(1, 0, 0));
                UV.Add(new Vertex(1, 1, 0));
                _SpriteUV = ConvertToByteArray(UV, 2);
            }

            _Manager.Active.Attributes.SetData("V_Vertex", 6 * 3 * sizeof(float), _SpriteVertices);
            _Manager.Active.Attributes.SetData("V_TextureUV", 6 * 2 * sizeof(float), _SpriteUV);

            _Manager.Active.Uniforms.SetData("Index", BitConverter.GetBytes(CurrentIndex));

            _Manager.SetDrawMode(GraphicDrawMode.Triangles);
            _Manager.Draw();
        }
        public override void RenderGeometry(List<Vertex> Vertices, List<Vertex> Normals, List<Vertex> TexCoords, List<Face> Faces, bool Update)
        {
            if((TexCoords == null || TexCoords.Count == 0) && _Manager.Active.Attributes.Exists("V_TextureUV"))
            {
                _Manager.Active.Attributes.DeleteDefinition("V_TextureUV");
                _Manager.Active.ReCompile();
                Update = true;
            }
            if (Update || (!_Manager.Active.Attributes.BufferExists))
            {
                _Manager.Active.Attributes.SetData("V_Vertex", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Vertices, 3));
                _Manager.Active.Attributes.SetData("V_Normal", Vertices.Count * 3 * sizeof(float), ConvertToByteArray(Normals, 3));
                if(TexCoords != null) _Manager.Active.Attributes.SetData("V_TextureUV", Vertices.Count * 2 * sizeof(float), ConvertToByteArray(TexCoords, 2));
            }
            _Manager.SetDrawMode(GraphicDrawMode.Triangles);
            _Manager.Draw();
        }
        public virtual ShaderProgram CurrentShader()
        {
            return _Manager.Active;
        }
        public override void PushPreferences()
        {
            this._PushedID = _Manager.Active.ShaderID;
        }
        public override void PopPreferences()
        {
            if (this._PushedID != "") _Manager.ActivateShader(this._PushedID);
        }
    }
}
