using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Engineer.Engine;

namespace Engineer.Interface
{
    public class LibraryData
    {
        private Dictionary<string, Scene> _Scenes;
        public Dictionary<string, Scene> Scenes { get => _Scenes; set => _Scenes = value; }
        public LibraryData()
        {
            this._Scenes = new Dictionary<string, Scene>();
            this.Init();
        }
        private void Init()
        {
            InitScenes();
        }
        private void InitScenes()
        {
            Scene2D NewScene = new Scene2D("EmptyScene2D");
            NewScene.BackColor = Color.FromArgb(40, 40, 40);
            NewScene.Type = SceneType.Scene2D;
            this._Scenes.Add("EmptyScene2D", NewScene);

            NewScene = new Scene2D("Platformer2D");
            NewScene.BackColor = Color.SkyBlue;
            NewScene.Type = SceneType.Scene2D;
            this._Scenes.Add("Platformer2D", NewScene);
        }
    }
}
