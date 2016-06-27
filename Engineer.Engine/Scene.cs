using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    public enum SceneType
    {
        Scene2D = 0,
        Scene3D = 1
    }
    [XmlInclude(typeof(SceneObject))]
    [XmlInclude(typeof(ScriptSceneObject))]
    [XmlInclude(typeof(DrawnSceneObject))]
    public class Scene
    {
        private string _ID;
        protected string _Name;
        protected SceneType _Type;
        protected Color _BackColor;
        private SceneEvents _Events;
        protected List<SceneObject> _Objects;
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
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
        public SceneType Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        [XmlIgnore]
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;
            }
        }
        public SceneEvents Events
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
        public List<SceneObject> Objects
        {
            get
            {
                return _Objects;
            }
        }
        public List<ScriptSceneObject> Scripts
        {
            get
            {
                List<ScriptSceneObject> NewList = new List<ScriptSceneObject>();
                for (int i = 0; i < Objects.Count; i++)
                {
                    if (Objects[i].Type == SceneObjectType.ScriptSceneObject)
                    {
                        NewList.Add((ScriptSceneObject)Objects[i]);
                    }
                }
                return NewList;
            }
        }
        public virtual bool AddSceneObject(SceneObject Object)
        {
            Object.ParentScene = this;
            this._Objects.Add(Object);
            return true;
        }
        public Scene()
        {
            this._ID = Guid.NewGuid().ToString();
            this._Name = this._ID;
            this._BackColor = Color.FromArgb(40, 40, 40);
            this._Objects = new List<SceneObject>();
            this._Events = new SceneEvents();
        }
        public Scene(string Name)
        {
            this._ID = Guid.NewGuid().ToString();
            this._Name = Name;
            this._BackColor = Color.FromArgb(40, 40, 40);
            this._Objects = new List<SceneObject>();
            this._Events = new SceneEvents();
        }
        public Scene(Scene S)
        {
            this._ID = Guid.NewGuid().ToString();
            this._Name = S.Name;
            this._Type = S._Type;
            this._BackColor = S._BackColor;
            this._Events = new SceneEvents(S._Events, this);
            this._Objects = new List<SceneObject>();
            for(int i = 0; i < S._Objects.Count; i++)
            {
                if (S._Objects[i].Type == SceneObjectType.DrawnSceneObject) this._Objects.Add(new DrawnSceneObject((DrawnSceneObject)S._Objects[i], this));
                else if (S._Objects[i].Type == SceneObjectType.ScriptSceneObject) this._Objects.Add(new ScriptSceneObject((ScriptSceneObject)S._Objects[i], this));
            }
        }
    }
    public class SceneEvents
    {
        private List<SceneEventHandlers> _EventList;
        public List<SceneEventHandlers> EventList
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
        public SceneEvents()
        {
            this._EventList = SceneEventHandlers.NewSceneEvents();
        }
        public SceneEvents(SceneEvents SE, Scene ParentScene)
        {
            for (int i = 0; i < SE._EventList.Count; i++) _EventList.Add(new SceneEventHandlers(SE._EventList[i], ParentScene));
        }
        public List<ScriptSceneObject> Events(string ID)
        {
            for(int i = 0; i < _EventList.Count; i++)
            {
                if (_EventList[i].ID == ID) return _EventList[i].Events;
            }
            return null;
        }
    }
    public class SceneEventHandlers
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
        public SceneEventHandlers()
        {
            this.ID = Guid.NewGuid().ToString();
            this.Events = new List<ScriptSceneObject>();
        }
        public SceneEventHandlers(string ID)
        {
            this.ID = ID;
            this.Events = new List<ScriptSceneObject>();
        }
        public SceneEventHandlers(SceneEventHandlers SEH, Scene ParentScene)
        {
            this.ID = SEH.ID;
            this._Events = new List<ScriptSceneObject>();
            for(int i = 0; i < SEH._Events.Count; i++) _Events.Add(new ScriptSceneObject(SEH._Events[i], ParentScene));
        }
        public static List<SceneEventHandlers> NewSceneEvents()
        {
            List<SceneEventHandlers> EventList = new List<SceneEventHandlers>();
            EventList.Add(new SceneEventHandlers("Closing"));
            EventList.Add(new SceneEventHandlers("KeyDown"));
            EventList.Add(new SceneEventHandlers("KeyUp"));
            EventList.Add(new SceneEventHandlers("KeyPress"));
            EventList.Add(new SceneEventHandlers("Load"));
            EventList.Add(new SceneEventHandlers("MouseDown"));
            EventList.Add(new SceneEventHandlers("MouseUp"));
            EventList.Add(new SceneEventHandlers("MouseClick"));
            EventList.Add(new SceneEventHandlers("MouseMove"));
            EventList.Add(new SceneEventHandlers("MouseWheel"));
            EventList.Add(new SceneEventHandlers("RenderFrame"));
            EventList.Add(new SceneEventHandlers("TimerTick"));
            return EventList;
        }
    }
}
