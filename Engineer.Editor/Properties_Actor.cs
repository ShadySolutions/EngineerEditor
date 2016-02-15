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

namespace Engineer.Editor
{
    public partial class Properties_Actor : UserControl
    {
        private DockPanel _Dock;
        private Actor _CurrentActor;
        public Properties_Actor()
        {
            InitializeComponent();
        }
        public Properties_Actor(Actor CurrentActor, DockPanel Dock)
        {
            InitializeComponent();
            this.Margin = new Padding(10, 0, 0, 0);
            this._Dock = Dock;
            this._CurrentActor = CurrentActor;
            this.Value_Modified.Checked = CurrentActor.Modified;
            for(int i = 0; i < CurrentActor.Materials.Count; i++)
            {
                Panel NewPanel = new Panel();
                NewPanel.Size = new Size(320, 30);
                NewPanel.Dock = DockStyle.Top;
                Label NewLabel = new Label();
                NewLabel.Size = new Size(100, 30);
                NewLabel.Dock = DockStyle.Left;
                NewLabel.ForeColor = Color.White;
                NewLabel.AutoSize = false;
                NewLabel.Padding = new Padding(0, 0, 10, 0);
                NewLabel.TextAlign = ContentAlignment.MiddleRight;
                NewLabel.Text = CurrentActor.Materials[i].Name;
                Button NewButton = new Button();
                NewButton.FlatStyle = FlatStyle.Flat;
                NewButton.BackColor = Color.FromArgb(40,40,40);
                NewButton.ForeColor = Color.White;
                NewButton.Size = new Size(200, 25);
                NewButton.Dock = DockStyle.Bottom;
                NewButton.Text = "Edit";
                NewButton.Tag = i;
                NewButton.Click += new EventHandler(EditMaterial);
                NewPanel.Controls.Add(NewLabel);
                NewPanel.Controls.Add(NewButton);
                NewButton.BringToFront();
                this.Controls.Add(NewPanel);
            }
        }
        public void EditMaterial(object sender, EventArgs e)
        {
            int Index = Convert.ToInt32((sender as Button).Tag);
            MaterialEditor Editor = new MaterialEditor(_CurrentActor.Materials[Index]);
            Editor.Title = _CurrentActor.Materials[Index].Name + " - Material Editor";
            Editor.Show(_Dock, DockState.Document);
        }
    }
}
