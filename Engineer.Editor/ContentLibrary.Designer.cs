namespace Engineer.Editor
{
    partial class ContentLibrary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentLibrary));
            this.MenuLine = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitMain = new System.Windows.Forms.SplitContainer();
            this.Tree = new System.Windows.Forms.TreeView();
            this.FolderIcons = new System.Windows.Forms.ImageList(this.components);
            this.FileList = new System.Windows.Forms.ListView();
            this.LibraryThumbs = new System.Windows.Forms.ImageList(this.components);
            this.AssetsThumbs = new System.Windows.Forms.ImageList(this.components);
            this.ContentPanel.SuspendLayout();
            this.MenuLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitMain)).BeginInit();
            this.SplitMain.Panel1.SuspendLayout();
            this.SplitMain.Panel2.SuspendLayout();
            this.SplitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.SplitMain);
            this.ContentPanel.Controls.Add(this.MenuLine);
            // 
            // MenuLine
            // 
            this.MenuLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MenuLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.MenuLine.Location = new System.Drawing.Point(0, 0);
            this.MenuLine.Name = "MenuLine";
            this.MenuLine.Size = new System.Drawing.Size(490, 24);
            this.MenuLine.TabIndex = 0;
            this.MenuLine.Text = "MenuLine";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentToolStripMenuItem,
            this.assetsToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // contentToolStripMenuItem
            // 
            this.contentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.contentToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
            this.contentToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.contentToolStripMenuItem.Text = "Content";
            this.contentToolStripMenuItem.Click += new System.EventHandler(this.contentToolStripMenuItem_Click);
            // 
            // assetsToolStripMenuItem
            // 
            this.assetsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.assetsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.assetsToolStripMenuItem.Name = "assetsToolStripMenuItem";
            this.assetsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.assetsToolStripMenuItem.Text = "Assets";
            this.assetsToolStripMenuItem.Click += new System.EventHandler(this.assetsToolStripMenuItem_Click);
            // 
            // SplitMain
            // 
            this.SplitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitMain.Location = new System.Drawing.Point(0, 24);
            this.SplitMain.Name = "SplitMain";
            // 
            // SplitMain.Panel1
            // 
            this.SplitMain.Panel1.Controls.Add(this.Tree);
            this.SplitMain.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // SplitMain.Panel2
            // 
            this.SplitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SplitMain.Panel2.Controls.Add(this.FileList);
            this.SplitMain.Panel2.ForeColor = System.Drawing.Color.White;
            this.SplitMain.Size = new System.Drawing.Size(490, 346);
            this.SplitMain.SplitterDistance = 243;
            this.SplitMain.TabIndex = 1;
            // 
            // Tree
            // 
            this.Tree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.ForeColor = System.Drawing.Color.White;
            this.Tree.FullRowSelect = true;
            this.Tree.ImageIndex = 0;
            this.Tree.ImageList = this.FolderIcons;
            this.Tree.Location = new System.Drawing.Point(0, 0);
            this.Tree.Name = "Tree";
            this.Tree.SelectedImageIndex = 0;
            this.Tree.Size = new System.Drawing.Size(243, 346);
            this.Tree.TabIndex = 0;
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
            // 
            // FolderIcons
            // 
            this.FolderIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FolderIcons.ImageStream")));
            this.FolderIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.FolderIcons.Images.SetKeyName(0, "Folder.png");
            // 
            // FileList
            // 
            this.FileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.ForeColor = System.Drawing.Color.White;
            this.FileList.LargeImageList = this.LibraryThumbs;
            this.FileList.Location = new System.Drawing.Point(0, 0);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(243, 346);
            this.FileList.TabIndex = 0;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.FileList_ItemDrag);
            // 
            // LibraryThumbs
            // 
            this.LibraryThumbs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LibraryThumbs.ImageStream")));
            this.LibraryThumbs.TransparentColor = System.Drawing.Color.Transparent;
            this.LibraryThumbs.Images.SetKeyName(0, "File.png");
            this.LibraryThumbs.Images.SetKeyName(1, "FileText.png");
            this.LibraryThumbs.Images.SetKeyName(2, "FileCode.png");
            this.LibraryThumbs.Images.SetKeyName(3, "FileSound.png");
            this.LibraryThumbs.Images.SetKeyName(4, "FilePicture.png");
            this.LibraryThumbs.Images.SetKeyName(5, "File3D.png");
            // 
            // AssetsThumbs
            // 
            this.AssetsThumbs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AssetsThumbs.ImageStream")));
            this.AssetsThumbs.TransparentColor = System.Drawing.Color.Transparent;
            this.AssetsThumbs.Images.SetKeyName(0, "Object.png");
            this.AssetsThumbs.Images.SetKeyName(1, "Camera.png");
            this.AssetsThumbs.Images.SetKeyName(2, "Light.png");
            this.AssetsThumbs.Images.SetKeyName(3, "Background.png");
            this.AssetsThumbs.Images.SetKeyName(4, "Sprite.png");
            this.AssetsThumbs.Images.SetKeyName(5, "Actor.png");
            this.AssetsThumbs.Images.SetKeyName(6, "Event.png");
            this.AssetsThumbs.Images.SetKeyName(7, "Sound.png");
            // 
            // ContentLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MainMenuStrip = this.MenuLine;
            this.MaximiseVisible = true;
            this.Name = "ContentLibrary";
            this.Text = "Library";
            this.Title = "Content Library";
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.MenuLine.ResumeLayout(false);
            this.MenuLine.PerformLayout();
            this.SplitMain.Panel1.ResumeLayout(false);
            this.SplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitMain)).EndInit();
            this.SplitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuLine;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentToolStripMenuItem;
        private System.Windows.Forms.SplitContainer SplitMain;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ImageList FolderIcons;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.ImageList LibraryThumbs;
        private System.Windows.Forms.ImageList AssetsThumbs;
    }
}