using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public class Renderer
    {
        private object _RenderDestination;
        protected object RenderDestination
        {
            get
            {
                return _RenderDestination;
            }

            set
            {
                _RenderDestination = value;
            }
        }
        public Renderer()
        {

        }
    }
}
