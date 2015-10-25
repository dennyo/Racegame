using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racegame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            black form1 = new black();
            Super_InformatiKart form2 = new Super_InformatiKart();
            form1.Show();
            form2.Show();
            Application.Run();
        }
    }
}
