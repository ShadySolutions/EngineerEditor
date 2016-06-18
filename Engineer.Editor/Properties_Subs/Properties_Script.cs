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
    public partial class Properties_Script : PropertiesHolder
    {
        private DockPanel _Dock;
        private ScriptSceneObject _CurrentScript;
        private List<ToolForm> _OpenForms;
        public Properties_Script()
        {
            InitializeComponent();
        }
        public Properties_Script(ScriptSceneObject CurrentScript, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            Init(CurrentScript, Dock, OpenForms);
        }
        public void Init(ScriptSceneObject CurrentScript, DockPanel Dock, List<ToolForm> OpenForms)
        {
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this._CurrentScript = CurrentScript;
            PropertiesInput_Script SE = new PropertiesInput_Script("Code", CurrentScript, Dock, OpenForms);
            this.AddControl(SE);
        }
    }
}
