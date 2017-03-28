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
            Timer.SetFirstTime(DateTime.Now);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mex.AddMessage("Starting Application: " + Timer.GetTimestampPrecision(DateTime.Now), Mex.INFO);
            List<MessageT> test = Mex.GetMessageOfType((int)Mex.INFO);
            Mex.PrintMessageInForm(Mex.FormatMessageAtIndex());
            Mex.RemoveAll();

            ConfigFile.LoadConfig();
            frmMain firstMain = new frmMain();
            GeneralOps.Startup(firstMain);
            ConfigFile.ACTUAL_MAIN = firstMain;
            Logger.Initialize(@"F:\CODICE\Output");

            Application.Run(firstMain);
            
        }
    }
}
