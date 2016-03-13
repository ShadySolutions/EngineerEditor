using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;
using Engineer.Engine;
using WeifenLuo.WinFormsUI.Docking;

namespace Engineer.Editor
{
    public partial class PropertiesWindow : ToolForm
    {
        private DockPanel _Dock;
        private Scene _CurrentScene;
        private SceneObject _CurrentObject;
        public PropertiesWindow()
        {
            InitializeComponent();
            this.ContentPanel.Padding = new Padding(10);
        }
        public PropertiesWindow(DockPanel Dock)
        {
            InitializeComponent();
            this.ContentPanel.Padding = new Padding(10);
            this._Dock = Dock;
        }
        public void SetDrawObject(SceneObject CurrentObject)
        {
            this._CurrentScene = null;
            this._CurrentObject = CurrentObject;
            this.ContentPanel.Controls.Clear();
            if (CurrentObject == null) return;
            NameLabel.Visible = true;
            NameLabel.Text = CurrentObject.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            if (CurrentObject.Type == SceneObjectType.DrawnSceneObject)
            {
                Properties_DrawObject PDO = new Properties_DrawObject(DrawnSceneObject.Drawn(CurrentObject).Representation);
                PDO.Dock = DockStyle.Top;
                PDO.Height = 130;
                this.ContentPanel.Controls.Add(PDO);
                PDO.BringToFront();
                if(DrawnSceneObject.Drawn(CurrentObject).Representation.Type == DrawObjectType.Actor)
                {
                    Properties_Actor ActorProperties = new Properties_Actor(DrawnSceneObject.Drawn(CurrentObject).Representation as Actor, _Dock);
                    ActorProperties.Dock = DockStyle.Top;
                    this.ContentPanel.Controls.Add(ActorProperties);
                    ActorProperties.BringToFront();
                }
                if (DrawnSceneObject.Drawn(CurrentObject).Representation.Type == DrawObjectType.Sprite)
                {
                    Properties_Sprite ActorProperties = new Properties_Sprite(DrawnSceneObject.Drawn(CurrentObject).Representation as Sprite, _Dock);
                    ActorProperties.Dock = DockStyle.Top;
                    this.ContentPanel.Controls.Add(ActorProperties);
                    ActorProperties.BringToFront();
                }
            }
        }
        public void SetScriptObject(SceneObject CurrentObject)
        {
            this._CurrentScene = null;
            this._CurrentObject = CurrentObject;
            this.ContentPanel.Controls.Clear();
            NameLabel.Visible = true;
            NameLabel.Text = CurrentObject.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            ScriptEditor Editor = new ScriptEditor();
            Editor.Text = CurrentObject.Name + " - Script Editor";
            Editor.Title = CurrentObject.Name + " - Script Editor";
            Editor.SetScript((ScriptSceneObject)CurrentObject);
            Editor.Show(_Dock, DockState.Document);
        }
        public void SetScene(Scene CurrentScene)
        {
            this._CurrentScene = CurrentScene;
            this._CurrentObject = null;
            this.ContentPanel.Controls.Clear();
            NameLabel.Visible = true;
            NameLabel.Text = CurrentScene.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            Properties_Scene PSC = new Properties_Scene();
            PSC.SetScene(CurrentScene);
            PSC.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(PSC);
            PSC.BringToFront();
        }
    }
}
