using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engineer.Engine
{
    [XmlInclude(typeof(Scene))]
    [XmlInclude(typeof(Scene2D))]
    [XmlInclude(typeof(Scene3D))]
    public class Game
    {
        private string _Name;
        private List<Scene> _Scenes;
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
        public List<Scene> Scenes
        {
            get
            {
                return _Scenes;
            }

            set
            {
                _Scenes = value;
            }
        }
        public Game()
        {
            this._Scenes = new List<Scene>();
        }
        public static void Serialize(Game CurrentGame, string Path)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Game));
            using (TextWriter Writer = new StreamWriter(Path))
            {
                Serializer.Serialize(Writer, CurrentGame);
            }
        }
    }
}
