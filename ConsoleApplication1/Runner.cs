//#define FixedPipeline
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
using Engineer.Draw.OpenGL;
using Engineer.Draw.OpenGL.FixedGL;
using Engineer.Draw.OpenGL.GLSL;
using Engineer.Engine;

namespace Engineer.Runner
{
    public class Runner : OpenTK.GameWindow
    {
        /// Temp
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
        private void SetExampleShader(GLSLShaderProgram S)
        {
            S.Uniforms.SetData("Lights[0].Color", ConvertToByteArray(new float[3] { 0.8f, 0.8f, 0.8f }));
            S.Uniforms.SetData("Lights[0].Position", ConvertToByteArray(new float[3] { 0, -4, -4 }));
            S.Uniforms.SetData("Lights[0].Attenuation", ConvertToByteArray(new float[3] { 0.6f, 0.2f, 0.2f }));
            S.Uniforms.SetData("Lights[0].Intensity", BitConverter.GetBytes(1.0f));
            S.Uniforms.SetData("CameraPosition", ConvertToByteArray(new float[3] { 0, 1, 1 }));
        }
        /// Temp

        private Scene _Scene;
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
            SetUpScene();
        }
        private void SetUpScene()
        {
            OBJContainer OBJ = new OBJContainer();
            OBJ.Load("storm.obj", null);
            OBJ.Repack();
            Actor NewActor = new Actor(OBJ);
            NewActor.Scale = new Vertex(0.15f, 0.15f, 0.15f);
            Actor NewActor1 = new Actor(OBJ);
            NewActor1.Translation = new Vertex(1, 0, 0);
            NewActor1.Scale = new Vertex(0.15f, 0.15f, 0.15f);
            Camera NewCamera = new Camera();
            NewCamera.Translation = new Vertex(0, 1, 1);
            NewCamera.Rotation = new Vertex(45, 0, 0);
            _Scene = new Scene();
            _Scene.Actors.Add(NewActor);
            //_Scene.Actors.Add(NewActor1);
            _Scene.Cameras.Add(NewCamera);
            _Scene.ActiveCamera = 0;
        }
        protected override void OnResize(EventArgs e)
        {
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            #if !FixedPipeline
            GLSLShaderRenderer SR = _Engine.CurrentRenderer as GLSLShaderRenderer;
            GLSLShaderProgram S = SR.CurrentShader() as GLSLShaderProgram;
            SetExampleShader(S);
            #endif

            _Engine.DrawScene(_Scene, this.ClientRectangle.Width, this.ClientRectangle.Height);
            SwapBuffers();
        }
    }
}
