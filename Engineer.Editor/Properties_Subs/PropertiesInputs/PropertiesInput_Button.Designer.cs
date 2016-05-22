namespace Engineer.Editor
{
    partial class PropertiesInput_Button
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
            this.ValueButton = new System.Windows.Forms.Button();
            this.Bouncer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ValueButton
            // 
            this.ValueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ValueButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ValueButton.FlatAppearance.BorderSize = 0;
            this.ValueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ValueButton.ForeColor = System.Drawing.Color.White;
            this.ValueButton.Location = new System.Drawing.Point(100, 5);
            this.ValueButton.Name = "ValueButton";
            this.ValueButton.Size = new System.Drawing.Size(175, 25);
            this.ValueButton.TabIndex = 9;
            this.ValueButton.Text = "Text";
            this.ValueButton.UseVisualStyleBackColor = false;
            // 
            // Bouncer
            // 
            this.Bouncer.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bouncer.Location = new System.Drawing.Point(275, 0);
            this.Bouncer.Name = "Bouncer";
            this.Bouncer.Size = new System.Drawing.Size(25, 30);
            this.Bouncer.TabIndex = 10;
            // 
            // PropertiesInput_Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueButton);
            this.Controls.Add(this.Bouncer);
            this.Name = "PropertiesInput_Button";
            this.Controls.SetChildIndex(this.Bouncer, 0);
            this.Controls.SetChildIndex(this.ValueButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ValueButton;
        private System.Windows.Forms.Label Bouncer;
    }
}
