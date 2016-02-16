using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
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
    }
}
