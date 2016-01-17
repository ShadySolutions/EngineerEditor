namespace ShadySolutions.UI.NodeEditor
{
    partial class VectorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.X = new System.Windows.Forms.NumericUpDown();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.NumericUpDown();
            this.ZLabel = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.NumericUpDown();
            this.WLabel = new System.Windows.Forms.Label();
            this.W = new System.Windows.Forms.NumericUpDown();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.W)).BeginInit();
            this.SuspendLayout();
            // 
            // X
            // 
            this.X.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.X.DecimalPlaces = 2;
            this.X.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.Color.White;
            this.X.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.X.Location = new System.Drawing.Point(54, 12);
            this.X.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.X.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(79, 20);
            this.X.TabIndex = 4;
            // 
            // XLabel
            // 
            this.XLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XLabel.ForeColor = System.Drawing.Color.Transparent;
            this.XLabel.Location = new System.Drawing.Point(11, 12);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(37, 20);
            this.XLabel.TabIndex = 6;
            this.XLabel.Text = "X";
            this.XLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // YLabel
            // 
            this.YLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YLabel.ForeColor = System.Drawing.Color.Transparent;
            this.YLabel.Location = new System.Drawing.Point(11, 38);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(37, 20);
            this.YLabel.TabIndex = 8;
            this.YLabel.Text = "Y";
            this.YLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Y
            // 
            this.Y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Y.DecimalPlaces = 2;
            this.Y.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y.ForeColor = System.Drawing.Color.White;
            this.Y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Y.Location = new System.Drawing.Point(54, 38);
            this.Y.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Y.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(79, 20);
            this.Y.TabIndex = 7;
            // 
            // ZLabel
            // 
            this.ZLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ZLabel.Location = new System.Drawing.Point(11, 64);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(37, 20);
            this.ZLabel.TabIndex = 10;
            this.ZLabel.Text = "Z";
            this.ZLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Z
            // 
            this.Z.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Z.DecimalPlaces = 2;
            this.Z.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z.ForeColor = System.Drawing.Color.White;
            this.Z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Z.Location = new System.Drawing.Point(54, 64);
            this.Z.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Z.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(79, 20);
            this.Z.TabIndex = 9;
            // 
            // WLabel
            // 
            this.WLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WLabel.ForeColor = System.Drawing.Color.Transparent;
            this.WLabel.Location = new System.Drawing.Point(11, 90);
            this.WLabel.Name = "WLabel";
            this.WLabel.Size = new System.Drawing.Size(37, 20);
            this.WLabel.TabIndex = 12;
            this.WLabel.Text = "W";
            this.WLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // W
            // 
            this.W.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.W.DecimalPlaces = 2;
            this.W.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.W.ForeColor = System.Drawing.Color.White;
            this.W.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.W.Location = new System.Drawing.Point(54, 90);
            this.W.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.W.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.W.Name = "W";
            this.W.Size = new System.Drawing.Size(79, 20);
            this.W.TabIndex = 11;
            // 
            // OK
            // 
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.Color.White;
            this.OK.Location = new System.Drawing.Point(14, 116);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(119, 24);
            this.OK.TabIndex = 13;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // VectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(148, 152);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.WLabel);
            this.Controls.Add(this.W);
            this.Controls.Add(this.ZLabel);
            this.Controls.Add(this.Z);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VectorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VectorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.W)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown X;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.NumericUpDown Y;
        private System.Windows.Forms.Label ZLabel;
        private System.Windows.Forms.NumericUpDown Z;
        private System.Windows.Forms.Label WLabel;
        private System.Windows.Forms.NumericUpDown W;
        private System.Windows.Forms.Button OK;
    }
}