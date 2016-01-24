using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeOne.WindowSuite
{
    public partial class ControlResizer : UserControl
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
        [Category("TO Specific")]
        public bool ResizeEnabled
        {
            get { return this._ResizeEnabled; }
            set 
            { 
                this._ResizeEnabled = value;
                if (value)
                {
                    this.ResizerUp.Cursor = System.Windows.Forms.Cursors.SizeNS;
                    this.ResizerDown.Cursor = System.Windows.Forms.Cursors.SizeNS;
                    this.ResizerRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
                    this.ResizerLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
                    this.ResizerUpRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    this.ResizerDownLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
                    this.ResizerUpLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                    this.ResizerDownRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
                }
                else
                {
                    this.ResizerUp.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerDown.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerRight.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerLeft.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerUpRight.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerDownLeft.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerUpLeft.Cursor = System.Windows.Forms.Cursors.Default;
                    this.ResizerDownRight.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
        }
        public ControlCollection ContentControls
        {
            get
            {
                return Content.Controls;
            }
        }
        public ControlResizer()
        {
            InitializeComponent();
            this._Parent = this.Parent;
        }
        public void SetReferenceParent(Control Parent)
        {
            this._Parent = Parent;
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
            if (!ResizeEnabled) return;
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
