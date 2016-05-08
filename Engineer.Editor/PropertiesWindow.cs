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
using Engineer.Interface;

namespace Engineer.Editor
{
    public enum SelectedObjectType
    {
        SceneObject = 0,
        Scene = 1
    }
    public partial class PropertiesWindow : ToolForm
    {
        private bool _BlockEvents;
        private object _Selected;
        private SelectedObjectType _Type;
        private DockPanel _Dock;
        private Game_Interface _Interface;
        private List<ToolForm> _OpenForms;
        public PropertiesWindow()
        {
            InitializeComponent();
            this.ContentPanel.Padding = new Padding(10);
        }
        public PropertiesWindow(Game_Interface Interface, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            Init(Interface, Dock, OpenForms);
        }
        public void Init(Game_Interface Interface, DockPanel Dock, List<ToolForm> OpenForms)
        {
            _Interface = Interface;
            _Interface.Update += new InterfaceUpdate(InterfaceUpdate);
            this.ContentPanel.Padding = new Padding(10);
            this._Dock = Dock;
            this._OpenForms = OpenForms;
        }
        private void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            _BlockEvents = true;
            if (Message == InterfaceUpdateMessage.SelectionUpdated)
            {
                SetObject(_Interface.CurrentSelection);
            }
            else if (Message == InterfaceUpdateMessage.SceneObjectsUpdated && _Type == SelectedObjectType.SceneObject)
            {
                SetSceneObject(_Interface.CurrentSceneObject);
            }
            else if (Message == InterfaceUpdateMessage.SceneUpdated && _Type == SelectedObjectType.Scene)
            {
                SetScene(_Interface.CurrentScene);
            }
            _BlockEvents = false;
        }
        private void SetObject(object SelectedObject)
        {
            if(SelectedObject.GetType().IsSubclassOf(typeof(SceneObject)))
            {
                _Type = SelectedObjectType.SceneObject;
                SetSceneObject((SceneObject)SelectedObject);
            }
            else if (SelectedObject.GetType().IsSubclassOf(typeof(Scene)))
            {
                _Type = SelectedObjectType.Scene;
                SetScene((Scene)SelectedObject);
            }
        }
        private void SetSceneObject(SceneObject CurrentObject)
        {
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
                    ActorProperties.Init(((DrawnSceneObject)CurrentObject).Representation as Actor, _Dock, _OpenForms);
                    ActorProperties.Dock = DockStyle.Top;
                    this.ContentPanel.Controls.Add(ActorProperties);
                    ActorProperties.BringToFront();
                }
                if (((DrawnSceneObject)CurrentObject).Representation.Type == DrawObjectType.Sprite)
                {
                    Properties_Sprite SpriteProperties = new Properties_Sprite();
                    SpriteProperties.Init(((DrawnSceneObject)CurrentObject).Representation as Sprite, _Dock, _OpenForms);
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
            ScriptProperties.Init(CurrentObject as ScriptSceneObject, _Dock, _OpenForms);
            ScriptProperties.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(ScriptProperties);
            ScriptProperties.BringToFront();
        }
        private void SetScene(Scene CurrentScene)
        {
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
