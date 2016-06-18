namespace Engineer.Editor
{
    partial class PropertiesInput_Sprite
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
            this.Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // Preview
            // 
            this.Preview.BackgroundImage = global::Engineer.Editor.Properties.Resources.Disabled;
            this.Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Preview.Dock = System.Windows.Forms.DockStyle.Left;
            this.Preview.Location = new System.Drawing.Point(100, 0);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(100, 100);
            this.Preview.TabIndex = 10;
            this.Preview.TabStop = false;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // PropertiesInput_Sprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Preview);
            this.Name = "PropertiesInput_Sprite";
            this.Size = new System.Drawing.Size(300, 100);
            this.Controls.SetChildIndex(this.Preview, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Preview;
    }
}
