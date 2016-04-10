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
        public Sprite(Sprite S) : base(S)
        {
            this._SpriteSets = new List<SpriteSet>();
            for (int i = 0; i < S._SpriteSets.Count; i++) this._SpriteSets.Add(new SpriteSet(S._SpriteSets[i]));

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
        private int _IO_SpriteCount;
        private string _ID;
        private string _Name;
        private List<Bitmap> _Sprites;
        public int IO_SpriteCount
        {
            get
            {
                if (_Sprites.Count == 0 && _IO_SpriteCount != -1) return _IO_SpriteCount;
                return _Sprites.Count;
            }
            set
            {
                this._IO_SpriteCount = value;
            }
        }
        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
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
        [XmlIgnore]
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
            this._IO_SpriteCount = -1;
            this._ID = Guid.NewGuid().ToString();
            this._Name = this._ID;
            this._Sprites = new List<Bitmap>();
        }
        public SpriteSet(string Name)
        {
            this._IO_SpriteCount = -1;
            this._ID = Guid.NewGuid().ToString();
            this._Name = Name;
            this._Sprites = new List<Bitmap>();
        }
        public SpriteSet(SpriteSet SS)
        {
            this._IO_SpriteCount = SS._IO_SpriteCount;
            this._ID = SS._ID;
            this._Name = SS._Name;
            this._Sprites = new List<Bitmap>(SS._Sprites);
        }
    }
}
