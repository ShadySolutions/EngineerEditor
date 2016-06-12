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
    public partial class PropertiesInput_Combo : PropertiesInput
    {
        public PropertiesInput_Combo()
        {
            InitializeComponent();
        }
        public PropertiesInput_Combo(string Title, List<string> Items, int Index, EventHandler Update) : base(Title)
        {
            InitializeComponent();
            for(int i = 0; i < Items.Count; i++)
            {
                this.ValueCombo.Items.Add(Items[i]);
            }
            if (Index < Items.Count) this.ValueCombo.SelectedIndex = Index;
            else this.ValueCombo.Enabled = false;
            this.ValueCombo.SelectedIndexChanged += Update;
        }
        public void Lock()
        {
            this.Enabled = false;
        }
        public override object GetValue()
        {
            if (this.ValueCombo.Enabled)
            {
                return this.ValueCombo.SelectedIndex;
            }
            else return -1;
        }
    }
}
