using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TakeOne.WindowSuite
{
    public partial class MainForm : Form
    {
        private bool _ResizeEnabled = true;
        private int _OperationIndex = -1;
        private Point _MouseLocation;
        private Point _LocationDifference;
        private Point _SizeDifference;
        private Point _AppliedLocationDifference;
        private Point _AppliedSizeDifference;
        private Control _Parent;
        private ResizeDisplayForm _ActiveResizeDisplayForm;
        private List<object> Settings;
        [Category("TO Specific")]
        public bool Resizable
        {
            get
            {
                return this._ResizeEnabled;
            }
            set
            {
                this._ResizeEnabled = value;
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
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            AutoHideStripSkin autoHideSkin = new AutoHideStripSkin();
            autoHideSkin.DockStripGradient.StartColor = Color.DimGray;
            autoHideSkin.DockStripGradient.EndColor = Color.DimGray;
            autoHideSkin.DockStripGradient.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            autoHideSkin.TabGradient.StartColor = Color.DimGray;
            autoHideSkin.TabGradient.EndColor = Color.DimGray;
            autoHideSkin.TabGradient.TextColor = Color.Red;
            Dock.Skin.AutoHideStripSkin = autoHideSkin;
            DockPaneStripSkin dockPaneSkin = new DockPaneStripSkin();
            dockPaneSkin.ToolWindowGradient.DockStripGradient.StartColor = Color.FromArgb(64, 64, 64);
            dockPaneSkin.ToolWindowGradient.DockStripGradient.EndColor = Color.FromArgb(64, 64, 64);
            dockPaneSkin.ToolWindowGradient.ActiveTabGradient.StartColor = Color.Gray;
            dockPaneSkin.ToolWindowGradient.ActiveTabGradient.EndColor = Color.Gray;
            dockPaneSkin.ToolWindowGradient.ActiveTabGradient.TextColor = Color.White;
            dockPaneSkin.ToolWindowGradient.InactiveTabGradient.StartColor = Color.DimGray;
            dockPaneSkin.ToolWindowGradient.InactiveTabGradient.EndColor = Color.DimGray;
            dockPaneSkin.ToolWindowGradient.InactiveTabGradient.TextColor = Color.White;
            dockPaneSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor = Color.FromArgb(64, 64, 64);
            dockPaneSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor = Color.FromArgb(64, 64, 64);
            dockPaneSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor = Color.White;
            dockPaneSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor = Color.DimGray;
            dockPaneSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor = Color.DimGray;
            dockPaneSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor = Color.White;
            dockPaneSkin.DocumentGradient.DockStripGradient.StartColor = Color.FromArgb(50, 50, 50);
            dockPaneSkin.DocumentGradient.DockStripGradient.EndColor = Color.FromArgb(50, 50, 50);
            dockPaneSkin.DocumentGradient.ActiveTabGradient.StartColor = Color.White;
            dockPaneSkin.DocumentGradient.ActiveTabGradient.EndColor = Color.White;
            dockPaneSkin.DocumentGradient.ActiveTabGradient.TextColor = Color.FromArgb(64, 64, 64);
            dockPaneSkin.DocumentGradient.InactiveTabGradient.StartColor = Color.Gray;
            dockPaneSkin.DocumentGradient.InactiveTabGradient.EndColor = Color.Gray;
            dockPaneSkin.DocumentGradient.InactiveTabGradient.TextColor = Color.White;
            Dock.Skin.DockPaneStripSkin = dockPaneSkin;
            Settings = new List<object>();
            Settings.Add(true);
            this._Parent = this;
        }
        private void Resizers_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this._ResizeEnabled) return;
            Control SenderAsControl = sender as Control;
            this._OperationIndex = Convert.ToInt32(SenderAsControl.Tag);
            this._MouseLocation = new Point(e.X, e.Y);
            this._LocationDifference = new Point();
            this._SizeDifference = new Point();
            this._AppliedLocationDifference = new Point();
            this._ActiveResizeDisplayForm = new ResizeDisplayForm();
            this._ActiveResizeDisplayForm.Location = this._Parent.Location;
            this._ActiveResizeDisplayForm.Size = this._Parent.Size;
            this._ActiveResizeDisplayForm.Show();
        }
        private void Resizers_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this._ResizeEnabled) return;
            this._OperationIndex = -1;
            this._Parent.Location = new Point(this._Parent.Location.X + this._AppliedLocationDifference.X, this._Parent.Location.Y + this._AppliedLocationDifference.Y);
            this._Parent.Size = new Size(this._Parent.Size.Width + this._AppliedSizeDifference.X, this._Parent.Size.Height + this._AppliedSizeDifference.Y);
            this._ActiveResizeDisplayForm.Close();
        }
        private void FormResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_ResizeEnabled) return;
            if (this._OperationIndex == -1) return;
            if (this._OperationIndex == 0)
            {
                this._LocationDifference.Y += (e.Y - _MouseLocation.Y);
                this._SizeDifference.Y -= (e.Y - _MouseLocation.Y);
            }
            if (this._OperationIndex == 1)
            {
                this._SizeDifference.Y += (e.Y - _MouseLocation.Y);
            }
            if (this._OperationIndex == 2)
            {
                this._LocationDifference.X += (e.X - _MouseLocation.X);
                this._SizeDifference.X -= (e.X - _MouseLocation.X);
            }
            if (this._OperationIndex == 3)
            {
                this._SizeDifference.X += (e.X - _MouseLocation.X);
            }
            if (this._OperationIndex == 4)
            {
                this._LocationDifference.Y += (e.Y - _MouseLocation.Y);
                this._SizeDifference.Y -= (e.Y - _MouseLocation.Y);
                this._LocationDifference.X += (e.X - _MouseLocation.X);
                this._SizeDifference.X -= (e.X - _MouseLocation.X);
            }
            if (this._OperationIndex == 5)
            {
                this._LocationDifference.Y += (e.Y - _MouseLocation.Y);
                this._SizeDifference.Y -= (e.Y - _MouseLocation.Y);
                this._SizeDifference.X += (e.X - _MouseLocation.X);
            }
            if (this._OperationIndex == 6)
            {
                this._SizeDifference.Y += (e.Y - _MouseLocation.Y);
                this._LocationDifference.X += (e.X - _MouseLocation.X);
                this._SizeDifference.X -= (e.X - _MouseLocation.X);
            }
            if (this._OperationIndex == 7)
            {
                this._SizeDifference.Y += (e.Y - _MouseLocation.Y);
                this._SizeDifference.X += (e.X - _MouseLocation.X);
            }
            this._MouseLocation = new Point(e.X, e.Y);
            this._AppliedSizeDifference = this._SizeDifference;
            if (this._Parent.MaximumSize.Width != 0 && this._SizeDifference.X > this._Parent.MaximumSize.Width - this._Parent.Size.Width) this._AppliedSizeDifference.X = this._Parent.MaximumSize.Width - this._Parent.Size.Width;
            else if (this._Parent.MaximumSize.Width != 0 && this._SizeDifference.X < this._Parent.MinimumSize.Width - this._Parent.Size.Width) this._AppliedSizeDifference.X = this._Parent.MinimumSize.Width - this._Parent.Size.Width;
            else this._AppliedLocationDifference.X = this._LocationDifference.X;
            if (this._Parent.MaximumSize.Height != 0 && this._SizeDifference.Y > this._Parent.MaximumSize.Height - this._Parent.Size.Height) this._AppliedSizeDifference.Y = this._Parent.MaximumSize.Height - this._Parent.Size.Height;
            else if (this._Parent.MaximumSize.Height != 0 && this._SizeDifference.Y < this._Parent.MinimumSize.Height - this._Parent.Size.Height) this._AppliedSizeDifference.Y = this._Parent.MinimumSize.Height - this._Parent.Size.Height;
            else this._AppliedLocationDifference.Y = this._LocationDifference.Y;
            this._ActiveResizeDisplayForm.Location = new Point(this._Parent.Location.X + this._AppliedLocationDifference.X, this._Parent.Location.Y + this._AppliedLocationDifference.Y);
            this._ActiveResizeDisplayForm.Size = new Size(this._Parent.Size.Width + this._AppliedSizeDifference.X, this._Parent.Size.Height + this._AppliedSizeDifference.Y);
        }
    }
}
