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
        private List<OBJContainer> _Scene3DContainers;
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
            }
        }
        public Game_Interface(Game CurrentGame)
        {
            if (CurrentGame != null) this.CurrentGame = CurrentGame;
            else
            {
                this.CurrentGame = new Game();
                this.CurrentGame.Name = "New Game";
            }
            AcquireData();
        }
        public void SetGameName(string NewName)
        {
            _CurrentGame.Name = NewName;
        }
        public bool AddSceneItem(GenericSceneObjectType Type, ref string ErrorString)
        {
            bool ReturnValue = false;
            try
            {
                if (this.CurrentScene.Type == SceneType.Scene2D)
                {
                    if (Type == GenericSceneObjectType.Sprite)
                    {
                        Sprite NewSprite = new Sprite();
                        DrawnSceneObject New_Object = new DrawnSceneObject("New Sprite", NewSprite);
                        this.CurrentScene.AddSceneObject(New_Object);
                    }
                    ReturnValue = true;
                }
                else if (this.CurrentScene.Type == SceneType.Scene3D)
                {
                    if (Type == GenericSceneObjectType.Floor || Type == GenericSceneObjectType.Cube || Type == GenericSceneObjectType.Soldier)
                    {
                        Actor New_Actor = new Actor(_Scene3DContainers[(int)Type], _Scene3DContainers[(int)Type].Geometries[0].Name);
                        New_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
                        DrawnSceneObject New_Object = new DrawnSceneObject(_Scene3DContainers[(int)Type].Geometries[0].Name, New_Actor);
                        this.CurrentScene.AddSceneObject(New_Object);
                    }
                    ReturnValue = true;
                }
                if (Type == GenericSceneObjectType.Event)
                {
                    ScriptSceneObject New_Object = new ScriptSceneObject("New Event");
                    this.CurrentScene.AddSceneObject(New_Object);
                    ReturnValue = true;
                }
                ReturnValue = false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    ErrorString = ex.InnerException.ToString();
                }
                else ErrorString = ex.Message;
                ReturnValue = false;
            }
            return ReturnValue;
        }
        public bool AddEmptyScene(SceneType Type, ref string ErrorString)
        {
            try
            {
                if (Type == SceneType.Scene2D)
                {
                    Actor Floor_Actor = new Actor(_Scene3DContainers[0], "Floor");
                    Floor_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
                    Camera MainCamera_Camera = new Camera();
                    MainCamera_Camera.Translation = new Vertex(0, 0.6f, 0.8f);
                    MainCamera_Camera.Rotation = new Vertex(30, 0, 0);
                    Light Light1_Light = new Light();
                    Light1_Light.Translation = new Vertex(4, -4, -4);
                    Light1_Light.Color = Color.White;
                    Light1_Light.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
                    Light1_Light.Intensity = 0.3f;
                    Scene2D NewScene = new Scene2D("Scene_" + (CurrentGame.Scenes.Count + 1).ToString("000"));
                    NewScene.BackColor = Color.FromArgb(40, 40, 40);
                    NewScene.Type = SceneType.Scene2D;
                    this.CurrentScene = NewScene;
                    this.CurrentGame.Scenes.Add(NewScene);
                    return true;
                }
                else if (Type == SceneType.Scene3D)
                {
                    Actor Floor_Actor = new Actor(_Scene3DContainers[0], "Floor");
                    Floor_Actor.Scale = new Vertex(0.001f, 0.001f, 0.001f);
                    Camera MainCamera_Camera = new Camera();
                    MainCamera_Camera.Translation = new Vertex(0, 0.6f, 0.8f);
                    MainCamera_Camera.Rotation = new Vertex(30, 0, 0);
                    Light Light1_Light = new Light();
                    Light1_Light.Translation = new Vertex(4, -4, -4);
                    Light1_Light.Color = Color.White;
                    Light1_Light.Attenuation = new Vertex(0.6f, 0.2f, 0.2f);
                    Light1_Light.Intensity = 0.3f;
                    Scene3D NewScene = new Scene3D("Scene_" + (CurrentGame.Scenes.Count + 1).ToString("000"));
                    NewScene.BackColor = Color.FromArgb(40, 40, 40);
                    NewScene.Type = SceneType.Scene3D;
                    DrawnSceneObject Floor_Object = new DrawnSceneObject("Floor", Floor_Actor);
                    NewScene.AddSceneObject(Floor_Object);
                    DrawnSceneObject Camera_Object = new DrawnSceneObject("Camera", MainCamera_Camera);
                    NewScene.AddSceneObject(Camera_Object);
                    DrawnSceneObject Light_Object = new DrawnSceneObject("Light", Light1_Light);
                    NewScene.AddSceneObject(Light_Object);
                    NewScene.ActiveCamera = new Camera(MainCamera_Camera);
                    NewScene.EditorCamera = new Camera(MainCamera_Camera);
                    this.CurrentScene = NewScene;
                    this.CurrentGame.Scenes.Add(NewScene);
                    return true;
                }
                else return false;
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
        public bool SelectScene(int Index, ref string ErrorString)
        {
            bool Value;
            if (Index == -1)
            {
                Value = AddEmptyScene(SceneType.Scene2D, ref ErrorString);
            }
            else if (Index == -2)
            {
                Value = AddEmptyScene(SceneType.Scene3D, ref ErrorString);
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
            }
            return Value;
        }
        private void AcquireData()
        {
            this._Scene3DContainers = new List<OBJContainer>();

            OBJContainer Floor_OBJ = new OBJContainer();
            Floor_OBJ.Load("Library/Mesh/Floor.obj", null);
            if (Floor_OBJ.Geometries[0].Normals.Count == 0) Floor_OBJ.RecalculateNormals();
            Floor_OBJ.Repack();
            _Scene3DContainers.Add(Floor_OBJ);

            OBJContainer Cube_OBJ = new OBJContainer();
            Cube_OBJ.Load("Library/Mesh/Cube.obj", null);
            if (Cube_OBJ.Geometries[0].Normals.Count == 0) Cube_OBJ.RecalculateNormals();
            Cube_OBJ.Repack();
            _Scene3DContainers.Add(Cube_OBJ);

            OBJContainer Soldier_OBJ = new OBJContainer();
            Soldier_OBJ.Load("Library/Mesh/Soldier.obj", null);
            if (Soldier_OBJ.Geometries[0].Normals.Count == 0) Soldier_OBJ.RecalculateNormals();
            Soldier_OBJ.Repack();
            _Scene3DContainers.Add(Soldier_OBJ);

            XmlDocument Document = new XmlDocument();
            Document.Load("Library/Material/Default.mtx");
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
