namespace Engineer.Editor
{
    partial class Properties_Actor
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
            this.ToggleHeader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToggleHeader
            // 
            this.ToggleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ToggleHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToggleHeader.FlatAppearance.BorderSize = 0;
            this.ToggleHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleHeader.ForeColor = System.Drawing.Color.White;
            this.ToggleHeader.Location = new System.Drawing.Point(0, 0);
            this.ToggleHeader.Name = "ToggleHeader";
            this.ToggleHeader.Size = new System.Drawing.Size(320, 24);
            this.ToggleHeader.TabIndex = 4;
            this.ToggleHeader.Text = "Actor";
            this.ToggleHeader.UseVisualStyleBackColor = false;
            this.ToggleHeader.Click += new System.EventHandler(this.ToggleHeader_Click);
            // 
            // Properties_Actor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.ToggleHeader);
            this.Name = "Properties_Actor";
            this.Size = new System.Drawing.Size(320, 62);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ToggleHeader;
    }
}
