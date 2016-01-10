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
            this.Geometries = new List<Geometry>();
        }
        public Actor(MeshContainer Mesh) : base()
        {
            this.Geometries = Mesh.Geometries;
        }
    }
}
