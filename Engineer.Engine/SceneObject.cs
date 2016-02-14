using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public enum SceneObjectType
    {
        Undefined = 0,
        DrawnSceneObject = 1
    }
    public class SceneObject
    {
        private string _Name;
        private SceneObjectType _Type;
        private Scene _ParentScene;
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
        public SceneObjectType Type
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
        public Scene ParentScene
        {
            get
            {
                return _ParentScene;
            }

            set
            {
                _ParentScene = value;
            }
        }
        public SceneObject(string Name)
        {
            this._Name = Name;
            this._Type = SceneObjectType.Undefined;
        }
    }
}
