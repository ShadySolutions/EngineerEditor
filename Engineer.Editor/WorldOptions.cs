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
        private List<Button> _Filters;
        private List<Button> _Options;
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
            _Filters = new List<Button>();
            _Filters.Add(Filter0);
            _Filters.Add(Filter1);
            _Filters.Add(Filter2);
            _Filters.Add(Filter3);
            _Filters.Add(Filter4);
            _Filters.Add(Filter5);
            _Filters.Add(Filter6);
            _Filters.Add(Filter7);
            _Filters.Add(Filter8);
            Filter0.Tag = new int[3] { -1, -1, -1 };
            Filter1.Tag = new int[3] { (int)SceneType.Scene3D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Actor };
            Filter2.Tag = new int[3] { (int)SceneType.Scene3D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Figure };
            Filter3.Tag = new int[3] { (int)SceneType.Scene3D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Camera };
            Filter4.Tag = new int[3] { (int)SceneType.Scene3D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Light };
            Filter5.Tag = new int[3] { (int)SceneType.Scene2D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Background };
            Filter6.Tag = new int[3] { (int)SceneType.Scene2D, (int)SceneObjectType.DrawnSceneObject, (int)DrawObjectType.Sprite };
            Filter7.Tag = new int[3] { -1, (int)SceneObjectType.ScriptSceneObject, -1 };
            Filter8.Tag = new int[3] { -1, (int)SceneObjectType.SoundSceneObject, -1 };
            _Options = new List<Button>();
            _Options.Add(Option0);
            _Options.Add(Option1);
            _Options.Add(Option2);
            _Options.Add(Option3);
            _Options.Add(Option4);
            _Options.Add(Option5);
            _Options.Add(Option6);
            UpdateVisibleFilters();
            UpdateColors(0);
            UpdateVisibleOptions();
        }
        public void InterfaceUpdate(InterfaceUpdateMessage Message)
        {
            if (_BlockEvents) return;
            _BlockEvents = true;
            if(Message == InterfaceUpdateMessage.SceneUpdated)
            {
                if (_Interface.CurrentScene != null)
                {
                    this._Type = _Interface.CurrentScene.Type;
                    UpdateVisibleFilters();
                    UpdateVisibleOptions();
                }
            }
            _BlockEvents = false;
        }
        //Services
        private void UpdateColors(int Index)
        {
            for(int i = 0; i < _Filters.Count; i++) _Filters[i].BackColor = Color.FromArgb(30, 30, 30);
            _Filters[Index].BackColor = Color.FromArgb(20, 20, 20);
        }
        private void UpdateVisibleOptions()
        {
            if (_FilterType == 0)
            {
                if (_Type == SceneType.Scene2D)
                {
                    for (int j = 0; j < _Options.Count; j++) _Options[j].Visible = false;
                    _Options[5].Visible = true;
                    _Options[6].Visible = true;
                }
                else if (_Type == SceneType.Scene3D)
                {
                    for (int j = 0; j < _Options.Count; j++) _Options[j].Visible = true;
                    _Options[5].Visible = false;
                }
            }
            else
            {
                int[] Tags = _Filters[_FilterType].Tag as int[];
                for (int j = 0; j < _Options.Count; j++)
                {
                    if (Tags[1] == -1 || (int)_Interface.GlobalSceneObjects[j].Type == Tags[1])
                    {
                        _Options[j].Visible = false;
                        if (_Interface.GlobalSceneObjects[j].Type == SceneObjectType.DrawnSceneObject)
                        {
                            DrawnSceneObject DSO = (DrawnSceneObject)_Interface.GlobalSceneObjects[j];
                            DrawObjectType DType = DSO.Representation.Type;
                            if ((int)DType == Tags[2])
                            {
                                _Options[j].Visible = true;
                            }
                        }
                        else _Options[j].Visible = true;
                    }
                    else _Options[j].Visible = false;
                }
            }
        }
        //Events
        private void UpdateVisibleFilters()
        {
            for (int i = 0; i < _Filters.Count; i++)
            {
                _Filters[i].Visible = false;
                int[] Tags = _Filters[i].Tag as int[];
                if (Tags[0] == -1 || Tags[0] == (int)_Type) _Filters[i].Visible = true;
            }
            this._FilterType = 0;
            UpdateColors(0);
            UpdateVisibleOptions();
        }
        private void Option_MouseEnter(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(50,50,50);
        }
        private void Option_MouseLeave(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void Option_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button CurrentButton = sender as Button;
            int Index = Convert.ToInt32(CurrentButton.Tag);
            string ErrorString = "";
            _Interface.AddSceneItem(Index, ref ErrorString);
        }
        private void All_Click(object sender, EventArgs e)
        {
            if (_BlockEvents) return;
            Button Current = sender as Button;
            int Index = _Filters.IndexOf(Current);
            this._FilterType = Index;
            UpdateColors(Index);
            UpdateVisibleOptions();
        }
    }
}
