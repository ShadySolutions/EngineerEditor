using Engineer.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeOne.WindowSuite;

namespace Engineer.Editor
{
    public partial class SpriteSetEditor : ToolForm
    {
        private List<Bitmap> _Images;
        private Sprite _CurrentSprite;
        public SpriteSetEditor()
        {
            InitializeComponent();
        }
        public SpriteSetEditor(Sprite CurrentSprite)
        {
            InitializeComponent();
            this._Images = new List<Bitmap>();
            this._CurrentSprite = CurrentSprite;
            for (int i = 0; i < CurrentSprite.SpriteSets.Count; i++)
            {
                SpriteSetEntry Entry = new SpriteSetEntry(CurrentSprite.SpriteSets[i]);
                Entry.Dock = DockStyle.Top;
                EntryPanel.Controls.Add(Entry);
                Entry.BringToFront();
            }
        }

        private void Button_AddSpriteSet_Click(object sender, EventArgs e)
        {
            SpriteSet NewSpriteSet = new SpriteSet("New SpriteSet");
            this._CurrentSprite.SpriteSets.Add(NewSpriteSet);
            SpriteSetEntry Entry = new SpriteSetEntry(NewSpriteSet);
            Entry.Dock = DockStyle.Top;
            EntryPanel.Controls.Add(Entry);
            Entry.BringToFront();
        }

        private void Button_AddImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image|*jpg;*jpeg;*png;*bmp";
            Dialog.Multiselect = true;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                for(int i = 0; i < Dialog.FileNames.Length; i++)
                {
                    this._Images.Add((Bitmap)Image.FromFile(Dialog.FileNames[i]));
                    this.TileImages.Images.Add(this._Images[this._Images.Count-1]);
                    this.List.Items.Add(new ListViewItem("", this._Images.Count - 1));
                }
            }
        }

        private void List_MouseDown(object sender, MouseEventArgs e)
        {
            List<Bitmap> Images = new List<Bitmap>();
            for(int i = 0; i < List.SelectedIndices.Count; i++)
            {
                Images.Add(this._Images[List.SelectedIndices[i]]);
            }
            DoDragDrop(Images, DragDropEffects.Copy);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            _CurrentSprite.Modified = true;
        }
    }
}
