using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Engineer.Engine;
using TakeOne.WindowSuite;

namespace Engineer.Editor
{
    public partial class PropertiesInput_Sprite : PropertiesInput
    {
        private Sprite _CurrentSprite;
        private DockPanel _Dock;
        private List<ToolForm> _OpenForms;
        public PropertiesInput_Sprite()
        {
            InitializeComponent();
        }
        public PropertiesInput_Sprite(string Title, Sprite CurrentSprite, DockPanel Dock, List<ToolForm> OpenForms) : base(Title)
        {
            InitializeComponent();
            this._CurrentSprite = CurrentSprite;
            this._OpenForms = OpenForms;
            if (CurrentSprite.SpriteSets.Count > 0 && _CurrentSprite.SpriteSets[0].Sprite.Count > 0) Preview.BackgroundImage = _CurrentSprite.SpriteSets[0].Sprite[0];
        }
        private void Preview_Click(object sender, EventArgs e)
        {
            SpriteSetEditor Editor = new SpriteSetEditor(_CurrentSprite);
            Editor.Text = this._CurrentSprite.Name + "[SPS]";
            Editor.Title = this._CurrentSprite.Name + "[SPS]";
            _OpenForms.Add(Editor);
            Editor.Show(_Dock, DockState.Document);
        }
    }
}
