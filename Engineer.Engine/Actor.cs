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
        private List<int> _GeometryMaterialIndices;
        private List<Material> _Materials;
        private List<Geometry> _Geometries;
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
        public List<int> GeometryMaterialIndices
        {
            get
            {
                return _GeometryMaterialIndices;
            }

            set
            {
                _GeometryMaterialIndices = value;
            }
        }
        public List<Material> Materials
        {
            get
            {
                return _Materials;
            }

            set
            {
                _Materials = value;
            }
        }
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
        public Actor(string Name) : base(Name)
        {
            this._Animated = false;
            this.GeometryMaterialIndices = new List<int>();
            this._Geometries = new List<Geometry>();
            this.Materials = new List<Material>();
        }
        public Actor(MeshContainer Mesh, string Name) : base(Name)
        {
            this._Animated = false;
            this.GeometryMaterialIndices = new List<int>();
            this._Geometries = Mesh.Geometries;
            this.Materials = new List<Material>();
            this.Materials.Add(new Material(Name + "_01", Material.Default));
            for(int i = 0; i < this._Geometries.Count; i++) this.GeometryMaterialIndices.Add(0);
        }
    }
}
