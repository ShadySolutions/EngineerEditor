using Engineer.Engine;
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
    public delegate void SceneSelection(int Index);
    public partial class GameWindow : ToolForm
    {
        private Game _CurrentGame;
        public event SceneSelection EntrySelection;
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(Game CurrentGame)
        {
            InitializeComponent();
            this._CurrentGame = CurrentGame;
            GenerateEntries();
        }
        public void OnEntrySelection(int Index)
        {

        }
        public void GenerateEntries()
        {
            Entries.Controls.Clear();
            this.GameName.Text = _CurrentGame.Name;
            for (int i = 0; i < _CurrentGame.Scenes.Count; i++)
            {
                Button NewButton = new Button();
                NewButton.Text = _CurrentGame.Scenes[i].Name;
                NewButton.TextAlign = ContentAlignment.MiddleCenter;
                NewButton.Tag = i;
                NewButton.FlatStyle = FlatStyle.Flat;
                NewButton.Dock = DockStyle.Top;
                NewButton.FlatAppearance.BorderSize = 0;
                NewButton.BackColor = Color.FromArgb(20, 20, 20);
                NewButton.ForeColor = Color.White;
                NewButton.Click += new EventHandler(EntryClick);
                Entries.Controls.Add(NewButton);
                NewButton.BringToFront();
            }
            Button New2DButton = new Button();
            New2DButton.Text = "New 2D Scene";
            New2DButton.TextAlign = ContentAlignment.MiddleCenter;
            New2DButton.Tag = -1;
            New2DButton.Dock = DockStyle.Top;
            New2DButton.FlatAppearance.BorderSize = 0;
            New2DButton.FlatStyle = FlatStyle.Flat;
            New2DButton.BackColor = Color.FromArgb(20, 20, 20);
            New2DButton.ForeColor = Color.OrangeRed;
            New2DButton.Click += new EventHandler(EntryClick);
            Entries.Controls.Add(New2DButton);
            New2DButton.BringToFront();
            Button New3DButton = new Button();
            New3DButton.Text = "New 3D Scene";
            New3DButton.TextAlign = ContentAlignment.MiddleCenter;
            New3DButton.Tag = -2;
            New3DButton.Dock = DockStyle.Top;
            New3DButton.FlatAppearance.BorderSize = 0;
            New3DButton.FlatStyle = FlatStyle.Flat;
            New3DButton.BackColor = Color.FromArgb(20, 20, 20);
            New3DButton.ForeColor = Color.CadetBlue;
            New3DButton.Click += new EventHandler(EntryClick);
            Entries.Controls.Add(New3DButton);
            New3DButton.BringToFront();
        }
        private void EntryClick(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            this.EntrySelection.Invoke(Convert.ToInt32(CurrentButton.Tag));
        }

        private void GameName_TextChanged(object sender, EventArgs e)
        {
            this._CurrentGame.Name = GameName.Text;
        }
    }
}
