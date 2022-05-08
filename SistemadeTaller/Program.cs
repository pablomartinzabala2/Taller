using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SistemadeTaller
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
          //  Application.Run(new FrmBorrar());  
           //  Application.Run(new FrmLogin());
            //    Application.Run(new FrmTest ());
                Application.Run(new FrmRentabilidad ());
        }
    }
}
