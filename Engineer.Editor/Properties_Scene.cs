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
        private bool _Toggled;
        private Scene _Scene;
        private List<ScriptSceneObject> _EventScripts_Load;
        private List<ScriptSceneObject> _EventScripts_Closing;
        private List<ScriptSceneObject> _EventScripts_MousePress;
        private List<ScriptSceneObject> _EventScripts_MouseDown;
        private List<ScriptSceneObject> _EventScripts_MouseUp;
        private List<ScriptSceneObject> _EventScripts_MouseMove;
        private List<ScriptSceneObject> _EventScripts_MouseWheel;
        private List<ScriptSceneObject> _EventScripts_KeyPress;
        private List<ScriptSceneObject> _EventScripts_KeyDown;
        private List<ScriptSceneObject> _EventScripts_KeyUp;
        private List<ScriptSceneObject> _EventScripts_RenderFrame;
        private List<ScriptSceneObject> _EventScripts_EverySecond;
        public Properties_Scene()
        {
            InitializeComponent();
            this._Toggled = true;
            this._EventScripts_Load = new List<ScriptSceneObject>();
            this._EventScripts_Closing = new List<ScriptSceneObject>();
            this._EventScripts_MousePress = new List<ScriptSceneObject>();
            this._EventScripts_MouseDown = new List<ScriptSceneObject>();
            this._EventScripts_MouseUp = new List<ScriptSceneObject>();
            this._EventScripts_MouseMove = new List<ScriptSceneObject>();
            this._EventScripts_MouseWheel = new List<ScriptSceneObject>();
            this._EventScripts_KeyPress = new List<ScriptSceneObject>();
            this._EventScripts_KeyDown = new List<ScriptSceneObject>();
            this._EventScripts_KeyUp = new List<ScriptSceneObject>();
            this._EventScripts_RenderFrame = new List<ScriptSceneObject>();
            this._EventScripts_EverySecond = new List<ScriptSceneObject>();
        }
        public void Init(Scene CurrentScene)
        {
            this._Scene = CurrentScene;
            this.Value_ID.Text = CurrentScene.ID;
            this.Value_Name.Text = CurrentScene.Name;
            for(int i = 0; i < this._Scene.Objects.Count; i++)
            {
                if(this._Scene.Objects[i].Type == SceneObjectType.ScriptSceneObject)
                {
                    ScriptSceneObject Current = (ScriptSceneObject)this._Scene.Objects[i];
                    if (Current.Script.Contains("public void Load"))
                    {
                        if (this._EventScripts_Load.Count == 0) PossibleEvents_Load.Items.Add("None");
                        PossibleEvents_Load.Items.Add(Current.Name);
                        this._EventScripts_Load.Add(Current);
                    }
                    if (Current.Script.Contains("public void MousePress"))
                    {
                        if (this._EventScripts_MousePress.Count == 0) PossibleEvents_MousePress.Items.Add("None");
                        PossibleEvents_MousePress.Items.Add(Current.Name);
                        this._EventScripts_MousePress.Add(Current);
                    }
                    if (Current.Script.Contains("public void MouseDown"))
                    {
                        if (this._EventScripts_MouseDown.Count == 0) PossibleEvents_MouseDown.Items.Add("None");
                        PossibleEvents_MouseDown.Items.Add(Current.Name);
                        this._EventScripts_MouseDown.Add(Current);
                    }
                    if (Current.Script.Contains("public void MouseUp"))
                    {
                        if (this._EventScripts_MouseUp.Count == 0) PossibleEvents_MouseUp.Items.Add("None");
                        PossibleEvents_MouseUp.Items.Add(Current.Name);
                        this._EventScripts_MouseUp.Add(Current);
                    }
                    if (Current.Script.Contains("public void MouseMove"))
                    {
                        if (this._EventScripts_MouseMove.Count == 0) PossibleEvents_MouseMove.Items.Add("None");
                        PossibleEvents_MouseMove.Items.Add(Current.Name);
                        this._EventScripts_MouseMove.Add(Current);
                    }
                    if (Current.Script.Contains("public void KeyPress"))
                    {
                        if (this._EventScripts_KeyPress.Count == 0) PossibleEvents_KeyPress.Items.Add("None");
                        PossibleEvents_KeyPress.Items.Add(Current.Name);
                        this._EventScripts_KeyPress.Add(Current);
                    }
                    if (Current.Script.Contains("public void KeyDown"))
                    {
                        if (this._EventScripts_KeyDown.Count == 0) PossibleEvents_KeyDown.Items.Add("None");
                        PossibleEvents_KeyDown.Items.Add(Current.Name);
                        this._EventScripts_KeyDown.Add(Current);
                    }
                    if (Current.Script.Contains("public void KeyUp"))
                    {
                        if (this._EventScripts_KeyUp.Count == 0) PossibleEvents_KeyUp.Items.Add("None");
                        PossibleEvents_KeyUp.Items.Add(Current.Name);
                        this._EventScripts_KeyUp.Add(Current);
                    }
                    if (Current.Script.Contains("public void RenderFrame"))
                    {
                        if (this._EventScripts_RenderFrame.Count == 0) PossibleEvents_RenderFrame.Items.Add("None");
                        PossibleEvents_RenderFrame.Items.Add(Current.Name);
                        this._EventScripts_RenderFrame.Add(Current);
                    }
                    if (Current.Script.Contains("public void EverySecond"))
                    {
                        if (this._EventScripts_EverySecond.Count == 0) PossibleEvents_EverySecond.Items.Add("None");
                        PossibleEvents_EverySecond.Items.Add(Current.Name);
                        this._EventScripts_EverySecond.Add(Current);
                    }
                }
            }
            PossibleEvents_Load.Enabled = PossibleEvents_Load.Items.Count != 0;
            PossibleEvents_MousePress.Enabled = PossibleEvents_MousePress.Items.Count != 0;
            PossibleEvents_MouseDown.Enabled = PossibleEvents_MouseDown.Items.Count != 0;
            PossibleEvents_MouseUp.Enabled = PossibleEvents_MouseUp.Items.Count != 0;
            PossibleEvents_MouseMove.Enabled = PossibleEvents_MouseMove.Items.Count != 0;
            PossibleEvents_KeyPress.Enabled = PossibleEvents_KeyPress.Items.Count != 0;
            PossibleEvents_KeyDown.Enabled = PossibleEvents_KeyDown.Items.Count != 0;
            PossibleEvents_KeyUp.Enabled = PossibleEvents_KeyUp.Items.Count != 0;
            PossibleEvents_RenderFrame.Enabled = PossibleEvents_RenderFrame.Items.Count != 0;
            PossibleEvents_EverySecond.Enabled = PossibleEvents_EverySecond.Items.Count != 0;
            if (PossibleEvents_Load.Items.Count > 0) PossibleEvents_Load.SelectedIndex = 0;
            if (PossibleEvents_MousePress.Items.Count > 0) PossibleEvents_MousePress.SelectedIndex = 0;
            if (PossibleEvents_MouseDown.Items.Count > 0) PossibleEvents_MouseDown.SelectedIndex = 0;
            if (PossibleEvents_MouseUp.Items.Count > 0) PossibleEvents_MouseUp.SelectedIndex = 0;
            if (PossibleEvents_MouseMove.Items.Count > 0) PossibleEvents_MouseMove.SelectedIndex = 0;
            if (PossibleEvents_KeyPress.Items.Count > 0) PossibleEvents_KeyPress.SelectedIndex = 0;
            if (PossibleEvents_KeyDown.Items.Count > 0) PossibleEvents_KeyDown.SelectedIndex = 0;
            if (PossibleEvents_KeyUp.Items.Count > 0) PossibleEvents_KeyUp.SelectedIndex = 0;
            if (PossibleEvents_RenderFrame.Items.Count > 0) PossibleEvents_RenderFrame.SelectedIndex = 0;
            if (PossibleEvents_EverySecond.Items.Count > 0) PossibleEvents_EverySecond.SelectedIndex = 0;
        }
        private void PossibleEvents_Load_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.Load.Clear();
            if(PossibleEvents_Load.SelectedIndex > 0) this._Scene.Events.Load.Add(this._EventScripts_Load[PossibleEvents_Load.SelectedIndex-1]);
        }
        private void PossibleEvents_MousePress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.MousePress.Clear();
            if (PossibleEvents_MousePress.SelectedIndex > 0) this._Scene.Events.MousePress.Add(this._EventScripts_MousePress[PossibleEvents_MousePress.SelectedIndex - 1]);
        }
        private void PossibleEvents_MouseDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.MouseDown.Clear();
            if (PossibleEvents_MouseDown.SelectedIndex > 0) this._Scene.Events.MouseDown.Add(this._EventScripts_MouseDown[PossibleEvents_MouseDown.SelectedIndex - 1]);
        }
        private void PossibleEvents_MouseUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.MouseUp.Clear();
            if (PossibleEvents_MouseUp.SelectedIndex > 0) this._Scene.Events.MouseUp.Add(this._EventScripts_MouseUp[PossibleEvents_MouseUp.SelectedIndex - 1]);
        }
        private void PossibleEvents_MouseMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.MouseMove.Clear();
            if (PossibleEvents_MouseMove.SelectedIndex > 0) this._Scene.Events.MouseMove.Add(this._EventScripts_MouseMove[PossibleEvents_MouseMove.SelectedIndex - 1]);
        }
        private void PossibleEvents_KeyPress_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.KeyPress.Clear();
            if (PossibleEvents_KeyPress.SelectedIndex > 0) this._Scene.Events.KeyPress.Add(this._EventScripts_KeyPress[PossibleEvents_KeyPress.SelectedIndex - 1]);
        }
        private void PossibleEvents_KeyDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.KeyDown.Clear();
            if (PossibleEvents_KeyDown.SelectedIndex > 0) this._Scene.Events.KeyDown.Add(this._EventScripts_KeyDown[PossibleEvents_KeyDown.SelectedIndex - 1]);
        }
        private void PossibleEvents_KeyUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.KeyUp.Clear();
            if (PossibleEvents_KeyUp.SelectedIndex > 0) this._Scene.Events.KeyUp.Add(this._EventScripts_KeyUp[PossibleEvents_KeyUp.SelectedIndex - 1]);
        }
        private void PossibleEvents_RenderFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.RenderFrame.Clear();
            if (PossibleEvents_RenderFrame.SelectedIndex > 0) this._Scene.Events.RenderFrame.Add(this._EventScripts_RenderFrame[PossibleEvents_RenderFrame.SelectedIndex - 1]);
        }
        private void PossibleEvents_EverySecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._Scene.Events.EverySecond.Clear();
            if (PossibleEvents_EverySecond.SelectedIndex > 0) this._Scene.Events.EverySecond.Add(this._EventScripts_EverySecond[PossibleEvents_EverySecond.SelectedIndex - 1]);
        }
        private void ToggleHeader_Click(object sender, EventArgs e)
        {
            if (_Toggled)
            {
                _Toggled = false;
                this.Height = 24;
            }
            else
            {
                _Toggled = true;
                this.Height = 394;
            }
        }
        private void Value_Name_TextChanged(object sender, EventArgs e)
        {
            this._Scene.Name = Value_Name.Text;
        }
    }
}
