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
            this.Panel_ScriptCode = new System.Windows.Forms.Panel();
            this.Button_ScriptCode = new System.Windows.Forms.Button();
            this.Label_ScriptCode = new System.Windows.Forms.Label();
            this.ToggleHeader = new System.Windows.Forms.Button();
            this.Panel_ScriptCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_ScriptCode
            // 
            this.Panel_ScriptCode.BackColor = System.Drawing.Color.Transparent;
            this.Panel_ScriptCode.Controls.Add(this.Button_ScriptCode);
            this.Panel_ScriptCode.Controls.Add(this.Label_ScriptCode);
            this.Panel_ScriptCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_ScriptCode.Location = new System.Drawing.Point(0, 24);
            this.Panel_ScriptCode.Name = "Panel_ScriptCode";
            this.Panel_ScriptCode.Size = new System.Drawing.Size(320, 30);
            this.Panel_ScriptCode.TabIndex = 4;
            // 
            // Button_ScriptCode
            // 
            this.Button_ScriptCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_ScriptCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_ScriptCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_ScriptCode.ForeColor = System.Drawing.Color.White;
            this.Button_ScriptCode.Location = new System.Drawing.Point(100, 5);
            this.Button_ScriptCode.Name = "Button_ScriptCode";
            this.Button_ScriptCode.Size = new System.Drawing.Size(220, 25);
            this.Button_ScriptCode.TabIndex = 1;
            this.Button_ScriptCode.Text = "Edit";
            this.Button_ScriptCode.UseVisualStyleBackColor = false;
            this.Button_ScriptCode.Click += new System.EventHandler(this.Button_ScriptCode_Click);
            // 
            // Label_ScriptCode
            // 
            this.Label_ScriptCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_ScriptCode.ForeColor = System.Drawing.Color.White;
            this.Label_ScriptCode.Location = new System.Drawing.Point(0, 0);
            this.Label_ScriptCode.Name = "Label_ScriptCode";
            this.Label_ScriptCode.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_ScriptCode.Size = new System.Drawing.Size(100, 30);
            this.Label_ScriptCode.TabIndex = 0;
            this.Label_ScriptCode.Text = "Script Code";
            this.Label_ScriptCode.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.ToggleHeader.TabIndex = 5;
            this.ToggleHeader.Text = "Script";
            this.ToggleHeader.UseVisualStyleBackColor = false;
            this.ToggleHeader.Click += new System.EventHandler(this.ToggleHeader_Click);
            // 
            // Properties_Script
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.Panel_ScriptCode);
            this.Controls.Add(this.ToggleHeader);
            this.Name = "Properties_Script";
            this.Size = new System.Drawing.Size(320, 56);
            this.Panel_ScriptCode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_ScriptCode;
        private System.Windows.Forms.Button Button_ScriptCode;
        private System.Windows.Forms.Label Label_ScriptCode;
        private System.Windows.Forms.Button ToggleHeader;
    }
}
