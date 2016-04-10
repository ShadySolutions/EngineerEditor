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
        public static List<ToolForm> OpenForms;

        private GameWindow _GameW;
        private ContentLibrary _Library;
        private PropertiesWindow _Properties;
        private SceneWindow _Scene;
        private WorldOptions _World;
        private ViewWindow _View;

        private Game _Game;
        private Scene _CurrentScene;
        private SceneType _CurrentSceneType;
        private List<OBJContainer> _Scene3DContainers;

        public _Parent()
        {
            InitializeComponent();
            if (OpenForms == null) OpenForms = new List<ToolForm>();
            if (!Directory.Exists("Library")) CheckRuntime();
            AcquireData();
            this._Game = new Game();
            this._Game.Name = "New Project";
            this._GameW = new GameWindow(this._Game);
            this._GameW.Show(MainDock, DockState.Document);
            this._GameW.EntrySelection += new Editor.SceneSelection(SceneSelection);
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
            this._Properties = new PropertiesWindow(MainDock);
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
        }

        private void MemoryTime_Tick(object sender, EventArgs e)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            System.GC.Collect();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Runner.Runner Run = new Runner.Runner(800, 600, OpenTK.Graphics.GraphicsMode.Default, _Game.Name);
            Run.Init(_CurrentScene, _View.Engine);
            Run.Run();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.Filter = "Engineer Game File (*.egf)|*.egf";
            if(Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                try
                {
                    if (File.Exists(Dialog.FileName)) File.Delete(Dialog.FileName);
                    string DirPath = Dialog.FileName.Replace(Path.GetFileName(Dialog.FileName), Path.GetFileNameWithoutExtension(Dialog.FileName)) + "\\";
                    Directory.CreateDirectory(DirPath);
                    List<string> Files = new List<string>();
                    for(int i = 0; i < _Game.Scenes.Count; i++)
                    {
                        for(int j = 0; j < _Game.Scenes[i].Objects.Count; j++)
                        {
                            if(_Game.Scenes[i].Objects[j].Type == SceneObjectType.DrawnSceneObject)
                            {
                                DrawnSceneObject Drawn = (DrawnSceneObject)_Game.Scenes[i].Objects[j];
                                if(Drawn.Representation.Type == DrawObjectType.Actor)
                                {
                                    Actor CurrentActor = (Actor)Drawn.Representation;
                                    if(CurrentActor.Geometries.Count > 0)
                                    {
                                        OBJContainer OBJ = new OBJContainer();
                                        OBJ.Geometries = CurrentActor.Geometries;
                                        string NewFilePath = DirPath + CurrentActor.ID + ".obj";
                                        Files.Add(NewFilePath);
                                        OBJ.Save(NewFilePath, null);
                                    }
                                }
                            }
                        }
                    }
                    Files.Add(DirPath + Path.GetFileNameWithoutExtension(Dialog.FileName) + ".xml");
                    Game.Serialize(_Game, DirPath + Path.GetFileNameWithoutExtension(Dialog.FileName) + ".xml");
                    ZipFile.CreateFromDirectory(DirPath, Dialog.FileName);
                    for (int i = 0; i < Files.Count; i++) File.Delete(Files[i]);
                    Directory.Delete(DirPath);
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
        }
    }
}
