using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Data;

namespace Engineer.Engine
{
    public class Actor : DrawObject
    {
        private bool _Animated;
        private string _ID;
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
        public Actor() : base()
        {
            this._Animated = false;
            this.Type = DrawObjectType.Actor;
            this.GeometryMaterialIndices = new List<int>();
            this._Geometries = new List<Geometry>();
            this.Materials = new List<Material>();
            if (_UsedIDs == null) _UsedIDs = new List<string>();
            _UsedIDs.Add(ID);
        }
        public Actor(MeshContainer Mesh, string ID) : base()
        {
            this._ID = ID;
            this._Animated = false;
            this.Type = DrawObjectType.Actor;
            this.GeometryMaterialIndices = new List<int>();
            this._Geometries = Mesh.Geometries;
            this.Materials = new List<Material>();
            this.Materials.Add(new Material(ID + "_01", Material.Default));
            for(int i = 0; i < this._Geometries.Count; i++) this.GeometryMaterialIndices.Add(0);
        }
        private static List<string> _UsedIDs;
    }
}
