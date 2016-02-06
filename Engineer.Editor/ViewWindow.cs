using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;
using Engineer.Engine;
using Engineer.Draw;
using Engineer.Draw.OpenGL;
using Engineer.Draw.OpenGL.GLSL;
using Engineer.Mathematics;
using Engineer.Data;

namespace Engineer.Editor
{
    public partial class ViewWindow : ToolForm
    {
        private bool _MouseDown;
        private bool _GLControlLoaded;
        private Point _OriginalPoint;
        private Point _CurrentPoint;
        private Vertex _OriginalTranslation;
        private Vertex _OriginalRotation;
        private Scene _CurrentScene;
        private DrawEngine _Engine;
        public ViewWindow()
        {
            InitializeComponent();
            this._MouseDown = false;
        }
        public void SetScene(Scene CurrentScene)
        {
            this._CurrentScene = CurrentScene;
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

            XmlDocument Document = new XmlDocument();
            Document.Load("Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            _Engine.ForceApplyMaterial("DefaultMaterial", Mat);
        }
        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this._GLControlLoaded) return;

            GLSLShaderRenderer SR = _Engine.CurrentRenderer as GLSLShaderRenderer;
            GLSLShaderProgram S = SR.CurrentShader() as GLSLShaderProgram;

            _Engine.DrawScene(_CurrentScene, this.GLControl.Width, this.GLControl.Height);
            GLControl.SwapBuffers();
        }
        private void GLControl_Resize(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }
        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            this._MouseDown = true;
            this._OriginalPoint = e.Location;
            this._OriginalTranslation = _CurrentScene.Cameras[_CurrentScene.ActiveCamera].Translation;
            this._OriginalRotation = _CurrentScene.Cameras[_CurrentScene.ActiveCamera].Rotation;
        }
        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(this._MouseDown)
            {
                this._CurrentPoint = e.Location;
                float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                _CurrentScene.Cameras[_CurrentScene.ActiveCamera].Rotation = new Vertex(this._OriginalRotation.X, this._OriginalRotation.Y + XIntensity, this._OriginalRotation.Z);
                _CurrentScene.Cameras[_CurrentScene.ActiveCamera].Translation = MatrixTransformer.TransformVertex(MatrixTransformer.MTRotate(1, XIntensity), this._OriginalTranslation);
            }
        }
        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            this._MouseDown = false;
        }
    }
}
