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

namespace Engineer.Editor
{
    public partial class SpriteSetEntry : UserControl
    {
        private SpriteSet _CurrentSet;
        public SpriteSetEntry()
        {
            InitializeComponent();
        }
        public SpriteSetEntry(SpriteSet CurrentSet)
        {
            InitializeComponent();
            this._CurrentSet = CurrentSet;
            this.Name_Box.Text = CurrentSet.Name;
            UpdateItems();
        }
        public void UpdateItems()
        {
            List.Items.Clear();
            EntryTileList.Images.Clear();
            for (int i = 0; i < this._CurrentSet.Sprite.Count; i++)
            {
                EntryTileList.Images.Add(this._CurrentSet.Sprite[i]);
            }
            for (int i = 0; i < this._CurrentSet.Sprite.Count; i++)
            {
                List.Items.Add(new ListViewItem("", i));
            }
        }

        private void SpriteSetEntry_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void List_DragDrop(object sender, DragEventArgs e)
        {
            List<Bitmap> Images = e.Data.GetData(typeof(List<Bitmap>)) as List<Bitmap>;
            for(int i = 0; i < Images.Count; i++)
            {
                this._CurrentSet.Sprite.Add(Images[i]);
            }
            UpdateItems();
        }
    }
}
