namespace Engineer.Editor
{
    partial class SpriteSetEditor
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
            this.EntryPanel = new System.Windows.Forms.Panel();
            this.List = new System.Windows.Forms.ListView();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.Button_AddImages = new System.Windows.Forms.Button();
            this.Button_RemoveImages = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SpriteSetOptionsPanel = new System.Windows.Forms.Panel();
            this.Button_RemoveSpriteSet = new System.Windows.Forms.Button();
            this.Button_AddSpriteSet = new System.Windows.Forms.Button();
            this.TileImages = new System.Windows.Forms.ImageList(this.components);
            this.Update = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SpriteSetOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.splitContainer1);
            this.ContentPanel.Size = new System.Drawing.Size(899, 581);
            // 
            // EntryPanel
            // 
            this.EntryPanel.AutoScroll = true;
            this.EntryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.EntryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntryPanel.Location = new System.Drawing.Point(0, 0);
            this.EntryPanel.Name = "EntryPanel";
            this.EntryPanel.Size = new System.Drawing.Size(542, 545);
            this.EntryPanel.TabIndex = 0;
            // 
            // List
            // 
            this.List.AllowDrop = true;
            this.List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ForeColor = System.Drawing.Color.White;
            this.List.LargeImageList = this.TileImages;
            this.List.Location = new System.Drawing.Point(0, 0);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(353, 545);
            this.List.TabIndex = 1;
            this.List.TileSize = new System.Drawing.Size(120, 120);
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Tile;
            this.List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.List_MouseDown);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.Update);
            this.OptionsPanel.Controls.Add(this.Button_RemoveImages);
            this.OptionsPanel.Controls.Add(this.Button_AddImages);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 545);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(353, 36);
            this.OptionsPanel.TabIndex = 2;
            // 
            // Button_AddImages
            // 
            this.Button_AddImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_AddImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddImages.ForeColor = System.Drawing.Color.White;
            this.Button_AddImages.Location = new System.Drawing.Point(6, 4);
            this.Button_AddImages.Name = "Button_AddImages";
            this.Button_AddImages.Size = new System.Drawing.Size(100, 25);
            this.Button_AddImages.TabIndex = 2;
            this.Button_AddImages.Text = "Add";
            this.Button_AddImages.UseVisualStyleBackColor = false;
            this.Button_AddImages.Click += new System.EventHandler(this.Button_AddImages_Click);
            // 
            // Button_RemoveImages
            // 
            this.Button_RemoveImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_RemoveImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RemoveImages.ForeColor = System.Drawing.Color.White;
            this.Button_RemoveImages.Location = new System.Drawing.Point(112, 4);
            this.Button_RemoveImages.Name = "Button_RemoveImages";
            this.Button_RemoveImages.Size = new System.Drawing.Size(100, 25);
            this.Button_RemoveImages.TabIndex = 3;
            this.Button_RemoveImages.Text = "Remove";
            this.Button_RemoveImages.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.splitContainer1.Panel1.Controls.Add(this.EntryPanel);
            this.splitContainer1.Panel1.Controls.Add(this.SpriteSetOptionsPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.splitContainer1.Panel2.Controls.Add(this.List);
            this.splitContainer1.Panel2.Controls.Add(this.OptionsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(899, 581);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 3;
            // 
            // SpriteSetOptionsPanel
            // 
            this.SpriteSetOptionsPanel.Controls.Add(this.Button_RemoveSpriteSet);
            this.SpriteSetOptionsPanel.Controls.Add(this.Button_AddSpriteSet);
            this.SpriteSetOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SpriteSetOptionsPanel.Location = new System.Drawing.Point(0, 545);
            this.SpriteSetOptionsPanel.Name = "SpriteSetOptionsPanel";
            this.SpriteSetOptionsPanel.Size = new System.Drawing.Size(542, 36);
            this.SpriteSetOptionsPanel.TabIndex = 3;
            // 
            // Button_RemoveSpriteSet
            // 
            this.Button_RemoveSpriteSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_RemoveSpriteSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RemoveSpriteSet.ForeColor = System.Drawing.Color.White;
            this.Button_RemoveSpriteSet.Location = new System.Drawing.Point(112, 4);
            this.Button_RemoveSpriteSet.Name = "Button_RemoveSpriteSet";
            this.Button_RemoveSpriteSet.Size = new System.Drawing.Size(100, 25);
            this.Button_RemoveSpriteSet.TabIndex = 3;
            this.Button_RemoveSpriteSet.Text = "Remove";
            this.Button_RemoveSpriteSet.UseVisualStyleBackColor = false;
            // 
            // Button_AddSpriteSet
            // 
            this.Button_AddSpriteSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_AddSpriteSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddSpriteSet.ForeColor = System.Drawing.Color.White;
            this.Button_AddSpriteSet.Location = new System.Drawing.Point(6, 4);
            this.Button_AddSpriteSet.Name = "Button_AddSpriteSet";
            this.Button_AddSpriteSet.Size = new System.Drawing.Size(100, 25);
            this.Button_AddSpriteSet.TabIndex = 2;
            this.Button_AddSpriteSet.Text = "Add";
            this.Button_AddSpriteSet.UseVisualStyleBackColor = false;
            this.Button_AddSpriteSet.Click += new System.EventHandler(this.Button_AddSpriteSet_Click);
            // 
            // TileImages
            // 
            this.TileImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.TileImages.ImageSize = new System.Drawing.Size(100, 100);
            this.TileImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update.ForeColor = System.Drawing.Color.White;
            this.Update.Location = new System.Drawing.Point(218, 4);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(100, 25);
            this.Update.TabIndex = 4;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // SpriteSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 611);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MaximiseVisible = true;
            this.Name = "SpriteSetEditor";
            this.Text = "SpriteSetEditor";
            this.Title = "SpriteSet";
            this.ContentPanel.ResumeLayout(false);
            this.OptionsPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SpriteSetOptionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EntryPanel;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Button_RemoveImages;
        private System.Windows.Forms.Button Button_AddImages;
        private System.Windows.Forms.Panel SpriteSetOptionsPanel;
        private System.Windows.Forms.Button Button_RemoveSpriteSet;
        private System.Windows.Forms.Button Button_AddSpriteSet;
        private System.Windows.Forms.ImageList TileImages;
        private System.Windows.Forms.Button Update;
    }
}