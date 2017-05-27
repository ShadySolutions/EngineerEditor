using Engineer.Data;
using Engineer.Engine;
using Engineer.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Engineer.Interface.Categories;

namespace Engineer.Interface
{
    public enum InterfaceUpdateMessage
    {
        GameUpdated,
        SceneUpdated,
        SceneObjectsUpdated,
        SelectionUpdated,
        AssetsUpdated,
        LibraryUpdated
    }
    public delegate void InterfaceUpdate(InterfaceUpdateMessage Message);
    public class Game_Interface
    {
        private object _CurrentSelection;
        private SceneObject _CurrentSceneObject;
        private Scene _CurrentScene;
        private Game _CurrentGame;
        private LibraryData _Library;
        public event InterfaceUpdate Update;
        public object CurrentSelection
        {
            get
            {
                return _CurrentSelection;
            }

            set
            {
                _CurrentSelection = value;
                Update.Invoke(InterfaceUpdateMessage.SelectionUpdated);
            }
        }
        public SceneObject CurrentSceneObject
        {
            get
            {
                return _CurrentSceneObject;
            }

            set
            {
                _CurrentSceneObject = value;
                Update.Invoke(InterfaceUpdateMessage.SceneObjectsUpdated);
            }
        }
        public Scene CurrentScene
        {
            get
            {
                return _CurrentScene;
            }

            set
            {
                _CurrentScene = value;
                Update.Invoke(InterfaceUpdateMessage.SceneUpdated);
            }
        }
        public Game CurrentGame
        {
            get
            {
                return _CurrentGame;
            }

            set
            {
                _CurrentGame = value;
                Update.Invoke(InterfaceUpdateMessage.GameUpdated);
            }
        }
        public LibraryData Library
        { get => _Library; set => _Library = value; }
        public Game_Interface(Game CurrentGame)
        {
            this.Library = new LibraryData();
            Update = new Interface.InterfaceUpdate(OnInterfaceUpdate);
            if (CurrentGame != null) this.CurrentGame = CurrentGame;
            else
            {
                this.CurrentGame = new Game();
                this.CurrentGame.Name = "New Game";
            }
            AcquireData();
        }
        public void ForceUpdate(InterfaceUpdateMessage Message)
        {
            Update.Invoke(Message);
        }
        public void SetGameName(string NewName)
        {
            _CurrentGame.Name = NewName;
            Update.Invoke(InterfaceUpdateMessage.GameUpdated);
        }
        public void NewGame()
        {
            _CurrentSelection = null;
            _CurrentScene = null;
            _CurrentSceneObject = null;
            _CurrentGame = new Game();
            _CurrentGame.Name = "New Game";
            ForceUpdate(InterfaceUpdateMessage.GameUpdated);
        }
        public void SceneItem(string ItemCode, ref string ErrorString)
        {
            
        }
        public bool AddEmptyScene(string SceneCode, ref string ErrorString)
        {
            if(this._Library.Scenes[SceneCode].Type == SceneType.Scene2D) this.CurrentScene = new Scene2D((Scene2D)this._Library.Scenes[SceneCode]);
            else if (this._Library.Scenes[SceneCode].Type == SceneType.Scene3D) this.CurrentScene = new Scene3D((Scene3D)this._Library.Scenes[SceneCode]);
            this.CurrentScene.Name = "Scene_" + (CurrentGame.Scenes.Count + 1).ToString("000");
            this.CurrentGame.Scenes.Add(this.CurrentScene);
            return true;
        }
        public bool AddAsset(SceneObject NewAsset)
        {
            if (NewAsset == null) return false;
            _CurrentGame.Assets.Add(NewAsset);
            Update.Invoke(InterfaceUpdateMessage.AssetsUpdated);
            return true;
        }
        public bool SetCurrentScene(int Index, ref string ErrorString)
        {
            bool Value;
            if (Index == -1)
            {
                AddEmptyScene("EmptyScene2D", ref ErrorString);
                Value = true;
            }
            else if (Index == -2)
            {
                AddEmptyScene("EmptyScene3D", ref ErrorString);
                Value = true;
            }
            else
            {
                if (this.CurrentGame.Scenes.Count > Index)
                {
                    this.CurrentScene = this.CurrentGame.Scenes[Index];
                    Value = true;
                }
                else
                {
                    ErrorString = "No Scene at requested index";
                    Value = false;
                }
                if(Value) Update.Invoke(InterfaceUpdateMessage.SceneUpdated);
            }
            return Value;
        }       
        private void OnInterfaceUpdate(InterfaceUpdateMessage Message)
        {

        }
        private void AcquireData()
        {
            String LibPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Engineer/";
            XmlDocument Document = new XmlDocument();
            Document.Load(LibPath + "Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            Material.Default = Mat;
        }
        public static bool LoadGame(string FilePath, ref Game CurrentGame, ref string ErrorString)
        {
            try
            {
                string DirPath = FilePath.Replace(Path.GetFileName(FilePath), Path.GetFileNameWithoutExtension(FilePath)) + "\\";
                ZipFile.ExtractToDirectory(FilePath, DirPath);
                CurrentGame = Game.Deserialize(DirPath + Path.GetFileNameWithoutExtension(FilePath) + ".xml");
                List<string> Files = new List<string>(Directory.GetFiles(DirPath));
                for (int i = 0; i < CurrentGame.Scenes.Count; i++)
                {
                    for (int j = 0; j < CurrentGame.Scenes[i].Objects.Count; j++)
                    {
                        SceneObject_Interface.PostLoad(CurrentGame.Scenes[i].Objects[i], DirPath, Files);
                        CurrentGame.Scenes[i].Objects[j].ParentScene = CurrentGame.Scenes[i];
                    }
                }
                for (int i = 0; i < Files.Count; i++) File.Delete(Files[i]);
                Directory.Delete(DirPath);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    ErrorString = ex.InnerException.ToString();
                }
                else ErrorString = ex.Message;
                return false;
            }
        }
        public static bool SaveGame(string FilePath, ref Game CurrentGame, ref string ErrorString)
        {
            try
            {
                if (File.Exists(FilePath)) File.Delete(FilePath);
                string DirPath = FilePath.Replace(Path.GetFileName(FilePath), Path.GetFileNameWithoutExtension(FilePath)) + "\\";
                Directory.CreateDirectory(DirPath);
                List<string> Files = new List<string>();
                for (int i = 0; i < CurrentGame.Scenes.Count; i++)
                {
                    for (int j = 0; j < CurrentGame.Scenes[i].Objects.Count; j++)
                    {
                        SceneObject_Interface.PostSave(CurrentGame.Scenes[i].Objects[j], DirPath, Files);
                    }
                }
                Files.Add(DirPath + Path.GetFileNameWithoutExtension(FilePath) + ".xml");
                Game.Serialize(CurrentGame, DirPath + Path.GetFileNameWithoutExtension(FilePath) + ".xml");
                ZipFile.CreateFromDirectory(DirPath, FilePath);
                for (int i = 0; i < Files.Count; i++) File.Delete(Files[i]);
                Directory.Delete(DirPath);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    ErrorString = ex.InnerException.ToString();
                }
                else ErrorString = ex.Message;
                return false;
            }
        }
    }
}
