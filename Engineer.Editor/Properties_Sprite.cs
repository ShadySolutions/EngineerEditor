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

namespace Engineer.Editor
{
    public partial class Properties_Sprite : UserControl
    {
        private DockPanel _Dock;
        private Sprite _CurrentSprite;
        public Properties_Sprite()
        {
            InitializeComponent();
        }
        public Properties_Sprite(Sprite CurrentSprite, DockPanel Dock)
        {
            InitializeComponent();
            this._Dock = Dock;
            this._CurrentSprite = CurrentSprite;
        }
        private void Properties_Sprite_Load(object sender, EventArgs e)
        {
            
        }

        private void Button_SpriteSets_Click(object sender, EventArgs e)
        {
            SpriteSetEditor Editor = new SpriteSetEditor(_CurrentSprite);
            Editor.Show(_Dock, DockState.Document);
        }
    }
}
