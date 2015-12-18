using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public abstract class ShaderProgram
    {
        protected bool _Compiled;
        protected int _Program_Indexer;
        protected int _VertexShader_Indexer;
        protected int _FragmentShader_Indexer;
        protected int _GeometryShader_Indexer;
        protected int _TessellationControl_Indexer;
        protected int _TessellationEvaluation_Indexer;
        protected string _ShaderID;
        protected ShaderUniformPackage _Uniforms;
        protected ShaderAttributePackage _Attributes;
        public bool Compiled
        {
            get
            {
                return _Compiled;
            }

            set
            {
                _Compiled = value;
            }
        }
        public string ShaderID
        {
            get
            {
                return _ShaderID;
            }

            set
            {
                _ShaderID = value;
            }
        }
        public ShaderUniformPackage Uniforms
        {
            get
            {
                return _Uniforms;
            }

            set
            {
                _Uniforms = value;
            }
        }
        public ShaderAttributePackage Attributes
        {
            get
            {
                return _Attributes;
            }

            set
            {
                _Attributes = value;
            }
        }
        public ShaderProgram()
        {
            this._Compiled = false;
            this._Program_Indexer = -1;
            this._VertexShader_Indexer = -1;
            this._FragmentShader_Indexer = -1;
            this._GeometryShader_Indexer = -1;
            this._TessellationControl_Indexer = -1;
            this._TessellationEvaluation_Indexer = -1;
            this._ShaderID = "";
        }
        public ShaderProgram(string ShaderID)
        {
            this._Compiled = false;
            this._Program_Indexer = -1;
            this._VertexShader_Indexer = -1;
            this._FragmentShader_Indexer = -1;
            this._GeometryShader_Indexer = -1;
            this._TessellationControl_Indexer = -1;
            this._TessellationEvaluation_Indexer = -1;
            this._ShaderID = ShaderID;
        }
        public ShaderProgram(ShaderProgram ShaderProgram)
        {
            this._Compiled = ShaderProgram._Compiled;
            this._Program_Indexer = ShaderProgram._Program_Indexer;
            this._VertexShader_Indexer = ShaderProgram._VertexShader_Indexer;
            this._FragmentShader_Indexer = ShaderProgram._FragmentShader_Indexer;
            this._GeometryShader_Indexer = ShaderProgram._GeometryShader_Indexer;
            this._TessellationControl_Indexer = ShaderProgram._TessellationControl_Indexer;
            this._TessellationEvaluation_Indexer = ShaderProgram._TessellationEvaluation_Indexer;
            this._ShaderID = ShaderProgram._ShaderID;
        }
        public virtual bool Compile(string VertexShaderString, string FragmentShaderString)
        {
            return Compile(VertexShaderString, FragmentShaderString, null, null, null);
        }
        public abstract bool Compile(string VertexShaderString, string FragmentShaderString, string GeometryShaderString, string TessellationControlString, string TessellationEvaluationString);
        public abstract void Draw(GraphicDrawMode DrawMode, int Offset);
        public abstract void Activate();
    }
}
