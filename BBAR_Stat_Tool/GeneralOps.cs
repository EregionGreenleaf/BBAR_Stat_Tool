using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    static class GeneralOps
    {
        /// <summary>
        /// Sets up main Form informations (buttons, labels, etc.)
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        public static bool Startup(frmMain frm)
        {
            //Get assembly Version
            //Version xx = Assembly.GetEntryAssembly().GetName().Version;
            //string CopyrightStr = frm.lblCopyrightText;
            frm.lblCopyrightText += getExeVersion();
            return true;
        }
        public static string getExeVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        /// <summary>
        /// DEPRECATED
        /// </summary>
        /// <param name="frm"></param>
        public static void HideGetData(frmGetData frm)
        {
            frm.Hide();
        }

        public static async void RefreshDownloadTime()
        {
            double time = await WebOps.TestSpeed();
            ConfigFile.TIME_PAGE = time > 0 ? (time / 10000) * 1001 : 0;
        }
    }
}
