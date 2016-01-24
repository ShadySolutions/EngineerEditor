namespace TakeOne.WindowSuite
{
    partial class WindowHeader
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DockLeft = new System.Windows.Forms.Panel();
            this.DockRight = new System.Windows.Forms.Panel();
            this.DockRightUp = new System.Windows.Forms.Panel();
            this.WindowIcon = new System.Windows.Forms.PictureBox();
            this.Minimise = new System.Windows.Forms.PictureBox();
            this.Maximise = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.DockLeft.SuspendLayout();
            this.DockRight.SuspendLayout();
            this.DockRightUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(45, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(758, 30);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Window Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // DockLeft
            // 
            this.DockLeft.Controls.Add(this.WindowIcon);
            this.DockLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.DockLeft.Location = new System.Drawing.Point(0, 0);
            this.DockLeft.Name = "DockLeft";
            this.DockLeft.Size = new System.Drawing.Size(45, 30);
            this.DockLeft.TabIndex = 6;
            this.DockLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.DockLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.DockLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // DockRight
            // 
            this.DockRight.Controls.Add(this.DockRightUp);
            this.DockRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.DockRight.Location = new System.Drawing.Point(803, 0);
            this.DockRight.Name = "DockRight";
            this.DockRight.Size = new System.Drawing.Size(142, 30);
            this.DockRight.TabIndex = 5;
            this.DockRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.DockRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.DockRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // DockRightUp
            // 
            this.DockRightUp.Controls.Add(this.Minimise);
            this.DockRightUp.Controls.Add(this.Maximise);
            this.DockRightUp.Controls.Add(this.Close);
            this.DockRightUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.DockRightUp.Location = new System.Drawing.Point(0, 0);
            this.DockRightUp.Name = "DockRightUp";
            this.DockRightUp.Size = new System.Drawing.Size(142, 20);
            this.DockRightUp.TabIndex = 4;
            // 
            // WindowIcon
            // 
            this.WindowIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowIcon.Location = new System.Drawing.Point(15, 0);
            this.WindowIcon.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.WindowIcon.Name = "WindowIcon";
            this.WindowIcon.Size = new System.Drawing.Size(30, 30);
            this.WindowIcon.TabIndex = 6;
            this.WindowIcon.TabStop = false;
            this.WindowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.WindowIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseMove);
            this.WindowIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // Minimise
            // 
            this.Minimise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Minimize;
            this.Minimise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Minimise.Dock = System.Windows.Forms.DockStyle.Right;
            this.Minimise.Location = new System.Drawing.Point(2, 0);
            this.Minimise.Name = "Minimise";
            this.Minimise.Size = new System.Drawing.Size(40, 20);
            this.Minimise.TabIndex = 3;
            this.Minimise.TabStop = false;
            this.Minimise.Visible = false;
            this.Minimise.Click += new System.EventHandler(this.Minimise_Click);
            this.Minimise.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.Minimise.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // Maximise
            // 
            this.Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
            this.Maximise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Maximise.Dock = System.Windows.Forms.DockStyle.Right;
            this.Maximise.Location = new System.Drawing.Point(42, 0);
            this.Maximise.Name = "Maximise";
            this.Maximise.Size = new System.Drawing.Size(40, 20);
            this.Maximise.TabIndex = 2;
            this.Maximise.TabStop = false;
            this.Maximise.Visible = false;
            this.Maximise.Click += new System.EventHandler(this.Maximise_Click);
            this.Maximise.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.Maximise.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // Close
            // 
            this.Close.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Close;
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.Location = new System.Drawing.Point(82, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(60, 20);
            this.Close.TabIndex = 1;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            this.Close.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // WindowHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.DockLeft);
            this.Controls.Add(this.DockRight);
            this.Name = "WindowHeader";
            this.Size = new System.Drawing.Size(945, 30);
            this.DockLeft.ResumeLayout(false);
            this.DockRight.ResumeLayout(false);
            this.DockRightUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel DockLeft;
        private System.Windows.Forms.PictureBox WindowIcon;
        private System.Windows.Forms.Panel DockRight;
        private System.Windows.Forms.Panel DockRightUp;
        private System.Windows.Forms.PictureBox Minimise;
        private System.Windows.Forms.PictureBox Maximise;
        private System.Windows.Forms.PictureBox Close;
    }
}
