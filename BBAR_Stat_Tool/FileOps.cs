using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public static class FileOps
    {
        public static bool CheckFile (FileInfo file, bool pdf = false)
        {

            if (file.Exists)
            {
                FileInfo fileOld = new FileInfo(Path.Combine(Path.GetDirectoryName(file.FullName), Path.GetFileNameWithoutExtension(file.FullName) + (pdf ? "_OLD.pdf" : "_OLD.txt")).ToString());
                if (fileOld.Exists)
                {
                    try
                    {
                        fileOld.Delete();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot delete file: " + file.FullName + "." + Environment.NewLine +
                                        "File could be open or used by another application." + Environment.NewLine +
                                        (pdf ? "Close and try again." : "Player's Data will be appended to the existing one."),
                                        "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
                File.Copy(file.FullName, fileOld.FullName);
                file.IsReadOnly = false;
                try
                {
                    File.Delete(file.FullName);
                }
                catch
                {
                    MessageBox.Show("Cannot delete file: " + file.FullName + "." + Environment.NewLine +
                                    "File could be open or used by another application." + Environment.NewLine +
                                    (pdf ? "Close and try again." : "Player's Data will be appended to the existing one."),
                                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            return true;

            //string oldName = Path.GetFileNameWithoutExtension(file.FullName) + "_OLD.txt";
            //FileInfo oldNameInfo = new FileInfo(oldName);
            //if (file.Exists)
            //{
            //    File.Copy(file.FullName, file.FullName.Replace(file.Name, oldName), true);
            //    try
            //    {
            //        file.IsReadOnly = false;
            //        file.Delete();
            //    }
            //    catch
            //    {
            //        Mex.AddMessage("Could not delete file " + file.Name + " in path " + file.FullName.Replace(file.Name, string.Empty) + "." +
            //                       Environment.NewLine + "The file could be open. Data will be appended." , Mex.ERROR);
            //    }
            //}
            //else
            //{
            //    if (oldNameInfo.Exists)
            //    {

            //    }
            //}
            //return true;
        }
        public static bool CheckFile(string file, bool pdf = false)
        {
            return CheckFile(new FileInfo(file), pdf);
        }
        public static bool CheckFile(string fileName, string dirName, bool pdf = false)
        {
            return CheckFile(new FileInfo(Path.Combine(dirName, fileName)), pdf);
        }
        public static bool CheckFile(string fileName, DirectoryInfo dirInfo, bool pdf = false)
        {
            return CheckFile(new FileInfo(Path.Combine(dirInfo.FullName, fileName)), pdf);
        }
    }
}
