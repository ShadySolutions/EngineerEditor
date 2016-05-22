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
    public partial class VertexControl : UserControl
    {
        public event EventHandler ValueChanged;
        public VertexControl()
        {
            InitializeComponent();
            ValueChanged = new EventHandler(OnValueChange);
            X.ValueChanged += new EventHandler(ValueChanges);
            Y.ValueChanged += new EventHandler(ValueChanges);
            Z.ValueChanged += new EventHandler(ValueChanges);
        }
        public void OnValueChange(object sender, EventArgs e)
        {
        }
        public Vertex Value
        {
            get
            {
                return new Vertex((float)X.Value, (float)Y.Value, (float)Z.Value);
            }
            set
            {
                X.Value = (decimal)value.X;
                Y.Value = (decimal)value.Y;
                Z.Value = (decimal)value.Z;
            }
        }
        public Vertex Minimum
        {
            get
            {
                return new Vertex((float)X.Minimum, (float)Y.Minimum, (float)Z.Minimum);
            }
            set
            {
                X.Minimum = (decimal)value.X;
                Y.Minimum = (decimal)value.Y;
                Z.Minimum = (decimal)value.Z;
            }
        }
        public Vertex Maximum
        {
            get
            {
                return new Vertex((float)X.Maximum, (float)Y.Maximum, (float)Z.Maximum);
            }
            set
            {
                X.Maximum = (decimal)value.X;
                Y.Maximum = (decimal)value.Y;
                Z.Maximum = (decimal)value.Z;
            }
        }
        private void ValueChanges(object sender, EventArgs e)
        {
            ValueChanged.Invoke(this, e);
        }
        private void VertexControl_Resize(object sender, EventArgs e)
        {
            X.Width = this.Width / 3;
            Y.Width = this.Width / 3;
            Z.Width = this.Width / 3;
        }
    }
}
