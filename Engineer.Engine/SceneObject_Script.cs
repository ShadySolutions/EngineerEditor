﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    public enum ScriptObjectType
    {
        CSScript = 0
    }
    public class ScriptSceneObject : SceneObject
    {
        private string _Script;
        private ScriptObjectType _ScriptType;
        public string Script
        {
            get
            {
                return _Script;
            }

            set
            {
                _Script = value;
            }
        }
        public ScriptObjectType ScriptType
        {
            get
            {
                return _ScriptType;
            }

            set
            {
                _ScriptType = value;
            }
        }
        public ScriptSceneObject() : base()
        {
            this.ScriptType = ScriptObjectType.CSScript;
            this.Type = SceneObjectType.ScriptSceneObject;
        }
        public ScriptSceneObject(string Name) : base(Name)
        {
            this.ScriptType = ScriptObjectType.CSScript;
            this.Type = SceneObjectType.ScriptSceneObject;
        }
        public ScriptSceneObject(ScriptSceneObject SSO, Scene ParentScene) : base(SSO, ParentScene)
        {
            this._Script = SSO._Script;
            this._ScriptType = SSO.ScriptType;
        }
        public static void Serialize(ScriptSceneObject CurrentScriptSceneObject, string Path)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(ScriptSceneObject));
            using (TextWriter Writer = new StreamWriter(Path))
            {
                Serializer.Serialize(Writer, CurrentScriptSceneObject);
            }
        }
        public static ScriptSceneObject Deserialize(string Path)
        {
            XmlSerializer Deserializer = new XmlSerializer(typeof(ScriptSceneObject));
            TextReader Reader = new StreamReader(Path);
            ScriptSceneObject CurrentScriptSceneObject = (ScriptSceneObject)Deserializer.Deserialize(Reader);
            Reader.Close();
            return CurrentScriptSceneObject;
        }
    }
}
