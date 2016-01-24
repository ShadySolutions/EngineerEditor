using Engineer.Data;
using Engineer.Engine;
using Engineer.Mathematics;
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
            SetUpScene();
            GenerateLayout();
        }
        private void SetUpScene()
        {
            OBJContainer OBJ = new OBJContainer();
            OBJ.Load("storm.obj", null);
            OBJ.Repack();
            Actor NewActor = new Actor(OBJ, "Stormtrooper");
            NewActor.Scale = new Vertex(0.20f, 0.20f, 0.20f);
            Actor NewActor1 = new Actor(OBJ, "Stormtrooper");
            NewActor1.Translation = new Vertex(1, 0, 0);
            NewActor1.Scale = new Vertex(0.15f, 0.15f, 0.15f);
            Camera NewCamera = new Camera("Main Camera");
            NewCamera.Translation = new Vertex(0, 1.2f, 1);
            NewCamera.Rotation = new Vertex(40, 0, 0);
            Camera NewCamera1 = new Camera("Side Camera");
            NewCamera1.Translation = new Vertex(0, 1.2f, 1);
            NewCamera1.Rotation = new Vertex(40, 0, 0);
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
            _CurrentScene.Actors.Add(NewActor);
            _CurrentScene.Cameras.Add(NewCamera);
            _CurrentScene.Cameras.Add(NewCamera1);
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
