using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    class ConfigFile
    {

        private static string BASE_PATH = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        public static string APP_PATH = System.IO.Path.GetDirectoryName(BASE_PATH).Replace("file:\\", "");


        public static string DEFAULT_USER = "eregiongreenleafthegray@yahoo.it";
        public static string DEFAULT_PASS = "chupa33";

        public static frmMain ACTUAL_MAIN { get; set; } = null;
        public static frmGetData ACTUAL_GETDATA { get; set; } = null;
        public static frmGetDataSingle ACTUAL_GETDATASINGLE { get; set; } = null;
        public static List<PlayerStatT> GLOBAL_PLAYER { get; set; }
        public static Semaphore _Global = new Semaphore(0, 1);

        public static string SAVE_PATH { get; set; }
        public static int SEASON_FIRST { get; set; }
        public static int SEASON_LAST { get; set; }
        public static string ADDRESS { get; set; }
        public static int? START_PAGE { get; set; }
        public static int? END_PAGE { get; set; }
        public static int? LOG_LEVEL { get; set; }
        public static string SEPARATOR { get; set; }
        public static string FILE_OUTPUT { get; set; }
        private static int TASK_STARTED { get; set; } = 0;
        private static int TASK_FINISHED { get; set; } = 0;
        public static bool LAST_SEASON_CHECKED { get; set; } = false;
        // First Season used to search the last Season available. Hardcoded.
        public static int FIRST_SEASON_TO_SEARCH { get; set; } = 9;
        public static DirectoryInfo DIRECTORY_OUTPUT { get; set; }


        /// SEZIONE GET_DATA GLOBALE
        public static bool GENERAL { get; set; }
        public static bool LIGHT { get; set; }
        public static bool MEDIUM { get; set; }
        public static bool HEAVY { get; set; }
        public static bool ASSAULT { get; set; }

        public static double TIME_PAGE { get; set; } = 1500.00;
        public static double EXPECTED_TIME { get; set; }
        public static double ACTUAL_TIME { get; set; }
        public static int TOTAL_PAGES { get; set; }
        public static int MAX_PAGES = 3500;
        public static int MIN_PAGES = 0;


        public static bool LoadConfig()
        {
            try
            {
                ADDRESS = ConfigurationSettings.AppSettings["Address Start"];
                int tempInt = 0;
                double tempDouble = 2.0;
                START_PAGE = int.TryParse(ConfigurationSettings.AppSettings["Start Page"], out tempInt) ? tempInt : 0;
                END_PAGE = int.TryParse(ConfigurationSettings.AppSettings["End Page"], out tempInt) ? tempInt : 0;
                SEPARATOR = ConfigurationSettings.AppSettings["Separator"];
                
                SEASON_FIRST = int.TryParse(ConfigurationSettings.AppSettings["First Season"], out tempInt) ? tempInt : 1;
                SEASON_LAST = int.TryParse(ConfigurationSettings.AppSettings["Last Season"], out tempInt) ? tempInt : 7;
                MAX_PAGES = int.TryParse(ConfigurationSettings.AppSettings["Default Max Page"], out tempInt) ? tempInt : 4000;
                MIN_PAGES = int.TryParse(ConfigurationSettings.AppSettings["Default Min Page"], out tempInt) ? tempInt : 0;
                string directory = ConfigurationSettings.AppSettings["Output Folder"];
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                if (!dirInfo.Exists)
                {
                    Mex.AddMessage("'Output Folder' (in the configuration file) doesn't exist. Using the application folder instead.", Mex.ERROR);
                    ////
                    string output = Path.Combine(APP_PATH, "Output");
                    DirectoryInfo tempInfo = Directory.CreateDirectory(output);
                    if (tempInfo != null)
                    {
                        DIRECTORY_OUTPUT = tempInfo;
                        FILE_OUTPUT = ConfigurationSettings.AppSettings["Output File"];
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    DIRECTORY_OUTPUT = dirInfo;
                    FILE_OUTPUT = Path.Combine(DIRECTORY_OUTPUT.FullName, ConfigurationSettings.AppSettings["Output File"]);
                }
                GENERAL = false;
                LIGHT = false;
                MEDIUM = false;
                HEAVY = false;
                ASSAULT = false;
                EXPECTED_TIME = double.TryParse(ConfigurationSettings.AppSettings["Expected download time per page"], out tempDouble) ? tempDouble : 2.0;
                return true;
            }
            catch (Exception exp)
            {
                Logger.PrintLC("Failed to load Settings from the configuration file.\nLoading the default settings instead.");
                ADDRESS = "";
                START_PAGE = 1;
                END_PAGE = 200;
                SEASON_FIRST = 1;
                SEASON_LAST = 7;
                MAX_PAGES = 1700;
                MIN_PAGES = 0;

                GENERAL = false;
                LIGHT = false;
                MEDIUM = false;
                HEAVY = false;
                ASSAULT = false;
                EXPECTED_TIME = 2.0;
                return false;
            }
        }


        public static void IncrementTaskStarted(bool refreshMain = true)
        {
            TASK_STARTED++;
            RefreshMain(refreshMain);
        }
        public static void IncrementTaskFinished(bool refreshMain = true)
        {
            TASK_FINISHED++;
            RefreshMain(refreshMain);
        }
        private static void RefreshMain(bool refreshMain)
        {
            bool enabled = ACTUAL_MAIN.Enabled;
            if (refreshMain)
            {
                ACTUAL_MAIN.lblActiveTasksText = (GetTaskStarted() - GetTaskFinished()).ToString();
            }
            if (enabled)
                ACTUAL_MAIN.Enabled = enabled;
        }
        public static int GetTaskStarted()
        {
            return TASK_STARTED;
        }
        public static int GetTaskFinished()
        {
            return TASK_FINISHED;
        }
        public static int GetActiveTasks()
        {
            return GetTaskStarted() - GetTaskFinished();
        }

    }
}
