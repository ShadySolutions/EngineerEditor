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
    public partial class Properties_Scene : UserControl
    {
        private Scene _Scene;
        private List<ScriptSceneObject> _EventScripts_Load;
        private List<ScriptSceneObject> _EventScripts_MousePress;
        private List<ScriptSceneObject> _EventScripts_KeyPress;
        public Properties_Scene()
        {
            InitializeComponent();
            this._EventScripts_Load = new List<ScriptSceneObject>(); ;
            this._EventScripts_MousePress = new List<ScriptSceneObject>();
            this._EventScripts_KeyPress = new List<ScriptSceneObject>();
        }
        public void SetScene(Scene CurrentScene)
        {
            this._Scene = CurrentScene;
            for(int i = 0; i < this._Scene.Objects.Count; i++)
            {
                if(this._Scene.Objects[i].Type == SceneObjectType.ScriptSceneObject)
                {
                    ScriptSceneObject Current = (ScriptSceneObject)this._Scene.Objects[i];
                    if (Current.Script.Contains("public void Load"))
                    {
                        PossibleEvents_Load.Items.Add(Current.Name);
                        this._EventScripts_Load.Add(Current);
                    }
                    if (Current.Script.Contains("public void MousePress"))
                    {
                        PossibleEvents_MousePress.Items.Add(Current.Name);
                        this._EventScripts_MousePress.Add(Current);
                    }
                    if (Current.Script.Contains("public void KeyPress"))
                    {
                        PossibleEvents_KeyPress.Items.Add(Current.Name);
                        this._EventScripts_KeyPress.Add(Current);
                    }
                }
            }
            PossibleEvents_Load.Enabled = PossibleEvents_Load.Items.Count != 0;
            PossibleEvents_MousePress.Enabled = PossibleEvents_MousePress.Items.Count != 0;
            PossibleEvents_KeyPress.Enabled = PossibleEvents_KeyPress.Items.Count != 0;
            if (PossibleEvents_Load.Items.Count > 0) PossibleEvents_Load.SelectedIndex = 0;
            if (PossibleEvents_MousePress.Items.Count > 0) PossibleEvents_MousePress.SelectedIndex = 0;
            if (PossibleEvents_KeyPress.Items.Count > 0) PossibleEvents_KeyPress.SelectedIndex = 0;
        }

        private void PossibleEvents_Load_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.Load.Clear();
            this._Scene.Events.Load.Add(this._EventScripts_Load[PossibleEvents_Load.SelectedIndex]);
        }

        private void PossibleEvents_MousePress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.MousePress.Clear();
            this._Scene.Events.MousePress.Add(this._EventScripts_MousePress[PossibleEvents_MousePress.SelectedIndex]);
        }

        private void PossibleEvents_KeyPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.KeyPress.Clear();
            this._Scene.Events.KeyPress.Add(this._EventScripts_KeyPress[PossibleEvents_KeyPress.SelectedIndex]);
        }
    }
}
