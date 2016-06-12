namespace Engineer.Editor
{
    partial class Properties_DrawObject
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
            this.HolderDraw = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderDraw
            // 
            this.HolderDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderDraw.Location = new System.Drawing.Point(0, 0);
            this.HolderDraw.Name = "HolderDraw";
            this.HolderDraw.Size = new System.Drawing.Size(300, 20);
            this.HolderDraw.TabIndex = 0;
            this.HolderDraw.Title = "DrawObject";
            this.HolderDraw.Toggled = true;
            this.HolderDraw.Resize += new System.EventHandler(this.HolderDraw_Resize);
            // 
            // Properties_DrawObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.HolderDraw);
            this.Name = "Properties_DrawObject";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderDraw;
    }
}
