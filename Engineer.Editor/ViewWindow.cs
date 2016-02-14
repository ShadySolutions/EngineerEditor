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
        private SceneType _ViewType;
        private Point _OriginalPoint;
        private Point _CurrentPoint;
        private Vertex _OriginalTranslation;
        private Vertex _OriginalRotation;
        private Scene _CurrentScene;
        private Scene2D _Current2DScene;
        private Scene3D _Current3DScene;
        private DrawEngine _Engine;
        public ViewWindow()
        {
            InitializeComponent();
            this._MouseDown = false;
        }
        public void SetScene(SceneType Type, Scene CurrentScene)
        {
            this._CurrentScene = CurrentScene;
            _ViewType = Type;
            if (Type == SceneType.Scene2D) _Current2DScene = CurrentScene as Scene2D;
            else if (Type == SceneType.Scene3D) _Current3DScene = CurrentScene as Scene3D;
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
            _Engine.SetDefaults();
        }
        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this._GLControlLoaded) return;

            if (_ViewType == SceneType.Scene3D)
            {
                _Engine.Draw3DScene(_Current3DScene, this.GLControl.Width, this.GLControl.Height);
                GLControl.SwapBuffers();
            }
            else if (_ViewType == SceneType.Scene2D)
            {

            }
        }
        private void GLControl_Resize(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }
        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_ViewType == SceneType.Scene3D)
            {
                this._MouseDown = true;
                this._OriginalPoint = e.Location;
                this._OriginalTranslation = _Current3DScene.EditorCamera.Translation;
                this._OriginalRotation = _Current3DScene.EditorCamera.Rotation;
            }
        }
        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ViewType == SceneType.Scene3D)
            {
                if (this._MouseDown)
                {
                    this._CurrentPoint = e.Location;
                    float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                    float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                    _Current3DScene.EditorCamera.Rotation = new Vertex(this._OriginalRotation.X, this._OriginalRotation.Y + XIntensity, this._OriginalRotation.Z);
                    _Current3DScene.EditorCamera.Translation = MatrixTransformer.TransformVertex(MatrixTransformer.MTRotate(1, XIntensity), this._OriginalTranslation);
                }
            }
        }
        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_ViewType == SceneType.Scene3D)
            {
                this._MouseDown = false;
            }
        }
    }
}
