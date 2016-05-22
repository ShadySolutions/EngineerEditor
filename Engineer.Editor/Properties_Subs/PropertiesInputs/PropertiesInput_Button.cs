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
    public partial class PropertiesInput_Button : PropertiesInput
    {
        public PropertiesInput_Button()
        {
            InitializeComponent();
        }
        public PropertiesInput_Button(string Title, string Text, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            this.ValueButton.Text = Text;
            this.ValueButton.Click += Update;
        }
    }
}
