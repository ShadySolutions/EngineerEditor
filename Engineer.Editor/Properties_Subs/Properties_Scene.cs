using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engineer.Engine;
using Engineer.Interface;

namespace Engineer.Editor
{
    public partial class Properties_Scene : PropertiesHolder
    {
        private Scene _Scene;
        private Game_Interface _Interface;
        PropertiesInput_String _SceneName;
        PropertiesInput_Button _AddNewEvent;
        public Properties_Scene()
        {
            InitializeComponent();
        }
        public Properties_Scene(Game_Interface Interface, Scene CurrentScene)
        {
            InitializeComponent();
            Init(Interface, CurrentScene);
        }
        public void Init(Game_Interface Interface, Scene CurrentScene)
        {
            this._Scene = CurrentScene;
            this._Interface = Interface;
            _SceneName = new PropertiesInput_String("Name", CurrentScene.Name, new EventHandler(Name_Update));
            this.AddControl(_SceneName);
            for(int i = 0; i < _Scene.Events.EventList.Count; i++)
            {
                for(int j = 0; j < _Scene.Events.EventList[i].Events.Count; j++)
                {
                    Properties_Event NewEvent = new Properties_Event(_Interface, _Scene, i,
                        Scene_Interface.GetPossibleEventNames(_Scene, _Scene.Events.EventList[i].ID).IndexOf(_Scene.Events.EventList[i].Events[j].ID), true);
                    this.AddControl(NewEvent);
                }
            }
            _AddNewEvent = new PropertiesInput_Button("", "Add New Event", new EventHandler(AddNewEvent_Click));
            this.AddControl(_AddNewEvent);
        }
        private void Name_Update(object sender, EventArgs e)
        {
            _Interface.CurrentScene.Name = _SceneName.GetValue().ToString();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneUpdated);
        }
        private void AddNewEvent_Click(object sender, EventArgs e)
        {
            Properties_Event NewEvent = new Properties_Event(_Interface, _Scene);
            this.AddControl(NewEvent);
            _AddNewEvent.BringToFront();
        }
    }
}
