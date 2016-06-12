namespace Engineer.Editor
{
    partial class Properties_Scene
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
            this.HolderScene = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderScene
            // 
            this.HolderScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderScene.Location = new System.Drawing.Point(0, 0);
            this.HolderScene.Name = "HolderScene";
            this.HolderScene.Size = new System.Drawing.Size(300, 20);
            this.HolderScene.TabIndex = 0;
            this.HolderScene.Title = "Scene";
            this.HolderScene.Toggled = true;
            this.HolderScene.Resize += new System.EventHandler(this.HolderScene_Resize);
            // 
            // Properties_Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.HolderScene);
            this.Name = "Properties_Scene";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderScene;
    }
}
