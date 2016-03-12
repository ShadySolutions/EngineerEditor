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

namespace Engineer.Editor
{
    public partial class ScriptEditor : ToolForm
    {
        public ScriptEditor()
        {
            InitializeComponent();
            textEditorControl1.SetHighlight("script.cs");
        }
    }
}
