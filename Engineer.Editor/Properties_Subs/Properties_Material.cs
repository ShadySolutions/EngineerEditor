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
using TakeOne.WindowSuite;
using WeifenLuo.WinFormsUI.Docking;

namespace Engineer.Editor
{
    public partial class Properties_Material : UserControl
    {
        private int _Index;
        private Actor _CurrentActor;
        private Game_Interface _Interface;
        private PropertiesInput_String _Name;
        public Properties_Material()
        {
            InitializeComponent();
        }
        public Properties_Material(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms, int Index)
        {
            InitializeComponent();
            Init(Interface, CurrentActor, Dock, OpenForms, Index);
        }
        public void Init(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms, int Index)
        {
            this._Interface = Interface;
            this._CurrentActor = CurrentActor;
            this.HolderMaterial.Title = this._CurrentActor.Materials[Index].Name;
            this._Index = Index;
            _Name = new PropertiesInput_String("Name", _CurrentActor.Materials[Index].Name, new EventHandler(Name_Update));
            HolderMaterial.AddControl(_Name);
            PropertiesInput_Material Material = new PropertiesInput_Material("Material", _CurrentActor.Materials[Index], Dock, OpenForms);
            HolderMaterial.AddControl(Material);
        }
        private void Name_Update(object sender, EventArgs e)
        {
            _CurrentActor.Materials[_Index].Name = _Name.GetValue().ToString();
        }
        private void HolderMaterial_Resize(object sender, EventArgs e)
        {
            this.Height = HolderMaterial.Height;
        }
    }
}
