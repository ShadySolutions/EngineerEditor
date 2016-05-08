using Engineer.Engine;
using Engineer.Interface;
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
    public partial class GameWindow : ToolForm
    {
        private bool _BlockEvents;
        private Game_Interface _Interface;
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(Game_Interface Interface)
        {
            InitializeComponent();
            Init(Interface);
        }
        public void Init(Game_Interface Interface)
        {
            _BlockEvents = false;
            this._Interface = Interface;
            _Interface.Update += new InterfaceUpdate(InterfaceUpdate);
            GenerateEntries();
        }
        public void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            _BlockEvents = true;
            if(Message == InterfaceUpdateMessage.GameUpdated)
            {
                GameName.Text = _Interface.CurrentGame.Name;
            }
            else if (Message == InterfaceUpdateMessage.SceneUpdated)
            {
                GenerateEntries();
            }
            _BlockEvents = false;
        }
        //Service
        public void GenerateEntries()
        {
            Entries.Controls.Clear();
            this.GameName.Text = _Interface.CurrentGame.Name;
            for (int i = 0; i < _Interface.CurrentGame.Scenes.Count; i++)
            {
                Button NewButton = GenerateButton(_Interface.CurrentGame.Scenes[i].Name, Color.White, i);
                NewButton.Click += new EventHandler(SceneSelectClick);
                Entries.Controls.Add(NewButton);
                NewButton.BringToFront();
            }
            Button New2DButton = GenerateButton("New 2D Scene", Color.OrangeRed, SceneType.Scene2D);
            New2DButton.Click += new EventHandler(NewSceneClick);
            Entries.Controls.Add(New2DButton);
            New2DButton.BringToFront();
            Button New3DButton = GenerateButton("New 3D Scene", Color.CadetBlue, SceneType.Scene3D);
            New3DButton.Click += new EventHandler(NewSceneClick);
            Entries.Controls.Add(New3DButton);
            New3DButton.BringToFront();
        }
        private Button GenerateButton(string Text, Color TextColor, object Tag)
        {
            Button NewButton = new Button();
            NewButton.Text = Text;
            NewButton.TextAlign = ContentAlignment.MiddleCenter;
            NewButton.FlatStyle = FlatStyle.Flat;
            NewButton.Dock = DockStyle.Top;
            NewButton.FlatAppearance.BorderSize = 0;
            NewButton.BackColor = Color.FromArgb(20, 20, 20);
            NewButton.ForeColor = TextColor;
            NewButton.Tag = Tag;
            return NewButton;
        }
        //Events
        private void NewSceneClick(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            string ErrorString = "";
            if(!_Interface.AddEmptyScene((SceneType)CurrentButton.Tag, ref ErrorString))
            {
                MessageBox.Show(ErrorString, "Error");
            }
        }
        private void SceneSelectClick(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            string ErrorString = "";
            if (!_Interface.SelectScene((int)CurrentButton.Tag, ref ErrorString))
            {
                MessageBox.Show(ErrorString, "Error");
            }
        }
        private void GameName_TextChanged(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            _Interface.SetGameName(GameName.Text);
        }
    }
}
