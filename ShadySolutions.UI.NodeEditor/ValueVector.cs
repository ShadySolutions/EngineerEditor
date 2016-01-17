using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ShadySolutions.UI.NodeEditor
{
    public class ValueVector
    {
        private double _X;
        private double _Y;
        private double _Z;
        private double _W;
        private string _Value;
        public double X
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
            }
        }
        public double Y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
            }
        }
        public double Z
        {
            get
            {
                return _Z;
            }

            set
            {
                _Z = value;
            }
        }
        public double W
        {
            get
            {
                return _W;
            }

            set
            {
                _W = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }
        public ValueVector()
        {
            _X = 0;
            _Y = 0;
            _Z = 0;
            _W = 1;
        }
        public ValueVector(double X, double Y, double Z)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
            _W = 1;
        }
        public ValueVector(double X, double Y, double Z, double W)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
            _W = W;
        }
        public ValueVector(Color NewColor)
        {
            this._X = (NewColor.R * 1.0 + 1) / 256;
            this._Y = (NewColor.G * 1.0 + 1) / 256;
            this._Z = (NewColor.B * 1.0 + 1) / 256;
            this._W = (NewColor.A * 1.0 + 1) / 256;
        }
    }
}
