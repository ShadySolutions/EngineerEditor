using Engineer.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class Scene2D : Scene
    {
        private Scene2DTransformation _Transformation;
        public Scene2DTransformation Transformation
        {
            get
            {
                return _Transformation;
            }

            set
            {
                _Transformation = value;
            }
        }
        public override bool AddSceneObject(SceneObject Object)
        {
            if (Object.Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(Object).Representation.Type == DrawObjectType.Actor) return false;
            if (Object.Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(Object).Representation.Type == DrawObjectType.Camera) return false;
            if (Object.Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(Object).Representation.Type == DrawObjectType.Light) return false;
            if (Object.Type == SceneObjectType.DrawnSceneObject && DrawnSceneObject.Drawn(Object).Representation.Type == DrawObjectType.Undefined) return false;
            Object.ParentScene = this;
            this._Objects.Add(Object);
            return true;
        }
        public Scene2D(string Name) : base(Name)
        {
            this._Transformation = new Scene2DTransformation();
        }
    }
}
