using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public class DrawEngine
    {
        private Renderer _CurrentRenderer;
        public Renderer CurrentRenderer
        {
            get
            {
                return _CurrentRenderer;
            }

            set
            {
                _CurrentRenderer = value;
            }
        }
        public DrawEngine()
        {

        }
    }
}
