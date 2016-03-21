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
            this.ToggleHeader = new System.Windows.Forms.Button();
            this.Panel_Name = new System.Windows.Forms.Panel();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Value_Name = new System.Windows.Forms.TextBox();
            this.Panel_ID = new System.Windows.Forms.Panel();
            this.Label_ID = new System.Windows.Forms.Label();
            this.Value_ID = new System.Windows.Forms.Label();
            this.Panel_SceneObjectType = new System.Windows.Forms.Panel();
            this.Value_SceneObjectType = new System.Windows.Forms.Label();
            this.Label_SceneObjectType = new System.Windows.Forms.Label();
            this.Panel_Name.SuspendLayout();
            this.Panel_ID.SuspendLayout();
            this.Panel_SceneObjectType.SuspendLayout();
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
            this.ToggleHeader.TabIndex = 0;
            this.ToggleHeader.Text = "SceneObject";
            this.ToggleHeader.UseVisualStyleBackColor = false;
            this.ToggleHeader.Click += new System.EventHandler(this.ToggleHeader_Click);
            // 
            // Panel_Name
            // 
            this.Panel_Name.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Name.Controls.Add(this.Value_Name);
            this.Panel_Name.Controls.Add(this.Label_Name);
            this.Panel_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Name.Location = new System.Drawing.Point(0, 24);
            this.Panel_Name.Name = "Panel_Name";
            this.Panel_Name.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_Name.Size = new System.Drawing.Size(320, 30);
            this.Panel_Name.TabIndex = 3;
            // 
            // Label_Name
            // 
            this.Label_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Name.ForeColor = System.Drawing.Color.White;
            this.Label_Name.Location = new System.Drawing.Point(0, 0);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Name.Size = new System.Drawing.Size(100, 30);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name";
            this.Label_Name.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Value_Name
            // 
            this.Value_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Value_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value_Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Name.ForeColor = System.Drawing.Color.White;
            this.Value_Name.Location = new System.Drawing.Point(100, 17);
            this.Value_Name.Name = "Value_Name";
            this.Value_Name.Size = new System.Drawing.Size(210, 13);
            this.Value_Name.TabIndex = 1;
            this.Value_Name.TextChanged += new System.EventHandler(this.Value_Name_TextChanged);
            // 
            // Panel_ID
            // 
            this.Panel_ID.BackColor = System.Drawing.Color.Transparent;
            this.Panel_ID.Controls.Add(this.Value_ID);
            this.Panel_ID.Controls.Add(this.Label_ID);
            this.Panel_ID.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_ID.Location = new System.Drawing.Point(0, 54);
            this.Panel_ID.Name = "Panel_ID";
            this.Panel_ID.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_ID.Size = new System.Drawing.Size(320, 30);
            this.Panel_ID.TabIndex = 4;
            // 
            // Label_ID
            // 
            this.Label_ID.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_ID.ForeColor = System.Drawing.Color.White;
            this.Label_ID.Location = new System.Drawing.Point(0, 0);
            this.Label_ID.Name = "Label_ID";
            this.Label_ID.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_ID.Size = new System.Drawing.Size(100, 30);
            this.Label_ID.TabIndex = 0;
            this.Label_ID.Text = "ID";
            this.Label_ID.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Value_ID
            // 
            this.Value_ID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_ID.ForeColor = System.Drawing.Color.White;
            this.Value_ID.Location = new System.Drawing.Point(100, 0);
            this.Value_ID.Name = "Value_ID";
            this.Value_ID.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Value_ID.Size = new System.Drawing.Size(210, 30);
            this.Value_ID.TabIndex = 1;
            this.Value_ID.Text = "ID";
            this.Value_ID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Panel_SceneObjectType
            // 
            this.Panel_SceneObjectType.BackColor = System.Drawing.Color.Transparent;
            this.Panel_SceneObjectType.Controls.Add(this.Value_SceneObjectType);
            this.Panel_SceneObjectType.Controls.Add(this.Label_SceneObjectType);
            this.Panel_SceneObjectType.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_SceneObjectType.Location = new System.Drawing.Point(0, 84);
            this.Panel_SceneObjectType.Name = "Panel_SceneObjectType";
            this.Panel_SceneObjectType.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_SceneObjectType.Size = new System.Drawing.Size(320, 30);
            this.Panel_SceneObjectType.TabIndex = 5;
            // 
            // Value_SceneObjectType
            // 
            this.Value_SceneObjectType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_SceneObjectType.ForeColor = System.Drawing.Color.White;
            this.Value_SceneObjectType.Location = new System.Drawing.Point(100, 0);
            this.Value_SceneObjectType.Name = "Value_SceneObjectType";
            this.Value_SceneObjectType.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Value_SceneObjectType.Size = new System.Drawing.Size(210, 30);
            this.Value_SceneObjectType.TabIndex = 1;
            this.Value_SceneObjectType.Text = "Type";
            this.Value_SceneObjectType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Label_SceneObjectType
            // 
            this.Label_SceneObjectType.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_SceneObjectType.ForeColor = System.Drawing.Color.White;
            this.Label_SceneObjectType.Location = new System.Drawing.Point(0, 0);
            this.Label_SceneObjectType.Name = "Label_SceneObjectType";
            this.Label_SceneObjectType.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_SceneObjectType.Size = new System.Drawing.Size(100, 30);
            this.Label_SceneObjectType.TabIndex = 0;
            this.Label_SceneObjectType.Text = "Scene Object Type";
            this.Label_SceneObjectType.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Properties_SceneObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.Panel_SceneObjectType);
            this.Controls.Add(this.Panel_ID);
            this.Controls.Add(this.Panel_Name);
            this.Controls.Add(this.ToggleHeader);
            this.Name = "Properties_SceneObject";
            this.Size = new System.Drawing.Size(320, 126);
            this.Panel_Name.ResumeLayout(false);
            this.Panel_Name.PerformLayout();
            this.Panel_ID.ResumeLayout(false);
            this.Panel_SceneObjectType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ToggleHeader;
        private System.Windows.Forms.Panel Panel_Name;
        private System.Windows.Forms.TextBox Value_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Panel Panel_ID;
        private System.Windows.Forms.Label Value_ID;
        private System.Windows.Forms.Label Label_ID;
        private System.Windows.Forms.Panel Panel_SceneObjectType;
        private System.Windows.Forms.Label Value_SceneObjectType;
        private System.Windows.Forms.Label Label_SceneObjectType;
    }
}
