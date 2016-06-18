﻿namespace Engineer.Editor
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
            this.HolderActor = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderActor
            // 
            this.HolderActor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderActor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderActor.Location = new System.Drawing.Point(0, 0);
            this.HolderActor.Name = "HolderActor";
            this.HolderActor.Size = new System.Drawing.Size(300, 20);
            this.HolderActor.TabIndex = 1;
            this.HolderActor.Title = "Actor";
            this.HolderActor.Toggled = true;
            this.HolderActor.Resize += new System.EventHandler(this.HolderActor_Resize);
            // 
            // Properties_Actor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.HolderActor);
            this.Name = "Properties_Actor";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderActor;
    }
}
