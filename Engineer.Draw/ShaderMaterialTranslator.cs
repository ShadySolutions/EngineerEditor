using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Engineer.Engine;

namespace Engineer.Draw
{
    public class ShaderMaterialTranslator : MaterialTranslator
    {
        public static ShaderMaterialTranslator Translator;
        private string _MaterialTranslatorType;
        private string _VertexShaderOutput;
        private string _FragmentShaderOutput;
        private List<ShaderMaterialTranslatorEntry> _Entries;
        public List<ShaderMaterialTranslatorEntry> Entries
        {
            get
            {
                return _Entries;
            }

            set
            {
                _Entries = value;
            }
        }
        public string VertexShaderOutput
        {
            get
            {
                return _VertexShaderOutput;
            }

            set
            {
                _VertexShaderOutput = value;
            }
        }
        public string FragmentShaderOutput
        {
            get
            {
                return _FragmentShaderOutput;
            }

            set
            {
                _FragmentShaderOutput = value;
            }
        }
        public ShaderMaterialTranslator()
        {
            this._MaterialTranslatorType = "Shader";
            this._Entries = new List<ShaderMaterialTranslatorEntry>();
            LoadEntries();
            Translator = this;
        }
        public ShaderMaterialTranslator(string Type)
        {
            this._MaterialTranslatorType = Type;
            this._Entries = new List<ShaderMaterialTranslatorEntry>();
            LoadEntries();
            Translator = this;
        } 
        public override bool TranslateMaterial(Material AppliedMaterial)
        {
            MaterialNode Output = null;
            for(int i = 0; i < AppliedMaterial.Nodes.Count; i++)
            {
                if (AppliedMaterial.Nodes[i].ID == "Output") Output = AppliedMaterial.Nodes[i];
            }
            if (Output == null) return false;
            string Fragment = GenerateFragment(Output);
            if (Fragment == "") return false;
            this._FragmentShaderOutput = Fragment;
            this._VertexShaderOutput = File.ReadAllText(this._MaterialTranslatorType + "\\Generator\\Vertex.shader");
            return true;
        }
        protected virtual string GenerateFragment(MaterialNode Out)
        {
            string FragmentCode = "";
            string FragmentHeader = File.ReadAllText(this._MaterialTranslatorType + "\\Generator\\FragmentHeader.shader") + "\n";
            if (FragmentHeader == "") return "";
            FragmentCode += FragmentHeader;
            FragmentCode += "\n";
            List<string> UsedFunctions = new List<string>();
            List<string> FunctionCalls = new List<string>();
            MaterialNodeValue Surface = Out.Inputs[0];
            if (Surface.InputTarget != null)
            {
                FunctionCalls.Add("\t" + GenerateFragmentFinalizer(true, Surface.InputTarget.Parent.ID + "_" + Surface.InputTarget.Name));
                UsedFunctions.Add(Surface.InputTarget.Parent.FunctionID);
                ProcessCurrentNode(Surface.InputTarget.Parent, UsedFunctions, FunctionCalls);
            }
            else
            {
                FunctionCalls.Add(GenerateFragmentFinalizer(false, ""));
            }
            for(int i = 0; i < UsedFunctions.Count; i++)
            {
                bool Found = false;
                for(int j = 0; j < this._Entries.Count; j++)
                {
                    if (this._Entries[j].ID == UsedFunctions[i])
                    {
                        FragmentCode += this._Entries[j].FunctionCode;
                        FragmentCode += "\n";
                        FragmentCode += "\n";
                        Found = true;
                    }
                }
                if (!Found) return "";
            }
            FragmentCode += GenerateMainFunction(FunctionCalls.ToArray());
            File.WriteAllText(this._MaterialTranslatorType + "\\Generator\\Out.shader", FragmentCode);
            return FragmentCode;
        }
        private bool ProcessCurrentNode(MaterialNode CurNode, List<string> UsedFunctions, List<string> FunctionCalls)
        {
            List<string> ArgumentTexts = new List<string>();
            List<string> OutputNames = new List<string>();
            ShaderMaterialTranslatorEntry FunctionEntry = null;
            for(int i = 0; i < this._Entries.Count; i++)
            {
                if (CurNode.FunctionID == this._Entries[i].ID) FunctionEntry = this._Entries[i];
            }
            if (FunctionEntry == null) return false;
            if(!UsedFunctions.Contains(CurNode.FunctionID))UsedFunctions.Insert(0, CurNode.FunctionID);
            for(int i = 0; i < FunctionEntry.EngineInputs.Count; i++)
            {
                ArgumentTexts.Add(GenerateArgumentFromEngineVariable(FunctionEntry.EngineInputs[i]));
            }
            for(int i = 0; i < CurNode.Inputs.Count; i++)
            {
                if (CurNode.Inputs[i].InputTarget != null) ArgumentTexts.Add(CurNode.Inputs[i].InputTarget.Parent.ID + "_" + CurNode.Inputs[i].InputTarget.Name);
                else ArgumentTexts.Add(GenerateArgumentFromValue(CurNode.Inputs[i].Value));
            }
            for (int i = 0; i < CurNode.Outputs.Count; i++)
            {
                OutputNames.Add(CurNode.ID + "_" + CurNode.Outputs[i].Name);
            }
            FunctionCalls.Insert(0,GenerateFunctionCall(CurNode.FunctionID, ArgumentTexts.ToArray(), OutputNames.ToArray()));
            for (int i = 0; i < CurNode.Inputs.Count; i++)
            {
                if (CurNode.Inputs[i].InputTarget != null) ProcessCurrentNode(CurNode.Inputs[i].InputTarget.Parent, UsedFunctions, FunctionCalls);
            }
            return true;
        }
        protected virtual string GenerateMainFunction(string[] Lines)
        {
            return "";
        }
        protected virtual string GenerateFragmentFinalizer(bool Input, string ID)
        {
            return "";
        }
        protected virtual string GenerateFunctionCall(string FunctionName, string[] ArgumentTexts, string[] OutputNames)
        {
            return "";
        }
        protected virtual string GenerateArgumentFromValue(MaterialValueHolder Value)
        {
            return "";
        }
        protected virtual string GenerateArgumentFromEngineVariable(string VariableName)
        {
            return "";
        }
        private void LoadEntries()
        {
            List<string> PossibleEntries = new List<string>();
            string[] Files = Directory.GetFiles(_MaterialTranslatorType);
            for (int i = 0; i < Files.Length; i++)
            {
                if (!PossibleEntries.Contains(Path.GetFileNameWithoutExtension(Files[i]))) PossibleEntries.Add(Path.GetFileNameWithoutExtension(Files[i]));
            }
            for (int i = 0; i < PossibleEntries.Count; i++)
            {
                if (File.Exists(this._MaterialTranslatorType + "\\" + PossibleEntries[i] + ".xml") && File.Exists(this._MaterialTranslatorType + "\\" + PossibleEntries[i] + ".shader"))
                {
                    this._Entries.Add(new ShaderMaterialTranslatorEntry(this._MaterialTranslatorType + "\\" + PossibleEntries[i] + ".xml", this._MaterialTranslatorType));
                }
            }
        }
    }
}
