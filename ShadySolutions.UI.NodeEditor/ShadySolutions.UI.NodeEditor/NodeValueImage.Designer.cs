namespace ShadySolutions.UI.NodeEditor
{
    partial class NodeValueImage
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
            this.ValueImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ValueImage
            // 
            this.ValueImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueImage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueImage.ForeColor = System.Drawing.Color.Transparent;
            this.ValueImage.Location = new System.Drawing.Point(105, 0);
            this.ValueImage.Name = "ValueImage";
            this.ValueImage.Size = new System.Drawing.Size(75, 20);
            this.ValueImage.TabIndex = 3;
            this.ValueImage.Text = "No Image";
            this.ValueImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ValueImage.Click += new System.EventHandler(this.ValueImage_Click);
            // 
            // NodeValueImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueImage);
            this.Name = "NodeValueImage";
            this.Controls.SetChildIndex(this.ValueImage, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ValueImage;
    }
}
