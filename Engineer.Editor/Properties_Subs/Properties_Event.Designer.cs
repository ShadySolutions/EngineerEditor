namespace Engineer.Editor
{
    partial class Properties_Event
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
            this.HolderEvent = new Engineer.Editor.PropertiesHolder();
            this.SuspendLayout();
            // 
            // HolderEvent
            // 
            this.HolderEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HolderEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HolderEvent.Location = new System.Drawing.Point(0, 0);
            this.HolderEvent.Name = "HolderEvent";
            this.HolderEvent.Size = new System.Drawing.Size(300, 20);
            this.HolderEvent.TabIndex = 0;
            this.HolderEvent.Title = "Title";
            this.HolderEvent.Toggled = true;
            this.HolderEvent.Resize += new System.EventHandler(this.HolderEvent_Resize);
            // 
            // Properties_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.HolderEvent);
            this.Name = "Properties_Event";
            this.Size = new System.Drawing.Size(300, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesHolder HolderEvent;
    }
}
