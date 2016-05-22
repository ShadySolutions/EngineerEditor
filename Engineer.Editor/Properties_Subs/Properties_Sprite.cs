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
using WeifenLuo.WinFormsUI.Docking;
using TakeOne.WindowSuite;

namespace Engineer.Editor
{
    public partial class Properties_Sprite : UserControl
    {
        private bool _Toggled;
        private DockPanel _Dock;
        private Sprite _CurrentSprite;
        private List<ToolForm> _OpenForms;
        public Properties_Sprite()
        {
            InitializeComponent();
            this._Toggled = true;
        }
        public void Init(Sprite CurrentSprite, DockPanel Dock, List<ToolForm> OpenForms)
        {
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this._CurrentSprite = CurrentSprite;
        }
        private void Button_SpriteSets_Click(object sender, EventArgs e)
        {
            SpriteSetEditor Editor = new SpriteSetEditor(_CurrentSprite);
            Editor.Text = this._CurrentSprite.Name + " - SpriteSet Editor";
            Editor.Title = this._CurrentSprite.Name + " - SpriteSet Editor";
            _OpenForms.Add(Editor);
            Editor.Show(_Dock, DockState.Document);
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
                this.Height = 62;
            }
        }
    }
}
