﻿using System;
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
        private List<SceneObject> _Assets;
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
        public List<SceneObject> Assets
        {
            get
            {
                return _Assets;
            }

            set
            {
                _Assets = value;
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
            this._Assets = new List<SceneObject>();
            this._Scenes = new List<Scene>();
        }
        public Game(Game G)
        {
            this._Name = G._Name;
            this._Assets = new List<SceneObject>();
            for (int i = 0; i < G._Assets.Count; i++)
            {
                if (G._Assets[i].Type == SceneObjectType.DrawnSceneObject) this._Assets.Add(new DrawnSceneObject((DrawnSceneObject)G._Assets[i], null));
                else if (G._Assets[i].Type == SceneObjectType.ScriptSceneObject) this._Assets.Add(new ScriptSceneObject((ScriptSceneObject)G._Assets[i], null));
            }
            this._Scenes = new List<Scene>();
            for(int i = 0; i < G._Scenes.Count; i++)
            {
                if (G._Scenes[i].Type == SceneType.Scene2D) this._Scenes.Add(new Scene2D((Scene2D)G._Scenes[i]));
                else if (G._Scenes[i].Type == SceneType.Scene3D) this._Scenes.Add(new Scene3D((Scene3D)G._Scenes[i]));
            }
        }
        public static void Serialize(Game CurrentGame, string Path)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Game));
            using (TextWriter Writer = new StreamWriter(Path))
            {
                Serializer.Serialize(Writer, CurrentGame);
            }
        }
        public static Game Deserialize(string Path)
        {
            XmlSerializer Deserializer = new XmlSerializer(typeof(Game));
            TextReader Reader = new StreamReader(Path);
            Game CurrentGame = (Game)Deserializer.Deserialize(Reader);
            Reader.Close();
            return CurrentGame;
        }
    }
}
