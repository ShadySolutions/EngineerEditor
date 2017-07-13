using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Engineer.Engine;
using System.Xml;
using System.IO;
using Engineer.Engine.IO;

namespace Engineer.Interface.Categories
{
    public class LibraryData
    {
        private List<LibraryDataGroup> _Groups;
        private Dictionary<string, Scene> _Scenes;
        public List<LibraryDataGroup> Groups { get => _Groups; set => _Groups = value; }
        public Dictionary<string, Scene> Scenes { get => _Scenes; set => _Scenes = value; }
        public LibraryData()
        {
            this._Scenes = new Dictionary<string, Scene>();
            this._Groups = new List<LibraryDataGroup>();
            this.Init();
        }
        private void Init()
        {
            InitMaterials();
            InitScenes();
            InitGroups();
        }
        private void InitMaterials()
        {
            string LibPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Engineer/";
            XmlDocument Document = new XmlDocument();
            Document.Load(LibPath + "Library/Material/Default.mtx");
            XmlNode Main = Document.FirstChild;
            Material Mat = new Material(Main);
            Material.Default = Mat;
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
        private void InitGroups()
        {
            EFXInterface EFX = new EFXInterface();
            string LibPath = "Library/Assets/";
            string [] Dirs = Directory.GetDirectories(LibPath);
            for(int i = 0; i < Dirs.Length; i++)
            {
                LibraryDataGroup NewGroup = new LibraryDataGroup(Path.GetFileNameWithoutExtension(Dirs[i]));
                string[] Files = Directory.GetFiles(Dirs[i]);
                for(int j = 0; j < Files.Length; j++)
                {
                    if(Files[j].EndsWith(".efx"))
                    {
                        try
                        {
                            NewGroup.Objects.Add((SceneObject)EFX.Load(Files[j]));
                        }
                        catch (Exception E)
                        {
                            
                        }
                    }
                }
                this._Groups.Add(NewGroup);
            }
        }
    }
    public class LibraryDataGroup
    {
        private string _Name;
        private List<SceneObject> _Objects;
        public string Name { get => _Name; set => _Name = value; }
        public List<SceneObject> Objects { get => _Objects; set => _Objects = value; }
        public LibraryDataGroup(string Name)
        {
            this._Name = Name;
            this._Objects = new List<SceneObject>();
        }
    }
}
