using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    [XmlInclude(typeof(DrawObject))]
    [XmlInclude(typeof(Actor))]
    [XmlInclude(typeof(Background))]
    [XmlInclude(typeof(Camera))]
    [XmlInclude(typeof(Light))]
    [XmlInclude(typeof(Sprite))]
    public class DrawnSceneObject : SceneObject
    {
        private DrawObject _Representation;
        public DrawObject Representation
        {
            get
            {
                return _Representation;
            }

            set
            {
                _Representation = value;
            }
        }
        public DrawnSceneObject() : base()
        {
            this.Type = SceneObjectType.DrawnSceneObject;
            this.Representation = null;
        }
        public DrawnSceneObject(string Name, DrawObject Representation) : base(Name)
        {
            this.Type = SceneObjectType.DrawnSceneObject;
            this.Representation = Representation;
        }
        public static DrawnSceneObject Drawn(SceneObject Object)
        {
            return Object as DrawnSceneObject;
        }
    }
}
