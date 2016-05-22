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
    public partial class PropertiesInput_Bool : PropertiesInput
    {
        public PropertiesInput_Bool()
        {
            InitializeComponent();
        }
        public PropertiesInput_Bool(string Title, bool Value, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            this.ValueCheck.Checked = Value;
            this.ValueCheck.CheckedChanged += Update;
        }
        public override object GetValue()
        {
            return this.ValueCheck.Checked;
        }
    }
}
