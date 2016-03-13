using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;
using Engineer.Engine;

namespace Engineer.Editor
{
    public partial class ScriptEditor : ToolForm
    {
        private ScriptSceneObject _Script;
        public ScriptEditor()
        {
            InitializeComponent();
            CodeEditor.SetHighlight("script.cs");
            this._Script = new ScriptSceneObject("Empty");
        }
        public void SetScript(ScriptSceneObject Script)
        {
            this._Script = Script;
            this.CodeEditor.Text = Script.Script;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Script.Script = CodeEditor.Text;
        }
    }
}
