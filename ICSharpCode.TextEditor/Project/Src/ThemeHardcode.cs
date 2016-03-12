using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ICSharpCode
{
    public class ThemeHardcode
    {
        public static Color GlobalBack = Color.Gray;
        public static Color TextAreaBack = Color.Black;
        public static Color TextAreaControlBack = Color.Gray;
        public static Color IconBarMargin = Color.Red;
        public static Color HighlightColor = Color.Red;
        public static Color HighlightBackgroundColor = Color.WhiteSmoke;
        public static Brush BackBrush = new SolidBrush(Color.FromArgb(20,20,20));
        public static Brush SelectedBush = Brushes.Gray;
        public static Brush DefaultText = Brushes.White;
        public static Brush SelectedText = Brushes.Silver;
    }
}
