using Engineer.Engine;
using Engineer.Interface;
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

namespace Engineer.Editor
{
    public partial class WorldOptions : ToolForm
    {
        private bool _BlockEvents;
        private int _FilterType;
        private SceneType _Type;
        private Game_Interface _Interface;
        private List<Button> _Filters;
        private List<Button> _Options;
        public WorldOptions(Game_Interface Interface)
        {
            InitializeComponent();
        }
    }
}
