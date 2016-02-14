using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;
using Engineer.Engine;

namespace Engineer.Editor
{
    public partial class PropertiesWindow : ToolForm
    {
        private SceneObject _CurrentObject;
        public PropertiesWindow()
        {
            InitializeComponent();
            this.ContentPanel.Padding = new Padding(10);
        }
        public void SetDrawObject(SceneObject CurrentObject)
        {
            this._CurrentObject = CurrentObject;
            this.ContentPanel.Controls.Clear();
            if (CurrentObject == null) return;
            NameLabel.Visible = true;
            NameLabel.Text = CurrentObject.Name;
            NameLabel.Dock = DockStyle.Top;
            this.ContentPanel.Controls.Add(NameLabel);
            NameLabel.SendToBack();
            if (CurrentObject.Type == SceneObjectType.DrawnSceneObject)
            {
                Properties_DrawObject PDO = new Properties_DrawObject(DrawnSceneObject.Drawn(CurrentObject).Representation);
                PDO.Dock = DockStyle.Top;
                PDO.Height = 130;
                this.ContentPanel.Controls.Add(PDO);
                PDO.BringToFront();
            }
        }
    }
}
