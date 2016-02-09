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
        private Scene _CurrentScene;
        public _Parent()
        {
            InitializeComponent();
            if (!Directory.Exists("Library")) CheckRuntime();
            SetUpScene();
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
        private void SetUpScene()
        {
            XmlDocument Document = new XmlDocument();
            Document.Load("Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            Material.Default = Mat;

            OBJContainer FloorOBJ = new OBJContainer();
            FloorOBJ.Load("Library/Mesh/Floor.obj", null);
            if (FloorOBJ.Geometries[0].Normals.Count == 0) FloorOBJ.RecalculateNormals();
            FloorOBJ.Repack();

            OBJContainer SoldierOBJ = new OBJContainer();
            SoldierOBJ.Load("Library/Mesh/Soldier.obj", null);
            if(SoldierOBJ.Geometries[0].Normals.Count == 0) SoldierOBJ.RecalculateNormals();
            SoldierOBJ.Repack();

            Actor Soldier = new Actor(SoldierOBJ, "Soldier");
            Soldier.Scale = new Vertex(0.001f, 0.001f, 0.001f);
            Actor Soldier1 = new Actor(SoldierOBJ, "Soldier");
            //Soldier1.Scale = new Vertex(0.001f, 0.001f, 0.001f);
            Actor Floor = new Actor(FloorOBJ, "Floor");
            Floor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
            Camera NewCamera = new Camera("Main Camera");
            NewCamera.Translation = new Vertex(0, 0.6f, 0.8f);
            NewCamera.Rotation = new Vertex(30, 0, 0);
            Light MainLight = new Light("Light_01");
            MainLight.Translation = new Vertex(4, -4, -4);
            MainLight.Color = Color.White;
            MainLight.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
            MainLight.Intensity = 0.3f;
            Light SideLight = new Light("Light_02");
            SideLight.Translation = new Vertex(-4, -4, -4);
            SideLight.Color = Color.White;
            SideLight.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
            SideLight.Intensity = 0.3f;
            _CurrentScene = new Scene("Scene_01");
            _CurrentScene.Actors.Add(Floor);
            _CurrentScene.Actors.Add(Soldier);
            //_CurrentScene.Actors.Add(Soldier1);

            _CurrentScene.Cameras.Add(NewCamera);
            _CurrentScene.Lights.Add(MainLight);
            _CurrentScene.Lights.Add(SideLight);
            _CurrentScene.ActiveCamera = 0;
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
            this._Scene.SetScene(_CurrentScene);
            this._View = new ViewWindow();
            this._View.Show(MainDock, DockState.Document);
            this._View.SetScene(_CurrentScene);
        }
    }
}
