using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Engineer.Engine;
using Engineer.Mathematics;
using Engineer.Data;
using Engineer.Draw;
using Engineer.Draw.OpenGL;
using Engineer.Draw.OpenGL.GLSL;
using ShadySolutions.UI;

namespace MaterialEditor
{
    public partial class MainForm : Form
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
        private bool _GLControlLoaded;
        private Scene _Scene;
        private DrawEngine _Engine;
        private Material _CurrentMaterial;
        public MainForm()
        {
            InitializeComponent();
            _GLControlLoaded = false;

        }
        private void SetUpScene()
        {
            OBJContainer OBJ = new OBJContainer();
            OBJ.Load("storm.obj", null);
            OBJ.Repack();
            Actor NewActor = new Actor(OBJ);
            NewActor.Scale = new Vertex(0.20f, 0.20f, 0.20f);
            Actor NewActor1 = new Actor(OBJ);
            NewActor1.Translation = new Vertex(1, 0, 0);
            NewActor1.Scale = new Vertex(0.15f, 0.15f, 0.15f);
            Camera NewCamera = new Camera();
            NewCamera.Translation = new Vertex(0, 1.2f, 1);
            NewCamera.Rotation = new Vertex(40, 0, 0);
            _Scene = new Scene();
            _Scene.Actors.Add(NewActor);
            _Scene.Cameras.Add(NewCamera);
            _Scene.ActiveCamera = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument Document = new XmlDocument();
                Document.Load(Dialog.FileName);
                XmlNode Main = Document.FirstChild;
                Material Mat = new Material(Main);
                UIGenerator.MaterialToUI(Mat, this.Editor);
                _CurrentMaterial = Mat;
            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            this._GLControlLoaded = true;
            GLControl.MakeCurrent();
            _Engine = new DrawEngine();
            GLSLShaderRenderer Render = new GLSLShaderRenderer();
            Render.RenderDestination = this.GLControl;
            _Engine.CurrentRenderer = Render;
            GLSLShaderMaterialTranslator Translator = new GLSLShaderMaterialTranslator();
            _Engine.CurrentTranslator = Translator;
            SetUpScene();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this._GLControlLoaded) return;

            GLSLShaderRenderer SR = _Engine.CurrentRenderer as GLSLShaderRenderer;
            GLSLShaderProgram S = SR.CurrentShader() as GLSLShaderProgram;
            SetExampleShader(S);

            _Engine.DrawScene(_Scene, this.GLControl.Width, this.GLControl.Height);
            GLControl.SwapBuffers();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }

        private void applyShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Engine.ForceApplyMaterial("Current", _CurrentMaterial);
        }

        private void Editor_NodeUpdate(ShadySolutions.UI.NodeEditor.NodeValue sender)
        {
            MaterialNodeValue Source = (MaterialNodeValue)sender.Source;
            Source.Value = new MaterialValueHolder(sender.Value.X, sender.Value.Y, sender.Value.Z, sender.Value.W);
            if(Source.InputTarget != null && sender.Input == null)
            {
                Source.InputTarget.OutputTargets.Remove(Source);
                Source.InputTarget = null;
            }
            if (Source.InputTarget != null && (MaterialNodeValue)sender.Input.Source != Source.InputTarget)
            {
                Source.InputTarget.OutputTargets.Remove(Source);
                Source.InputTarget = (MaterialNodeValue)sender.Input.Source;
            }
            if(Source.InputTarget == null && sender.Input != null)
            {
                Source.InputTarget = (MaterialNodeValue)sender.Input.Source;
            }
        }
    }
}
