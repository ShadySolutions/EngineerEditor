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
using Engineer.Interface;

namespace Engineer.Editor
{
    public partial class ViewWindow : ToolForm
    {
        private bool _BlockEvents;
        private bool _MouseDown;
        private bool _GLControlLoaded;
        private object _MouseMoved;
        private Point _OriginalPoint;
        private Point _CurrentPoint;
        private Vertex _OriginalTranslation;
        private Vertex _OriginalRotation;
        private Game_Interface _Interface;
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
        }
        public ViewWindow(Game_Interface Interface, RenderTechType RenderType)
        {
            InitializeComponent();
            Init(Interface, RenderType);
        }
        public void Init(Game_Interface Interface, RenderTechType RenderType)
        {
            this._BlockEvents = false;
            this._Interface = Interface;
            _Interface.Update += new Engineer.Interface.InterfaceUpdate(InterfaceUpdate);
            this._MouseDown = false;
        }
        public void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            if (_BlockEvents) return;
            _BlockEvents = true;
            _BlockEvents = false;
        }
        //Events
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
            GLControl.MakeCurrent();
            if (_Interface.CurrentScene == null) return;
            if (_Interface.CurrentScene.Type == SceneType.Scene3D)
            {
                Engine.Draw3DScene((_Interface.CurrentScene as Scene3D), this.GLControl.Width, this.GLControl.Height);
                GLControl.SwapBuffers();
            }
            else if (_Interface.CurrentScene.Type == SceneType.Scene2D)
            {
                Engine.Draw2DScene((_Interface.CurrentScene as Scene2D), this.GLControl.Width, this.GLControl.Height);
                GLControl.SwapBuffers();
            }
        }
        private void GLControl_Resize(object sender, EventArgs e)
        {
            GLControl_Paint(null, null);
        }
        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentScene.Type == SceneType.Scene2D)
            {
                this._MouseDown = true;
                this._OriginalPoint = e.Location;
                Vertex Translation = (_Interface.CurrentScene as Scene2D).Transformation.Translation;
                this._OriginalTranslation = new Vertex(Translation.X, Translation.Y, Translation.Z);
                List<Sprite> Sprites = (_Interface.CurrentScene as Scene2D).Sprites;
                _MouseMoved = null;
                for (int i = Sprites.Count - 1; i >= 0; i--)
                {
                    bool InX = false;
                    bool InY = false;
                    if (e.X > Translation.X + Sprites[i].Translation.X && e.X < Translation.X + Sprites[i].Translation.X + Sprites[i].Scale.X) InX = true;
                    if (e.Y > Translation.Y + Sprites[i].Translation.Y && e.Y < Translation.Y + Sprites[i].Translation.Y + Sprites[i].Scale.Y) InY = true;
                    if(InX && InY)
                    {
                        this._OriginalTranslation = new Vertex(Sprites[i].Translation.X, Sprites[i].Translation.Y, Sprites[i].Translation.Z);
                        _MouseMoved = Sprites[i];
                        break;
                    }
                }
            }
            else if (_Interface.CurrentScene.Type == SceneType.Scene3D)
            {
                this._MouseDown = true;
                this._OriginalPoint = e.Location;
                this._OriginalTranslation = (_Interface.CurrentScene as Scene3D).EditorCamera.Translation;
                this._OriginalRotation = (_Interface.CurrentScene as Scene3D).EditorCamera.Rotation;
                _MouseMoved = null;
            }
        }
        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentScene.Type == SceneType.Scene2D)
            {
                if (this._MouseDown)
                {
                    this._CurrentPoint = e.Location;
                    float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                    float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                    if (_MouseMoved == null)
                    {
                        (_Interface.CurrentScene as Scene2D).Transformation.Translation = new Vertex(this._OriginalTranslation.X + XIntensity, this._OriginalTranslation.Y + YIntensity, 0);
                    }
                    else
                    {
                        Sprite CurrentSprite = _MouseMoved as Sprite;
                        CurrentSprite.Translation = new Vertex(this._OriginalTranslation.X + XIntensity, this._OriginalTranslation.Y + YIntensity, this._OriginalTranslation.Z);
                        _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
                    }
                }
            }
            else if (_Interface.CurrentScene.Type == SceneType.Scene3D)
            {
                if (this._MouseDown)
                {
                    this._CurrentPoint = e.Location;
                    float XIntensity = this._CurrentPoint.X - this._OriginalPoint.X;
                    float YIntensity = this._CurrentPoint.Y - this._OriginalPoint.Y;
                    (_Interface.CurrentScene as Scene3D).EditorCamera.Rotation = new Vertex(this._OriginalRotation.X, this._OriginalRotation.Y + XIntensity, this._OriginalRotation.Z);
                    (_Interface.CurrentScene as Scene3D).EditorCamera.Translation = MatrixTransformer.TransformVertex(MatrixTransformer.MTRotate(1, XIntensity), this._OriginalTranslation);
                }
            }
        }
        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentScene.Type == SceneType.Scene2D)
            {
                this._MouseDown = false;
            }
            else if (_Interface.CurrentScene.Type == SceneType.Scene3D)
            {
                this._MouseDown = false;
            }
        }
        private void GLControl_DragEnter(object sender, DragEventArgs e)
        {
            if (_BlockEvents) return;
            e.Effect = DragDropEffects.Copy;
        }
        private void GLControl_DragDrop(object sender, DragEventArgs e)
        {
            if (_BlockEvents) return;
            if (e.Data!=null)
            {
                object LVData = e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
                ListView.SelectedListViewItemCollection Collection = (ListView.SelectedListViewItemCollection)LVData;
                foreach (ListViewItem Item in Collection)
                {
                    object[] Info = (object[])Item.Tag;
                    if(Info[0].ToString() == "Asset")
                    {
                        int Index = (int)Info[1];
                        SceneObject New = null;
                        if (_Interface.CurrentGame.Assets[Index].Type == SceneObjectType.DrawnSceneObject) New = new DrawnSceneObject((DrawnSceneObject)_Interface.CurrentGame.Assets[Index], _Interface.CurrentScene);
                        else if (_Interface.CurrentGame.Assets[Index].Type == SceneObjectType.ScriptSceneObject) New = new ScriptSceneObject((ScriptSceneObject)_Interface.CurrentGame.Assets[Index], _Interface.CurrentScene);
                        if (New != null)
                        {
                            _Interface.CurrentScene.Objects.Add(New);
                            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
                        }
                        else MessageBox.Show("File type not supported for this scene type", "Not Supported");
                    }
                    if (Info[0].ToString() == "Library")
                    {
                        string Path = (string)Info[1];
                        SceneObject New = SceneObject.FromFile(Path, _Interface.CurrentScene);
                        if (New != null)
                        {
                            _Interface.CurrentScene.Objects.Add(New);
                            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
                        }
                        else MessageBox.Show("File type not supported for this scene type","Not Supported");
                    }
                }
            }
        }
    }
}
