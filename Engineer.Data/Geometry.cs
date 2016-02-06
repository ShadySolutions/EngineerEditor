using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;

namespace Engineer.Data
{
    public class Geometry
    {
        private string _Name;
        private List<Vertex> _Vertices;
        private List<Vertex> _Normals;
        private List<Vertex> _TexCoords;
        private List<Face> _Faces;
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
        public List<Vertex> Vertices
        {
            get
            {
                return _Vertices;
            }

            set
            {
                _Vertices = value;
            }
        }
        public List<Vertex> Normals
        {
            get
            {
                return _Normals;
            }

            set
            {
                _Normals = value;
            }
        }
        public List<Vertex> TexCoords
        {
            get
            {
                return _TexCoords;
            }

            set
            {
                _TexCoords = value;
            }
        }
        public List<Face> Faces
        {
            get
            {
                return _Faces;
            }

            set
            {
                _Faces = value;
            }
        }
        public Geometry(string Name)
        {
            this._Name = Name;
            this._Vertices = new List<Vertex>();
            this._Normals = new List<Vertex>();
            this._TexCoords = new List<Vertex>();
            this._Faces = new List<Face>();
        }
        public void RecalculateNormals()
        {
            this._Normals = new List<Vertex>();
            List<Vertex>[] Normals = new List<Vertex>[_Vertices.Count];
            for(int i = 0; i < this._Faces.Count; i++)
            {
                List<Vertex> Vertices = new List<Vertex>();
                for(int j = 0; j < this._Faces[i].Vertices.Count; j++)
                {
                    Vertices.Add(this._Vertices[Faces[i].Vertices[j]]);
                }
                Vertex Normal = VertexTransformer.CalculateNormal(Vertices.ToArray());
                for (int j = 0; j < this._Faces[i].Vertices.Count; j++)
                {
                    if (Normals[Faces[i].Vertices[j]] == null) Normals[Faces[i].Vertices[j]] = new List<Vertex>();
                    Normals[Faces[i].Vertices[j]].Add(Normal);
                    Faces[i].Normals.Add(j);
                }
            }
            for(int i = 0; i < _Vertices.Count; i++)
            {
                if (Normals[i] == null) this._Normals.Add(new Vertex(0, 1, 0));
                else this._Normals.Add(VertexTransformer.Average(Normals[i].ToArray()));
            }
        }
    }
}
