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

namespace Engineer.Editor
{
    public partial class SceneWindow : ToolForm
    {
        private SceneType _CurrentSceneType;
        private Scene _CurrentScene;
        private PropertiesWindow _Properties;
        public SceneWindow()
        {
            InitializeComponent();
        }
        public void SetScene(SceneType Type, Scene CurrentScene)
        {
            this._CurrentSceneType = Type;
            this._CurrentScene = CurrentScene;
            AssembleTree();
        }
        private void AssembleTree()
        {
            Scene3D Current3DScene = this._CurrentScene as Scene3D;
            TreeNode SceneNode = new TreeNode(this._CurrentScene.Name, 0, 0);
            for (int i = 0; i < _CurrentScene.Objects.Count; i++)
            {
                if(_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Actor)
                {
                    TreeNode ActorNode = new TreeNode(Current3DScene.Objects[i].Name, 1, 1);
                    ActorNode.Tag = new object[2] { DrawObjectType.Actor, Current3DScene.Objects[i].ID };
                    SceneNode.Nodes.Add(ActorNode);
                }
                if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Camera)
                {
                    TreeNode CameraNode = new TreeNode(Current3DScene.Objects[i].Name, 2, 2);
                    CameraNode.Tag = new object[2] { DrawObjectType.Camera, Current3DScene.Objects[i].ID };
                    SceneNode.Nodes.Add(CameraNode);
                }
                if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Light)
                {
                    TreeNode LightNode = new TreeNode(Current3DScene.Objects[i].Name, 3, 3);
                    LightNode.Tag = new object[2] { DrawObjectType.Light, Current3DScene.Objects[i].ID };
                    SceneNode.Nodes.Add(LightNode);
                }
                if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Background)
                {
                    TreeNode BackgroundNode = new TreeNode(Current3DScene.Objects[i].Name, 4, 4);
                    BackgroundNode.Tag = new object[2] { DrawObjectType.Background, Current3DScene.Objects[i].ID };
                    SceneNode.Nodes.Add(BackgroundNode);
                }
            }
            SceneTree.Nodes.Clear();
            SceneTree.Nodes.Add(SceneNode);
            SceneTree.ExpandAll();
        }
        private void SceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(SceneTree.SelectedNode != null)
            {
                if (SceneTree.SelectedNode.Tag != null)
                {
                    DrawObjectType Type = (DrawObjectType)((object[])SceneTree.SelectedNode.Tag)[0];
                    deleteToolStripMenuItem.Visible = true;
                    SetAsCurrentToolStripMenuItem.Visible = Type == DrawObjectType.Camera;
                }
                else
                {
                    SetAsCurrentToolStripMenuItem.Visible = false;
                    deleteToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                SetAsCurrentToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = false;
            }
        }
        private void SetAsCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_CurrentSceneType == SceneType.Scene3D)
            {
                Scene3D Current3DScene = this._CurrentScene as Scene3D;
                if (SceneTree.SelectedNode == null) return;
                for (int i = 0; i < Current3DScene.Objects.Count; i++)
                {
                    if(Current3DScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(Current3DScene.Objects[i]).Representation.Type == DrawObjectType.Camera)
                    {
                        if(Current3DScene.Objects[i].ID == ((object[])SceneTree.SelectedNode.Tag)[1].ToString())
                        {
                            Current3DScene.EditorCamera = new Camera(DrawnSceneObject.Drawn(Current3DScene.Objects[i]).Representation as Camera);
                        }
                    }
                }
            }
        }
        public void SetPropertiesWindow(PropertiesWindow Properties)
        {
            this._Properties = Properties;
        }
        private void PropertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SceneTree.SelectedNode == null) return;
            for (int i = 0; i < this._CurrentScene.Objects.Count; i++)
            {
                if (((object[])SceneTree.SelectedNode.Tag)[1].ToString() == this._CurrentScene.Objects[i].ID)
                {
                    this._Properties.SetDrawObject(this._CurrentScene.Objects[i]);
                }
            }
        }
    }
}
