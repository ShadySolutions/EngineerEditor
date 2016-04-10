using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    [XmlInclude(typeof(SpriteSet))]
    public class Sprite : DrawObject
    {
        private bool _Modified;
        private List<SpriteSet> _SpriteSets;
        public bool Modified
        {
            get
            {
                return _Modified;
            }

            set
            {
                _Modified = value;
            }
        }
        public List<SpriteSet> SpriteSets
        {
            get
            {
                return _SpriteSets;
            }

            set
            {
                _SpriteSets = value;
            }
        }
        public Sprite() : base()
        {
            this.Type = DrawObjectType.Sprite;
            this._SpriteSets = new List<SpriteSet>();
            this.Scale = new Mathematics.Vertex(100,100,1);
        }
        public List<Bitmap> CollectiveLists()
        {
            List<Bitmap> Lists = new List<Bitmap>();
            for(int i = 0; i < _SpriteSets.Count; i++)
            {
                Lists.AddRange(_SpriteSets[i].Sprite);
            }
            return Lists;
        }
    }
    public class SpriteSet
    {
        private string _Name;
        private List<Bitmap> _Sprites;
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
        public List<Bitmap> Sprite
        {
            get
            {
                return _Sprites;
            }

            set
            {
                _Sprites = value;
            }
        }
        public SpriteSet()
        {
            this._Name = Guid.NewGuid().ToString();
            this._Sprites = new List<Bitmap>();
        }
        public SpriteSet(string Name)
        {
            this._Name = Name;
            this._Sprites = new List<Bitmap>();
        }
    }
}
