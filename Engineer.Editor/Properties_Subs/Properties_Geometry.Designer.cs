namespace Engineer.Editor
{
    partial class Properties_Geometry
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
            this.HolderGeometry = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderGeometry
            // 
            this.HolderGeometry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderGeometry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderGeometry.Location = new System.Drawing.Point(0, 0);
            this.HolderGeometry.Name = "HolderGeometry";
            this.HolderGeometry.Size = new System.Drawing.Size(300, 20);
            this.HolderGeometry.TabIndex = 1;
            this.HolderGeometry.Title = "Geometry";
            this.HolderGeometry.Toggled = true;
            this.HolderGeometry.Resize += new System.EventHandler(this.HolderGeometry_Resize);
            // 
            // Properties_Geometry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.HolderGeometry);
            this.Name = "Properties_Geometry";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderGeometry;
    }
}
