namespace TakeOne.WindowSuite
{
    partial class ControlResizer
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
            this.ResizerRight = new System.Windows.Forms.Panel();
            this.ResizerLeft = new System.Windows.Forms.Panel();
            this.ResizerDown = new System.Windows.Forms.Panel();
            this.ResizerDownLeft = new System.Windows.Forms.Panel();
            this.ResizerDownRight = new System.Windows.Forms.Panel();
            this.ResizerUp = new System.Windows.Forms.Panel();
            this.ResizerUpLeft = new System.Windows.Forms.Panel();
            this.ResizerUpRight = new System.Windows.Forms.Panel();
            this.Content = new System.Windows.Forms.Panel();
            this.ResizerDown.SuspendLayout();
            this.ResizerUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResizerRight
            // 
            this.ResizerRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResizerRight.Location = new System.Drawing.Point(658, 5);
            this.ResizerRight.Name = "ResizerRight";
            this.ResizerRight.Size = new System.Drawing.Size(5, 578);
            this.ResizerRight.TabIndex = 7;
            this.ResizerRight.Tag = "3";
            this.ResizerRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerLeft
            // 
            this.ResizerLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResizerLeft.Location = new System.Drawing.Point(0, 5);
            this.ResizerLeft.Name = "ResizerLeft";
            this.ResizerLeft.Size = new System.Drawing.Size(5, 578);
            this.ResizerLeft.TabIndex = 6;
            this.ResizerLeft.Tag = "2";
            this.ResizerLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerDown
            // 
            this.ResizerDown.Controls.Add(this.ResizerDownLeft);
            this.ResizerDown.Controls.Add(this.ResizerDownRight);
            this.ResizerDown.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizerDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResizerDown.Location = new System.Drawing.Point(0, 583);
            this.ResizerDown.Name = "ResizerDown";
            this.ResizerDown.Size = new System.Drawing.Size(663, 5);
            this.ResizerDown.TabIndex = 5;
            this.ResizerDown.Tag = "1";
            this.ResizerDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerDownLeft
            // 
            this.ResizerDownLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizerDownLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResizerDownLeft.Location = new System.Drawing.Point(0, 0);
            this.ResizerDownLeft.Name = "ResizerDownLeft";
            this.ResizerDownLeft.Size = new System.Drawing.Size(5, 5);
            this.ResizerDownLeft.TabIndex = 8;
            this.ResizerDownLeft.Tag = "6";
            this.ResizerDownLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerDownLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerDownLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerDownRight
            // 
            this.ResizerDownRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizerDownRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResizerDownRight.Location = new System.Drawing.Point(658, 0);
            this.ResizerDownRight.Name = "ResizerDownRight";
            this.ResizerDownRight.Size = new System.Drawing.Size(5, 5);
            this.ResizerDownRight.TabIndex = 7;
            this.ResizerDownRight.Tag = "7";
            this.ResizerDownRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerDownRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerDownRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerUp
            // 
            this.ResizerUp.Controls.Add(this.ResizerUpLeft);
            this.ResizerUp.Controls.Add(this.ResizerUpRight);
            this.ResizerUp.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizerUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResizerUp.Location = new System.Drawing.Point(0, 0);
            this.ResizerUp.Name = "ResizerUp";
            this.ResizerUp.Size = new System.Drawing.Size(663, 5);
            this.ResizerUp.TabIndex = 4;
            this.ResizerUp.Tag = "0";
            this.ResizerUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerUpLeft
            // 
            this.ResizerUpLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizerUpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResizerUpLeft.Location = new System.Drawing.Point(0, 0);
            this.ResizerUpLeft.Name = "ResizerUpLeft";
            this.ResizerUpLeft.Size = new System.Drawing.Size(5, 5);
            this.ResizerUpLeft.TabIndex = 6;
            this.ResizerUpLeft.Tag = "4";
            this.ResizerUpLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerUpLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerUpLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // ResizerUpRight
            // 
            this.ResizerUpRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizerUpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResizerUpRight.Location = new System.Drawing.Point(658, 0);
            this.ResizerUpRight.Name = "ResizerUpRight";
            this.ResizerUpRight.Size = new System.Drawing.Size(5, 5);
            this.ResizerUpRight.TabIndex = 5;
            this.ResizerUpRight.Tag = "5";
            this.ResizerUpRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseDown);
            this.ResizerUpRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerUpRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resizers_MouseUp);
            // 
            // Content
            // 
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(5, 5);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(653, 578);
            this.Content.TabIndex = 8;
            // 
            // ControlResizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Content);
            this.Controls.Add(this.ResizerRight);
            this.Controls.Add(this.ResizerLeft);
            this.Controls.Add(this.ResizerDown);
            this.Controls.Add(this.ResizerUp);
            this.Name = "ControlResizer";
            this.Size = new System.Drawing.Size(663, 588);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormResize_MouseMove);
            this.ResizerDown.ResumeLayout(false);
            this.ResizerUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ResizerRight;
        private System.Windows.Forms.Panel ResizerLeft;
        private System.Windows.Forms.Panel ResizerDown;
        private System.Windows.Forms.Panel ResizerDownLeft;
        private System.Windows.Forms.Panel ResizerDownRight;
        private System.Windows.Forms.Panel ResizerUp;
        private System.Windows.Forms.Panel ResizerUpLeft;
        private System.Windows.Forms.Panel ResizerUpRight;
        private System.Windows.Forms.Panel Content;
    }
}
