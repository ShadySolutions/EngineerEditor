﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Mathematics;

namespace Engineer.Engine
{
    public class SceneObject
    {
        private bool _Active;
        private string _Name;
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
        public SceneObject(string Name)
        {
            this._Active = true;
            this._Name = Name;
            this._Translation = new Vertex();
            this._Scale = new Vertex(1, 1, 1);
            this._Rotation = new Vertex();
        }
    }
}
