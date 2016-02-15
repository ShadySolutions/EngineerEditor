﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Engineer.Mathematics;
using System.Drawing;

namespace Engineer.Engine
{
    public class MaterialNodeValue
    {
        private string _Name;
        private MaterialValueHolder _Value;
        private MaterialNodeValue _InputTarget;
        private MaterialNode _Parent;
        private List<MaterialNodeValue> _OutputTargets;
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
        public MaterialValueHolder Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }
        public MaterialNodeValue InputTarget
        {
            get
            {
                return _InputTarget;
            }

            set
            {
                _InputTarget = value;
            }
        }
        public MaterialNode Parent
        {
            get
            {
                return _Parent;
            }

            set
            {
                _Parent = value;
            }
        }
        public List<MaterialNodeValue> OutputTargets
        {
            get
            {
                return _OutputTargets;
            }

            set
            {
                _OutputTargets = value;
            }
        }       
        public MaterialNodeValue(string Name, MaterialNode Parent)
        {
            this._Name = Name;
            this._Value = new MaterialValueHolder();
            this._InputTarget = null;
            this.Parent = Parent;
            this._OutputTargets = new List<MaterialNodeValue>();
        }
        private void SetValue(XmlNode XNode)
        {
            if (this._Value.Type == MaterialValueType.BoolValue)
            {
                if (XNode == null) this._Value = new MaterialValueHolder(0, 0, 0);
                if (XNode.InnerText == "True") this._Value = new MaterialValueHolder(1, 0, 0);
                else this._Value = new MaterialValueHolder(0, 0, 0);
            }
            else if (this._Value.Type == MaterialValueType.IntValue)
            {
                if (XNode == null) this._Value = new MaterialValueHolder(0, 0, 0);
                this._Value = new MaterialValueHolder(Convert.ToInt32(XNode.InnerText), 0, 0);
            }
            else if (this._Value.Type == MaterialValueType.FloatValue)
            {
                if (XNode == null) this._Value = new MaterialValueHolder(0, 0, 0);
                this._Value = new MaterialValueHolder(Convert.ToSingle(XNode.InnerText), 0, 0);
            }
            else if (this._Value.Type == MaterialValueType.VertexValue)
            {
                Vertex NewVertex = new Vertex();
                if (XNode != null)
                {
                    for (int j = 0; j < XNode.ChildNodes.Count; j++)
                    {
                        if (XNode.ChildNodes[j].Name == "X")
                        {
                            NewVertex.X = Convert.ToSingle(XNode.ChildNodes[j].InnerText);
                        }
                        else if (XNode.ChildNodes[j].Name == "Y")
                        {
                            NewVertex.X = Convert.ToSingle(XNode.ChildNodes[j].InnerText);
                        }
                        else if (XNode.ChildNodes[j].Name == "Z")
                        {
                            NewVertex.X = Convert.ToSingle(XNode.ChildNodes[j].InnerText);
                        }
                    }
                }
                this._Value = new MaterialValueHolder(NewVertex.X, NewVertex.Y, NewVertex.Z);
            }
            else if (this._Value.Type == MaterialValueType.ColorValue)
            {
                int R = 0, G = 0, B = 0, A = 255;
                if (XNode != null)
                {
                    for (int j = 0; j < XNode.ChildNodes.Count; j++)
                    {
                        if (XNode.ChildNodes[j].Name == "R")
                        {
                            R = (int)(Convert.ToSingle(XNode.ChildNodes[j].InnerText) * 256 - 1);
                        }
                        else if (XNode.ChildNodes[j].Name == "G")
                        {
                            G = (int)(Convert.ToSingle(XNode.ChildNodes[j].InnerText) * 256 - 1);
                        }
                        else if (XNode.ChildNodes[j].Name == "B")
                        {
                            B = (int)(Convert.ToSingle(XNode.ChildNodes[j].InnerText) * 256 - 1);
                        }
                        else if (XNode.ChildNodes[j].Name == "A")
                        {
                            A = (int)(Convert.ToSingle(XNode.ChildNodes[j].InnerText) * 256 - 1);
                        }
                    }
                }
                this._Value = new MaterialValueHolder(R, G, B, A);
            }
            else if (this._Value.Type == MaterialValueType.TextureValue)
            {
                this._Value = new MaterialValueHolder(0, 0, 0);
                if (XNode != null)
                {
                    this._Value.Value = XNode.InnerText;
                }
            }
        }
        public MaterialNodeValue(MaterialNode Parent, XmlNode XNode, MaterialValueType Type)
        {
            this._Name = "Unnamed";
            this._Value = new MaterialValueHolder();
            this._InputTarget = null;
            this.Parent = Parent;
            this._OutputTargets = new List<MaterialNodeValue>();
            if (Type == MaterialValueType.Output) this._Value.Type = MaterialValueType.Output;
            else if (Type == MaterialValueType.Input) this._Value.Type = MaterialValueType.Input;
            XmlNode XValue = null;
            for (int i = 0; i < XNode.ChildNodes.Count; i++)
            {
                if (XNode.ChildNodes[i].Name == "Name")
                {
                    this._Name = XNode.ChildNodes[i].InnerText;
                }
                if (XNode.ChildNodes[i].Name == "Type")
                {
                    if (XNode.ChildNodes[i].InnerText == "Input") this._Value.Type = MaterialValueType.Input;
                    else if (XNode.ChildNodes[i].InnerText == "Output") this._Value.Type = MaterialValueType.Output;
                    else if (XNode.ChildNodes[i].InnerText == "Bool") this._Value.Type = MaterialValueType.BoolValue;
                    else if (XNode.ChildNodes[i].InnerText == "Int") this._Value.Type = MaterialValueType.IntValue;
                    else if (XNode.ChildNodes[i].InnerText == "Float") this._Value.Type = MaterialValueType.FloatValue;
                    else if (XNode.ChildNodes[i].InnerText == "Vertex") this._Value.Type = MaterialValueType.VertexValue;
                    else if (XNode.ChildNodes[i].InnerText == "Color") this._Value.Type = MaterialValueType.ColorValue;
                    else if (XNode.ChildNodes[i].InnerText == "Image") this._Value.Type = MaterialValueType.TextureValue;
                }
                if (XNode.ChildNodes[i].Name == "Value")
                {
                    XValue = XNode.ChildNodes[i];
                }
                if (XNode.ChildNodes[i].Name == "Connect")
                {
                    string TargetID = XNode.ChildNodes[i].ChildNodes[0].InnerText;
                    string TragetNodeValue = XNode.ChildNodes[i].ChildNodes[1].InnerText;
                    if (Type == MaterialValueType.Input)
                    {
                        MaterialNodeValue Connection = FindConnection(Parent, TargetID, TragetNodeValue, MaterialValueType.Output);
                        if(Connection != null)
                        {
                            this._InputTarget = Connection;
                            Connection.OutputTargets.Add(this);
                        }
                    }
                    else if (Type == MaterialValueType.Output)
                    {
                        MaterialNodeValue Connection = FindConnection(Parent, TargetID, TragetNodeValue, MaterialValueType.Input);
                        if (Connection != null)
                        {
                            Connection._InputTarget = this;
                            this.OutputTargets.Add(Connection);
                        }
                    }
                }
            }
            SetValue(XValue);
        }
        private MaterialNodeValue FindConnection(MaterialNode Parent, string ID, string ValueName, MaterialValueType Type)
        {
            Material HolderMaterial = Parent.Holder;
            for(int i = 0; i < HolderMaterial.Nodes.Count; i++)
            {
                if(HolderMaterial.Nodes[i].ID == ID)
                {
                    if (Type == MaterialValueType.Input)
                    {
                        for (int j = 0; j < HolderMaterial.Nodes[i].Inputs.Count; j++)
                        {
                            if (HolderMaterial.Nodes[i].Inputs[j].Name == ValueName)
                            {
                                return HolderMaterial.Nodes[i].Inputs[j];
                            }
                        }
                    }
                    else if (Type == MaterialValueType.Output)
                    {
                        for (int j = 0; j < HolderMaterial.Nodes[i].Outputs.Count; j++)
                        {
                            if (HolderMaterial.Nodes[i].Outputs[j].Name == ValueName)
                            {
                                return HolderMaterial.Nodes[i].Outputs[j];
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
