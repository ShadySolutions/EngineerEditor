using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TakeOne.WindowSuite
{
    public delegate void WindowStateChanged(object sender, System.Windows.Forms.FormWindowState NewState);
    public partial class WindowHeader : UserControl
    {
        private bool _Move = false;
        private bool _ActiveResizeDisplayFormShown = false;
        private Point _Start = new Point(-1,-1);
        private Point _Current = new Point(-1,-1);
        private Control _Parent;
        private ResizeDisplayForm _ActiveResizeDisplayForm;
        public event WindowStateChanged WindowStateChange;
        [Category("TO Specific")]
        public bool ControlsVisible
        {
            get
            {
                return this.DockLeft.Visible;
            }
            set
            {
                this.DockLeft.Visible = value;
            }
        }
        [Category("TO Specific")]
        public bool MaximiseVisible
        {
            get
            {
                return this.Maximise.Visible;
            }
            set
            {
                this.Maximise.Visible = value;
            }
        }
        [Category("TO Specific")]
        public bool MinimiseVisible
        {
            get
            {
                return this.Minimise.Visible;
            }
            set
            {
                this.Minimise.Visible = value;
            }
        }
        [Category("TO Specific")]
        public bool CloseVisible
        {
            get
            {
                return this.Close.Visible;
            }
            set
            {
                this.Close.Visible = value;
            }
        }
        [Category("TO Specific")]
        public bool IconVisible
        {
            get
            {
                return this.WindowIcon.Visible;
            }
            set
            {
                this.WindowIcon.Visible = value;
                if (value) DockLeft.Width = 45;
                else DockLeft.Width = 15;
            }
        }
        [Category("TO Specific")]
        public string Title
        {
            get
            {
                return this.TitleLabel.Text;
            }
            set
            {
                this.TitleLabel.Text = value;
            }
        }
        [Category("TO Specific")]
        public Font TitleFont
        {
            get
            {
                return this.TitleLabel.Font;
            }
            set
            {
                this.TitleLabel.Font = value;
            }
        }
        [Category("TO Specific")]
        public Image IconImage
        {
            get
            {
                return this.WindowIcon.BackgroundImage;
            }
            set
            {
                this.WindowIcon.BackgroundImage = value;
            }
        }
        public WindowHeader()
        {
            InitializeComponent();
            this.WindowStateChange = new WindowStateChanged(OnWindowStateChanged);
            this.TitleLabel.DoubleClick += new System.EventHandler(this.TitleLabel_DoubleClick);
        }
        private void OnWindowStateChanged(object sender, System.Windows.Forms.FormWindowState NewState)
        {
        }
        public void SetReferenceParent(Control Parent)
        {
            this._Parent = Parent;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            if (!this.Close.Visible) return;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsForm != null) ParentAsForm.Close();
            else this._Parent.Visible = false;
        }
        private void Maximise_Click(object sender, EventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            if (!this.Maximise.Visible) return;
            DockContent ParentAsDockContent = this._Parent as DockContent;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsDockContent != null)
            {
                if (ParentAsDockContent.DockHandler.Pane != null)
                {
                    if (ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState == FormWindowState.Maximized)
                    {
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState = FormWindowState.Normal;
                        double[] Values = ParseArray(ParentAsDockContent.DockHandler.Pane.FloatWindow.Tag.ToString(), ',');
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.Location = new Point(Convert.ToInt32(Values[0]), Convert.ToInt32(Values[1]));
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                        this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                    }
                    else if (ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState == FormWindowState.Normal)
                    {
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.MaximumSize = Screen.FromControl(this).WorkingArea.Size;
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.Tag = ParentAsDockContent.DockHandler.Pane.FloatWindow.Location.ToString();
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.Location = Screen.FromControl(this).WorkingArea.Location;
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState = FormWindowState.Maximized;
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Restore;
                        this.WindowStateChange.Invoke(this, FormWindowState.Maximized);
                    }
                }
                else
                {
                    if (ParentAsDockContent.WindowState == FormWindowState.Maximized)
                    {
                        ParentAsDockContent.WindowState = FormWindowState.Normal;
                        double[] Values = ParseArray(ParentAsDockContent.Tag.ToString(), ',');
                        ParentAsDockContent.Location = new Point(Convert.ToInt32(Values[0]), Convert.ToInt32(Values[1]));
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                        this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                    }
                    else if (ParentAsDockContent.WindowState == FormWindowState.Normal)
                    {
                        ParentAsDockContent.MaximumSize = Screen.FromControl(this).WorkingArea.Size;
                        ParentAsDockContent.Tag = ParentAsDockContent.Location.ToString();
                        ParentAsDockContent.Location = Screen.FromControl(this).WorkingArea.Location;
                        ParentAsDockContent.WindowState = FormWindowState.Maximized;
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Restore;
                        this.WindowStateChange.Invoke(this, FormWindowState.Maximized);
                    }
                }
            }
            else if (ParentAsForm != null)
            {
                if (ParentAsForm.WindowState == FormWindowState.Maximized)
                {
                    ParentAsForm.WindowState = FormWindowState.Normal;
                    double[] Values = ParseArray(ParentAsForm.Tag.ToString(), ',');
                    ParentAsForm.Location = new Point(Convert.ToInt32(Values[0]), Convert.ToInt32(Values[1]));
                    Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                    this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                }
                else if (ParentAsForm.WindowState == FormWindowState.Normal)
                {
                    ParentAsForm.MaximumSize = Screen.FromControl(this).WorkingArea.Size;
                    ParentAsForm.Tag = ParentAsForm.Location.ToString();
                    ParentAsForm.Location = Screen.FromControl(this).WorkingArea.Location;
                    ParentAsForm.WindowState = FormWindowState.Maximized;
                    Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Restore;
                }
            }
            else
            {
                if (this._Parent.Dock == DockStyle.Fill)
                {
                    this._Parent.Dock = DockStyle.None;
                    Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                    this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                }
                else
                {
                    this._Parent.Dock = DockStyle.Fill;
                    Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Restore;
                    this.WindowStateChange.Invoke(this, FormWindowState.Maximized);
                }
            }
        }
        private void Minimise_Click(object sender, EventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            if (!this.Minimise.Visible) return;
            DockContent ParentAsDockContent = this._Parent as DockContent;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsDockContent != null)
            {
                if (ParentAsDockContent.DockHandler.Pane != null)
                {
                    ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState = FormWindowState.Minimized;
                    this.WindowStateChange.Invoke(this, FormWindowState.Minimized);
                }
                else
                {
                    ParentAsDockContent.WindowState = FormWindowState.Minimized;
                    this.WindowStateChange.Invoke(this, FormWindowState.Minimized);
                }
            }
            else if (ParentAsForm != null)
            {
                ParentAsForm.WindowState = FormWindowState.Minimized;
                this.WindowStateChange.Invoke(this, FormWindowState.Minimized);
            }
            else
            {
                this.Visible = false;
            }
        }
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            DockContent ParentAsDockContent = this._Parent as DockContent;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsDockContent != null && ParentAsDockContent.DockPanel != null)
            {
                if (ParentAsDockContent.DockHandler.Pane != null)
                {
                    if (ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState == FormWindowState.Maximized)
                    {
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.WindowState = FormWindowState.Normal;
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.Location = new Point(e.X - ParentAsDockContent.DockHandler.Pane.FloatWindow.Width/2, 0);
                        this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                        _Start.X = _Current.X = ParentAsDockContent.DockHandler.Pane.FloatWindow.Width / 2;
                        _Start.Y = _Current.Y = e.Y + 10;
                    }
                    else
                    {
                        _Start.X = _Current.X = e.X;
                        _Start.Y = _Current.Y = e.Y;
                    }
                }
                else
                {
                    if (ParentAsDockContent.WindowState == FormWindowState.Maximized)
                    {
                        ParentAsDockContent.WindowState = FormWindowState.Normal;
                        ParentAsDockContent.Location = new Point(e.X - ParentAsDockContent.DockHandler.Pane.FloatWindow.Width / 2, 0);
                        this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                        Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                        _Start.X = _Current.X = ParentAsDockContent.Width / 2;
                        _Start.Y = _Current.Y = e.Y + 10;
                    }
                    else
                    {
                        _Start.X = _Current.X = e.X;
                        _Start.Y = _Current.Y = e.Y;
                    }
                }
                this._Move = true;
            }
            else if (ParentAsForm != null)
            {
                if (ParentAsForm.WindowState == FormWindowState.Maximized)
                {
                    ParentAsForm.WindowState = FormWindowState.Normal;
                    ParentAsForm.Location = new Point(e.X, 0);
                    this.WindowStateChange.Invoke(this, FormWindowState.Normal);
                    Maximise.BackgroundImage = global::TakeOne.WindowSuite.Properties.Resources.Maximize;
                    _Start.X = _Current.X = ParentAsForm.Width / 2;
                    _Start.Y = _Current.Y = e.Y + 10;
                    this._ActiveResizeDisplayForm = new ResizeDisplayForm();
                    this._ActiveResizeDisplayForm.Location = this._Parent.Location;
                    this._ActiveResizeDisplayForm.Size = this._Parent.Size;
                }
                else
                {
                    _Start.X = _Current.X = e.X;
                    _Start.Y = _Current.Y = e.Y;
                    this._ActiveResizeDisplayForm = new ResizeDisplayForm();
                    this._ActiveResizeDisplayForm.Location = this._Parent.Location;
                    this._ActiveResizeDisplayForm.Size = this._Parent.Size;
                }
                this._Move = true;
            }
            else
            {
            }
            
        }
        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            DockContent ParentAsDockContent = this._Parent as DockContent;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsDockContent != null && ParentAsDockContent.DockPanel != null)
            {
                if (this._Move && ParentAsDockContent.DockHandler.Pane == null) ParentAsDockContent.Location = new Point(ParentAsDockContent.Location.X - _Start.X + e.X, ParentAsDockContent.Location.Y - _Start.Y + e.Y);
                this._Move = false;
            }
            else if (ParentAsForm != null)
            {
                ParentAsForm.Location = new Point(ParentAsForm.Location.X - _Start.X + e.X, ParentAsForm.Location.Y - _Start.Y + e.Y);
                this._Move = false;
                this._ActiveResizeDisplayForm.Close();
                this._ActiveResizeDisplayFormShown = false;
                if (ParentAsForm.Location.Y < -1)
                {
                    Maximise_Click(null, null);
                    ToolForm ParentAsToolForm = this._Parent as ToolForm;
                    if (ParentAsToolForm != null) ParentAsToolForm.CallCenterToScreen();
                }
            }
            else
            {
            }
        }
        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._Parent == null) this._Parent = this.Parent;
            DockContent ParentAsDockContent = this._Parent as DockContent;
            Form ParentAsForm = this._Parent as Form;
            if (ParentAsDockContent != null && ParentAsDockContent.DockPanel != null)
            {
                if (ParentAsDockContent.DockHandler.Pane == null || ParentAsDockContent.DockHandler.Pane.FloatWindow == null) return;
                if (this._Move)
                {
                    if (ParentAsDockContent.DockHandler.Pane != null)
                    {
                        ParentAsDockContent.DockHandler.Pane.FloatWindow.CallBeginDrag();
                    }
                    else
                    {
                        ParentAsDockContent.Location = new Point(ParentAsDockContent.Location.X - this._Current.X + e.X, ParentAsDockContent.Location.Y - this._Current.Y + e.Y);
                    }
                }
            }
            else if (ParentAsForm != null)
            {
                if (this._Move)
                {
                    if (!this._ActiveResizeDisplayFormShown)
                    {
                        this._ActiveResizeDisplayForm.Show();
                        this._ActiveResizeDisplayFormShown = true;
                    }
                    this._ActiveResizeDisplayForm.Location = new Point(ParentAsForm.Location.X - this._Current.X + e.X, ParentAsForm.Location.Y - this._Current.Y + e.Y);
                }
            }
            else
            {
            }
        }
        private void Buttons_MouseEnter(object sender, EventArgs e)
        {
            Control SenderAsControl = sender as Control;
            SenderAsControl.BackColor = Color.DimGray;
        }
        private void Buttons_MouseLeave(object sender, EventArgs e)
        {
            Control SenderAsControl = sender as Control;
            SenderAsControl.BackColor = this.BackColor;
        }
        private void TitleLabel_DoubleClick(object sender, EventArgs e)
        {
            Maximise_Click(sender, e);
        }
        private double[] ParseArray(string Input, char Splitter)
        {
            string[] InputSeparated = Input.Split(Splitter);
            for (int i = 0; i < InputSeparated.Length; i++)
            {
                InputSeparated[i] = InputSeparated[i].Trim();
                InputSeparated[i] = InputSeparated[i].Replace("X=", "");
                InputSeparated[i] = InputSeparated[i].Replace("Y=", "");
                InputSeparated[i] = InputSeparated[i].Replace("{", "");
                InputSeparated[i] = InputSeparated[i].Replace("}", "");
            }
            return ParseArray(InputSeparated);
        }
        private double[] ParseArray(string[] Array)
        {
            double[] NewParsed = new double[Array.Length];
            for (int i = 0; i < Array.Length; i++)
            {
                if (!Double.TryParse(Array[i], out NewParsed[i])) NewParsed[i] = Double.NaN;
            }
            return NewParsed;
        }
    }
}
