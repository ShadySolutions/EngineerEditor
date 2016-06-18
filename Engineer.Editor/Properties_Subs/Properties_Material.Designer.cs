namespace Engineer.Editor
{
    partial class Properties_Material
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
            this.HolderMaterial = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderMaterial
            // 
            this.HolderMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderMaterial.Location = new System.Drawing.Point(0, 0);
            this.HolderMaterial.Name = "HolderMaterial";
            this.HolderMaterial.Size = new System.Drawing.Size(300, 20);
            this.HolderMaterial.TabIndex = 2;
            this.HolderMaterial.Title = "Material Name";
            this.HolderMaterial.Toggled = true;
            this.HolderMaterial.Resize += new System.EventHandler(this.HolderMaterial_Resize);
            // 
            // Properties_Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.HolderMaterial);
            this.Name = "Properties_Material";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderMaterial;
    }
}
