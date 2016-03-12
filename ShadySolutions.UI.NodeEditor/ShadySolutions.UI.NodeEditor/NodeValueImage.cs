using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShadySolutions.UI.NodeEditor
{
    public partial class NodeValueImage : NodeValue
    {
        public override ValueVector Value
        {
            get
            {
                return this._Value;
            }

            set
            {
                _Value = value;
                this.ValueImage.Text = Path.GetFileName(value.Value);
            }
        }
        public override bool HasValue
        {
            get
            {
                return ValueImage.Visible;
            }
            set
            {
                ValueImage.Visible = value;
            }
        }
        public NodeValueImage()
        {
            InitializeComponent();
        }
        public NodeValueImage(string Title) : base(Title)
        {
            InitializeComponent();
            this.HasOutput = false;
        }
        private void ValueImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image|*jpg;*jpeg;*png;*bmp";
            if(Dialog.ShowDialog() == DialogResult.OK)
            {
                this.Value.Value = Dialog.FileName;
                this.ValueImage.Text = Path.GetFileName(Dialog.FileName);
                this.InvokeNodeUpdate();
            }
        }
    }
}
