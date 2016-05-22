using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engineer.Mathematics;

namespace Engineer.Editor
{
    public partial class PropertiesInput_Vertex : PropertiesInput
    {
        public PropertiesInput_Vertex()
        {
            InitializeComponent();
        }
        public PropertiesInput_Vertex(string Title, Vertex Value, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            this.ValueVertex.Value = Value;
            this.ValueVertex.ValueChanged += Update;
        }
        public PropertiesInput_Vertex(string Title, Vertex Value, Vertex Minimum, Vertex Maximum, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            this.ValueVertex.Value = Value;
            this.ValueVertex.Minimum = Minimum;
            this.ValueVertex.Maximum = Maximum;
            this.ValueVertex.ValueChanged += Update;
        }
        public override object GetValue()
        {
            return this.ValueVertex.Value;
        }
    }
}
