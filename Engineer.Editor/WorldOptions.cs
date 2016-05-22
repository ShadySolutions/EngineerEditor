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
    public partial class WorldOptions : ToolForm
    {
        private bool _BlockEvents;
        private int _FilterType;
        private SceneType _Type;
        private Game_Interface _Interface;
        public WorldOptions(Game_Interface Interface)
        {
            InitializeComponent();
            Init(Interface);
        }
        public void Init(Game_Interface Interface)
        {
            this._Interface = Interface;
            _Interface.Update += new Engineer.Interface.InterfaceUpdate(InterfaceUpdate);
            this._BlockEvents = false;
            this._FilterType = 1;
            this._Type = SceneType.Scene2D;
            UpdateColors(1);
            UpdateVisibleOptions();
        }
        public void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            if (_BlockEvents) return;
            _BlockEvents = true;
            _BlockEvents = false;
        }
        //Services
        private void UpdateColors(int Index)
        {
            All.BackColor = Color.FromArgb(30, 30, 30);
            Primitives.BackColor = Color.FromArgb(30, 30, 30);
            Characters.BackColor = Color.FromArgb(30, 30, 30);
            Cameras.BackColor = Color.FromArgb(30, 30, 30);
            Lights.BackColor = Color.FromArgb(30, 30, 30);
            Events.BackColor = Color.FromArgb(30, 30, 30);
            if (Index == 0) All.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 1) Primitives.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 2) Characters.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 3) Cameras.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 4) Lights.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 5) Events.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void UpdateVisibleOptions()
        {
            Floor.Visible = false;
            Cube.Visible = false;
            Soldier.Visible = false;
            Light.Visible = false;
            Camera.Visible = false;
            Sprite.Visible = false;
            Event.Visible = false;
            if (this._Type == SceneType.Scene3D)
            {
                Cameras.Visible = true;
                Lights.Visible = true;
                if (_FilterType == 0)
                {
                    Floor.Visible = true;
                    Cube.Visible = true;
                    Soldier.Visible = true;
                    Light.Visible = true;
                    Camera.Visible = true;
                    Event.Visible = true;
                }
                else if (_FilterType == 1)
                {
                    Floor.Visible = true;
                    Cube.Visible = true;
                }
                else if (_FilterType == 2)
                {
                    Soldier.Visible = true;
                }
                else if (_FilterType == 3)
                {
                    Camera.Visible = true;
                }
                else if (_FilterType == 4)
                {
                    Light.Visible = true;
                }
                else if (_FilterType == 5)
                {
                    Event.Visible = true;
                }
            }
            else if (this._Type == SceneType.Scene2D)
            {
                Cameras.Visible = false;
                Lights.Visible = false;
                if (_FilterType == 0)
                {
                    Sprite.Visible = true;
                    Event.Visible = true;
                }
                else if (_FilterType == 1)
                {
                    Sprite.Visible = true;
                }
                else if (_FilterType == 2)
                {
                }
                else if (_FilterType == 5)
                {
                    Event.Visible = true;
                }
            }
        }
        //Events
        private void Floor_MouseEnter(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(50,50,50);
        }
        private void Floor_MouseLeave(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void Floor_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            int Index = Convert.ToInt32(CurrentButton.Tag);
            string ErrorString = "";
            _Interface.AddSceneItem((GenericSceneObjectType)Index, ref ErrorString);
        }
        public void UpdateSceneType(SceneType Type)
        {
            if (_BlockEvents) return;
            this._Type = Type;
            this._FilterType = 0;
            UpdateVisibleOptions();
        }
        private void All_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button Current = sender as Button;
            int Index = Convert.ToInt32(Current.Tag);
            this._FilterType = Index;
            UpdateColors(Index);
            UpdateVisibleOptions();
        }
    }
}
