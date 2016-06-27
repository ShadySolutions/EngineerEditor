namespace Engineer.Editor
{
    partial class SpriteSetEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.List = new System.Windows.Forms.ListView();
            this.EntryTileList = new System.Windows.Forms.ImageList(this.components);
            this.Name_Panel = new System.Windows.Forms.Panel();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.Name_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.AllowDrop = true;
            this.List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ForeColor = System.Drawing.Color.White;
            this.List.LargeImageList = this.EntryTileList;
            this.List.Location = new System.Drawing.Point(0, 30);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(498, 220);
            this.List.TabIndex = 0;
            this.List.TileSize = new System.Drawing.Size(100, 100);
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Tile;
            this.List.DragDrop += new System.Windows.Forms.DragEventHandler(this.List_DragDrop);
            this.List.DragEnter += new System.Windows.Forms.DragEventHandler(this.SpriteSetEntry_DragEnter);
            // 
            // EntryTileList
            // 
            this.EntryTileList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.EntryTileList.ImageSize = new System.Drawing.Size(100, 100);
            this.EntryTileList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Name_Panel
            // 
            this.Name_Panel.Controls.Add(this.Name_Box);
            this.Name_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Name_Panel.Location = new System.Drawing.Point(0, 0);
            this.Name_Panel.Name = "Name_Panel";
            this.Name_Panel.Size = new System.Drawing.Size(498, 30);
            this.Name_Panel.TabIndex = 1;
            // 
            // Name_Box
            // 
            this.Name_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Name_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Name_Box.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Name_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Box.ForeColor = System.Drawing.Color.White;
            this.Name_Box.Location = new System.Drawing.Point(0, 8);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(498, 22);
            this.Name_Box.TabIndex = 0;
            this.Name_Box.TextChanged += new System.EventHandler(this.Name_Box_TextChanged);
            // 
            // SpriteSetEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.List);
            this.Controls.Add(this.Name_Panel);
            this.Name = "SpriteSetEntry";
            this.Size = new System.Drawing.Size(498, 250);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SpriteSetEntry_DragEnter);
            this.Name_Panel.ResumeLayout(false);
            this.Name_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.Panel Name_Panel;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.ImageList EntryTileList;
    }
}
