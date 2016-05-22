namespace Engineer.Editor
{
    partial class PropertiesInput_Combo
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
            this.ValueCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ValueCombo
            // 
            this.ValueCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ValueCombo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ValueCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ValueCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ValueCombo.ForeColor = System.Drawing.Color.White;
            this.ValueCombo.FormattingEnabled = true;
            this.ValueCombo.Location = new System.Drawing.Point(100, 9);
            this.ValueCombo.Name = "ValueCombo";
            this.ValueCombo.Size = new System.Drawing.Size(200, 21);
            this.ValueCombo.TabIndex = 9;
            // 
            // PropertiesInput_Combo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueCombo);
            this.Name = "PropertiesInput_Combo";
            this.Controls.SetChildIndex(this.ValueCombo, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ValueCombo;
    }
}
