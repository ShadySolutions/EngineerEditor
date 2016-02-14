using Engineer.Data;
using Engineer.Engine;
using Engineer.Mathematics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
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
        private ContentLibrary _Library;
        private PropertiesWindow _Properties;
        private SceneWindow _Scene;
        private WorldOptions _World;
        private ViewWindow _View;
        private SceneType _CurrentSceneType;
        private Scene _CurrentScene;
        public _Parent()
        {
            InitializeComponent();
            if (!Directory.Exists("Library")) CheckRuntime();
            SetUp3DScene();
            GenerateLayout();
        }
        private void CheckRuntime()
        {
            bool PackageWritten = false;
            Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
            using (Stream RuntimeStream = new MemoryStream(Engineer.Editor.Properties.Resources.AppRuntime))
            {
                if (RuntimeStream == null)
                {
                    MessageBox.Show("Fatal Error", "Unable to access Runtime!");
                    Application.Exit();
                }
                else using (Stream Output = File.OpenWrite("Package.zip"))
                {
                    RuntimeStream.CopyTo(Output);
                    PackageWritten = true;
                }
            }
            if (!PackageWritten) return;
            ZipFile.ExtractToDirectory("Package.zip", ".");
        }
        private void SetUp3DScene()
        {
            XmlDocument Document = new XmlDocument();
            Document.Load("Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            Material.Default = Mat;

            OBJContainer Floor_OBJ = new OBJContainer();
            Floor_OBJ.Load("Library/Mesh/Floor.obj", null);
            if (Floor_OBJ.Geometries[0].Normals.Count == 0) Floor_OBJ.RecalculateNormals();
            Floor_OBJ.Repack();

            OBJContainer Soldier_OBJ = new OBJContainer();
            Soldier_OBJ.Load("Library/Mesh/Soldier.obj", null);
            if(Soldier_OBJ.Geometries[0].Normals.Count == 0) Soldier_OBJ.RecalculateNormals();
            Soldier_OBJ.Repack();

            Actor Soldier_Actor = new Actor(Soldier_OBJ, "Soldier");
            Soldier_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);

            Actor Floor_Actor = new Actor(Floor_OBJ, "Floor");
            Floor_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);

            Camera MainCamera_Camera = new Camera();
            MainCamera_Camera.Translation = new Vertex(0, 0.6f, 0.8f);
            MainCamera_Camera.Rotation = new Vertex(30, 0, 0);

            Light Light1_Light = new Light();
            Light1_Light.Translation = new Vertex(4, -4, -4);
            Light1_Light.Color = Color.White;
            Light1_Light.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
            Light1_Light.Intensity = 0.3f;

            Scene3D NewScene = new Scene3D("Scene_01");
            DrawnSceneObject Floor_Object = new DrawnSceneObject("Floor", Floor_Actor);
            NewScene.AddSceneObject(Floor_Object);
            DrawnSceneObject Soldier_Object = new DrawnSceneObject("Soldier", Soldier_Actor);
            NewScene.AddSceneObject(Soldier_Object);
            DrawnSceneObject Camera_Object = new DrawnSceneObject("Camera", MainCamera_Camera);
            NewScene.AddSceneObject(Camera_Object);
            DrawnSceneObject Light_Object = new DrawnSceneObject("Light", Light1_Light);
            NewScene.AddSceneObject(Light_Object);

            NewScene.ActiveCamera = new Camera(MainCamera_Camera);
            NewScene.EditorCamera = new Camera(MainCamera_Camera);

            this._CurrentSceneType = SceneType.Scene3D;
            this._CurrentScene = NewScene;
        }
        private void GenerateLayout()
        {
            MainDock.BringToFront();
            MainDock.DockRightPortion = 310;
            MainDock.DockLeftPortion = 310;
            this._World = new WorldOptions();
            this._Library = new ContentLibrary();
            this._Properties = new PropertiesWindow();
            this._Scene = new SceneWindow();
            this._Scene.SetPropertiesWindow(this._Properties);
            this._World.Show(MainDock, DockState.DockLeft);
            this._Library.Show(this._World.Pane, DockAlignment.Bottom, 1.4 / 2);
            this._Scene.Show(MainDock, DockState.DockRight);
            this._Properties.Show(this._Scene.Pane, DockAlignment.Bottom, 1.0 / 2);
            this._Library.SetLibraryRoot("Library", 0);
            this._Library.SetLibraryRoot("Project\\Assets", 1);
            this._Library.SetLibraryView(0);
            this._Scene.SetScene(_CurrentSceneType, _CurrentScene);
            this._View = new ViewWindow();
            this._View.Show(MainDock, DockState.Document);
            this._View.SetScene(_CurrentSceneType, _CurrentScene);
        }
    }
}
