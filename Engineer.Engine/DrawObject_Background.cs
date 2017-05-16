using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public enum BackgroundDrawStyle
    {
        Static = 0,
        Movable = 1,
        Parallax = 2
    }
    public class Background : DrawObject
    {
        private BackgroundDrawStyle _Style;
        public BackgroundDrawStyle Style
        { get => _Style; set => _Style = value; }
        public Background() : base()
        {
            this.Style = BackgroundDrawStyle.Static;
            this.Type = DrawObjectType.Background;
        }
        public Background(Background B) : base(B)
        {
            this.Style = B.Style;
            this.Type = B.Type;
        }
    }
}
