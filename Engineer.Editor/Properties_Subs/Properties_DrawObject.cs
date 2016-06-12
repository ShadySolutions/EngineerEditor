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
using Engineer.Mathematics;

namespace Engineer.Editor
{
    public partial class Properties_DrawObject : UserControl
    {
        private DrawObject _CurrentDrawObject;
        private Game_Interface _Interface;
        private PropertiesInput_Bool _Active;
        private PropertiesInput_Vertex _Translation;
        private PropertiesInput_Vertex _Rotation;
        private PropertiesInput_Vertex _Scale;
        public Properties_DrawObject()
        {
            InitializeComponent();
        }
        public Properties_DrawObject(Game_Interface Interface, DrawObject CurrentDrawObject)
        {
            InitializeComponent();
            Init(Interface, CurrentDrawObject);
        }
        public void Init(Game_Interface Interface, DrawObject CurrentDrawObject)
        {
            this._Interface = Interface;
            this._CurrentDrawObject = CurrentDrawObject;
            PropertiesInput_Label Type = new PropertiesInput_Label("Type", _CurrentDrawObject.Type.ToString());
            HolderDraw.AddControl(Type);
            _Active = new PropertiesInput_Bool("Active", _CurrentDrawObject.Active, new EventHandler(ActiveChanged));
            HolderDraw.AddControl(_Active);
            _Translation = new PropertiesInput_Vertex("Translation", _CurrentDrawObject.Translation, new EventHandler(TranslationChanged));
            HolderDraw.AddControl(_Translation);
            _Rotation = new PropertiesInput_Vertex("Rotation", _CurrentDrawObject.Rotation, new EventHandler(RotationChanged));
            HolderDraw.AddControl(_Rotation);
            _Scale = new PropertiesInput_Vertex("Scale", _CurrentDrawObject.Scale, new EventHandler(ScaleChanged));
            HolderDraw.AddControl(_Scale);
        }
        private void ActiveChanged(object sender, EventArgs e)
        {
            if (this._CurrentDrawObject == null) return;
            _CurrentDrawObject.Active = (bool)_Active.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void TranslationChanged(object sender, EventArgs e)
        {
            if (this._CurrentDrawObject == null) return;
            _CurrentDrawObject.Translation = (Vertex)_Translation.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void RotationChanged(object sender, EventArgs e)
        {
            if (this._CurrentDrawObject == null) return;
            _CurrentDrawObject.Rotation = (Vertex)_Rotation.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void ScaleChanged(object sender, EventArgs e)
        {
            if (this._CurrentDrawObject == null) return;
            _CurrentDrawObject.Scale = (Vertex)_Scale.GetValue();
            _Interface.ForceUpdate(InterfaceUpdateMessage.SceneObjectsUpdated);
        }
        private void HolderDraw_Resize(object sender, EventArgs e)
        {
            this.Height = HolderDraw.Height;
        }
    }
}
