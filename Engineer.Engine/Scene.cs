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
            }
        }
    }
    public class SceneEvents
    {
        private List<ScriptSceneObject> _Closing;
        private List<ScriptSceneObject> _KeyDown;
        private List<ScriptSceneObject> _KeyUp;
        private List<ScriptSceneObject> _KeyPress;
        private List<ScriptSceneObject> _Load;
        private List<ScriptSceneObject> _MouseDown;
        private List<ScriptSceneObject> _MouseUp;
        private List<ScriptSceneObject> _MousePress;
        private List<ScriptSceneObject> _MouseMove;
        private List<ScriptSceneObject> _MouseWheel;
        private List<ScriptSceneObject> _RenderFrame;
        private List<ScriptSceneObject> _EverySecond;
        public List<ScriptSceneObject> Closing
        {
            get
            {
                return _Closing;
            }

            set
            {
                _Closing = value;
            }
        }
        public List<ScriptSceneObject> KeyDown
        {
            get
            {
                return _KeyDown;
            }

            set
            {
                _KeyDown = value;
            }
        }
        public List<ScriptSceneObject> KeyUp
        {
            get
            {
                return _KeyUp;
            }

            set
            {
                _KeyUp = value;
            }
        }
        public List<ScriptSceneObject> KeyPress
        {
            get
            {
                return _KeyPress;
            }

            set
            {
                _KeyPress = value;
            }
        }
        public List<ScriptSceneObject> Load
        {
            get
            {
                return _Load;
            }

            set
            {
                _Load = value;
            }
        }
        public List<ScriptSceneObject> MouseDown
        {
            get
            {
                return _MouseDown;
            }

            set
            {
                _MouseDown = value;
            }
        }
        public List<ScriptSceneObject> MouseUp
        {
            get
            {
                return _MouseUp;
            }

            set
            {
                _MouseUp = value;
            }
        }
        public List<ScriptSceneObject> MousePress
        {
            get
            {
                return _MousePress;
            }

            set
            {
                _MousePress = value;
            }
        }
        public List<ScriptSceneObject> MouseMove
        {
            get
            {
                return _MouseMove;
            }

            set
            {
                _MouseMove = value;
            }
        }
        public List<ScriptSceneObject> MouseWheel
        {
            get
            {
                return _MouseWheel;
            }

            set
            {
                _MouseWheel = value;
            }
        }
        public List<ScriptSceneObject> RenderFrame
        {
            get
            {
                return _RenderFrame;
            }

            set
            {
                _RenderFrame = value;
            }
        }
        public List<ScriptSceneObject> EverySecond
        {
            get
            {
                return _EverySecond;
            }

            set
            {
                _EverySecond = value;
            }
        }
        public SceneEvents()
        {
            this.Closing = new List<ScriptSceneObject>();
            this.KeyDown = new List<ScriptSceneObject>();
            this.KeyUp = new List<ScriptSceneObject>();
            this.KeyPress = new List<ScriptSceneObject>();
            this.Load = new List<ScriptSceneObject>();
            this.MouseDown = new List<ScriptSceneObject>();
            this.MouseUp = new List<ScriptSceneObject>();
            this.MousePress = new List<ScriptSceneObject>();
            this.MouseMove = new List<ScriptSceneObject>();
            this.MouseWheel = new List<ScriptSceneObject>();
            this.RenderFrame = new List<ScriptSceneObject>();
            this.EverySecond = new List<ScriptSceneObject>();
        }
        public SceneEvents(SceneEvents SE, Scene ParentScene)
        {
            this.Closing = new List<ScriptSceneObject>();
            this.KeyDown = new List<ScriptSceneObject>();
            this.KeyUp = new List<ScriptSceneObject>();
            this.KeyPress = new List<ScriptSceneObject>();
            this.Load = new List<ScriptSceneObject>();
            this.MouseDown = new List<ScriptSceneObject>();
            this.MouseUp = new List<ScriptSceneObject>();
            this.MousePress = new List<ScriptSceneObject>();
            this.MouseMove = new List<ScriptSceneObject>();
            this.MouseWheel = new List<ScriptSceneObject>();
            this.RenderFrame = new List<ScriptSceneObject>();
            this.EverySecond = new List<ScriptSceneObject>();
            for (int i = 0; i < SE.Closing.Count; i++) this.Closing.Add(new ScriptSceneObject(SE.Closing[i], ParentScene));
            for (int i = 0; i < SE.KeyDown.Count; i++) this.KeyDown.Add(new ScriptSceneObject(SE.KeyDown[i], ParentScene));
            for (int i = 0; i < SE.KeyUp.Count; i++) this.KeyUp.Add(new ScriptSceneObject(SE.KeyUp[i], ParentScene));
            for (int i = 0; i < SE.KeyPress.Count; i++) this.KeyPress.Add(new ScriptSceneObject(SE.KeyPress[i], ParentScene));
            for (int i = 0; i < SE.Load.Count; i++) this.Load.Add(new ScriptSceneObject(SE.Load[i], ParentScene));
            for (int i = 0; i < SE.MouseDown.Count; i++) this.MouseDown.Add(new ScriptSceneObject(SE.MouseDown[i], ParentScene));
            for (int i = 0; i < SE.MouseUp.Count; i++) this.MouseUp.Add(new ScriptSceneObject(SE.MouseUp[i], ParentScene));
            for (int i = 0; i < SE.MousePress.Count; i++) this.MousePress.Add(new ScriptSceneObject(SE.MousePress[i], ParentScene));
            for (int i = 0; i < SE.MouseMove.Count; i++) this.MouseMove.Add(new ScriptSceneObject(SE.MouseMove[i], ParentScene));
            for (int i = 0; i < SE.MouseWheel.Count; i++) this.MouseWheel.Add(new ScriptSceneObject(SE.MouseWheel[i], ParentScene));
            for (int i = 0; i < SE.RenderFrame.Count; i++) this.RenderFrame.Add(new ScriptSceneObject(SE.RenderFrame[i], ParentScene));
            for (int i = 0; i < SE.EverySecond.Count; i++) this.EverySecond.Add(new ScriptSceneObject(SE.EverySecond[i], ParentScene));
        }
    }
}
