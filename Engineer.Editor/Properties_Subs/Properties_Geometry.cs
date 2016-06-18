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

namespace Engineer.Editor
{
    public partial class Properties_Geometry : PropertiesHolder
    {
        private int _Index;
        private Actor _CurrentActor;
        private Game_Interface _Interface;
        private PropertiesInput_Combo _MatList;
        public Properties_Geometry()
        {
            InitializeComponent();
        }
        public Properties_Geometry(Game_Interface Interface, Actor CurrentActor, int Index)
        {
            InitializeComponent();
            Init(Interface, CurrentActor, Index);
        }
        public void Init(Game_Interface Interface, Actor CurrentActor, int Index)
        {
            this._Interface = Interface;
            this._CurrentActor = CurrentActor;
            this.Title = this._CurrentActor.Geometries[Index].Name;
            this._Index = Index;
            PropertiesInput_Label Name = new PropertiesInput_Label("Name", _CurrentActor.Geometries[Index].Name);
            this.AddControl(Name);
            GenerateMaterialList();
            this.SetTitleColor(Color.FromArgb(50, 50, 50));
        }
        private void GenerateMaterialList()
        {
            List<string> Names = new List<string>();
            for(int i = 0; i < _CurrentActor.Materials.Count; i++)
            {
                Names.Add(_CurrentActor.Materials[i].Name);
            }
            _MatList = new PropertiesInput_Combo("Material", Names, _CurrentActor.GeometryMaterialIndices[_Index], new EventHandler(MatList_Update));
            this.AddControl(_MatList);
        }
        private void MatList_Update(object sender, EventArgs e)
        {
            _CurrentActor.GeometryMaterialIndices[_Index] = (int)_MatList.GetValue();
        }
    }
}
