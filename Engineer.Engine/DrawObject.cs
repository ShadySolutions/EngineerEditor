﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;

namespace Engineer.Engine
{
    public enum DrawObjectType
    {
        Undefined = -1,
        Actor = 0,
        Camera = 1,
        Light = 2,
        Background = 3,
        Sprite = 4
    }
    public class DrawObject
    {
        private bool _Active;
        private string _Name;
        private string _ID;
        private DrawObjectType _Type;
        private Vertex _Translation;
        private Vertex _Scale;
        private Vertex _Rotation;
        public bool Active
        {
            get
            {
                return _Active;
            }

            set
            {
                _Active = value;
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
        public DrawObjectType Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        public Vertex Translation
        {
            get
            {
                return _Translation;
            }

            set
            {
                _Translation = value;
            }
        }
        public Vertex Scale
        {
            get
            {
                return _Scale;
            }

            set
            {
                _Scale = value;
            }
        }
        public Vertex Rotation
        {
            get
            {
                return _Rotation;
            }

            set
            {
                _Rotation = value;
            }
        }
        public DrawObject()
        {
            this._Active = true;
            this._Name = this._ID = Guid.NewGuid().ToString();
            this._Type = DrawObjectType.Undefined;
            this._Translation = new Vertex();
            this._Scale = new Vertex(1, 1, 1);
            this._Rotation = new Vertex();
        }
        public DrawObject(DrawObject Object)
        {
            this._Active = Object.Active;
            this._Name = Object.Name;
            this._ID = Guid.NewGuid().ToString();
            this._Type = Object.Type;
            this._Translation = new Vertex(Object.Translation.X, Object.Translation.Y, Object.Translation.Z);
            this._Rotation = new Vertex(Object.Rotation.X, Object.Rotation.Y, Object.Rotation.Z);
            this._Scale = new Vertex(Object.Scale.X, Object.Scale.Y, Object.Scale.Z);
        }
    }
}
