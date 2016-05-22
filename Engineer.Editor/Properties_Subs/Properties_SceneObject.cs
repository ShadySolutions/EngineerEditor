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
    public partial class Properties_SceneObject : UserControl
    {
        private SceneObject _CurrentSceneObject;
        private Game_Interface _Interface;
        private PropertiesInput_String _Name;
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
            HolderSceneObject.AddControl(_Name);
            PropertiesInput_Label Type = new PropertiesInput_Label("Type", SceneObjectTypeString);
            HolderSceneObject.AddControl(Type);
        }
        private void NameChanged(object sender, EventArgs e)
        {
            if (this._CurrentSceneObject == null) return;
            _CurrentSceneObject.Name = (string)_Name.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void HolderSceneObject_Resize(object sender, EventArgs e)
        {
            this.Height = HolderSceneObject.Height;
        }
    }
}
