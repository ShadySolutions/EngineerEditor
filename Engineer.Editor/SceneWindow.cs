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
        private Scene _CurrentScene;
        public SceneWindow()
        {
            InitializeComponent();
        }
        public void SetScene(Scene CurrentScene)
        {
            this._CurrentScene = CurrentScene;
            AssembleTree();
        }
        private void AssembleTree()
        {
            TreeNode SceneNode = new TreeNode(this._CurrentScene.Name, 0, 0);
            for(int i = 0; i < this._CurrentScene.Actors.Count; i++)
            {
                TreeNode ActorNode = new TreeNode(this._CurrentScene.Actors[i].Name, 1, 1);
                ActorNode.Tag = SceneObjectType.Actor;
                SceneNode.Nodes.Add(ActorNode);
            }
            for (int i = 0; i < this._CurrentScene.Cameras.Count; i++)
            {
                TreeNode CameraNode = new TreeNode(this._CurrentScene.Cameras[i].Name, 2, 2);
                CameraNode.Tag = SceneObjectType.Camera;
                SceneNode.Nodes.Add(CameraNode);
            }
            for (int i = 0; i < this._CurrentScene.Lights.Count; i++)
            {
                TreeNode LightNode = new TreeNode(this._CurrentScene.Lights[i].Name, 3, 3);
                LightNode.Tag = SceneObjectType.Light;
                SceneNode.Nodes.Add(LightNode);
            }
            SceneTree.Nodes.Clear();
            SceneTree.Nodes.Add(SceneNode);
        }

        private void SceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(SceneTree.SelectedNode != null)
            {
                if (SceneTree.SelectedNode.Tag != null)
                {
                    SceneObjectType Type = (SceneObjectType)SceneTree.SelectedNode.Tag;
                    deleteToolStripMenuItem.Visible = true;
                    SetAsCurrentToolStripMenuItem.Visible = Type == SceneObjectType.Camera;
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
            if (SceneTree.SelectedNode == null) return;
            for(int i = 0; i < this._CurrentScene.Cameras.Count; i++)
            {
                if(SceneTree.SelectedNode.Text == this._CurrentScene.Cameras[i].Name)
                {
                    this._CurrentScene.ActiveCamera = i;
                }
            }
        }
    }
}
