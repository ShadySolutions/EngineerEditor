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
    public partial class PropertiesInput : UserControl
    {
        public PropertiesInput()
        {
            InitializeComponent();
        }
        public PropertiesInput(string Title)
        {
            InitializeComponent();
            this.TitleLabel.Text = Title;
        }
        public virtual object GetValue()
        {
            return null;
        }
    }
}
