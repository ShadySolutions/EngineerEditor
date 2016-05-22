namespace Engineer.Editor
{
    partial class Properties_Script
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
            this.HolderScript = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderScript
            // 
            this.HolderScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderScript.Location = new System.Drawing.Point(0, 0);
            this.HolderScript.Name = "HolderScript";
            this.HolderScript.Size = new System.Drawing.Size(300, 20);
            this.HolderScript.TabIndex = 0;
            this.HolderScript.Title = "Script";
            this.HolderScript.Toggled = true;
            this.HolderScript.Resize += new System.EventHandler(this.HolderScript_Resize);
            // 
            // Properties_Script
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.HolderScript);
            this.Name = "Properties_Script";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderScript;
    }
}
