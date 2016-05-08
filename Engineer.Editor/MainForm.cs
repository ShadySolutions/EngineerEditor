using Engineer.Data;
using Engineer.Engine;
using Engineer.Mathematics;
using Engineer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TakeOne.WindowSuite;
using WeifenLuo.WinFormsUI.Docking;

namespace Engineer.Editor
{
    public partial class _Parent : TakeOne.WindowSuite.MainForm
    {
        public static string Version = "0.0.1.0";
        public static List<ToolForm> OpenForms;
        private GameWindow _GameW;
        private ContentLibrary _Library;
        private PropertiesWindow _Properties;
        private SceneWindow _Scene;
        private WorldOptions _World;
        private ViewWindow _View;
        private Game_Interface _Interface;

        public _Parent()
        {
            InitializeComponent();
            if (OpenForms == null) OpenForms = new List<ToolForm>();
            AcquireData();
            this._Interface = new Game_Interface(null);
            this._GameW = new GameWindow(this._Game);
            this._GameW.Show(MainDock, DockState.Document);
            this._GameW.EntrySelection += new Editor.SceneSelection(SceneSelection);
            this.Title = "Engineer " + Version;
            this.Text = "Engineer " + Version;
        }
        private void AcquireData()
        {
            this._Scene3DContainers = new List<OBJContainer>();

            OBJContainer Floor_OBJ = new OBJContainer();
            Floor_OBJ.Load("Library/Mesh/Floor.obj", null);
            if (Floor_OBJ.Geometries[0].Normals.Count == 0) Floor_OBJ.RecalculateNormals();
            Floor_OBJ.Repack();
            _Scene3DContainers.Add(Floor_OBJ);

            OBJContainer Cube_OBJ = new OBJContainer();
            Cube_OBJ.Load("Library/Mesh/Cube.obj", null);
            if (Cube_OBJ.Geometries[0].Normals.Count == 0) Cube_OBJ.RecalculateNormals();
            Cube_OBJ.Repack();
            _Scene3DContainers.Add(Cube_OBJ);

            OBJContainer Soldier_OBJ = new OBJContainer();
            Soldier_OBJ.Load("Library/Mesh/Soldier.obj", null);
            if (Soldier_OBJ.Geometries[0].Normals.Count == 0) Soldier_OBJ.RecalculateNormals();
            Soldier_OBJ.Repack();
            _Scene3DContainers.Add(Soldier_OBJ);

            XmlDocument Document = new XmlDocument();
            Document.Load("Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            Material.Default = Mat;
        }
        private void SceneSelection(int Index)
        {
            if(Index == -1)
            {
                SetUp2DScene();
            }
            else if (Index == -2)
            {
                SetUp3DScene();
            }
            else
            {
                this._CurrentScene = this._Game.Scenes[Index];
            }
            GenerateLayout();
            sceneToolStripMenuItem.Visible = true;
            sceneObjectToolStripMenuItem.Visible = true;
            runToolStripMenuItem.Visible = true;
        }
        private void SetUp3DScene()
        {
            Actor Floor_Actor = new Actor(_Scene3DContainers[0], "Floor");
            Floor_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);

            Camera MainCamera_Camera = new Camera();
            MainCamera_Camera.Translation = new Vertex(0, 0.6f, 0.8f);
            MainCamera_Camera.Rotation = new Vertex(30, 0, 0);

            Light Light1_Light = new Light();
            Light1_Light.Translation = new Vertex(4, -4, -4);
            Light1_Light.Color = Color.White;
            Light1_Light.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
            Light1_Light.Intensity = 0.3f;

            Scene3D NewScene = new Scene3D("Scene_" + (_Game.Scenes.Count + 1).ToString("000"));
            NewScene.BackColor = Color.FromArgb(40, 40, 40);
            NewScene.Type = SceneType.Scene3D;

            DrawnSceneObject Floor_Object = new DrawnSceneObject("Floor", Floor_Actor);
            NewScene.AddSceneObject(Floor_Object);
            DrawnSceneObject Camera_Object = new DrawnSceneObject("Camera", MainCamera_Camera);
            NewScene.AddSceneObject(Camera_Object);
            DrawnSceneObject Light_Object = new DrawnSceneObject("Light", Light1_Light);
            NewScene.AddSceneObject(Light_Object);

            NewScene.ActiveCamera = new Camera(MainCamera_Camera);
            NewScene.EditorCamera = new Camera(MainCamera_Camera);

            this._CurrentSceneType = SceneType.Scene3D;
            this._CurrentScene = NewScene;
            this._Game.Scenes.Add(NewScene);
        }
        private void SetUp2DScene()
        {
            Actor Floor_Actor = new Actor(_Scene3DContainers[0], "Floor");
            Floor_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);

            Camera MainCamera_Camera = new Camera();
            MainCamera_Camera.Translation = new Vertex(0, 0.6f, 0.8f);
            MainCamera_Camera.Rotation = new Vertex(30, 0, 0);

            Light Light1_Light = new Light();
            Light1_Light.Translation = new Vertex(4, -4, -4);
            Light1_Light.Color = Color.White;
            Light1_Light.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
            Light1_Light.Intensity = 0.3f;

            Scene2D NewScene = new Scene2D("Scene_" + (_Game.Scenes.Count + 1).ToString("000"));
            NewScene.BackColor = Color.FromArgb(40,40,40);
            NewScene.Type = SceneType.Scene2D;

            this._CurrentSceneType = SceneType.Scene2D;
            this._CurrentScene = NewScene;
            this._Game.Scenes.Add(NewScene);
        }
        private void GenerateLayout()
        {
            this._GameW.Hide();
            MainDock.BringToFront();
            MainDock.DockRightPortion = 310;
            MainDock.DockLeftPortion = 310;
            this._World = new WorldOptions();
            this._Library = new ContentLibrary();
            this._Properties = new PropertiesWindow(MainDock, OpenForms);
            this._Scene = new SceneWindow();
            this._Scene.SetPropertiesWindow(this._Properties);
            this._World.Show(MainDock, DockState.DockLeft);
            this._Library.Show(this._World.Pane, DockAlignment.Bottom, 1.4 / 2);
            this._Scene.Show(MainDock, DockState.DockRight);
            this._Properties.Show(this._Scene.Pane, DockAlignment.Bottom, 1.0 / 2);
            this._Library.Init("Library", _Game);
            this._Library.SetLibraryView("Library");
            this._Scene.SetScene(_CurrentSceneType, _CurrentScene);
            this._View = new ViewWindow();
            this._View.Show(MainDock, DockState.Document);
            this._View.SetScene(_CurrentSceneType, _CurrentScene, _Game);
            this._World.AddItem += new AddToSceeneEventHandler(AddSceneItem);
            this._World.UpdateSceneType(_CurrentSceneType);
        }
        private void AddSceneItem(int Index)
        {
            if (this._CurrentSceneType == SceneType.Scene2D)
            {
                if (Index == 5)
                {
                    Sprite NewSprite = new Sprite();
                    DrawnSceneObject New_Object = new DrawnSceneObject("New Sprite", NewSprite);
                    this._CurrentScene.AddSceneObject(New_Object);
                }
                this._Scene.SetScene(_CurrentSceneType, _CurrentScene);
            }
            else if (this._CurrentSceneType == SceneType.Scene3D)
            {
                if (Index < 3)
                {
                    Actor New_Actor = new Actor(_Scene3DContainers[Index], _Scene3DContainers[Index].Geometries[0].Name);
                    New_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
                    DrawnSceneObject New_Object = new DrawnSceneObject(_Scene3DContainers[Index].Geometries[0].Name, New_Actor);
                    this._CurrentScene.AddSceneObject(New_Object);
                }
                this._Scene.SetScene(_CurrentSceneType, _CurrentScene);
            }
            if (Index == 6)
            {
                ScriptSceneObject New_Object = new ScriptSceneObject("New Event");
                this._CurrentScene.AddSceneObject(New_Object);
                this._Scene.SetScene(_CurrentSceneType, _CurrentScene);
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._CurrentScene == null) return;
            this._World.Close();
            this._Library.Close();
            this._Properties.Close();
            this._Scene.Close();
            this._View.Close();
            this._CurrentScene = null;
            for (int i = 0; i < OpenForms.Count; i++) OpenForms[i].Close();
            OpenForms.Clear();
            this._GameW.GenerateEntries();
            this._GameW.Show(MainDock, DockState.Document);
            sceneToolStripMenuItem.Visible = false;
            sceneObjectToolStripMenuItem.Visible = false;
            runGameToolStripMenuItem.Visible = false;
        }
        private void MemoryTime_Tick(object sender, EventArgs e)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            System.GC.Collect();
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Runner.Runner Run = new Runner.Runner(800, 600, OpenTK.Graphics.GraphicsMode.Default, _Game.Name);
            Scene NewScene = null;
            if (_CurrentScene.Type == SceneType.Scene2D) NewScene = new Scene2D((Scene2D)_CurrentScene);
            else if (_CurrentScene.Type == SceneType.Scene3D) NewScene = new Scene3D((Scene3D)_CurrentScene);
            Run.Init(_Game, _CurrentScene);
            Run.Run();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.Filter = "Engineer Game XML (*.egx)|*.egx";
            if(Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                string ErrorMessage = "";
                if (Game_Interface.SaveGame(Dialog.FileName, ref _Game, ref ErrorMessage)) { }
                else MessageBox.Show(ErrorMessage, "Error");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Engineer Game XML (*.egx)|*.egx";
            if (Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                string ErrorMessage = "";
                Game LoadedGame = null;
                if (Game_Interface.LoadGame(Dialog.FileName, ref LoadedGame, ref ErrorMessage))
                {
                    _Game = LoadedGame;
                    _GameW.SetGame(_Game);
                }
                else MessageBox.Show(ErrorMessage, "Error");
            }
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is pre-alpha.\nMay god have mercy on your soul.","Help");
        }
        private void addCurrentItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_Scene.CurrentSceneObject!=null)
            {
                SceneObject NewAsset = null;
                if (_Scene.CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) NewAsset = new DrawnSceneObject((DrawnSceneObject)_Scene.CurrentSceneObject, null);
                else if (_Scene.CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) NewAsset = new ScriptSceneObject((ScriptSceneObject)_Scene.CurrentSceneObject, null);
                _Game.Assets.Add(NewAsset);
            }
            else
            {
                MessageBox.Show("No SceneObject Selected"," Warning");
            }
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Scene.CurrentSceneObject != null)
            {
                string Path = "Library\\Objects\\" + _Scene.CurrentSceneObject.Name + ".sco";
                if(File.Exists(Path)) Path = "Library\\Objects\\" + _Scene.CurrentSceneObject.Name + Guid.NewGuid().ToString() + ".sco";
                try
                {
                    if(_Scene.CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) DrawnSceneObject.Serialize((DrawnSceneObject)_Scene.CurrentSceneObject, Path);
                    else if (_Scene.CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) ScriptSceneObject.Serialize((ScriptSceneObject)_Scene.CurrentSceneObject, Path);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.InnerException.ToString(), ex.Message);
                    }
                    else MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("No SceneObject Selected", " Warning");
            }
        }
    }
}
