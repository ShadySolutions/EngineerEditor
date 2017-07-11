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
        private int _FilterType;
        private SceneType _Type;
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
                Filter.FlatStyle = FlatStyle.Flat;
                Filter.Tag = i;
                Filter.Dock = DockStyle.Top;
                Filter.Size = new Size(100, 30);
                Filter.ForeColor = Color.White;
                Filter.BackColor = Color.FromArgb(30, 30, 30);
                Filter.FlatAppearance.BorderSize = 0;
                Filter.MouseEnter += new EventHandler(this.MouseEnterFilter);
                Filter.MouseLeave += new EventHandler(this.MouseLeaveFilter);
                FilterPanel.Controls.Add(Filter);
                this._Filters.Add(Filter);
            }
        }
        private void MouseEnterFilter(object sender, EventArgs e)
        {
            Button B = sender as Button;
            B.BackColor = Color.FromArgb(40,40,40);
        }
        private void MouseLeaveFilter(object sender, EventArgs e)
        {
            Button B = sender as Button;
            B.BackColor = Color.FromArgb(30, 30, 30);
        }
        private void InitAssets()
        {

        }
    }
}
