using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Data;

namespace Engineer.Engine
{
    public class Actor : SceneObject
    {
        private bool _Animated;
        public bool Animated
        {
            get
            {
                return _Animated;
            }

            set
            {
                _Animated = value;
            }
        }
        private List<Geometry> _Geometries;
        public List<Geometry> Geometries
        {
            get
            {
                return _Geometries;
            }

            set
            {
                _Geometries = value;
            }
        }
        public Actor() : base()
        {
            this._Animated = false;
            this.Geometries = new List<Geometry>();
        }
        public Actor(MeshContainer Mesh) : base()
        {
            this._Animated = false;
            this.Geometries = Mesh.Geometries;
        }
    }
}
