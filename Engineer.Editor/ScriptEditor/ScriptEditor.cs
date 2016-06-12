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
using System.IO;

namespace Engineer.Editor
{
    public partial class ScriptEditor : ToolForm
    {
        private ScriptSceneObject _Script;
        public ScriptEditor()
        {
            InitializeComponent();
            Init();
            CodeEditor.SetHighlight("script.cs");
            this._Script = new ScriptSceneObject("Empty" + Guid.NewGuid().ToString());
        }
        public ScriptEditor(ScriptSceneObject Script)
        {
            InitializeComponent();
            Init();
            CodeEditor.SetHighlight("script.cs");
            this._Script = Script;
            this.CodeEditor.Text = Script.Script;
        }
        public void Init()
        {
            if(Directory.Exists("Library\\Script\\Events\\"))
            {
                string[] Files = Directory.GetFiles("Library\\Script\\Events\\");
                for(int i = 0; i < Files.Length; i++)
                {
                    if(Files[i].ToUpper().EndsWith(".CS"))
                    {
                        ToolStripMenuItem ScriptItem = new ToolStripMenuItem(Path.GetFileNameWithoutExtension(Files[i]));
                        ScriptItem.Tag = File.ReadAllText(Files[i]);
                        ScriptItem.Click += new EventHandler(SetText);
                        ScriptItem.BackColor = Color.FromArgb(20,20,20);
                        ScriptItem.ForeColor = Color.White;
                        eventToolStripMenuItem1.DropDownItems.Add(ScriptItem);
                    }
                }
            }
        }
        private void SetText(object sender, EventArgs e)
        {
            this.CodeEditor.Text = ((ToolStripMenuItem)sender).Tag.ToString();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Script.Script = CodeEditor.Text;
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.Filter = "C# Script (*.cs)|*cs";
            if(Dialog.ShowDialog() == DialogResult.OK && Dialog.FileName != "")
            {
                File.WriteAllText(Dialog.FileName, CodeEditor.Text);
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CodeEditor.Text = "";
        }
    }
}
