using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
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

            ConfigFile.LoadConfig();
            frmMain firstMain = new frmMain();
            GeneralOps.Startup(firstMain);
            ConfigFile.ACTUAL_MAIN = firstMain;
            Logger.Initialize(@"F:\CODICE\Output");

            Application.Run(firstMain);
            
        }
    }
}
