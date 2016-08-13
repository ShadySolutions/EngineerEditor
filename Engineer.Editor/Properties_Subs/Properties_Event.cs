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
    public partial class Properties_Event : PropertiesHolder
    {
        private int _Type;
        private int _Index;
        private Scene _Scene;
        private SceneObject _SceneObject;
        private Game_Interface _Interface;
        private PropertiesInput_Combo _EventTypes;
        private PropertiesInput_Combo _PossibleEvents;
        private List<string> _EventTypeString;
        public Properties_Event()
        {
            InitializeComponent();
        }
        public Properties_Event(Game_Interface Interface, object EventCaller)
        {
            InitializeComponent();
            Init(Interface, EventCaller, 0, -1, false);
        }
        public Properties_Event(Game_Interface Interface, object EventCaller, int Type, int Index, bool Locked)
        {
            InitializeComponent();
            Init(Interface, EventCaller, Type, Index, Locked);
        }
        public void Init(Game_Interface Interface, object EventCaller, int Type, int Index, bool Locked)
        {
            this._Type = Type;
            this._Index = Index;
            this._Interface = Interface;
            _EventTypeString = new List<string>();
            List<string> EventScriptString = new List<string>();
            if (EventCaller.GetType().IsSubclassOf(typeof(Scene)))
            {
                this._Scene = (Scene)EventCaller;
                for (int i = 0; i < _Scene.Events.EventList.Count; i++) _EventTypeString.Add(_Scene.Events.EventList[i].ID);
                EventScriptString = Scene_Interface.GetPossibleEventNames(_Scene, _Scene.Events.EventList[Type].ID);
            }
            else if (EventCaller.GetType().IsSubclassOf(typeof(SceneObject)))
            {
                this._SceneObject = (SceneObject)EventCaller;
                for (int i = 0; i < _SceneObject.Events.EventList.Count; i++) _EventTypeString.Add(_SceneObject.Events.EventList[i].ID);
                EventScriptString = Scene_Interface.GetPossibleEventNames(_SceneObject.ParentScene, _SceneObject.Events.EventList[Type].ID);
            }
            this.ClearControls();
            _EventTypes = new PropertiesInput_Combo("Type", _EventTypeString, Type, new EventHandler(EventTypeUpdate));
            this.AddControl(_EventTypes);
            _PossibleEvents = new PropertiesInput_Combo("Event", EventScriptString, Index, new EventHandler(EventScriptUpdate));
            this.AddControl(_PossibleEvents);
            if (Locked)
            {
                _EventTypes.Lock();
                _PossibleEvents.Lock();
                PropertiesInput_Button Delete = new PropertiesInput_Button("", "Remove Event", new EventHandler(RemoveEvent));
                this.AddControl(Delete);
            }
            else
            {
                PropertiesInput_Button Lock = new PropertiesInput_Button("", "Lock", new EventHandler(LockEvent));
                this.AddControl(Lock);
            }
            this.SetTitleColor(Color.FromArgb(80,80,80));
        }
        private void EventTypeUpdate(object sender, EventArgs e)
        {
            this._Type = (int)_EventTypes.GetValue();
            if(_Scene!=null) Init(_Interface, _Scene, _Type, _Index, false);
            else Init(_Interface, _SceneObject, _Type, _Index, false);
        }
        private void EventScriptUpdate(object sender, EventArgs e)
        {
            this._Index = (int)_PossibleEvents.GetValue();
        }
        private void RemoveEvent(object sender, EventArgs e)
        {
            if (_Scene != null)
            {
                _Scene.Events.Events(_EventTypeString[_Type]).RemoveAt(_Scene.Events.Events(_EventTypeString[_Type]).IndexOf(
                Scene_Interface.GetPossibleEvents(_Scene, _EventTypeString[_Type])[_Index]));
            }
            else
            {
                _SceneObject.Events.Events(_EventTypeString[_Type]).RemoveAt(_SceneObject.Events.Events(_EventTypeString[_Type]).IndexOf(
                Scene_Interface.GetPossibleEvents(_SceneObject.ParentScene, _EventTypeString[_Type])[_Index]));
            }
            this.Visible = false;
        }
        private void LockEvent(object sender, EventArgs e)
        {
            if (_Index == -1) return;
            if (_Scene != null)
            {
                _Scene.Events.Events(_EventTypeString[_Type]).Add(Scene_Interface.GetPossibleEvents(_Scene, _EventTypeString[_Type])[_Index]);
                Init(_Interface, _Scene, _Type, _Index, true);
            }
            else
            {
                _SceneObject.Events.Events(_EventTypeString[_Type]).Add(Scene_Interface.GetPossibleEvents(_SceneObject.ParentScene, _EventTypeString[_Type])[_Index]);
                Init(_Interface, _SceneObject, _Type, _Index, true);
            }
        }
    }
}
