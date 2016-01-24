using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace TakeOne.WindowSuite
{
    public partial class ToolForm : DockContent
    {
        private bool _Docked = false;
        [Category("TO Specific")]
        public bool Resizable
        {
            get
            {
                return this.Border.ResizeEnabled;
            }
            set
            {
                this.Border.ResizeEnabled = value;
            }
        }
        [Category("TO Specific")]
        public bool ControlsVisible
        {
            get
            {
                return this.TopPanel.ControlsVisible;
            }
            set
            {
                this.TopPanel.ControlsVisible = value;
            }
        }
        [Category("TO Specific")]
        public bool MaximiseVisible
        {
            get
            {
                return this.TopPanel.MaximiseVisible;
            }
            set
            {
                this.TopPanel.MaximiseVisible = value;
            }
        }
        [Category("TO Specific")]
        public bool MinimiseVisible
        {
            get
            {
                return this.TopPanel.MinimiseVisible;
            }
            set
            {
                this.TopPanel.MinimiseVisible = value;
            }
        }
        [Category("TO Specific")]
        public bool CloseVisible
        {
            get
            {
                return this.TopPanel.CloseVisible;
            }
            set
            {
                this.TopPanel.CloseVisible = value;
            }
        }
        [Category("TO Specific")]
        public bool IconVisible
        {
            get
            {
                return this.TopPanel.IconVisible;
            }
            set
            {
                this.TopPanel.IconVisible = value;
            }
        }
        [Category("TO Specific")]
        public string Title
        {
            get
            {
                return this.TopPanel.Title;
            }
            set
            {
                this.TopPanel.Title = value;
            }
        }
        [Category("TO Specific")]
        public Font TitleFont
        {
            get
            {
                return this.TopPanel.TitleFont;
            }
            set
            {
                this.TopPanel.TitleFont = value;
            }
        }
        [Category("TO Specific")]
        public Image IconImage
        {
            get
            {
                return this.TopPanel.IconImage;
            }
            set
            {
                this.TopPanel.IconImage = value;
            }
        }    
        public ToolForm()
        {
            InitializeComponent();
            ChangeLayout(true);
            ChangeLayout(false);
            TopPanel.WindowStateChange += new WindowStateChanged(FormWindowStateChanged);
            if (this.Parent == null) this.ShowInTaskbar = true;
        }
        protected void SetTitle(string Title)
        {
            this.TopPanel.Title = Title;
        }
        public void SetPermanent()
        {
            this.FormClosing += new FormClosingEventHandler(Window_FormClosing);
        }
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }
        private void ChangeLayout(bool MdiActive)
        {
            if (MdiActive)
            {
                this.Controls.Clear();
                this.Controls.Add(ContentPanel);
            }
            else
            {
                this.Controls.Clear();
                Border.ContentControls.Clear();
                Border.ContentControls.Add(TopPanel);
                TopPanel.SetReferenceParent(this);
                TopPanel.MinimiseVisible = false;
                Border.ContentControls.Add(ContentPanel);
                this.Controls.Add(Border);
                ContentPanel.BringToFront();
                if (this.DockHandler.Pane != null)
                {
                    Border.SetReferenceParent(this.DockHandler.Pane.FloatWindow);
                    this.DockHandler.Pane.FloatWindow.MaximumSize = this.MaximumSize;
                    this.DockHandler.Pane.FloatWindow.MinimumSize = this.MinimumSize;
                    this.DockHandler.Pane.FloatWindow.Size = this.Size;
                    this.DockHandler.Pane.FloatWindow.Resize += new EventHandler(ResizeCall);
                    this.DockHandler.Pane.FloatWindow.StartPosition = FormStartPosition.CenterScreen;
                }
                else Border.SetReferenceParent(this);
            }
        }
        private void FormWindowStateChanged(object sender, System.Windows.Forms.FormWindowState NewState)
        {
            if (NewState == FormWindowState.Maximized) Border.ResizeEnabled = false;
            else Border.ResizeEnabled = true;
        }
        private void ResizeCall(object sender, EventArgs e)
        {
            this.OnResize(e);
        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolForm_DockStateChanged(object sender, EventArgs e)
        {
            this._Docked = this.DockState != WeifenLuo.WinFormsUI.Docking.DockState.Float;
            ChangeLayout(this._Docked);
        }
        public void CallCenterToScreen()
        {
            this.CenterToScreen();
        }
    }
}
