using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class MaterialNode
    {
        private string _ID;
        private string _Name;
        private string _FunctionID;
        private object _Tags;
        private Material _Holder;
        private List<MaterialNodeValue> _Values;
        private List<MaterialNodeValue> _Inputs;
        private List<MaterialNodeValue> _Outputs;
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
        public string FunctionID
        {
            get
            {
                return _FunctionID;
            }

            set
            {
                _FunctionID = value;
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
        public Material Holder
        {
            get
            {
                return _Holder;
            }

            set
            {
                _Holder = value;
            }
        }
        public List<MaterialNodeValue> Values
        {
            get
            {
                return _Values;
            }

            set
            {
                _Values = value;
            }
        }
        public List<MaterialNodeValue> Inputs
        {
            get
            {
                return _Inputs;
            }

            set
            {
                _Inputs = value;
            }
        }
        public List<MaterialNodeValue> Outputs
        {
            get
            {
                return _Outputs;
            }

            set
            {
                _Outputs = value;
            }
        }
        public MaterialNode(string Name, Material Holder)
        {
            SetID(Name, Holder);
            this._Name = Name;
            this._Holder = Holder;
            this._Values = new List<MaterialNodeValue>();
            this._Inputs = new List<MaterialNodeValue>();
            this._Outputs = new List<MaterialNodeValue>();
        }
        public MaterialNode(XmlNode XNode, Material Holder)
        {
            this._ID = "";
            this._Holder = Holder;
            this._Values = new List<MaterialNodeValue>();
            this._Inputs = new List<MaterialNodeValue>();
            this._Outputs = new List<MaterialNodeValue>();
            for(int i = 0; i < XNode.ChildNodes.Count; i++)
            {
                if(XNode.ChildNodes[i].Name == "ID")
                {
                    this._ID = XNode.ChildNodes[i].InnerText;
                }
                else if (XNode.ChildNodes[i].Name == "Name")
                {
                    this._Name = XNode.ChildNodes[i].InnerText;
                    if (this._ID == "") SetID(this._Name, Holder);
                }
                else if (XNode.ChildNodes[i].Name == "Function")
                {
                    this._FunctionID = XNode.ChildNodes[i].InnerText;
                    if (this._FunctionID == "") this._FunctionID = "None";
                }
                else if (XNode.ChildNodes[i].Name == "Value")
                {
                    this._Values.Add(new MaterialNodeValue(this, XNode.ChildNodes[i], MaterialValueType.Value));
                }
                else if (XNode.ChildNodes[i].Name == "Input")
                {
                    this._Inputs.Add(new MaterialNodeValue(this, XNode.ChildNodes[i], MaterialValueType.Input));
                }
                else if (XNode.ChildNodes[i].Name == "Output")
                {
                    this._Outputs.Add(new MaterialNodeValue(this, XNode.ChildNodes[i], MaterialValueType.Output));
                }
            }
        }
        private void SetID(string Name, Material Holder)
        {
            for (int i = 0; true; i++)
            {
                if (Holder.IsNodeIDFree(Name + "_" + i))
                {
                    this._ID = Name + "_" + i;
                    break;
                }
            }
        }
    }
}
