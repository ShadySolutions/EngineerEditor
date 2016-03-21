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

namespace Engineer.Editor
{
    public partial class Properties_SceneObject : UserControl
    {
        private bool _Toggled;
        private SceneObject _CurrentSceneObject;
        public Properties_SceneObject()
        {
            InitializeComponent();
            this._Toggled = true;
        }
        public void Init(SceneObject CurrentSceneObject)
        {
            this._CurrentSceneObject = CurrentSceneObject;
            this.Value_Name.Text = CurrentSceneObject.Name;
            this.Value_ID.Text = CurrentSceneObject.ID;
            if (CurrentSceneObject.Type == SceneObjectType.DrawnSceneObject) this.Value_SceneObjectType.Text = "DrawnSceneObject";
            else if (CurrentSceneObject.Type == SceneObjectType.ScriptSceneObject) this.Value_SceneObjectType.Text = "ScriptSceneObject";
            else this.Value_SceneObjectType.Text = "Undefined";
        }
        private void Value_Name_TextChanged(object sender, EventArgs e)
        {
            if (this._CurrentSceneObject == null) return;
            this._CurrentSceneObject.Name = Value_Name.Text;
        }
        private void ToggleHeader_Click(object sender, EventArgs e)
        {
            if(_Toggled)
            {
                _Toggled = false;
                this.Height = 24;
            }
            else
            {
                _Toggled = true;
                this.Height = 126;
            }
        }
    }
}
