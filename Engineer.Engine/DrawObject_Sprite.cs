using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class Sprite : DrawObject
    {
        public Sprite() : base()
        {
            this.Type = DrawObjectType.Sprite;
        }
    }
}
