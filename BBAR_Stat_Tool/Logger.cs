﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    static class Logger
    {
        private static string FileName;
        private static FileInfo FileInfos;
        //private static StreamWriter StrWr;
        private static string FileNameStream;
        public static void Initialize(string fileName)
        {
            Timer.SetFirstTime(DateTime.Now);
            FileName = fileName;
            FileInfos = new FileInfo(FileName);
            FileNameStream = FileInfos.DirectoryName +
                             @"\" +
                             Path.GetFileNameWithoutExtension(FileInfos.FullName) +
                             "_" +
                             Timer.GetTimestampDay(DateTime.Now) +
                             ".txt";
            //StrWr = File.AppendText(FileNameStream);
        }

        /// <summary>
        /// Write on the standard log file, defined in the log file
        /// Scrive sul file di log standard definito nel config file
        /// </summary>
        /// <param name="text"></param>
        public static void PrintL(string text)
        {
            string line = Timer.GetTimestampPrecision(DateTime.Now) + "    " + text;
            using (StreamWriter StrWr = File.AppendText(FileNameStream))
            {
                StrWr.WriteLine(line);
                StrWr.Close();
            }
        }

        /// <summary>
        /// Scrive sulla consolle
        /// </summary>
        /// <param name="text"></param>
        public static void PrintC(string text)
        {
            string line = Timer.GetTimestampPrecision(DateTime.Now) + "    " + text;
            Console.WriteLine(line);
        }
        /// <summary>
        /// scrive sia su consolle che su file di log standard
        /// </summary>
        /// <param name="text"></param>
        /// <param name="level"></param>
        public static void PrintLC(string text, int level = 1)
        {
            if (!(level > ConfigFile.LOG_LEVEL))
            {
                string line = Timer.GetTimestampPrecision(DateTime.Now);
                if (!(level >= 0 && level <= 6))
                    level = 1;
                for (int x = 0; x < level; x++)
                {
                    line = line + "    ";
                }
                line = line + text;
                Console.WriteLine(line);
                using (StreamWriter StrWr = File.AppendText(FileNameStream))
                {
                    StrWr.WriteLine(line);
                    StrWr.Close();
                }
            }
        }
        /// <summary>
        /// scrive su un file definito dal richiamante con possibilità di aggiungere il timestamp
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <param name="timestamp"></param>
        public static void PrintF(string fileName, string text, bool timestamp = false)
        {
            string line = (timestamp ? (Timer.GetTimestampPrecision(DateTime.Now) + "    ") : "") +
                        text;
            FileInfo file = new FileInfo(fileName);
            DirectoryInfo dir = new DirectoryInfo(file.DirectoryName);
            if (dir.Exists)
                using (StreamWriter StrWr = File.AppendText(fileName))
                {
                    StrWr.WriteLine(line);
                    StrWr.Close();
                }
        }
    }
}

