using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engineer.Interface;
using Engineer.Engine;

namespace Engineer.Editor
{
    public partial class Properties_Event : UserControl
    {
        private int _Type;
        private int _Index;
        private Scene _Scene;
        private Game_Interface _Interface;
        private PropertiesInput_Combo _EventTypes;
        private PropertiesInput_Combo _PossibleEvents;
        private List<string> _EventTypeString;
        public Properties_Event()
        {
            InitializeComponent();
        }
        public Properties_Event(Game_Interface Interface, Scene CurrentScene)
        {
            InitializeComponent();
            Init(Interface, CurrentScene, 0, -1, false);
        }
        public Properties_Event(Game_Interface Interface, Scene CurrentScene, int Type, int Index, bool Locked)
        {
            InitializeComponent();
            Init(Interface, CurrentScene, Type, Index, Locked);
        }
        public void Init(Game_Interface Interface, Scene CurrentScene, int Type, int Index, bool Locked)
        {
            this._Type = Type;
            this._Index = Index;
            this._Scene = CurrentScene;
            this._Interface = Interface;
            _EventTypeString = new List<string>();
            for (int i = 0; i < CurrentScene.Events.EventList.Count; i++) _EventTypeString.Add(CurrentScene.Events.EventList[i].ID);
            List<string> EventScriptString = new List<string>();
            EventScriptString = Scene_Interface.GetPossibleEventNames(CurrentScene, CurrentScene.Events.EventList[Type].ID);
            HolderEvent.ClearControls();
            _EventTypes = new PropertiesInput_Combo("Type", _EventTypeString, Type, new EventHandler(EventTypeUpdate));
            HolderEvent.AddControl(_EventTypes);
            _PossibleEvents = new PropertiesInput_Combo("Event", EventScriptString, Index, new EventHandler(EventScriptUpdate));
            HolderEvent.AddControl(_PossibleEvents);
            if (Locked)
            {
                _EventTypes.Lock();
                _PossibleEvents.Lock();
                PropertiesInput_Button Delete = new PropertiesInput_Button("", "Remove Event", new EventHandler(RemoveEvent));
                HolderEvent.AddControl(Delete);
            }
            else
            {
                PropertiesInput_Button Lock = new PropertiesInput_Button("", "Lock", new EventHandler(LockEvent));
                HolderEvent.AddControl(Lock);
            }
        }
        private void EventTypeUpdate(object sender, EventArgs e)
        {
            this._Type = (int)_EventTypes.GetValue();
            Init(_Interface, _Scene, _Type, _Index, false);
        }
        private void EventScriptUpdate(object sender, EventArgs e)
        {
            this._Index = (int)_PossibleEvents.GetValue();
        }
        private void RemoveEvent(object sender, EventArgs e)
        {
            _Scene.Events.Events(_EventTypeString[_Type]).RemoveAt(_Scene.Events.Events(_EventTypeString[_Type]).IndexOf(
                Scene_Interface.GetPossibleEvents(_Scene, _EventTypeString[_Type])[_Index]));
            this.Visible = false;
        }
        private void LockEvent(object sender, EventArgs e)
        {
            if (_Index == -1) return;
            _Scene.Events.Events(_EventTypeString[_Type]).Add(Scene_Interface.GetPossibleEvents(_Scene, _EventTypeString[_Type])[_Index]);
            Init(_Interface, _Scene, _Type, _Index, true);
        }
        private void HolderEvent_Resize(object sender, EventArgs e)
        {
            this.Height = HolderEvent.Height;
        }
    }
}
