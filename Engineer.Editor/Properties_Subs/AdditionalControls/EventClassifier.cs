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
    public partial class EventClassifier : UserControl
    {
        public EventClassifier()
        {
            InitializeComponent();
        }
        public void SetEvent(EventHandler eh)
        {
            TypeLabel.Click += eh;
        }
        public void ClassifyScript(string Script)
        {
            List<string> Types = new List<string>();
            if (Script != null)
            {
                if (Script.Contains("public void Load"))
                {
                    TypeLabel.ForeColor = Color.Aqua;
                    Types.Add("Load");
                }
                if (Script.Contains("public void MousePress"))
                {
                    TypeLabel.ForeColor = Color.Orange;
                    Types.Add("MousePress");
                }
                if (Script.Contains("public void MouseDown"))
                {
                    TypeLabel.ForeColor = Color.Purple;
                    Types.Add("MouseDown");
                }
                if (Script.Contains("public void MouseUp"))
                {
                    TypeLabel.ForeColor = Color.Pink;
                    Types.Add("MouseUp");
                }
                if (Script.Contains("public void MouseMove"))
                {
                    TypeLabel.ForeColor = Color.Yellow;
                    Types.Add("MouseMove");
                }
                if (Script.Contains("public void KeyPress"))
                {
                    TypeLabel.ForeColor = Color.Green;
                    Types.Add("KeyPress");
                }
                if (Script.Contains("public void KeyDown"))
                {
                    TypeLabel.ForeColor = Color.DarkGreen;
                    Types.Add("KeyDown");
                }
                if (Script.Contains("public void KeyUp"))
                {
                    TypeLabel.ForeColor = Color.Lime;
                    Types.Add("KeyUp");
                }
                if (Script.Contains("public void RenderFrame"))
                {
                    TypeLabel.ForeColor = Color.Blue;
                    Types.Add("RenderFrame");
                }
                if (Script.Contains("public void EverySecond"))
                {
                    TypeLabel.ForeColor = Color.BlueViolet;
                    Types.Add("EverySecond");
                }
            }
            if (Types.Count > 0)
            {
                if (Types.Count > 1) TypeLabel.ForeColor = Color.Brown;
                string Text = "";
                for (int i = 0; i < Types.Count; i++)
                {
                    if (i > 0) Text += "/";
                    Text += Types[i];
                }
                TypeLabel.Text = Text;
            }
            else
            {
                TypeLabel.ForeColor = Color.Red;
                TypeLabel.Text = "Undefined";
            }
        }
    }
}
