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
        private bool _BlockEvents;
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
            Init();
        }
        private void Init()
        {
            _BlockEvents = false;
            if (OpenForms == null) OpenForms = new List<ToolForm>();
            this._Interface = new Game_Interface(null);
            GenerateLayout();
            _Interface.Update += new Interface.InterfaceUpdate(InterfaceUpdate);
            this.Title = "Engineer " + Version;
            this.Text = "Engineer " + Version;
            _Interface.CurrentScene = null;
        }
        private void GenerateLayout()
        {
            MainDock.BringToFront();
            MainDock.DockRightPortion = 310;
            MainDock.DockLeftPortion = 310;
            String LibPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Engineer/";
            this._GameW = new GameWindow(this._Interface);
            this._World = new WorldOptions(this._Interface);
            this._Library = new ContentLibrary(_Interface, LibPath + "Library");
            this._Scene = new SceneWindow(_Interface, _Properties);
            this._Properties = new PropertiesWindow(_Interface, MainDock, OpenForms);
            this._View = new ViewWindow(_Interface, RenderTechType.OpenGLCore);
        }
        private void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            if (_BlockEvents) return;
            _BlockEvents = true;
            if (Message == InterfaceUpdateMessage.SceneUpdated)
            {
                if(_Interface.CurrentScene != null)
                {
                    this._GameW.Hide();
                    this._View.Show(MainDock, DockState.Document);
                    this._World.Show(MainDock, DockState.DockLeft);
                    this._Library.Show(this._World.Pane, DockAlignment.Bottom, 1.0 / 2);
                    this._Scene.Show(MainDock, DockState.DockRight);
                    this._Properties.Show(this._Scene.Pane, DockAlignment.Bottom, 1.0 / 2);
                    sceneToolStripMenuItem.Visible = true;
                    sceneObjectToolStripMenuItem.Visible = true;
                    runToolStripMenuItem.Visible = true;
                }
                else
                {
                    this._GameW.Show(MainDock, DockState.Document);
                    this._View.Hide();
                    this._World.Hide();
                    this._Library.Hide();
                    this._Scene.Hide();
                    this._Properties.Hide();
                    sceneToolStripMenuItem.Visible = false;
                    sceneObjectToolStripMenuItem.Visible = false;
                    runToolStripMenuItem.Visible = false;
                }
            }
            _BlockEvents = false;
        }
        //Events
        private void MemoryTime_Tick(object sender, EventArgs e)
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            System.GC.Collect();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentScene == null) return;
            _Interface.CurrentScene = null;
            for (int i = 0; i < OpenForms.Count; i++) OpenForms[i].Close();
            OpenForms.Clear();
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Runner.ScriptedRunner Run = new Runner.ScriptedRunner(800, 600, OpenTK.Graphics.GraphicsMode.Default, _Interface.CurrentGame.Name);
            Scene NewScene = null;
            if (_Interface.CurrentScene.Type == SceneType.Scene2D) NewScene = new Scene2D((Scene2D)_Interface.CurrentScene);
            else if (_Interface.CurrentScene.Type == SceneType.Scene3D) NewScene = new Scene3D((Scene3D)_Interface.CurrentScene);
            Run.Init(_Interface.CurrentGame, _Interface.CurrentScene);
            Run.Run();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.Filter = "Engineer Game XML (*.egx)|*.egx";
            if(Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                string ErrorMessage = "";
                Game Current = _Interface.CurrentGame;
                if (Game_Interface.SaveGame(Dialog.FileName, ref Current, ref ErrorMessage)) { }
                else MessageBox.Show(ErrorMessage, "Error");
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Engineer Game XML (*.egx)|*.egx";
            if (Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                string ErrorMessage = "";
                Game LoadedGame = null;
                if (Game_Interface.LoadGame(Dialog.FileName, ref LoadedGame, ref ErrorMessage))
                {
                    _Interface.CurrentGame = LoadedGame;
                }
                else MessageBox.Show(ErrorMessage, "Error");
            }
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            MessageBox.Show("This is pre-alpha.\nMay god have mercy on your soul.","Help");
        }
        private void addCurrentItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentSceneObject!=null)
            {
                SceneObject NewAsset = null;
                if (_Interface.CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) NewAsset = new DrawnSceneObject((DrawnSceneObject)_Interface.CurrentSceneObject, null);
                else if (_Interface.CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) NewAsset = new ScriptSceneObject((ScriptSceneObject)_Interface.CurrentSceneObject, null);
                _Interface.AddAsset(NewAsset);
            }
            else
            {
                MessageBox.Show("No SceneObject Selected"," Warning");
            }
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            if (_Interface.CurrentSceneObject != null)
            {
                string Path = "Library\\Objects\\" + _Interface.CurrentSceneObject.Name + ".sco";
                if(File.Exists(Path)) Path = "Library\\Objects\\" + _Interface.CurrentSceneObject.Name + Guid.NewGuid().ToString() + ".sco";
                try
                {
                    if(_Interface.CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) DrawnSceneObject.Serialize((DrawnSceneObject)_Interface.CurrentSceneObject, Path);
                    else if (_Interface.CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) ScriptSceneObject.Serialize((ScriptSceneObject)_Interface.CurrentSceneObject, Path);
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
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            closeToolStripMenuItem_Click(sender, e);
            _Interface.NewGame();
        }
    }
}
