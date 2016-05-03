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
using WeifenLuo.WinFormsUI.Docking;
using TakeOne.WindowSuite;

namespace Engineer.Editor
{
    public partial class Properties_Script : UserControl
    {
        private bool _Toggled;
        private DockPanel _Dock;
        private ScriptSceneObject _CurrentScript;
        private List<ToolForm> _OpenForms;
        public Properties_Script()
        {
            InitializeComponent();
            this._Toggled = true;
        }
        public void Init(ScriptSceneObject CurrentScript, DockPanel Dock, List<ToolForm> OpenForms)
        {
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this._CurrentScript = CurrentScript;
        }
        private void Button_ScriptCode_Click(object sender, EventArgs e)
        {
            ScriptEditor Editor = new ScriptEditor();
            Editor.SetScript(this._CurrentScript);
            Editor.Text = this._CurrentScript.Name + " - Script Editor";
            Editor.Title = this._CurrentScript.Name + " - Script Editor";
            _OpenForms.Add(Editor);
            Editor.Show(_Dock, DockState.Document);
        }
        private void ToggleHeader_Click(object sender, EventArgs e)
        {
            if (_Toggled)
            {
                _Toggled = false;
                this.Height = 24;
            }
            else
            {
                _Toggled = true;
                this.Height = 62;
            }
        }
    }
}
