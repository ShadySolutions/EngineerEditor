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
using Engineer.Draw;

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
            for(int i = 0; i < ShaderMaterialTranslator.Translator.Entries.Count; i++)
            {
                ToolStripMenuItem NewItem = new ToolStripMenuItem(ShaderMaterialTranslator.Translator.Entries[i].ID);
                NewItem.Tag = i;
                NewItem.ForeColor = Color.White;
                NewItem.BackColor = Color.FromArgb(30,30,30);
                NewItem.Click += new EventHandler(AddMaterialNode);
                if(ShaderMaterialTranslator.Translator.Entries[i].Type == ShaderMaterialTranslatorEntryType.Generic)
                {
                    genericToolStripMenuItem.DropDownItems.Add(NewItem);
                }
                if (ShaderMaterialTranslator.Translator.Entries[i].Type == ShaderMaterialTranslatorEntryType.Surface)
                {
                    surfaceToolStripMenuItem.DropDownItems.Add(NewItem);
                }
                if (ShaderMaterialTranslator.Translator.Entries[i].Type == ShaderMaterialTranslatorEntryType.Texture)
                {
                    textureToolStripMenuItem.DropDownItems.Add(NewItem);
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CurrentMaterial.Modified = true;
        }

        private void Editor_NodeUpdate(ShadySolutions.UI.NodeEditor.NodeValue sender)
        {
            MaterialNodeValue Source = (MaterialNodeValue)sender.Source;
            MaterialValueHolder NewValueHolder = new MaterialValueHolder(sender.Value.X, sender.Value.Y, sender.Value.Z, sender.Value.W);
            NewValueHolder.Type = Source.Value.Type;
            NewValueHolder.Value = sender.Value.Value;
            Source.Value = NewValueHolder;
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

        private void AddMaterialNode(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = sender as ToolStripMenuItem;
            int Index = Convert.ToInt32(Item.Tag);
            MaterialNode NewNode = ShaderMaterialTranslator.Translator.Entries[Index].ToMaterialNode(_CurrentMaterial);
            _CurrentMaterial.Nodes.Add(NewNode);
            UIGenerator.MaterialNodeToUI(_CurrentMaterial, NewNode, this.Editor);
        }
    }
}
