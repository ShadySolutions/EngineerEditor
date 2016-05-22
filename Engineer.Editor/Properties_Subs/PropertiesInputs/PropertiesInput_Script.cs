using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using TakeOne.WindowSuite;
using Engineer.Engine;

namespace Engineer.Editor
{
    public partial class PropertiesInput_Script : PropertiesInput
    {
        private ScriptSceneObject _CurrentScript;
        private DockPanel _Dock;
        private List<ToolForm> _OpenForms;
        public PropertiesInput_Script()
        {
            InitializeComponent();
        }
        public PropertiesInput_Script(string Title, ScriptSceneObject CurrentScript, DockPanel Dock, List<ToolForm> OpenForms) : base(Title)
        {
            InitializeComponent();
            this._CurrentScript = CurrentScript;
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this.Classifier.ClassifyScript(_CurrentScript.Script);
            this.Classifier.SetEvent(Classifier_Click);
        }
        private void Classifier_Click(object sender, EventArgs e)
        {
            ScriptEditor Editor = new ScriptEditor(_CurrentScript);
            Editor.Text = this._CurrentScript.Name + "[SCR]";
            Editor.Title = this._CurrentScript.Name + "[SCR]";
            _OpenForms.Add(Editor);
            Editor.Show(_Dock, DockState.Document);
        }
    }
}
