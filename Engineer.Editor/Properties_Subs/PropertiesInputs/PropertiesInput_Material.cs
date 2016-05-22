using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engineer.Engine;
using TakeOne.WindowSuite;
using WeifenLuo.WinFormsUI.Docking;

namespace Engineer.Editor
{
    public partial class PropertiesInput_Material : PropertiesInput
    {
        private Material _CurrentMaterial;
        private DockPanel _Dock;
        private List<ToolForm> _OpenForms;
        public PropertiesInput_Material()
        {
            InitializeComponent();
        }
        public PropertiesInput_Material(string Title, Material CurrentMaterial, DockPanel Dock, List<ToolForm> OpenForms) : base(Title)
        {
            InitializeComponent();
            this._CurrentMaterial = CurrentMaterial;
            this._OpenForms = OpenForms;
        }
        private void Preview_Click(object sender, EventArgs e)
        {
            MaterialEditor Editor = new MaterialEditor(_CurrentMaterial);
            Editor.Text = _CurrentMaterial.Name + "[MAT]";
            Editor.Title = _CurrentMaterial.Name + "[MAT]";
            _OpenForms.Add(Editor);
            Editor.Show(_Dock, DockState.Document);
        }
    }
}
