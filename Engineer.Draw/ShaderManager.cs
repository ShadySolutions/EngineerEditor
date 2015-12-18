using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public enum GraphicDrawMode
    {
        Points = 0,
        Lines = 1,
        LineLoop = 2,
        LineStrip = 3,
        Triangles = 4,
        TriangleStrip = 5,
        TriangleFan = 6,
        Quads = 7,
        QuadsExt = 7,
        LinesAdjacency = 10,
        LinesAdjacencyArb = 10,
        LinesAdjacencyExt = 10,
        LineStripAdjacency = 11,
        LineStripAdjacencyArb = 11,
        LineStripAdjacencyExt = 11,
        TrianglesAdjacency = 12,
        TrianglesAdjacencyArb = 12,
        TrianglesAdjacencyExt = 12,
        TriangleStripAdjacency = 13,
        TriangleStripAdjacencyArb = 13,
        TriangleStripAdjacencyExt = 13,
        Patches = 14,
        PatchesExt = 14
    }
    public abstract class ShaderManager
    {
        protected int _ActiveShaderIndex;
        protected int _DrawLineOffset;
        protected GraphicDrawMode _DrawMode;
        protected List<ShaderProgram> _Shader;
        protected int FindShader(string ID)
        {
            for (int i = 0; i < _Shader.Count; i++) if (_Shader[i].ShaderID == ID) return i;
            return -1;
        }
        public ShaderProgram Active
        {
            get
            {
                if (_ActiveShaderIndex < 0) return null;
                return _Shader[_ActiveShaderIndex];
            }
        }
        public ShaderManager()
        {

        }
        public abstract bool AddShader(string ID);
        public virtual bool CompileShader(string ID, string VertexShaderString, string FragmentShaderString)
        {
            int ShaderIndex = FindShader(ID);
            if (ShaderIndex == -1) return false;
            return _Shader[ShaderIndex].Compile(VertexShaderString, FragmentShaderString);
        }
        public virtual bool CompileShader(string ID, string VertexShaderString, string FragmentShaderString, string GeometryShaderString, string TessellationControlString, string TessellationEvaluationString)
        {
            int ShaderIndex = FindShader(ID);
            if (ShaderIndex == -1) return false;
            return _Shader[ShaderIndex].Compile(VertexShaderString, FragmentShaderString, GeometryShaderString, TessellationControlString, TessellationEvaluationString);
        }
        virtual public bool DeleteShader(string ID)
        {
            int ShaderIndex = FindShader(ID);
            if (ShaderIndex == -1) return false;
            _Shader.RemoveAt(ShaderIndex);
            return true;
        }
        virtual public bool ActivateShader(string ID)
        {
            int ShaderIndex = FindShader(ID);
            if (ShaderIndex == -1) return false;
            _ActiveShaderIndex = ShaderIndex;
            return true;
        }
        virtual public void SetDrawMode(GraphicDrawMode DrawMode)
        {
            this._DrawMode = DrawMode;
        }
        virtual public void Draw()
        {
            if (_ActiveShaderIndex != -1) _Shader[_ActiveShaderIndex].Draw(_DrawMode, _DrawLineOffset);
        }
    }
}
