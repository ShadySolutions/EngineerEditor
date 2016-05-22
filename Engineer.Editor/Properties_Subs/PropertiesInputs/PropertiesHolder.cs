using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineer.Editor
{
    public partial class PropertiesHolder : UserControl
    {
        public event EventHandler ToggleChanged;
        private bool _Toggled;
        public bool Toggled
        {
            get
            {
                return _Toggled;
            }
            set
            {
                _Toggled = value;
                ChangeToggle(_Toggled);
            }
        }
        public string Title
        {
            get
            {
                return TitleLabel.Text;
            }
            set
            {
                TitleLabel.Text = value;
            }
        }
        public PropertiesHolder()
        {
            InitializeComponent();
            this.ToggleChanged = new EventHandler(OnToggleChanged);
        }
        public void OnToggleChanged(object sender, EventArgs e)
        {

        }
        public void ChildToggleChanged(object sender, EventArgs e)
        {
            ChangeToggle(_Toggled);
        }
        public void AddControl(Control NewControl)
        {
            NewControl.Dock = DockStyle.Top;
            this.Controls.Add(NewControl);
            NewControl.BringToFront();
            if(NewControl.GetType() == typeof(PropertiesHolder))
            {
                PropertiesHolder ChildHolder = NewControl as PropertiesHolder;
                ChildHolder.ToggleChanged += new EventHandler(ChildToggleChanged);
            }
            TitleLabel.SendToBack();
            ChangeToggle(_Toggled);
        }
        public void ClearControls()
        {
            if (this.Controls.Count == 1) return;
            this.Controls.Clear();
            this.Controls.Add(this.TitleLabel);
        }
        private void Title_Click(object sender, EventArgs e)
        {
            _Toggled = !_Toggled;
            ChangeToggle(_Toggled);
            
        }
        private int CalculateHeight()
        {
            int HolderHeight = 0;
            for(int i = 0; i < this.Controls.Count; i++)
            {
                if(this.Controls[i].GetType() == typeof(PropertiesHolder))
                {
                    HolderHeight += ((PropertiesHolder)this.Controls[i]).CalculateHeight() + 10;
                }
                else HolderHeight += this.Controls[i].Height;
            }
            return HolderHeight;
        }
        private void ChangeToggle(bool Toggle)
        {
            if (!Toggled) this.Height = this.Controls[this.Controls.Count - 1].Height;
            else this.Height = CalculateHeight() + 10;
        }
    }
}
