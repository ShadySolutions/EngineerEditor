using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class EventsPackage
    {
        private List<EventHandlersPackage> _EventList;
        public List<EventHandlersPackage> EventList
        {
            get
            {
                return _EventList;
            }
            set
            {
                _EventList = value;
            }
        }
        public EventsPackage()
        {
            this._EventList = new List<EventHandlersPackage>();
        }
        public EventsPackage(List<EventHandlersPackage> EventList)
        {
            this._EventList = EventList;
        }
        public EventsPackage(EventsPackage SE, Scene ParentScene)
        {
            for (int i = 0; i < SE._EventList.Count; i++) _EventList.Add(new EventHandlersPackage(SE._EventList[i], ParentScene));
        }
        public List<ScriptSceneObject> Events(string ID)
        {
            for (int i = 0; i < _EventList.Count; i++)
            {
                if (_EventList[i].ID == ID) return _EventList[i].Events;
            }
            return null;
        }
    }
    public class EventHandlersPackage
    {
        private string _ID;
        private List<ScriptSceneObject> _Events;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public List<ScriptSceneObject> Events
        {
            get
            {
                return _Events;
            }
            set
            {
                _Events = value;
            }
        }
        public EventHandlersPackage()
        {
            this.ID = Guid.NewGuid().ToString();
            this.Events = new List<ScriptSceneObject>();
        }
        public EventHandlersPackage(string ID)
        {
            this.ID = ID;
            this.Events = new List<ScriptSceneObject>();
        }
        public EventHandlersPackage(EventHandlersPackage SEH, Scene ParentScene)
        {
            this.ID = SEH.ID;
            this._Events = new List<ScriptSceneObject>();
            for (int i = 0; i < SEH._Events.Count; i++) _Events.Add(new ScriptSceneObject(SEH._Events[i], ParentScene));
        }
        public static List<EventHandlersPackage> NewSceneEventsPackage()
        {
            List<EventHandlersPackage> EventList = new List<EventHandlersPackage>();
            EventList.Add(new EventHandlersPackage("Closing"));
            EventList.Add(new EventHandlersPackage("KeyDown"));
            EventList.Add(new EventHandlersPackage("KeyUp"));
            EventList.Add(new EventHandlersPackage("KeyPress"));
            EventList.Add(new EventHandlersPackage("Load"));
            EventList.Add(new EventHandlersPackage("MouseDown"));
            EventList.Add(new EventHandlersPackage("MouseUp"));
            EventList.Add(new EventHandlersPackage("MouseClick"));
            EventList.Add(new EventHandlersPackage("MouseMove"));
            EventList.Add(new EventHandlersPackage("MouseWheel"));
            EventList.Add(new EventHandlersPackage("RenderFrame"));
            EventList.Add(new EventHandlersPackage("TimerTick"));
            return EventList;
        }
        public static List<EventHandlersPackage> NewDrawnSceneObjectEventsPackage()
        {
            List<EventHandlersPackage> EventList = new List<EventHandlersPackage>();
            EventList.Add(new EventHandlersPackage("MouseDown"));
            EventList.Add(new EventHandlersPackage("MouseUp"));
            EventList.Add(new EventHandlersPackage("MouseClick"));
            EventList.Add(new EventHandlersPackage("MouseMove"));
            return EventList;
        }
    }
}
