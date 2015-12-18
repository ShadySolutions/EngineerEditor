using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public class ShaderRenderer : Renderer
    {
        protected ShaderManager _Manager;
        protected ShaderManager Manager
        {
            get
            {
                return _Manager;
            }

            set
            {
                _Manager = value;
            }
        }
        public ShaderRenderer() : base()
        {
            
        }
    }
}
