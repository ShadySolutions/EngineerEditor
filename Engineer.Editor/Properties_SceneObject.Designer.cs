﻿namespace Engineer.Editor
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
            this.Panel_Active = new System.Windows.Forms.Panel();
            this.Value_Active = new System.Windows.Forms.CheckBox();
            this.Label_Active = new System.Windows.Forms.Label();
            this.Panel_Name = new System.Windows.Forms.Panel();
            this.Value_Name = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Panel_Translation = new System.Windows.Forms.Panel();
            this.Value_Translation = new Engineer.Editor.VertexControl();
            this.Label_Translation = new System.Windows.Forms.Label();
            this.Panel_Rotation = new System.Windows.Forms.Panel();
            this.Value_Rotation = new Engineer.Editor.VertexControl();
            this.Label_Rotation = new System.Windows.Forms.Label();
            this.Panel_Scale = new System.Windows.Forms.Panel();
            this.Value_Scale = new Engineer.Editor.VertexControl();
            this.Label_Scale = new System.Windows.Forms.Label();
            this.Panel_Active.SuspendLayout();
            this.Panel_Name.SuspendLayout();
            this.Panel_Translation.SuspendLayout();
            this.Panel_Rotation.SuspendLayout();
            this.Panel_Scale.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Active
            // 
            this.Panel_Active.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Active.Controls.Add(this.Value_Active);
            this.Panel_Active.Controls.Add(this.Label_Active);
            this.Panel_Active.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Active.Location = new System.Drawing.Point(0, 30);
            this.Panel_Active.Name = "Panel_Active";
            this.Panel_Active.Size = new System.Drawing.Size(320, 30);
            this.Panel_Active.TabIndex = 0;
            // 
            // Value_Active
            // 
            this.Value_Active.AutoSize = true;
            this.Value_Active.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Active.Location = new System.Drawing.Point(100, 16);
            this.Value_Active.Name = "Value_Active";
            this.Value_Active.Size = new System.Drawing.Size(220, 14);
            this.Value_Active.TabIndex = 1;
            this.Value_Active.UseVisualStyleBackColor = true;
            this.Value_Active.CheckedChanged += new System.EventHandler(this.Value_Active_CheckedChanged);
            // 
            // Label_Active
            // 
            this.Label_Active.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Active.ForeColor = System.Drawing.Color.White;
            this.Label_Active.Location = new System.Drawing.Point(0, 0);
            this.Label_Active.Name = "Label_Active";
            this.Label_Active.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Active.Size = new System.Drawing.Size(100, 30);
            this.Label_Active.TabIndex = 0;
            this.Label_Active.Text = "Active";
            this.Label_Active.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Panel_Name
            // 
            this.Panel_Name.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Name.Controls.Add(this.Value_Name);
            this.Panel_Name.Controls.Add(this.Label_Name);
            this.Panel_Name.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Name.Location = new System.Drawing.Point(0, 0);
            this.Panel_Name.Name = "Panel_Name";
            this.Panel_Name.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_Name.Size = new System.Drawing.Size(320, 30);
            this.Panel_Name.TabIndex = 1;
            // 
            // Value_Name
            // 
            this.Value_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Value_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value_Name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value_Name.ForeColor = System.Drawing.Color.White;
            this.Value_Name.Location = new System.Drawing.Point(100, 6);
            this.Value_Name.Name = "Value_Name";
            this.Value_Name.ReadOnly = true;
            this.Value_Name.Size = new System.Drawing.Size(210, 24);
            this.Value_Name.TabIndex = 1;
            this.Value_Name.TextChanged += new System.EventHandler(this.Value_Name_TextChanged);
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
            // Panel_Translation
            // 
            this.Panel_Translation.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Translation.Controls.Add(this.Value_Translation);
            this.Panel_Translation.Controls.Add(this.Label_Translation);
            this.Panel_Translation.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Translation.Location = new System.Drawing.Point(0, 60);
            this.Panel_Translation.Name = "Panel_Translation";
            this.Panel_Translation.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_Translation.Size = new System.Drawing.Size(320, 30);
            this.Panel_Translation.TabIndex = 2;
            // 
            // Value_Translation
            // 
            this.Value_Translation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Translation.Location = new System.Drawing.Point(100, 14);
            this.Value_Translation.Name = "Value_Translation";
            this.Value_Translation.Size = new System.Drawing.Size(210, 16);
            this.Value_Translation.TabIndex = 1;
            // 
            // Label_Translation
            // 
            this.Label_Translation.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Translation.ForeColor = System.Drawing.Color.White;
            this.Label_Translation.Location = new System.Drawing.Point(0, 0);
            this.Label_Translation.Name = "Label_Translation";
            this.Label_Translation.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Translation.Size = new System.Drawing.Size(100, 30);
            this.Label_Translation.TabIndex = 0;
            this.Label_Translation.Text = "Translation";
            this.Label_Translation.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Panel_Rotation
            // 
            this.Panel_Rotation.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Rotation.Controls.Add(this.Value_Rotation);
            this.Panel_Rotation.Controls.Add(this.Label_Rotation);
            this.Panel_Rotation.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Rotation.Location = new System.Drawing.Point(0, 90);
            this.Panel_Rotation.Name = "Panel_Rotation";
            this.Panel_Rotation.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_Rotation.Size = new System.Drawing.Size(320, 30);
            this.Panel_Rotation.TabIndex = 3;
            // 
            // Value_Rotation
            // 
            this.Value_Rotation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Rotation.Location = new System.Drawing.Point(100, 14);
            this.Value_Rotation.Name = "Value_Rotation";
            this.Value_Rotation.Size = new System.Drawing.Size(210, 16);
            this.Value_Rotation.TabIndex = 2;
            // 
            // Label_Rotation
            // 
            this.Label_Rotation.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Rotation.ForeColor = System.Drawing.Color.White;
            this.Label_Rotation.Location = new System.Drawing.Point(0, 0);
            this.Label_Rotation.Name = "Label_Rotation";
            this.Label_Rotation.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Rotation.Size = new System.Drawing.Size(100, 30);
            this.Label_Rotation.TabIndex = 0;
            this.Label_Rotation.Text = "Rotation";
            this.Label_Rotation.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Panel_Scale
            // 
            this.Panel_Scale.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Scale.Controls.Add(this.Value_Scale);
            this.Panel_Scale.Controls.Add(this.Label_Scale);
            this.Panel_Scale.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Scale.Location = new System.Drawing.Point(0, 120);
            this.Panel_Scale.Name = "Panel_Scale";
            this.Panel_Scale.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Panel_Scale.Size = new System.Drawing.Size(320, 30);
            this.Panel_Scale.TabIndex = 4;
            // 
            // Value_Scale
            // 
            this.Value_Scale.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Value_Scale.Location = new System.Drawing.Point(100, 14);
            this.Value_Scale.Name = "Value_Scale";
            this.Value_Scale.Size = new System.Drawing.Size(210, 16);
            this.Value_Scale.TabIndex = 2;
            // 
            // Label_Scale
            // 
            this.Label_Scale.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_Scale.ForeColor = System.Drawing.Color.White;
            this.Label_Scale.Location = new System.Drawing.Point(0, 0);
            this.Label_Scale.Name = "Label_Scale";
            this.Label_Scale.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_Scale.Size = new System.Drawing.Size(100, 30);
            this.Label_Scale.TabIndex = 0;
            this.Label_Scale.Text = "Scale";
            this.Label_Scale.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Properties_SceneObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.Panel_Scale);
            this.Controls.Add(this.Panel_Rotation);
            this.Controls.Add(this.Panel_Translation);
            this.Controls.Add(this.Panel_Active);
            this.Controls.Add(this.Panel_Name);
            this.Name = "Properties_SceneObject";
            this.Size = new System.Drawing.Size(320, 160);
            this.Panel_Active.ResumeLayout(false);
            this.Panel_Active.PerformLayout();
            this.Panel_Name.ResumeLayout(false);
            this.Panel_Name.PerformLayout();
            this.Panel_Translation.ResumeLayout(false);
            this.Panel_Rotation.ResumeLayout(false);
            this.Panel_Scale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Active;
        private System.Windows.Forms.Label Label_Active;
        private System.Windows.Forms.CheckBox Value_Active;
        private System.Windows.Forms.Panel Panel_Name;
        private System.Windows.Forms.TextBox Value_Name;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Panel Panel_Translation;
        private System.Windows.Forms.Label Label_Translation;
        private System.Windows.Forms.Panel Panel_Rotation;
        private System.Windows.Forms.Label Label_Rotation;
        private System.Windows.Forms.Panel Panel_Scale;
        private System.Windows.Forms.Label Label_Scale;
        private VertexControl Value_Translation;
        private VertexControl Value_Rotation;
        private VertexControl Value_Scale;
    }
}
