using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engineer.Engine;
using TakeOne.WindowSuite;

namespace Engineer.Editor
{
    public partial class MaterialEditor : ToolForm
    {
        private Material _CurrentMaterial;
        public MaterialEditor()
        {
            InitializeComponent();
        }
        public MaterialEditor(Material CurrentMaterial)
        {
            InitializeComponent();
            this.Text = CurrentMaterial.Name + " - Material";
            this.Title = CurrentMaterial.Name + " - Material";
            UIGenerator.MaterialToUI(CurrentMaterial, this.Editor);
            this._CurrentMaterial = CurrentMaterial;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentMaterial.Modified = true;
        }

        private void Editor_NodeUpdate(ShadySolutions.UI.NodeEditor.NodeValue sender)
        {
            MaterialNodeValue Source = (MaterialNodeValue)sender.Source;
            Source.Value = new MaterialValueHolder(sender.Value.X, sender.Value.Y, sender.Value.Z, sender.Value.W);
            if (Source.InputTarget != null && sender.Input == null)
            {
                Source.InputTarget.OutputTargets.Remove(Source);
                Source.InputTarget = null;
            }
            if (Source.InputTarget != null && (MaterialNodeValue)sender.Input.Source != Source.InputTarget)
            {
                Source.InputTarget.OutputTargets.Remove(Source);
                Source.InputTarget = (MaterialNodeValue)sender.Input.Source;
            }
            if (Source.InputTarget == null && sender.Input != null)
            {
                Source.InputTarget = (MaterialNodeValue)sender.Input.Source;
            }
        }
    }
}
