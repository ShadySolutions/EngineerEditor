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
    public partial class Properties_Actor : UserControl
    {
        private DockPanel _Dock;
        private Actor _CurrentActor;
        private Game_Interface _Interface;
        private List<ToolForm> _OpenForms;
        private PropertiesInput_Button _AddMaterial;
        private PropertiesHolder _Materials;
        public Properties_Actor()
        {
            InitializeComponent();
        }
        public Properties_Actor(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            Init(Interface, CurrentActor, Dock, OpenForms);
        }
        public void Init(Game_Interface Interface, Actor CurrentActor, DockPanel Dock, List<ToolForm> OpenForms)
        {
            InitializeComponent();
            this._Interface = Interface;
            this._CurrentActor = CurrentActor;
            this._Dock = Dock;
            this._OpenForms = OpenForms;
            PropertiesHolder Geometries = new PropertiesHolder();
            Geometries.Title = "Geometries";
            Geometries.Toggled = false;
            for(int i = 0; i < CurrentActor.Geometries.Count; i++)
            {
                Properties_Geometry NewGeometry = new Properties_Geometry(Interface, CurrentActor, i);
                //Geometries.AddControl(NewGeometry);
            }
            HolderActor.AddControl(Geometries);
            _Materials = new PropertiesHolder();
            _Materials.Title = "Materials";
            _Materials.Toggled = false;
            for(int i = 0; i < CurrentActor.Materials.Count; i++)
            {
                Properties_Material NewMaterial = new Properties_Material(Interface, CurrentActor, Dock, OpenForms, i);
                //_Materials.AddControl(NewMaterial);
            }
            _AddMaterial = new PropertiesInput_Button("", "Add Material", new EventHandler(AddMaterial));
            _Materials.AddControl(_AddMaterial);
            HolderActor.AddControl(_Materials);
        }
        public void AddMaterial(object sender, EventArgs e)
        {
            _CurrentActor.Materials.Add(new Material("New Material", Material.Default));
            Properties_Material NewMaterial = new Properties_Material(_Interface, _CurrentActor, _Dock, _OpenForms, _CurrentActor.Materials.Count-1);
            //_Materials.AddControl(NewMaterial);
            //_AddMaterial.BringToFront();
        }
        private void HolderActor_Resize(object sender, EventArgs e)
        {
            this.Height = HolderActor.Height;
        }
    }
}
