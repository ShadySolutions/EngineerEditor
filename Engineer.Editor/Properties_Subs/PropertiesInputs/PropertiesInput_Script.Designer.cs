namespace Engineer.Editor
{
    partial class PropertiesInput_Script
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
            this.Classifier = new Engineer.Editor.EventClassifier();
            this.SuspendLayout();
            // 
            // Classifier
            // 
            this.Classifier.BackColor = System.Drawing.Color.Transparent;
            this.Classifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Classifier.Location = new System.Drawing.Point(100, 0);
            this.Classifier.Name = "Classifier";
            this.Classifier.Size = new System.Drawing.Size(200, 30);
            this.Classifier.TabIndex = 9;
            // 
            // PropertiesInput_Script
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Classifier);
            this.Name = "PropertiesInput_Script";
            this.Controls.SetChildIndex(this.Classifier, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private EventClassifier Classifier;
    }
}
