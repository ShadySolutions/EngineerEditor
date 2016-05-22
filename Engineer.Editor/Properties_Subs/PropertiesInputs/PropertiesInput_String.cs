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
    public partial class PropertiesInput_String : PropertiesInput
    {
        public PropertiesInput_String()
        {
            InitializeComponent();
        }
        public PropertiesInput_String(string Title, string Value, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            this.ValueString.Text = Value;
            this.ValueString.TextChanged += Update;
        }
        public override object GetValue()
        {
            return this.ValueString.Text;
        }
    }
}
