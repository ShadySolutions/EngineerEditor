using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public enum SceneType
    {
        Scene2D = 0,
        Scene3D = 1
    }
    public class Scene
    {
        protected string _Name;
        protected Color _BackColor;
        protected List<SceneObject> _Objects;
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
        public Scene(string Name)
        {
            this._Name = Name;
            this._BackColor = Color.FromArgb(40, 40, 40);
            this._Objects = new List<SceneObject>();
        }
    }
}
