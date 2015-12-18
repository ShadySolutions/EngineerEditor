using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Engineer.Runner
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            using (var MainWindow = new Runner(800, 600, OpenTK.Graphics.GraphicsMode.Default, "Engineer Runner"))
            {
                MainWindow.Run();
            }
        }
    }
}
