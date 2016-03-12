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
using System.IO;

namespace Engineer.Editor
{
    public partial class ViewWindow : ToolForm
    {
        private bool _MouseDown;
        private bool _GLControlLoaded;
        private object _MouseMoved;
        private Point _OriginalPoint;
        private Point _CurrentPoint;
        private Vertex _OriginalTranslation;
        private Vertex _OriginalRotation;
        private Scene _CurrentScene;
        private DrawEngine _Engine;
        public DrawEngine Engine
        {
            get
            {
                return _Engine;
            }

            set
            {
                _Engine = value;
            }
        }
        public ViewWindow()
        {
            InitializeComponent();
            this._MouseDown = false;
        }
        public void SetScene(SceneType Type, Scene CurrentScene)
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
            Engine = new DrawEngine();
            GLSLShaderRenderer Render = new GLSLShaderRenderer();
            Render.RenderDestination = this.GLControl;
            Render.TargetType = RenderTargetType.Editor;
            Engine.CurrentRenderer = Render;
            GLSLShaderMaterialTranslator Translator = new GLSLShaderMaterialTranslator();
            Engine.CurrentTranslator = Translator;
            Engine.SetDefaults();
        }
        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this._GLControlLoaded) return;
            if (_CurrentScene == null) return;
            if (_CurrentScene.Type == SceneType.Scene3D)
            {
                Engine.Draw3DScene((_CurrentScene as Scene3D), this.GLControl.Width, this.GLControl.Height);
                GLControl.SwapBuffers();
            }
            else if (_CurrentScene.Type == SceneType.Scene2D)
            {
                Engine.Draw2DScene((_CurrentScene as Scene2D), this.GLControl.Width, this.GLControl.Height);
                GLControl.SwapBuffers();
            }
        }
        private void GLControl_Resize(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }
        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_CurrentScene.Type == SceneType.Scene2D)
            {
                this._MouseDown = true;
                this._OriginalPoint = e.Location;
                Vertex Translation = (this._CurrentScene as Scene2D).Transformation.Translation;
                this._OriginalTranslation = new Vertex(Translation.X, Translation.Y, Translation.Z);
                List<Sprite> Sprites = (this._CurrentScene as Scene2D).Sprites;
                _MouseMoved = null;
                for (int i = Sprites.Count - 1; i >= 0; i--)
                {
                    bool InX = false;
                    bool InY = false;
                    if (e.X > Translation.X + Sprites[i].Translation.X && e.X < Translation.X + Sprites[i].Translation.X + Sprites[i].Scale.X * 100) InX = true;
                    if (e.Y > Translation.Y + Sprites[i].Translation.Y && e.Y < Translation.Y + Sprites[i].Translation.Y + Sprites[i].Scale.Y * 100) InY = true;
                    if(InX && InY)
                    {
                        this._OriginalTranslation = new Vertex(Sprites[i].Translation.X, Sprites[i].Translation.Y, Sprites[i].Translation.Z);
                        _MouseMoved = Sprites[i];
                        break;
                    }
                }
            }
            else if (_CurrentScene.Type == SceneType.Scene3D)
            {
                this._MouseDown = true;
                this._OriginalPoint = e.Location;
                this._OriginalTranslation = (_CurrentScene as Scene3D).EditorCamera.Translation;
                this._OriginalRotation = (_CurrentScene as Scene3D).EditorCamera.Rotation;
                _MouseMoved = null;
            }
        }
        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_CurrentScene.Type == SceneType.Scene2D)
            {
                if (this._MouseDown)
                {
                    this._CurrentPoint = e.Location;
                    float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                    float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                    if (_MouseMoved == null)
                    {
                        (this._CurrentScene as Scene2D).Transformation.Translation = new Vertex(this._OriginalTranslation.X + XIntensity, this._OriginalTranslation.Y + YIntensity, 0);
                    }
                    else
                    {
                        Sprite CurrentSprite = _MouseMoved as Sprite;
                        CurrentSprite.Translation = new Vertex(this._OriginalTranslation.X + XIntensity, this._OriginalTranslation.Y + YIntensity, this._OriginalTranslation.Z);
                    }
                }
            }
            else if (_CurrentScene.Type == SceneType.Scene3D)
            {
                if (this._MouseDown)
                {
                    this._CurrentPoint = e.Location;
                    float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                    float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                    (_CurrentScene as Scene3D).EditorCamera.Rotation = new Vertex(this._OriginalRotation.X, this._OriginalRotation.Y + XIntensity, this._OriginalRotation.Z);
                    (_CurrentScene as Scene3D).EditorCamera.Translation = MatrixTransformer.TransformVertex(MatrixTransformer.MTRotate(1, XIntensity), this._OriginalTranslation);
                }
            }
        }
        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_CurrentScene.Type == SceneType.Scene2D)
            {
                this._MouseDown = false;
            }
            else if (_CurrentScene.Type == SceneType.Scene3D)
            {
                this._MouseDown = false;
            }
        }
    }
}
