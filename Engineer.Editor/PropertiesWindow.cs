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
        public void SetSceneObject(SceneObject CurrentObject)
        {
            this._CurrentScene = null;
            this._CurrentObject = CurrentObject;
            this.ContentPanel.Controls.Clear();
            if (CurrentObject == null) return;

            Properties_SceneObject PSO = new Properties_SceneObject();
            PSO.Init(CurrentObject);
            PSO.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(PSO);
            PSO.BringToFront();
            if (CurrentObject.Type == SceneObjectType.DrawnSceneObject) SetDrawObject(CurrentObject);
            else if (CurrentObject.Type == SceneObjectType.ScriptSceneObject) SetScriptObject(CurrentObject);
        }
        private void SetDrawObject(SceneObject CurrentObject)
        {
            NameLabel.Visible = true;
            NameLabel.Text = CurrentObject.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            if (CurrentObject.Type == SceneObjectType.DrawnSceneObject)
            {
                Properties_DrawObject PDO = new Properties_DrawObject();
                PDO.Init(((DrawnSceneObject)CurrentObject).Representation);
                PDO.Dock = DockStyle.Top;
                this.ContentPanel.Controls.Add(PDO);
                PDO.BringToFront();

                if(((DrawnSceneObject)CurrentObject).Representation.Type == DrawObjectType.Actor)
                {
                    Properties_Actor ActorProperties = new Properties_Actor();
                    ActorProperties.Init(((DrawnSceneObject)CurrentObject).Representation as Actor, _Dock);
                    ActorProperties.Dock = DockStyle.Top;
                    this.ContentPanel.Controls.Add(ActorProperties);
                    ActorProperties.BringToFront();
                }
                if (((DrawnSceneObject)CurrentObject).Representation.Type == DrawObjectType.Sprite)
                {
                    Properties_Sprite SpriteProperties = new Properties_Sprite();
                    SpriteProperties.Init(((DrawnSceneObject)CurrentObject).Representation as Sprite, _Dock);
                    SpriteProperties.Dock = DockStyle.Top;
                    this.ContentPanel.Controls.Add(SpriteProperties);
                    SpriteProperties.BringToFront();
                }
            }
        }
        private void SetScriptObject(SceneObject CurrentObject)
        {
            NameLabel.Visible = true;
            NameLabel.Text = CurrentObject.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            Properties_Script ScriptProperties = new Properties_Script();
            ScriptProperties.Init(CurrentObject as ScriptSceneObject, _Dock);
            ScriptProperties.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(ScriptProperties);
            ScriptProperties.BringToFront();
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
            PSC.Init(CurrentScene);
            PSC.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(PSC);
            PSC.BringToFront();
        }
    }
}
