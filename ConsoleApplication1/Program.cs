using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ConsoleApplication1
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            using (var mainWindow = new GameWindow(800, 600))
            {
                mainWindow.Run();
            }
        }
    }
}
