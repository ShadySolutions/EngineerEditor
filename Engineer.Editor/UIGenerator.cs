using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Engine;
using Engineer.Mathematics;
using ShadySolutions.UI.NodeEditor;
using System.Drawing;

namespace Engineer.Editor
{
    public class UIGenerator
    {
        public static void MaterialToUI(Material Mat, NodeEditor Editor)
        {
            for(int i = 0; i < Mat.Nodes.Count; i++)
            {
                MaterialNodeToUI(Mat, Mat.Nodes[i], Editor);
            }
        }
        private static Node MaterialNodeToUI(Material Mat, MaterialNode MatNode, NodeEditor Editor)
        {
            Node NewNode = new Node(MatNode.Name);
            NewNode.ID = MatNode.ID;
            NewNode.Source = MatNode;
            for (int i = 0; i < MatNode.Outputs.Count; i++) NewNode.AddNodeValue(MaterialNodeValueToUI(Mat, MatNode.Outputs[i], Editor));
            for (int i = 0; i < MatNode.Inputs.Count; i++) NewNode.AddNodeValue(MaterialNodeValueToUI(Mat, MatNode.Inputs[i], Editor));
            for (int i = 0; i < MatNode.Values.Count; i++) NewNode.AddNodeValue(MaterialNodeValueToUI(Mat, MatNode.Values[i], Editor));
            Editor.AddNode(NewNode);
            return NewNode;
        }
        private static NodeValue MaterialNodeValueToUI(Material Mat, MaterialNodeValue MatNodeVal, NodeEditor Editor)
        {
            NodeValue NewNodeValue;
            if (MatNodeVal.Value.Type == MaterialValueType.Input)
            {
                NewNodeValue = new NodeValueColor(MatNodeVal.Name);
                NewNodeValue.HasValue = false;
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.Output) NewNodeValue = new NodeValueOutput(MatNodeVal.Name);
            else if (MatNodeVal.Value.Type == MaterialValueType.Value)
            {
                NewNodeValue = new NodeValue(MatNodeVal.Name);
                NewNodeValue.HasOutput = false;
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.BoolValue)
            {
                NewNodeValue = new NodeValueBoolean(MatNodeVal.Name);
                NewNodeValue.Value.X = (MatNodeVal.Value.X == 1)?1:0;
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.IntValue)
            {
                NewNodeValue = new NodeValueFloat(MatNodeVal.Name);
                NewNodeValue.Value.X = MatNodeVal.Value.X;
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.FloatValue)
            {
                NewNodeValue = new NodeValueFloat(MatNodeVal.Name);
                NewNodeValue.Value.X = MatNodeVal.Value.X;
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.VertexValue)
            {
                NewNodeValue = new NodeValueVector(MatNodeVal.Name);
                NewNodeValue.Value = new ValueVector(MatNodeVal.Value.X, MatNodeVal.Value.Y, MatNodeVal.Value.Z);
            }
            else if (MatNodeVal.Value.Type == MaterialValueType.ColorValue)
            {
                NewNodeValue = new NodeValueColor(MatNodeVal.Name);
                NewNodeValue.Value = new ValueVector(MatNodeVal.Value.X, MatNodeVal.Value.Y, MatNodeVal.Value.Z, MatNodeVal.Value.W);
            }
            else
            {
                NewNodeValue = new NodeValue(MatNodeVal.Name);
                NewNodeValue.HasInput = false;
                NewNodeValue.HasOutput = false;
                NewNodeValue.HasValue = false;
            }
            NewNodeValue.Source = MatNodeVal;
            if (MatNodeVal.InputTarget != null)
            {
                for(int i = 0; i < Editor.Nodes.Count; i++)
                {
                    if(Editor.Nodes[i].ID == MatNodeVal.InputTarget.Parent.ID)
                    {
                        for(int j = 0; j < Editor.Nodes[i].Values.Count; j++)
                        {
                            if(Editor.Nodes[i].Values[j].Title == MatNodeVal.InputTarget.Name)
                            {
                                NewNodeValue.Input = Editor.Nodes[i].Values[j];
                                Editor.Nodes[i].Values[j].Outputs.Add(NewNodeValue);
                            }
                        }
                    }
                }
            }
            for(int k = 0; k < MatNodeVal.OutputTargets.Count; k++)
            {
                for (int i = 0; i < Editor.Nodes.Count; i++)
                {
                    if (Editor.Nodes[i].ID == MatNodeVal.OutputTargets[k].Parent.ID)
                    {
                        for (int j = 0; j < Editor.Nodes[i].Values.Count; j++)
                        {
                            if (Editor.Nodes[i].Values[j].Title == MatNodeVal.OutputTargets[k].Name)
                            {
                                NewNodeValue.Outputs.Add(Editor.Nodes[i].Values[j]);
                                Editor.Nodes[i].Values[j].Input = NewNodeValue;
                            }
                        }
                    }
                }
            }
            return NewNodeValue;
        }
    }
}
