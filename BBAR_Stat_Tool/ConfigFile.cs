using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    class ConfigFile
    {

        public static frmMain ACTUAL_MAIN { get; set; } = null;
        public static frmGetData ACTUAL_GETDATA { get; set; } = null;

        public static string SAVE_PATH { get; set; }
        public static int SEASON_FIRST { get; set; }
        public static int SEASON_LAST { get; set; }
        public static string ADDRESS { get; set; }
        public static int? START_PAGE { get; set; }
        public static int? END_PAGE { get; set; }
        public static int? LOG_LEVEL { get; set; }
        public static string SEPARATOR { get; set; }
        public static string FILE_OUTPUT { get; set; }
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
                FILE_OUTPUT = ConfigurationSettings.AppSettings["Output File"];
                SEASON_FIRST = int.TryParse(ConfigurationSettings.AppSettings["First Season"], out tempInt) ? tempInt : 1;
                SEASON_LAST = int.TryParse(ConfigurationSettings.AppSettings["Last Season"], out tempInt) ? tempInt : 7;
                MAX_PAGES = int.TryParse(ConfigurationSettings.AppSettings["Default Max Page"], out tempInt) ? tempInt : 3500;
                MIN_PAGES = int.TryParse(ConfigurationSettings.AppSettings["Default Min Page"], out tempInt) ? tempInt : 0;

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
                MAX_PAGES = 3500;
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

        /// SEZIONE GET_DATA GLOBALE
        public static bool GENERAL { get; set; }
        public static bool LIGHT { get; set; }
        public static bool MEDIUM { get; set; }
        public static bool HEAVY { get; set; }
        public static bool ASSAULT { get; set; }

        public static double EXPECTED_TIME { get; set; }
        public static double ACTUAL_TIME { get; set; }
        public static int TOTAL_PAGES { get; set; }
        public static int MAX_PAGES = 3500;
        public static int MIN_PAGES = 0;
        

    }
}
