using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
