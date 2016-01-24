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
 
namespace Engineer.Editor
{
    public partial class ContentLibrary : ToolForm
    {
        private int _LibraryVisible;
        private List<string> _LibraryRoot;
        public ContentLibrary()
        {
            InitializeComponent();
            this._LibraryVisible = 0;
            this._LibraryRoot = new List<string>();
            this._LibraryRoot.Add("");
            this._LibraryRoot.Add("");
        }
        public void SetLibraryRoot(string FileRoot, int Index)
        {
            if (!Directory.Exists(FileRoot)) return;
            _LibraryRoot[Index] = FileRoot;
        }
        public void SetLibraryView(int Index)
        {
            Tree.Nodes.Clear();
            this._LibraryVisible = Index;
            if (this._LibraryRoot[Index] == "") return;
            TreeNode MainNode = null;
            if (Index == 0) MainNode = new TreeNode("Content", 0, 0);
            else if (Index == 1) MainNode = new TreeNode("Assets", 0, 0);
            MainNode.Tag = this._LibraryRoot[Index];
            SetElements(MainNode, this._LibraryRoot[Index]);
            Tree.Nodes.Add(MainNode);
            Tree.ExpandAll();
            Tree.SelectedNode = MainNode;
        }
        private void SetElements(TreeNode Node, string FileRoot)
        {
            TreeNode CurrentNode = new TreeNode(new DirectoryInfo(FileRoot).Name, 0, 0);
            CurrentNode.Tag = FileRoot;
            Node.Nodes.Add(CurrentNode);
            string[] Directories = Directory.GetDirectories(FileRoot);
            for (int i = 0; i < Directories.Length; i++) SetElements(CurrentNode, Directories[i]);
        }
        private List<string> GetFiles(List<string> Files, string FileRoot)
        {
            string[] Directories = Directory.GetDirectories(FileRoot);
            string[] CurrentFiles = Directory.GetFiles(FileRoot);
            Files.AddRange(CurrentFiles);
            for (int i = 0; i < Directories.Length; i++) Files = GetFiles(Files, Directories[i]);
            return Files;
        }
        private int FindImageIndex(string FileRoot)
        {
            if (FileRoot.EndsWith(".obj") || FileRoot.EndsWith(".htr") || FileRoot.EndsWith(".bvh") || FileRoot.EndsWith(".dae") ||
                FileRoot.EndsWith(".fbx") || FileRoot.EndsWith(".pz3") || FileRoot.EndsWith(".c3d"))
                return 5;
            if (FileRoot.EndsWith(".jpg") || FileRoot.EndsWith(".jpeg") || FileRoot.EndsWith(".png") || FileRoot.EndsWith(".bmp") ||
                FileRoot.EndsWith(".ico") || FileRoot.EndsWith(".tiff") || FileRoot.EndsWith(".tga") || FileRoot.EndsWith(".psd"))
                return 4;
            if (FileRoot.EndsWith(".mp3") || FileRoot.EndsWith(".wav"))
                return 3;
            if (FileRoot.EndsWith(".js") || FileRoot.EndsWith(".py") || FileRoot.EndsWith(".cs") || FileRoot.EndsWith(".c") || FileRoot.EndsWith(".cpp"))
                return 2;
            if (FileRoot.EndsWith(".txt") || FileRoot.EndsWith(".config"))
                return 1;
            return 0;
        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FileList.Items.Clear();
            string FileRoot = e.Node.Tag as string;
            List<string> Files = new List<string>();
            Files = GetFiles(Files, FileRoot);
            for(int i = 0; i < Files.Count; i++)
            {
                FileList.Items.Add(new ListViewItem(Path.GetFileName(Files[i]), FindImageIndex(Files[i])));
            }
        }

        private void contentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetLibraryView(0);
        }

        private void assetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetLibraryView(1);
        }
    }
    public enum ContentLibraryType
    {
        Content = 0,
        Assets = 1
    }
}
