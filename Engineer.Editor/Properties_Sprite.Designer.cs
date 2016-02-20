namespace Engineer.Editor
{
    partial class Properties_Sprite
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
            this.Panel_SpriteSets = new System.Windows.Forms.Panel();
            this.Label_SpriteSets = new System.Windows.Forms.Label();
            this.Button_SpriteSets = new System.Windows.Forms.Button();
            this.Panel_SpriteSets.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_SpriteSets
            // 
            this.Panel_SpriteSets.BackColor = System.Drawing.Color.Transparent;
            this.Panel_SpriteSets.Controls.Add(this.Button_SpriteSets);
            this.Panel_SpriteSets.Controls.Add(this.Label_SpriteSets);
            this.Panel_SpriteSets.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_SpriteSets.Location = new System.Drawing.Point(0, 0);
            this.Panel_SpriteSets.Name = "Panel_SpriteSets";
            this.Panel_SpriteSets.Size = new System.Drawing.Size(320, 30);
            this.Panel_SpriteSets.TabIndex = 2;
            // 
            // Label_SpriteSets
            // 
            this.Label_SpriteSets.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label_SpriteSets.ForeColor = System.Drawing.Color.White;
            this.Label_SpriteSets.Location = new System.Drawing.Point(0, 0);
            this.Label_SpriteSets.Name = "Label_SpriteSets";
            this.Label_SpriteSets.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Label_SpriteSets.Size = new System.Drawing.Size(100, 30);
            this.Label_SpriteSets.TabIndex = 0;
            this.Label_SpriteSets.Text = "Modified";
            this.Label_SpriteSets.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Button_SpriteSets
            // 
            this.Button_SpriteSets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Button_SpriteSets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_SpriteSets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_SpriteSets.ForeColor = System.Drawing.Color.White;
            this.Button_SpriteSets.Location = new System.Drawing.Point(100, 5);
            this.Button_SpriteSets.Name = "Button_SpriteSets";
            this.Button_SpriteSets.Size = new System.Drawing.Size(220, 25);
            this.Button_SpriteSets.TabIndex = 1;
            this.Button_SpriteSets.Text = "Edit";
            this.Button_SpriteSets.UseVisualStyleBackColor = false;
            this.Button_SpriteSets.Click += new System.EventHandler(this.Button_SpriteSets_Click);
            // 
            // Properties_Sprite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.Panel_SpriteSets);
            this.Name = "Properties_Sprite";
            this.Size = new System.Drawing.Size(320, 40);
            this.Load += new System.EventHandler(this.Properties_Sprite_Load);
            this.Panel_SpriteSets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_SpriteSets;
        private System.Windows.Forms.Button Button_SpriteSets;
        private System.Windows.Forms.Label Label_SpriteSets;
    }
}
