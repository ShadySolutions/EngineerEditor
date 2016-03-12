﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Engineer.Draw
{
    public class ShaderTexturePackage
    {
        protected bool _Active;
        protected int _TexturesNumber;
        protected byte[] _Textures;
        public ShaderTexturePackage()
        {
            this._Active = false;
            this._TexturesNumber = 0;
            this._Textures = null;
        }
        public ShaderTexturePackage(ShaderTexturePackage Package)
        {
            this._Active = false;
            this._TexturesNumber = Package._TexturesNumber;
            Array.Copy(Package._Textures, this._Textures, Package._Textures.Length);
        }
        public virtual void SetData(int TexturesNumber, byte[] Textures)
        {
            this._Active = false;
            this._TexturesNumber = TexturesNumber;
            this._Textures = Textures;
        }
        public virtual void ClearData()
        {
            this._TexturesNumber = 0;
            this._Textures = null;
        }
        public virtual bool Activate()
        {
            return false;
        }
    }
}
