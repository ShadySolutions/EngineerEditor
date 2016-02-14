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
            if (_CurrentSceneType == SceneType.Scene3D)
            {
                /*Scene3D Current3DScene = this._CurrentScene as Scene3D;
                TreeNode SceneNode = new TreeNode(this._CurrentScene.Name, 0, 0);
                for (int i = 0; i < Current3DScene.Actors.Count; i++)
                {
                    TreeNode ActorNode = new TreeNode(Current3DScene.Actors[i].Name, 1, 1);
                    ActorNode.Tag = DrawObjectType.Actor;
                    SceneNode.Nodes.Add(ActorNode);
                }
                for (int i = 0; i < Current3DScene.Cameras.Count; i++)
                {
                    TreeNode CameraNode = new TreeNode(Current3DScene.Cameras[i].Name, 2, 2);
                    CameraNode.Tag = DrawObjectType.Camera;
                    SceneNode.Nodes.Add(CameraNode);
                }
                for (int i = 0; i < Current3DScene.Lights.Count; i++)
                {
                    TreeNode LightNode = new TreeNode(Current3DScene.Lights[i].Name, 3, 3);
                    LightNode.Tag = DrawObjectType.Light;
                    SceneNode.Nodes.Add(LightNode);
                }
                SceneTree.Nodes.Clear();
                SceneTree.Nodes.Add(SceneNode);*/
            }
        }
        private void SceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(SceneTree.SelectedNode != null)
            {
                if (SceneTree.SelectedNode.Tag != null)
                {
                    DrawObjectType Type = (DrawObjectType)SceneTree.SelectedNode.Tag;
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
                /*Scene3D Current3DScene = this._CurrentScene as Scene3D;
                if (SceneTree.SelectedNode == null) return;
                for (int i = 0; i < Current3DScene.Cameras.Count; i++)
                {
                    if (SceneTree.SelectedNode.Text == Current3DScene.Cameras[i].Name)
                    {
                        Current3DScene.ActiveCamera = i;
                    }
                }*/
            }
        }
        public void SetPropertiesWindow(PropertiesWindow Properties)
        {
            this._Properties = Properties;
        }
        private void PropertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*if (SceneTree.SelectedNode == null) return;
            for (int i = 0; i < this._CurrentScene.Objects.Count; i++)
            {
                if (SceneTree.SelectedNode.Text == this._CurrentScene.Objects[i].Name)
                {
                    this._Properties.SetDrawObject(this._CurrentScene.Objects[i]);
                }
            }*/
        }
    }
}
