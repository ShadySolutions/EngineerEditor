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
    public partial class GlobalAssets : ToolForm
    {
        private bool _BlockEvents;
        private int _SelectedFilter;
        private Game_Interface _Interface;
        private List<Button> _Filters;
        private List<Button> _Options;
        public GlobalAssets(Game_Interface Interface)
        {
            InitializeComponent();
            this._Interface = Interface;
            InitFilters();
        }
        private void InitFilters()
        {
            this._Filters = new List<Button>();
            FilterPanel.Controls.Clear();
            for (int i = 0; i < this._Interface.Library.Groups.Count; i++)
            {
                Button Filter = new Button();
                Filter.Name = "Filter_"+i;
                Filter.Text = this._Interface.Library.Groups[i].Name;
                Filter.TextAlign = ContentAlignment.MiddleLeft;
                Filter.Padding = new Padding(20, 0, 0, 0);
                Filter.FlatStyle = FlatStyle.Flat;
                Filter.Tag = i;
                Filter.Dock = DockStyle.Top;
                Filter.Size = new Size(100, 30);
                Filter.ForeColor = Color.White;
                Filter.BackColor = Color.FromArgb(30, 30, 30);
                Filter.FlatAppearance.BorderSize = 0;
                Filter.MouseEnter += new EventHandler(this.MouseEnterFilter);
                Filter.MouseLeave += new EventHandler(this.MouseLeaveFilter);
                Filter.Click += new EventHandler(this.MouseClickFilter);
                FilterPanel.Controls.Add(Filter);
                this._Filters.Add(Filter);
                Filter.BringToFront();
            }
            this._SelectedFilter = 0;
            this._Filters[0].BackColor = Color.FromArgb(80, 80, 80);
            InitAssets();
        }
        private void MouseEnterFilter(object sender, EventArgs e)
        {
            Button B = sender as Button;
            if (this._SelectedFilter == (int)B.Tag) return;
            B.BackColor = Color.FromArgb(40,40,40);
        }
        private void MouseLeaveFilter(object sender, EventArgs e)
        {
            Button B = sender as Button;
            if (this._SelectedFilter == (int)B.Tag) return;
            B.BackColor = Color.FromArgb(30, 30, 30);
        }
        private void MouseClickFilter(object sender, EventArgs e)
        {
            for(int i = 0; i < this._Filters.Count; i++) this._Filters[i].BackColor = Color.FromArgb(30, 30, 30);
            Button B = sender as Button;
            this._SelectedFilter = (int)B.Tag;
            B.BackColor = Color.FromArgb(80, 80, 80);
            InitAssets();
        }
        private void InitAssets()
        {
            if(this._Options == null) this._Options = new List<Button>();
            this.ContentPanel.Controls.Clear();
            this.ContentPanel.Controls.Add(this.FilterPanel);
            this._Options.Clear();
            for(int i = 0; i < this._Interface.Library.Groups[this._SelectedFilter].Objects.Count; i++)
            {
                Button Option = new Button();
                Option.Name = "Option_" + i;
                Option.Text = this._Interface.Library.Groups[this._SelectedFilter].Objects[i].Name;
                Option.TextAlign = ContentAlignment.MiddleLeft;
                Option.Padding = new Padding(50, 0, 0, 0);
                Option.FlatStyle = FlatStyle.Flat;
                Option.Tag = i;
                Option.Dock = DockStyle.Top;
                Option.Size = new Size(100, 50);
                Option.ForeColor = Color.White;
                Option.BackColor = Color.FromArgb(30, 30, 30);
                Option.FlatAppearance.BorderSize = 0;
                Option.BackgroundImageLayout = ImageLayout.None;
                if (this._Interface.Library.Groups[this._SelectedFilter].Objects[i].Type == SceneObjectType.SoundSceneObject) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Music_icon;
                else if (this._Interface.Library.Groups[this._SelectedFilter].Objects[i].Type == SceneObjectType.ScriptSceneObject) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Clock_icon;
                else if (this._Interface.Library.Groups[this._SelectedFilter].Objects[i].Type == SceneObjectType.DrawnSceneObject)
                {
                    DrawnSceneObject DSO = this._Interface.Library.Groups[this._SelectedFilter].Objects[i] as DrawnSceneObject;
                    if (DSO.Visual.Type == DrawObjectType.Tile) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Flower_Lotus_icon;
                    else if (DSO.Visual.Type == DrawObjectType.Sprite) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Photos_2_icon;
                    else if (DSO.Visual.Type == DrawObjectType.Figure) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Turtle_icon;
                    else if (DSO.Visual.Type == DrawObjectType.Actor) Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_3D_icon;
                    else Option.BackgroundImage = global::Engineer.Editor.Properties.Resources.G12_Document_icon;
                }
                Option.MouseEnter += new EventHandler(this.MouseEnterOption);
                Option.MouseLeave += new EventHandler(this.MouseLeaveOption);
                Option.Click += new EventHandler(this.MouseClickOption);
                ContentPanel.Controls.Add(Option);
                this._Options.Add(Option);
                Option.BringToFront();
            }
        }
        private void MouseEnterOption(object sender, EventArgs e)
        {
            Button B = sender as Button;
            B.BackColor = Color.Orange;
        }
        private void MouseLeaveOption(object sender, EventArgs e)
        {
            Button B = sender as Button;
            B.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void MouseClickOption(object sender, EventArgs e)
        {
            Button B = sender as Button;
            this._Interface.AddSceneItem(this._Interface.Library.Groups[this._SelectedFilter].Objects[(int)B.Tag]);
        }
    }
}
