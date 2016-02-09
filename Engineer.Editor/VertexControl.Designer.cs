namespace Engineer.Editor
{
    partial class VertexControl
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
            this.X = new System.Windows.Forms.NumericUpDown();
            this.Z = new System.Windows.Forms.NumericUpDown();
            this.Y = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
            this.SuspendLayout();
            // 
            // X
            // 
            this.X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.X.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.X.DecimalPlaces = 4;
            this.X.Dock = System.Windows.Forms.DockStyle.Left;
            this.X.ForeColor = System.Drawing.Color.White;
            this.X.Location = new System.Drawing.Point(0, 0);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(120, 16);
            this.X.TabIndex = 0;
            this.X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Z
            // 
            this.Z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Z.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Z.DecimalPlaces = 4;
            this.Z.Dock = System.Windows.Forms.DockStyle.Right;
            this.Z.ForeColor = System.Drawing.Color.White;
            this.Z.Location = new System.Drawing.Point(240, 0);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(120, 16);
            this.Z.TabIndex = 1;
            this.Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Y
            // 
            this.Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Y.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Y.DecimalPlaces = 4;
            this.Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Y.ForeColor = System.Drawing.Color.White;
            this.Y.Location = new System.Drawing.Point(120, 0);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(120, 16);
            this.Y.TabIndex = 2;
            this.Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VertexControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Y);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.X);
            this.Name = "VertexControl";
            this.Size = new System.Drawing.Size(360, 16);
            this.Resize += new System.EventHandler(this.VertexControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown X;
        public System.Windows.Forms.NumericUpDown Z;
        public System.Windows.Forms.NumericUpDown Y;
    }
}
