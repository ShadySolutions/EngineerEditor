﻿using Engineer.Data;
using Engineer.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    public enum SceneObjectType
    {
        Undefined = 0,
        DrawnSceneObject = 1,
        ScriptSceneObject = 2,
        SoundSceneObject = 3
    }
    public class SceneObject
    {
        private string _Name;
        private string _ID;
        private SceneObjectType _Type;
        private Scene _ParentScene;
        private Dictionary<string, object> _Data;
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
        public SceneObjectType Type
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
        [XmlIgnore]
        public Scene ParentScene
        {
            get
            {
                return _ParentScene;
            }

            set
            {
                _ParentScene = value;
            }
        }
        [XmlIgnore]
        public Dictionary<string, object> Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }
        public List<KeyValuePair<string, object>> IO_DataList
        {
            get
            {
                if (_Data == null) return null;
                List<KeyValuePair<string, object>> NewList = _Data.ToList();
                return NewList;
            }
            set
            {
                foreach (KeyValuePair<string, object> Pair in value)
                {
                    if (!_Data.ContainsKey(Pair.Key))
                    {
                        _Data.Add(Pair.Key, Pair.Value);
                    }
                }
            }
        }
        public SceneObject()
        {
            this._ID = Guid.NewGuid().ToString();
            this._Name = this._ID;
            this._Type = SceneObjectType.Undefined;
            this._Data = new Dictionary<string, object>();
        }
        public SceneObject(string Name)
        {
            this._Name = Name;
            this._ID = Guid.NewGuid().ToString();
            this._Type = SceneObjectType.Undefined;
            this._Data = new Dictionary<string, object>();
        }
        public SceneObject(SceneObject SO, Scene ParentScene)
        {
            this._Name = SO._Name;
            this._ID = Guid.NewGuid().ToString();
            this._Type = SO._Type;
            this._ParentScene = ParentScene;
            this._Data = new Dictionary<string, object>(SO._Data);
        }
        public static SceneObject FromFile(string FilePath, Scene CurrentScene)
        {
            if (!File.Exists(FilePath)) return null;
            SceneObject New = null;
            if(FilePath.ToUpper().EndsWith(".OBJ") && CurrentScene.Type == SceneType.Scene3D)
            {
                OBJContainer OBJ = new OBJContainer();
                OBJ.Load(FilePath, null);
                if (OBJ.Geometries[0].Normals.Count == 0) OBJ.RecalculateNormals();
                OBJ.Repack();
                Actor NewActor = new Actor(OBJ, Path.GetFileNameWithoutExtension(FilePath));
                NewActor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
                New = new DrawnSceneObject(NewActor.Name, NewActor);
                New.ParentScene = CurrentScene;
            }
            return New;
        }
    }
}
