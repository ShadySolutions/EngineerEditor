using Engineer.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class Light : SceneObject
    {
        private float _Intensity;
        private Color _Color;
        private Vertex _Attenuation;
        public float Intensity
        {
            get
            {
                return _Intensity;
            }

            set
            {
                _Intensity = value;
            }
        }
        public Color Color
        {
            get
            {
                return _Color;
            }

            set
            {
                _Color = value;
            }
        }
        public Vertex Attenuation
        {
            get
            {
                return _Attenuation;
            }

            set
            {
                _Attenuation = value;
            }
        }
        public Light(string Name) : base(Name)
        {
            this._Intensity = 1f;
            this._Color = Color.White;
            this._Attenuation = new Vertex(1, 0, 0);
        }
    }
}
