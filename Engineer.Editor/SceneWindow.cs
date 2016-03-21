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
        private TreeNode _SceneNode;
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
            Scene CurrentScene = this._CurrentScene as Scene;
            TreeNode SceneNode = new TreeNode(this._CurrentScene.Name, 0, 0);
            this._SceneNode = SceneNode;
            for (int i = 0; i < _CurrentScene.Objects.Count; i++)
            {
                if(_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Actor)
                {
                    TreeNode ActorNode = new TreeNode(CurrentScene.Objects[i].Name, 1, 1);
                    ActorNode.Tag = new object[3] { SceneObjectType.DrawnSceneObject, DrawObjectType.Actor, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(ActorNode);
                }
                else if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Camera)
                {
                    TreeNode CameraNode = new TreeNode(CurrentScene.Objects[i].Name, 3, 3);
                    CameraNode.Tag = new object[3] { SceneObjectType.DrawnSceneObject, DrawObjectType.Camera, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(CameraNode);
                }
                else if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Light)
                {
                    TreeNode LightNode = new TreeNode(CurrentScene.Objects[i].Name, 4, 4);
                    LightNode.Tag = new object[3] { SceneObjectType.DrawnSceneObject, DrawObjectType.Light, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(LightNode);
                }
                else if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Background)
                {
                    TreeNode BackgroundNode = new TreeNode(CurrentScene.Objects[i].Name, 5, 5);
                    BackgroundNode.Tag = new object[3] { SceneObjectType.DrawnSceneObject, DrawObjectType.Background, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(BackgroundNode);
                }
                else if (_CurrentScene.Objects[i].Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(_CurrentScene.Objects[i]).Representation.Type == DrawObjectType.Sprite)
                {
                    TreeNode SpriteNode = new TreeNode(CurrentScene.Objects[i].Name, 6, 6);
                    SpriteNode.Tag = new object[3] { SceneObjectType.DrawnSceneObject, DrawObjectType.Sprite, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(SpriteNode);
                }
                else if (_CurrentScene.Objects[i].Type == SceneObjectType.ScriptSceneObject)
                {
                    TreeNode SpriteNode = new TreeNode(CurrentScene.Objects[i].Name, 7, 7);
                    SpriteNode.Tag = new object[3] { SceneObjectType.ScriptSceneObject, ScriptObjectType.CSScript, CurrentScene.Objects[i].ID };
                    SceneNode.Nodes.Add(SpriteNode);
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
            if (SceneTree.SelectedNode == this._SceneNode)
            {
                this._Properties.SetScene(this._CurrentScene);
                return;
            }
            for (int i = 0; i < this._CurrentScene.Objects.Count; i++)
            {
                if (((object[])SceneTree.SelectedNode.Tag)[2].ToString() == this._CurrentScene.Objects[i].ID)
                {
                    if((SceneObjectType)((object[])SceneTree.SelectedNode.Tag)[0] == SceneObjectType.DrawnSceneObject) this._Properties.SetSceneObject(this._CurrentScene.Objects[i]);
                    else if ((SceneObjectType)((object[])SceneTree.SelectedNode.Tag)[0] == SceneObjectType.ScriptSceneObject) this._Properties.SetSceneObject(this._CurrentScene.Objects[i]);
                }
            }
        }
        private void RefreshView_Tick(object sender, EventArgs e)
        {
            if(false) AssembleTree();
        }
    }
}
