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
        public void SetSceneObject(SceneObject CurrentObject)
        {
            this._CurrentObject = CurrentObject;
            this.ContentPanel.Controls.Clear();
            if (CurrentObject == null) return;
            Properties_SceneObject PSO = new Properties_SceneObject(CurrentObject);
            PSO.Dock = DockStyle.Top;
            PSO.Height = 160;
            this.ContentPanel.Controls.Add(PSO);
        }
    }
}
