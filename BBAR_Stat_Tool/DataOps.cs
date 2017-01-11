using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BBAR_Stat_Tool
{
    class DataOps
    {
        public static string ParseHTML(string html)
        {
            string ret = "<tbody>";

            string to = @"</tbody>";

            int pFrom = html.IndexOf(ret) + ret.Length;
            int pTo = html.IndexOf(to, pFrom);
            int diff = pTo - pFrom;
            string rawData = html.Substring(pFrom, diff);
            string retValue = ParseData(rawData);
            return retValue;
        }

        public static string ParseData(string data)
        {
            string firstPass = data.Replace("<tr>", "");
            string secondPass = firstPass.Replace("<td>", "");
            string thirdPass = secondPass.Replace("</td>", ConfigFile.SEPARATOR);
            string fourthPass = thirdPass.Replace("\r", "");
            string fifthPass = fourthPass.Replace("\n", "");
            string sixthPass = fifthPass.Replace("\t", "");
            string seventhPass = sixthPass.Replace("</tr>", Environment.NewLine);
            string final = seventhPass.Remove(seventhPass.Length-2);
            return final;
        }

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }
}
