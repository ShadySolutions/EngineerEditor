namespace Engineer.Editor
{
    partial class SceneWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneWindow));
            this.SceneTree = new System.Windows.Forms.TreeView();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SetAsCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneIcons = new System.Windows.Forms.ImageList(this.components);
            this.RefreshView = new System.Windows.Forms.Timer(this.components);
            this.ContentPanel.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.SceneTree);
            // 
            // SceneTree
            // 
            this.SceneTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SceneTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SceneTree.ContextMenuStrip = this.ContextMenu;
            this.SceneTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneTree.ForeColor = System.Drawing.Color.White;
            this.SceneTree.ImageIndex = 0;
            this.SceneTree.ImageList = this.SceneIcons;
            this.SceneTree.Location = new System.Drawing.Point(0, 0);
            this.SceneTree.Name = "SceneTree";
            this.SceneTree.SelectedImageIndex = 0;
            this.SceneTree.Size = new System.Drawing.Size(490, 370);
            this.SceneTree.TabIndex = 1;
            this.SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SceneTree_AfterSelect);
            // 
            // ContextMenu
            // 
            this.ContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetAsCurrentToolStripMenuItem,
            this.PropertiesToolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.ContextMenu.Name = "contextMenuStrip1";
            this.ContextMenu.Size = new System.Drawing.Size(148, 70);
            // 
            // SetAsCurrentToolStripMenuItem
            // 
            this.SetAsCurrentToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SetAsCurrentToolStripMenuItem.Image = global::Engineer.Editor.Properties.Resources.SetAsCurrent;
            this.SetAsCurrentToolStripMenuItem.Name = "SetAsCurrentToolStripMenuItem";
            this.SetAsCurrentToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.SetAsCurrentToolStripMenuItem.Text = "Set as Current";
            // 
            // PropertiesToolStripMenuItem1
            // 
            this.PropertiesToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.PropertiesToolStripMenuItem1.Image = global::Engineer.Editor.Properties.Resources.Properties;
            this.PropertiesToolStripMenuItem1.Name = "PropertiesToolStripMenuItem1";
            this.PropertiesToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.PropertiesToolStripMenuItem1.Text = "Properties";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteToolStripMenuItem.Image = global::Engineer.Editor.Properties.Resources.Delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // SceneIcons
            // 
            this.SceneIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SceneIcons.ImageStream")));
            this.SceneIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.SceneIcons.Images.SetKeyName(0, "SceneSmall.png");
            this.SceneIcons.Images.SetKeyName(1, "Object.png");
            this.SceneIcons.Images.SetKeyName(2, "Actor.png");
            this.SceneIcons.Images.SetKeyName(3, "CameraSmall.png");
            this.SceneIcons.Images.SetKeyName(4, "LightSmall.png");
            this.SceneIcons.Images.SetKeyName(5, "SoundSmall.png");
            this.SceneIcons.Images.SetKeyName(6, "SpriteSmall.png");
            this.SceneIcons.Images.SetKeyName(7, "EventSmall.png");
            this.SceneIcons.Images.SetKeyName(8, "CodeSmall.png");
            // 
            // RefreshView
            // 
            this.RefreshView.Enabled = true;
            this.RefreshView.Interval = 1000;
            // 
            // SceneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MaximiseVisible = true;
            this.Name = "SceneWindow";
            this.Text = "Scene";
            this.Title = "Scene";
            this.ContentPanel.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SceneTree;
        private System.Windows.Forms.ImageList SceneIcons;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SetAsCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer RefreshView;
    }
}