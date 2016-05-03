namespace Engineer.Editor
{
    partial class GameWindow
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
            this.Entries = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GameNamePanel = new System.Windows.Forms.Panel();
            this.GameName = new System.Windows.Forms.TextBox();
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Info.SuspendLayout();
            this.GameNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.Entries);
            this.ContentPanel.Controls.Add(this.GameNamePanel);
            this.ContentPanel.Controls.Add(this.Info);
            this.ContentPanel.Size = new System.Drawing.Size(915, 536);
            // 
            // Entries
            // 
            this.Entries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Entries.Location = new System.Drawing.Point(367, 30);
            this.Entries.Name = "Entries";
            this.Entries.Size = new System.Drawing.Size(548, 506);
            this.Entries.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBox1.BackgroundImage = global::Engineer.Editor.Properties.Resources.Splash2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 509);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.pictureBox1);
            this.Info.Controls.Add(this.label1);
            this.Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(367, 536);
            this.Info.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Engineer by Shady Solutions";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameNamePanel
            // 
            this.GameNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.GameNamePanel.Controls.Add(this.GameName);
            this.GameNamePanel.Controls.Add(this.GameNameLabel);
            this.GameNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameNamePanel.Location = new System.Drawing.Point(367, 0);
            this.GameNamePanel.Name = "GameNamePanel";
            this.GameNamePanel.Size = new System.Drawing.Size(548, 30);
            this.GameNamePanel.TabIndex = 3;
            // 
            // GameName
            // 
            this.GameName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.GameName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GameName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GameName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameName.ForeColor = System.Drawing.Color.White;
            this.GameName.Location = new System.Drawing.Point(115, 8);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(433, 22);
            this.GameName.TabIndex = 3;
            this.GameName.Text = "New Project";
            this.GameName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GameName.TextChanged += new System.EventHandler(this.GameName_TextChanged);
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.GameNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.GameNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameNameLabel.ForeColor = System.Drawing.Color.White;
            this.GameNameLabel.Location = new System.Drawing.Point(0, 0);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(115, 30);
            this.GameNameLabel.TabIndex = 2;
            this.GameNameLabel.Text = "Project Name:";
            this.GameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 566);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MaximiseVisible = true;
            this.Name = "GameWindow";
            this.Text = "Game Window";
            this.Title = "Game Window";
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Info.ResumeLayout(false);
            this.GameNamePanel.ResumeLayout(false);
            this.GameNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Entries;
        private System.Windows.Forms.Panel Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GameNamePanel;
        private System.Windows.Forms.TextBox GameName;
        private System.Windows.Forms.Label GameNameLabel;
    }
}