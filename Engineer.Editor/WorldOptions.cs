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
    public delegate void AddToSceeneEventHandler(int Index);
    public partial class WorldOptions : ToolForm
    {
        public event AddToSceeneEventHandler AddItem;
        public WorldOptions()
        {
            InitializeComponent();
            AddItem = new AddToSceeneEventHandler(OnAddItem);
        }
        private void OnAddItem(int Index)
        {
        }
        private void Floor_MouseEnter(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(50,50,50);
        }
        private void Floor_MouseLeave(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            CurrentButton.BackColor = Color.FromArgb(20, 20, 20);
        }
        private void Floor_Click(object sender, EventArgs e)
        {
            Button CurrentButton = sender as Button;
            int Index = Convert.ToInt32(CurrentButton.Tag);
            AddItem.Invoke(Index);
        }
    }
}
