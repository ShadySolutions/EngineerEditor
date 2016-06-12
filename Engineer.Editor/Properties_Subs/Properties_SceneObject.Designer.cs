namespace Engineer.Editor
{
    partial class Properties_SceneObject
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
            this.HolderSceneObject = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderSceneObject
            // 
            this.HolderSceneObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderSceneObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.HolderSceneObject.Location = new System.Drawing.Point(0, 0);
            this.HolderSceneObject.Name = "HolderSceneObject";
            this.HolderSceneObject.Size = new System.Drawing.Size(300, 20);
            this.HolderSceneObject.TabIndex = 0;
            this.HolderSceneObject.Title = "SceneObject";
            this.HolderSceneObject.Toggled = true;
            this.HolderSceneObject.Resize += new System.EventHandler(this.HolderSceneObject_Resize);
            // 
            // Properties_SceneObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.HolderSceneObject);
            this.Name = "Properties_SceneObject";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderSceneObject;
    }
}
