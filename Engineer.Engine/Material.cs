using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class Material
    {
        private string _Name;
        private object _Tags;
        private List<MaterialNode> _Nodes;
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
        public object Tags
        {
            get
            {
                return _Tags;
            }

            set
            {
                _Tags = value;
            }
        }
        public List<MaterialNode> Nodes
        {
            get
            {
                return _Nodes;
            }

            set
            {
                _Nodes = value;
            }
        }
        public Material(string Name)
        {
            this._Name = Name;
            this._Tags = null;
            this._Nodes = new List<MaterialNode>();
        }
        public Material(XmlNode XNode)
        {
            this._Name = Guid.NewGuid().ToString();
            this._Tags = null;
            this._Nodes = new List<MaterialNode>();
            for(int i = 0; i < XNode.ChildNodes.Count; i++)
            {
                if(XNode.ChildNodes[i].Name == "Name")
                {
                    this._Name = XNode.ChildNodes[i].InnerText;
                }
                else if (XNode.ChildNodes[i].Name == "MaterialNode")
                {
                    this._Nodes.Add(new MaterialNode(XNode.ChildNodes[i], this));
                }
            }
        }
        public bool IsNodeIDFree(string ID)
        {
            bool Free = true;
            for(int i = 0; i < this._Nodes.Count; i++)
            {
                if(this._Nodes[i].ID == ID)
                {
                    Free = false;
                    break;
                }
            }
            return Free;
        }
    }
}
