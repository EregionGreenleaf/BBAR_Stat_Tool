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

        public static string SearchPlayerData(string full)
        {
            int index = full.IndexOf("<tr class=");
            string subString = full.Substring(index + 24);
            string[] partial = subString.Split(';');
            string[] finalArray = partial.Take(10).ToArray();
            string finalString = string.Join(";",finalArray);
            return finalString;
        }

        public static PlayerStatT ParsePlayerStat(string stat)
        {
            PlayerStatT playerStat = new PlayerStatT();
            string[] partial = stat.Split(';');
            if (partial.Length == 10)
            {
                int tempI;
                double tempD;
                string tempS;
                playerStat.Rank = int.TryParse(partial[0], out tempI) ? tempI : 0;
                playerStat.Name = partial[1];
                playerStat.Wins = int.TryParse(partial[2], out tempI) ? tempI : 0;
                playerStat.Losses = int.TryParse(partial[3], out tempI) ? tempI : 0;
                playerStat.WLr = double.TryParse(partial[4].Replace('.',','), out tempD) ? tempD : 0.0;
                playerStat.Kills = int.TryParse(partial[5], out tempI) ? tempI : 0;
                playerStat.Deaths = int.TryParse(partial[6], out tempI) ? tempI : 0;
                playerStat.KDr = double.TryParse(partial[7].Replace('.',','), out tempD) ? tempD : 0.0;
                playerStat.GamesPlayed = int.TryParse(partial[8], out tempI) ? tempI : 0;
                playerStat.AvarageMatchScore = int.TryParse(partial[9], out tempI) ? tempI : 0;
            }
            return playerStat;
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
