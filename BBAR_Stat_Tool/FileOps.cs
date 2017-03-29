using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    public static class FileOps
    {
        public static bool CheckFile (FileInfo file)
        {
            string oldName = Path.GetFileNameWithoutExtension(file.FullName) + "_OLD.txt";
            FileInfo oldNameInfo = new FileInfo(oldName);
            if (file.Exists)
            {
                File.Copy(file.FullName, file.FullName.Replace(file.Name, oldName), true);
                try
                {
                    file.IsReadOnly = false;
                    file.Delete();
                }
                catch
                {
                    Mex.AddMessage("Could not delete file " + file.Name + " in path " + file.FullName.Replace(file.Name, string.Empty) + "." +
                                   Environment.NewLine + "The file could be open. Data will be appended." , Mex.ERROR);
                }
            }
            else
            {
                if (oldNameInfo.Exists)
                {

                }
            }
            return true;
        }
        public static bool CheckFile(string file)
        {
            return CheckFile(new FileInfo(file));
        }
        public static bool CheckFile(string fileName, string dirName)
        {
            return CheckFile(new FileInfo(Path.Combine(dirName, fileName)));
        }
        public static bool CheckFile(string fileName, DirectoryInfo dirInfo)
        {
            return CheckFile(new FileInfo(Path.Combine(dirInfo.FullName, fileName)));
        }
    }
}
