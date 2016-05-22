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
using Engineer.Interface;

namespace Engineer.Editor
{
    public partial class Properties_Actor : UserControl
    {
        private bool _BlockEvents;
        private bool _Toggled;
        private int _TotalHeight;
        private DockPanel _Dock;
        private Actor _CurrentActor;
        private Game_Interface _Interface;
        private List<ToolForm> _OpenForms;
        public Properties_Actor()
        {
            InitializeComponent();
            this._Toggled = true;
        }
        public Properties_Actor(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            Init(Interface, CurrentActor, Dock, OpenForms);
        }
        public void Init(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            this._Toggled = true;
            this.Margin = new Padding(10, 0, 0, 0);
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this._CurrentActor = CurrentActor;
            for (int i = 0; i < CurrentActor.Materials.Count; i++)
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
                NewButton.BackColor = Color.FromArgb(40, 40, 40);
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
            this._TotalHeight = 62 + CurrentActor.Materials.Count * 30;
        }
        public void EditMaterial(object sender, EventArgs e)
        {
            int Index = Convert.ToInt32((sender as Button).Tag);
            MaterialEditor Editor = new MaterialEditor(_CurrentActor.Materials[Index]);
            _Parent.OpenForms.Add(Editor);
            Editor.Title = _CurrentActor.Materials[Index].Name + " - Material Editor";
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
                this.Height = _TotalHeight;
            }
        }
    }
}
