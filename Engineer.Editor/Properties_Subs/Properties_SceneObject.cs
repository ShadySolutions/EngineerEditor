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
    public partial class Properties_SceneObject : PropertiesHolder
    {
        private SceneObject _CurrentSceneObject;
        private Game_Interface _Interface;
        private PropertiesInput_String _Name;
        private PropertiesInput_Button _AddNewEvent;
        public Properties_SceneObject()
        {
            InitializeComponent();
        }
        public Properties_SceneObject(Game_Interface Interface, SceneObject CurrentSceneObject)
        {
            InitializeComponent();
            Init(Interface, CurrentSceneObject);
        }
        public void Init(Game_Interface Interface, SceneObject CurrentSceneObject)
        {
            this._Interface = Interface;
            this._CurrentSceneObject = CurrentSceneObject;
            string SceneObjectTypeString = "";
            if (CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) SceneObjectTypeString = "DrawnSceneObject";
            else if (CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) SceneObjectTypeString = "ScriptSceneObject";
            else SceneObjectTypeString = "Undefined";
            _Name = new PropertiesInput_String("Name", CurrentSceneObject.Name, new EventHandler(NameChanged));
            this.AddControl(_Name);
            PropertiesInput_Label Type = new PropertiesInput_Label("Type", SceneObjectTypeString);
            this.AddControl(Type);
            for (int i = 0; i < CurrentSceneObject.Events.EventList.Count; i++)
            {
                for (int j = 0; j < CurrentSceneObject.Events.EventList[i].Events.Count; j++)
                {
                    Properties_Event NewEvent = new Properties_Event();
                    NewEvent.Init(_Interface, _CurrentSceneObject, Scene_Interface.GetPossibleEventNames(_Interface.CurrentScene, _Interface.CurrentScene.Events.EventList[i].ID).IndexOf(_Interface.CurrentScene.Events.EventList[i].Events[j].ID), i, true);
                    this.AddControl(NewEvent);
                }
            }
            _AddNewEvent = new PropertiesInput_Button("", "Add New Event", new EventHandler(AddNewEvent_Click));
            this.AddControl(_AddNewEvent);
        }
        private void NameChanged(object sender, EventArgs e)
        {
            if (this._CurrentSceneObject == null) return;
            _CurrentSceneObject.Name = (string)_Name.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void AddNewEvent_Click(object sender, EventArgs e)
        {
            Properties_Event NewEvent = new Properties_Event(_Interface, _CurrentSceneObject);
            this.AddControl(NewEvent);
            _AddNewEvent.BringToFront();
        }
    }
}
