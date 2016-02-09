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
    public partial class VertexControl : UserControl
    {
        public VertexControl()
        {
            InitializeComponent();
        }

        private void VertexControl_Resize(object sender, EventArgs e)
        {
            X.Width = this.Width / 3;
            Y.Width = this.Width / 3;
            Z.Width = this.Width / 3;
        }

        public void SetMinMax(decimal Minimum, decimal Maximum)
        {
            X.Minimum = Minimum;
            Y.Minimum = Minimum;
            Z.Minimum = Minimum;
            X.Maximum = Maximum;
            Y.Maximum = Maximum;
            Z.Maximum = Maximum;
        }
    }
}
