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
using Engineer.Interface;

namespace Engineer.Editor
{
    public partial class Properties_Sprite : PropertiesHolder
    {
        private DockPanel _Dock;
        private Sprite _CurrentSprite;
        private Game_Interface _Interface;
        private List<ToolForm> _OpenForms;
        public Properties_Sprite()
        {
            InitializeComponent();
        }
        public Properties_Sprite(Game_Interface Interface, Sprite CurrentSprite, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            Init(Interface, CurrentSprite, Dock, OpenForms);
        }
        public void Init(Game_Interface Interface, Sprite CurrentSprite, DockPanel Dock, List<ToolForm> OpenForms)
        {
            this._Interface = Interface;
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            this._CurrentSprite = CurrentSprite;
            PropertiesInput_Sprite Sprite = new PropertiesInput_Sprite("SpriteSets", CurrentSprite, Dock, OpenForms);
            this.AddControl(Sprite);
        }
    }
}
