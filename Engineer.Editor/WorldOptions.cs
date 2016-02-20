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
    public delegate void AddToSceeneEventHandler(int Index);
    public partial class WorldOptions : ToolForm
    {
        public int _FilterType;
        public SceneType _Type;
        public event AddToSceeneEventHandler AddItem;
        public WorldOptions()
        {
            InitializeComponent();
            AddItem = new AddToSceeneEventHandler(OnAddItem);
            this._FilterType = 1;
            this._Type = SceneType.Scene2D;
            UpdateColors(1);
            UpdateVisibleOptions();
        }
        private void OnAddItem(int Index)
        {
        }
        private void Floor_MouseEnter(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(50,50,50);
        }
        private void Floor_MouseLeave(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void Floor_Click(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            int Index = Convert.ToInt32(CurrentButton.Tag);
            AddItem.Invoke(Index);
        }
        public void UpdateSceneType(SceneType Type)
        {
            this._Type = Type;
            this._FilterType = 0;
            UpdateVisibleOptions();
        }
        private void UpdateColors(int Index)
        {
            All.BackColor = Color.FromArgb(30, 30, 30);
            Primitives.BackColor = Color.FromArgb(30, 30, 30);
            Characters.BackColor = Color.FromArgb(30, 30, 30);
            Cameras.BackColor = Color.FromArgb(30, 30, 30);
            Lights.BackColor = Color.FromArgb(30, 30, 30);
            Events.BackColor = Color.FromArgb(30, 30, 30);
            if (Index == 0) All.BackColor = Color.FromArgb(20,20,20);
            else if (Index == 1) Primitives.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 2) Characters.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 3) Cameras.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 4) Lights.BackColor = Color.FromArgb(20, 20, 20);
            else if (Index == 5) Events.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void UpdateVisibleOptions()
        {

            if(this._Type == SceneType.Scene3D)
            {
                if(_FilterType == 0)
                {
                    Floor.Visible = true;
                    Cube.Visible = true;
                    Soldier.Visible = true;
                    Light.Visible = true;
                    Camera.Visible = true;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 1)
                {
                    Floor.Visible = true;
                    Cube.Visible = true;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 2)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = true;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 3)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = true;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 4)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = true;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 5)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
            }
            else if (this._Type == SceneType.Scene2D)
            {
                if (_FilterType == 0)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = true;
                }
                else if (_FilterType == 1)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = true;
                }
                else if (_FilterType == 2)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
                else if (_FilterType == 5)
                {
                    Floor.Visible = false;
                    Cube.Visible = false;
                    Soldier.Visible = false;
                    Light.Visible = false;
                    Camera.Visible = false;
                    Sprite.Visible = false;
                }
            }
        }

        private void All_Click(object sender, EventArgs e)
        {
            Button Current = sender as Button;
            int Index = Convert.ToInt32(Current.Tag);
            this._FilterType = Index;
            UpdateColors(Index);
            UpdateVisibleOptions();
        }
    }
}
