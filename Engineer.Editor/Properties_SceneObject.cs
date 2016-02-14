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
        private bool _SkipFlag;
        private DrawObject _CurrentObject;
        public Properties_SceneObject()
        {
            InitializeComponent();
            this.Value_Translation.SetMinMax(-100000, 100000);
            this.Value_Rotation.SetMinMax(-100000, 100000);
            this.Value_Scale.SetMinMax((decimal)0.000001, 100000);
            this.Value_Translation.X.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Translation.Y.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Translation.Z.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Rotation.X.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Rotation.Y.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Rotation.Z.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Scale.X.ValueChanged += new EventHandler(Value_Scale_Changed);
            this.Value_Scale.Y.ValueChanged += new EventHandler(Value_Scale_Changed);
            this.Value_Scale.Z.ValueChanged += new EventHandler(Value_Scale_Changed);
        }

        public Properties_SceneObject(DrawObject CurrentObject)
        {
            /*InitializeComponent();
            this.Value_Translation.SetMinMax(-100000, 100000);
            this.Value_Rotation.SetMinMax(-100000, 100000);
            this.Value_Scale.SetMinMax((decimal)0.000001, 100000);

            this._CurrentObject = CurrentObject;
            this.Value_Active.Checked = CurrentObject.Active;
            this.Value_Name.Text = CurrentObject.Name;
            this.Value_Translation.X.Value = Convert.ToDecimal(CurrentObject.Translation.X);
            this.Value_Translation.Y.Value = Convert.ToDecimal(CurrentObject.Translation.Y);
            this.Value_Translation.Z.Value = Convert.ToDecimal(CurrentObject.Translation.Z);
            this.Value_Rotation.X.Value = Convert.ToDecimal(CurrentObject.Rotation.X);
            this.Value_Rotation.Y.Value = Convert.ToDecimal(CurrentObject.Rotation.Y);
            this.Value_Rotation.Z.Value = Convert.ToDecimal(CurrentObject.Rotation.Z);
            this.Value_Scale.X.Value = Convert.ToDecimal(CurrentObject.Scale.X);
            this.Value_Scale.Y.Value = Convert.ToDecimal(CurrentObject.Scale.Y);
            this.Value_Scale.Z.Value = Convert.ToDecimal(CurrentObject.Scale.Z);

            this.Value_Translation.X.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Translation.Y.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Translation.Z.ValueChanged += new EventHandler(Value_Translation_Changed);
            this.Value_Rotation.X.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Rotation.Y.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Rotation.Z.ValueChanged += new EventHandler(Value_Rotation_Changed);
            this.Value_Scale.X.ValueChanged += new EventHandler(Value_Scale_Changed);
            this.Value_Scale.Y.ValueChanged += new EventHandler(Value_Scale_Changed);
            this.Value_Scale.Z.ValueChanged += new EventHandler(Value_Scale_Changed);*/
        }

        private void Value_Name_TextChanged(object sender, EventArgs e)
        {
            //this._CurrentObject.Name = Value_Name.Text;
        }

        private void Value_Active_CheckedChanged(object sender, EventArgs e)
        {
            this._CurrentObject.Active = Value_Active.Checked;
        }

        private void Value_Translation_Changed(object sender, EventArgs e)
        {
            this._CurrentObject.Translation = new Mathematics.Vertex((float)this.Value_Translation.X.Value, (float)this.Value_Translation.Y.Value, (float)this.Value_Translation.Z.Value);
        }

        private void Value_Rotation_Changed(object sender, EventArgs e)
        {
            this._CurrentObject.Rotation = new Mathematics.Vertex((float)this.Value_Rotation.X.Value, (float)this.Value_Rotation.Y.Value, (float)this.Value_Rotation.Z.Value);
        }

        private void Value_Scale_Changed(object sender, EventArgs e)
        {
            this._CurrentObject.Scale = new Mathematics.Vertex((float)this.Value_Scale.X.Value, (float)this.Value_Scale.Y.Value, (float)this.Value_Scale.Z.Value);
        }
    }
}
