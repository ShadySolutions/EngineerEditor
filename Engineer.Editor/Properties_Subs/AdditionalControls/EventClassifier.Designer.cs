namespace Engineer.Editor
{
    partial class EventClassifier
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
            this.TypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TypeLabel
            // 
            this.TypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.ForeColor = System.Drawing.Color.Red;
            this.TypeLabel.Location = new System.Drawing.Point(0, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(300, 30);
            this.TypeLabel.TabIndex = 0;
            this.TypeLabel.Text = "Unknown Event";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // EventClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TypeLabel);
            this.Name = "EventClassifier";
            this.Size = new System.Drawing.Size(300, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TypeLabel;
    }
}
