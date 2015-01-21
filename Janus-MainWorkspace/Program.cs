using System.Threading;
using CxTitan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
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
            //Application.Run(new ConnectPage());

            //Application.Run(new JanusManual());


            //Splash splash = new Splash();
            //splash.SetWaitTime(20);
            //splash.ShowDialog();
            SystemGlobals.ShowSplash();
            Application.Run(new LoginPage());
        }
    }
}
