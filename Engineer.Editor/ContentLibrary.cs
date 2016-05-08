using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;
using Engineer.Engine;
using Engineer.Interface;

namespace Engineer.Editor
{
    public enum LibraryViewType
    {
        Library = 0,
        Assets = 1
    }
    public partial class ContentLibrary : ToolForm
    {
        private bool _BlockEvents;
        private string _LibraryRoot;
        private LibraryViewType _View;
        private Game_Interface _Interface;
        public ContentLibrary()
        {
            InitializeComponent();
        }
        public ContentLibrary(Game CurrentGame, string FileRoot)
        {
            InitializeComponent();
        }
        public void Init(Game_Interface Interface, string FileRoot)
        {
            this._BlockEvents = false;
            this._Interface = Interface;
            _Interface.Update += new InterfaceUpdate(InterfaceUpdate);
            _LibraryRoot = FileRoot;
            SetLibraryView(LibraryViewType.Library);
        }
        private void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            _BlockEvents = true;
            if (Message == InterfaceUpdateMessage.LibraryUpdated)
            {
                if (_View == LibraryViewType.Library) SetLibraryView(LibraryViewType.Library);
            }
            if (Message == InterfaceUpdateMessage.AssetsUpdated)
            {
                if (_View == LibraryViewType.Assets) SetLibraryView(LibraryViewType.Assets);
            }
            _BlockEvents = false;
        }
        //Service
        private void SetLibraryView(LibraryViewType Type)
        {
            if (Type == LibraryViewType.Library)
            {
                Tree.Nodes.Clear();
                this._View = LibraryViewType.Library;
                FileList.Items.Clear();
                FileList.LargeImageList = LibraryThumbs;
                if (this._LibraryRoot == "") return;
                TreeNode MainNode = null;
                MainNode = new TreeNode("Content", 0, 0);
                MainNode.Tag = this._LibraryRoot;
                SetElements(MainNode, this._LibraryRoot);
                Tree.Nodes.Add(MainNode);
                Tree.ExpandAll();
                Tree.SelectedNode = MainNode;
            }
            else if (Type == LibraryViewType.Assets)
            {
                Tree.Nodes.Clear();
                this._View = LibraryViewType.Assets;
                FileList.Items.Clear();
                FileList.LargeImageList = AssetsThumbs;
                TreeNode AllNode = new TreeNode("All", 0, 0);
                AllNode.Tag = -1;
                Tree.Nodes.Add(AllNode);
                TreeNode NewNode = new TreeNode("Actors", 0, 0);
                NewNode.Tag = 0;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Cameras", 0, 0);
                NewNode.Tag = 1;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Lights", 0, 0);
                NewNode.Tag = 2;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Backgrounds", 0, 0);
                NewNode.Tag = 3;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Sprite", 0, 0);
                NewNode.Tag = 4;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Figure", 0, 0);
                NewNode.Tag = 5;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Scripts", 0, 0);
                NewNode.Tag = 6;
                Tree.Nodes.Add(NewNode);
                NewNode = new TreeNode("Sounds", 0, 0);
                NewNode.Tag = 7;
                Tree.Nodes.Add(NewNode);
                Tree.ExpandAll();
                Tree.SelectedNode = AllNode;
            }
        }
        private void SetElements(TreeNode Node, string FileRoot)
        {
            TreeNode CurrentNode = new TreeNode(new DirectoryInfo(FileRoot).Name, 0, 0);
            CurrentNode.Tag = FileRoot;
            Node.Nodes.Add(CurrentNode);
            string[] Directories = Directory.GetDirectories(FileRoot);
            for (int i = 0; i < Directories.Length; i++) SetElements(CurrentNode, Directories[i]);
        }
        private int FindImageIndex(string FileRoot)
        {
            if (FileRoot.EndsWith(".obj") || FileRoot.EndsWith(".bvh") || FileRoot.EndsWith(".dae"))
                return 5;
            if (FileRoot.EndsWith(".jpg") || FileRoot.EndsWith(".jpeg") || FileRoot.EndsWith(".png") || FileRoot.EndsWith(".bmp") ||
                FileRoot.EndsWith(".ico") || FileRoot.EndsWith(".tiff") || FileRoot.EndsWith(".tga") || FileRoot.EndsWith(".psd"))
                return 4;
            if (FileRoot.EndsWith(".mp3") || FileRoot.EndsWith(".wav"))
                return 3;
            if (FileRoot.EndsWith(".cs"))
                return 2;
            if (FileRoot.EndsWith(".txt") || FileRoot.EndsWith(".config"))
                return 1;
            return 0;
        }
        private List<string> GetFiles(List<string> Files, string FileRoot)
        {
            string[] Directories = Directory.GetDirectories(FileRoot);
            string[] CurrentFiles = Directory.GetFiles(FileRoot);
            Files.AddRange(CurrentFiles);
            for (int i = 0; i < Directories.Length; i++) Files = GetFiles(Files, Directories[i]);
            return Files;
        }
        //Events
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_BlockEvents) return;
            if (this._View == LibraryViewType.Library)
            {
                FileList.Items.Clear();
                string FileRoot = e.Node.Tag as string;
                List<string> Files = new List<string>();
                Files = GetFiles(Files, FileRoot);
                for (int i = 0; i < Files.Count; i++)
                {
                    ListViewItem NewItem = new ListViewItem(Path.GetFileName(Files[i]), FindImageIndex(Files[i]));
                    NewItem.Tag = new object[2] { "Library", Files[i] };
                    FileList.Items.Add(NewItem);
                }
            }
            else if(this._View == LibraryViewType.Assets)
            {
                FileList.Items.Clear();
                int Index = Convert.ToInt32(Tree.SelectedNode.Tag);
                for(int i = 0; i < _Interface.CurrentGame.Assets.Count; i++)
                {
                    if(_Interface.CurrentGame.Assets[i].Type == SceneObjectType.DrawnSceneObject && (Index == -1 || Index == 0 || Index < 6))
                    {
                        DrawnSceneObject DSO = (DrawnSceneObject)_Interface.CurrentGame.Assets[i];
                        if(DSO.Representation.Type == DrawObjectType.Actor && (Index == -1 || Index == 0))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 0);
                            NewListViewItem.Tag = new object[] {"Asset", i};
                            FileList.Items.Add(NewListViewItem);
                        }
                        else if (DSO.Representation.Type == DrawObjectType.Camera && (Index == -1 || Index == 1))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 1);
                            NewListViewItem.Tag = new object[] { "Asset", i };
                            FileList.Items.Add(NewListViewItem);
                        }
                        else if (DSO.Representation.Type == DrawObjectType.Light && (Index == -1 || Index == 2))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 2);
                            NewListViewItem.Tag = new object[] { "Asset", i };
                            FileList.Items.Add(NewListViewItem);
                        }
                        else if (DSO.Representation.Type == DrawObjectType.Background && (Index == -1 || Index == 3))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 3);
                            NewListViewItem.Tag = new object[] { "Asset", i };
                            FileList.Items.Add(NewListViewItem);
                        }
                        else if (DSO.Representation.Type == DrawObjectType.Sprite && (Index == -1 || Index == 4))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 4);
                            NewListViewItem.Tag = new object[] { "Asset", i };
                            FileList.Items.Add(NewListViewItem);
                        }
                        else if (DSO.Representation.Type == DrawObjectType.Figure && (Index == -1 || Index == 5))
                        {
                            ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 5);
                            NewListViewItem.Tag = new object[] { "Asset", i };
                            FileList.Items.Add(NewListViewItem);
                        }
                    }
                    else if (_Interface.CurrentGame.Assets[i].Type == SceneObjectType.ScriptSceneObject && (Index == -1 || Index == 6))
                    {
                        ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 6);
                        NewListViewItem.Tag = new object[] { "Asset", i };
                        FileList.Items.Add(NewListViewItem);
                    }
                    else if (_Interface.CurrentGame.Assets[i].Type == SceneObjectType.SoundSceneObject && (Index == -1 || Index == 7))
                    {
                        ListViewItem NewListViewItem = new ListViewItem(_Interface.CurrentGame.Assets[i].Name, 7);
                        NewListViewItem.Tag = new object[] { "Asset", i };
                        FileList.Items.Add(NewListViewItem);
                    }
                }
            }
        }
        private void contentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            this.SetLibraryView(LibraryViewType.Library);
        }
        private void assetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            this.SetLibraryView(LibraryViewType.Assets);
        }
        private void FileList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (_BlockEvents) return;
            FileList.DoDragDrop(FileList.SelectedItems, DragDropEffects.Copy);
        }
    }
    public enum ContentLibraryType
    {
        Content = 0,
        Assets = 1
    }
}
