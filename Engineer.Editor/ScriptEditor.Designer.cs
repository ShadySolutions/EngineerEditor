namespace Engineer.Editor
{
    partial class ScriptEditor
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
            this.CodeEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyPressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mousePressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseWheelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onEverySecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.CodeEditor);
            this.ContentPanel.Controls.Add(this.menuStrip1);
            this.ContentPanel.Size = new System.Drawing.Size(636, 548);
            // 
            // CodeEditor
            // 
            this.CodeEditor.BackColor = System.Drawing.Color.Black;
            this.CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeEditor.EnableFolding = false;
            this.CodeEditor.ForeColor = System.Drawing.Color.White;
            this.CodeEditor.IsReadOnly = false;
            this.CodeEditor.Location = new System.Drawing.Point(0, 24);
            this.CodeEditor.Name = "CodeEditor";
            this.CodeEditor.ShowLineNumbers = false;
            this.CodeEditor.ShowMatchingBracket = false;
            this.CodeEditor.ShowVRuler = false;
            this.CodeEditor.Size = new System.Drawing.Size(636, 524);
            this.CodeEditor.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(636, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem,
            this.standardToolStripMenuItem,
            this.eventToolStripMenuItem});
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.emptyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.emptyToolStripMenuItem.Text = "Empty";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.standardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.eventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem1,
            this.formToolStripMenuItem,
            this.keyboardToolStripMenuItem,
            this.mouseToolStripMenuItem});
            this.eventToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eventToolStripMenuItem.Text = "Event";
            // 
            // standardToolStripMenuItem1
            // 
            this.standardToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.standardToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.standardToolStripMenuItem1.Name = "standardToolStripMenuItem1";
            this.standardToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.standardToolStripMenuItem1.Text = "Standard";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.closingToolStripMenuItem,
            this.onEverySecondToolStripMenuItem,
            this.renderFrameToolStripMenuItem});
            this.formToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.formToolStripMenuItem.Text = "Window";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.loadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // closingToolStripMenuItem
            // 
            this.closingToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closingToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            this.closingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.closingToolStripMenuItem.Text = "Closing";
            // 
            // keyboardToolStripMenuItem
            // 
            this.keyboardToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.keyboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyPressToolStripMenuItem,
            this.keyDownToolStripMenuItem,
            this.keyUpToolStripMenuItem});
            this.keyboardToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            this.keyboardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keyboardToolStripMenuItem.Text = "Keyboard";
            // 
            // keyDownToolStripMenuItem
            // 
            this.keyDownToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.keyDownToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.keyDownToolStripMenuItem.Name = "keyDownToolStripMenuItem";
            this.keyDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keyDownToolStripMenuItem.Text = "KeyDown";
            // 
            // keyUpToolStripMenuItem
            // 
            this.keyUpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.keyUpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.keyUpToolStripMenuItem.Name = "keyUpToolStripMenuItem";
            this.keyUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keyUpToolStripMenuItem.Text = "KeyUp";
            // 
            // keyPressToolStripMenuItem
            // 
            this.keyPressToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.keyPressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.keyPressToolStripMenuItem.Name = "keyPressToolStripMenuItem";
            this.keyPressToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.keyPressToolStripMenuItem.Text = "KeyPress";
            // 
            // mouseToolStripMenuItem
            // 
            this.mouseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mouseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mousePressToolStripMenuItem,
            this.mouseMoveToolStripMenuItem,
            this.mouseDownToolStripMenuItem,
            this.mouseUpToolStripMenuItem,
            this.mouseWheelToolStripMenuItem});
            this.mouseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mouseToolStripMenuItem.Name = "mouseToolStripMenuItem";
            this.mouseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mouseToolStripMenuItem.Text = "Mouse";
            // 
            // mousePressToolStripMenuItem
            // 
            this.mousePressToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mousePressToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mousePressToolStripMenuItem.Name = "mousePressToolStripMenuItem";
            this.mousePressToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mousePressToolStripMenuItem.Text = "MousePress";
            // 
            // mouseMoveToolStripMenuItem
            // 
            this.mouseMoveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mouseMoveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mouseMoveToolStripMenuItem.Name = "mouseMoveToolStripMenuItem";
            this.mouseMoveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mouseMoveToolStripMenuItem.Text = "MouseMove";
            // 
            // mouseDownToolStripMenuItem
            // 
            this.mouseDownToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mouseDownToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mouseDownToolStripMenuItem.Name = "mouseDownToolStripMenuItem";
            this.mouseDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mouseDownToolStripMenuItem.Text = "MouseDown";
            // 
            // mouseUpToolStripMenuItem
            // 
            this.mouseUpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mouseUpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mouseUpToolStripMenuItem.Name = "mouseUpToolStripMenuItem";
            this.mouseUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mouseUpToolStripMenuItem.Text = "MouseUp";
            // 
            // mouseWheelToolStripMenuItem
            // 
            this.mouseWheelToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mouseWheelToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mouseWheelToolStripMenuItem.Name = "mouseWheelToolStripMenuItem";
            this.mouseWheelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mouseWheelToolStripMenuItem.Text = "MouseWheel";
            // 
            // renderFrameToolStripMenuItem
            // 
            this.renderFrameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.renderFrameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.renderFrameToolStripMenuItem.Name = "renderFrameToolStripMenuItem";
            this.renderFrameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.renderFrameToolStripMenuItem.Text = "OnRenderFrame";
            // 
            // onEverySecondToolStripMenuItem
            // 
            this.onEverySecondToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.onEverySecondToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.onEverySecondToolStripMenuItem.Name = "onEverySecondToolStripMenuItem";
            this.onEverySecondToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.onEverySecondToolStripMenuItem.Text = "OnEverySecond";
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 578);
            this.CloseVisible = true;
            this.ControlsVisible = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximiseVisible = true;
            this.Name = "ScriptEditor";
            this.Text = "ScriptEditor";
            this.Title = "Script Editor";
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl CodeEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyPressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mousePressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onEverySecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseWheelToolStripMenuItem;
    }
}