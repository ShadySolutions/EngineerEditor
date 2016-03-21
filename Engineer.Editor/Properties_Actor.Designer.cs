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
            this.Panel_Modified = new System.Windows.Forms.Panel();
            this.Value_Modified = new System.Windows.Forms.CheckBox();
            this.Label_Modified = new System.Windows.Forms.Label();
            this.ToggleHeader = new System.Windows.Forms.Button();
            this.Panel_Modified.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Modified
            // 
            this.Panel_Modified.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Modified.Controls.Add(this.Value_Modified);
            this.Panel_Modified.Controls.Add(this.Label_Modified);
            this.Panel_Modified.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Modified.Location = new System.Drawing.Point(0, 24);
            this.Panel_Modified.Name = "Panel_Modified";
            this.Panel_Modified.Size = new System.Drawing.Size(320, 30);
            this.Panel_Modified.TabIndex = 1;
            this.Panel_Modified.Visible = false;
            // 
            // Value_Modified
            // 
            this.Value_Modified.AutoSize = true;
            this.Value_Modified.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Modified.Location = new System.Drawing.Point(100, 16);
            this.Value_Modified.Name = "Value_Modified";
            this.Value_Modified.Size = new System.Drawing.Size(220, 14);
            this.Value_Modified.TabIndex = 1;
            this.Value_Modified.UseVisualStyleBackColor = true;
            // 
            // Label_Modified
            // 
            this.Label_Modified.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Modified.ForeColor = System.Drawing.Color.White;
            this.Label_Modified.Location = new System.Drawing.Point(0, 0);
            this.Label_Modified.Name = "Label_Modified";
            this.Label_Modified.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Modified.Size = new System.Drawing.Size(100, 30);
            this.Label_Modified.TabIndex = 0;
            this.Label_Modified.Text = "Modified";
            this.Label_Modified.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.Controls.Add(this.Panel_Modified);
            this.Controls.Add(this.ToggleHeader);
            this.Name = "Properties_Actor";
            this.Size = new System.Drawing.Size(320, 62);
            this.Panel_Modified.ResumeLayout(false);
            this.Panel_Modified.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Modified;
        private System.Windows.Forms.CheckBox Value_Modified;
        private System.Windows.Forms.Label Label_Modified;
        private System.Windows.Forms.Button ToggleHeader;
    }
}
