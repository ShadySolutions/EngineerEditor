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
    public partial class PropertiesInput_Label : PropertiesInput
    {
        public PropertiesInput_Label()
        {
            InitializeComponent();
        }
        public PropertiesInput_Label(string Title, string Value) : base(Title)
        {
            InitializeComponent();
            this.ValueLabel.Text = Value;
        }
    }
}
