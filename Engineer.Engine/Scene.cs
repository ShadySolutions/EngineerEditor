using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Engineer.Engine
{
    public class Scene
    {
        private int _ActiveCamera;
        private string _Name;
        private Color _BackColor;
        private List<SceneObject> _Objects;
        private List<Actor> _Actors;
        private List<Light> _Lights;
        private List<Camera> _Cameras;
        public int ActiveCamera
        {
            get
            {
                return _ActiveCamera;
            }

            set
            {
                _ActiveCamera = value;
            }
        }
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
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }

            set
            {
                _BackColor = value;
            }
        }
        public List<SceneObject> Objects
        {
            get
            {
                UpdateObjects();
                return _Objects;
            }
        }
        public List<Actor> Actors
        {
            get
            {
                return _Actors;
            }

            set
            {
                _Actors = value;
            }
        }
        public List<Light> Lights
        {
            get
            {
                return _Lights;
            }

            set
            {
                _Lights = value;
            }
        }
        public List<Camera> Cameras
        {
            get
            {
                return _Cameras;
            }

            set
            {
                _Cameras = value;
            }
        }
        public Scene(string Name)
        {
            this._ActiveCamera = -1;
            this._Name = Name;
            this._BackColor = Color.FromArgb(40, 40, 40);
            this._Objects = new List<SceneObject>();
            this._Actors = new List<Actor>();
            this._Lights = new List<Light>();
            this._Cameras = new List<Camera>();
        }
        private void UpdateObjects()
        {
            this._Objects = new List<SceneObject>();
            for (int i = 0; i < this._Actors.Count; i++) this._Objects.Add(this._Actors[i] as SceneObject);
            for (int i = 0; i < this._Lights.Count; i++) this._Objects.Add(this._Lights[i] as SceneObject);
            for (int i = 0; i < this._Cameras.Count; i++) this._Objects.Add(this._Cameras[i] as SceneObject);
        }
    }
}
