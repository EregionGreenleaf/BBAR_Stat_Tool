using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

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


        public static bool WriteToDB(FileInfo fileInfo, int season, int type)
        {
            string line;
            StreamReader file = new StreamReader(fileInfo.FullName);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                PlayerStatT actualPlayer = ParsePlayerStat(line);
                actualPlayer.Season = season;
                actualPlayer.Category = type;
                if(actualPlayer.Rank > 0)
                {
                    SqlOps.InsertPlayerDataInDB(actualPlayer);
                }
            }
            return true;
        }

        //public static List<string> DividePlayerData(string full)
        //{
        //    bool exit = false;
        //    List<string> finalList = new List<string>();
        //    int pos = 0;
        //    int oldPos = 1;
        //    while (!exit)
        //    {
        //        pos = full.IndexOf("\r\n", pos + 4);
        //        if (pos == oldPos)
        //            break;
        //        else
        //            oldPos = pos;
        //        string[] fullPlayerArray = full.Split(';');
        //        string[] singlePlayerArray = fullPlayerArray.Take(1).ToArray();
        //    }
        //    return new List<string>();
        //}

        public static string SearchPlayerData(string full, string name = null)
        {
            string subString = string.Empty;
            string[] arrayString;
            if (name == null)
            {
                int index = full.IndexOf("<tr class=");
                subString = full.Substring(index + 24);
            }
            else
            {
                arrayString = full.Split(';');
                int indexOfName = 0;
                for(int i = 0; i < arrayString.Count(); i++)
                {
                    if (arrayString[i].ToUpper() == name.ToUpper())
                    {
                        indexOfName = i;
                        break;
                    }
                }

                //Il valore esatto è determinato dalla Classe e dal Livello del Personaggio e può essere fisso (per i Maghi e i Ladri) o variabile (per i Guerrieri).
                //Consulta il paragrafo relativo alla Classe del tuo Personaggio nel Capitolo II e sagna il valore sulla Scheda.
                
                if (indexOfName > 0)
                {
                    subString = arrayString[indexOfName - 1].Replace("\r\n", string.Empty) + ";" +
                                arrayString[indexOfName] + ";" +
                                arrayString[indexOfName + 1] + ";" +
                                arrayString[indexOfName + 2] + ";" +
                                arrayString[indexOfName + 3] + ";" +
                                arrayString[indexOfName + 4] + ";" +
                                arrayString[indexOfName + 5] + ";" +
                                arrayString[indexOfName + 6] + ";" +
                                arrayString[indexOfName + 7] + ";" +
                                arrayString[indexOfName + 8] + ";";
                }
            }
            string[] partial = subString.Split(';');
            string[] finalArray = partial.Take(10).ToArray();
            string finalString = string.Join(";",finalArray);
            return finalString;
        }

        public static PlayerStatT ParsePlayerStat(string stat)
        {
            PlayerStatT playerStat = new PlayerStatT();
            string[] partial = stat.Split(';');
            if (partial.Length > 9)
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

        public static FileInfo PlayerDataToFile(List<PlayerStatT> playerDataList)
        {
            List<PlayerStatT> orderedList = new List<PlayerStatT>();
            string seasonStr = ConfigFile.SEASON_LAST < 10 ? "0" + ConfigFile.SEASON_LAST.ToString() : ConfigFile.SEASON_LAST.ToString();
            FileInfo file = new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, playerDataList.First().Name + "_" + seasonStr + ".txt"));
            if (file.Exists)
            {
                FileInfo fileOld = new FileInfo(Path.Combine(Path.GetDirectoryName(file.FullName), Path.GetFileNameWithoutExtension(file.FullName) + "_OLD.txt").ToString());
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
                                        "Player's Data will be appended to the existing one.",
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
                                    "Player's Data will be appended to the existing one.", 
                                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }


            for(int season = 0; season <= ConfigFile.SEASON_LAST; season++) //Should be from Season = 1, not = 0 (0 represent ABSOLUTE stats)
            {
                for(int type = 0; type <= 4; type++)
                {
                    List<PlayerStatT> last = playerDataList.Where(x => x.Season == season && x.Category == type).ToList();
                    if (last.Count != 0)
                    {
                        orderedList.Add(last.Last());
                        string typeStr = null;
                        switch (orderedList.Last().Category)
                        {
                            case 0:
                                typeStr = "GENERAL";
                                break;
                            case 1:
                                typeStr = "LIGHT";
                                break;
                            case 2:
                                typeStr = "MEDIUM";
                                break;
                            case 3:
                                typeStr = "HEAVY";
                                break;
                            case 4:
                                typeStr = "ASSAULT";
                                break;
                        }
                        string text = "S" + season +
                                      "_" + typeStr +
                                      ";" + orderedList.Last().Rank +
                                      ";" + orderedList.Last().Name +
                                      ";" + orderedList.Last().Wins +
                                      ";" + orderedList.Last().Losses +
                                      ";" + orderedList.Last().WLr.ToString().Replace(',', '.') +
                                      ";" + orderedList.Last().Kills +
                                      ";" + orderedList.Last().Deaths +
                                      ";" + orderedList.Last().KDr.ToString().Replace(',', '.') +
                                      ";" + orderedList.Last().GamesPlayed +
                                      ";" + orderedList.Last().AvarageMatchScore +
                                      ";" + orderedList.Last().KpM.ToString().Replace(',', '.') +
                                      ";" + orderedList.Last().DpM.ToString().Replace(',', '.');
                        Logger.PrintF(file.FullName, text, false);
                    }
                    else
                    {
                        string typeStr = null;
                        switch (type)
                        {
                            case 0:
                                typeStr = "GENERAL";
                                break;
                            case 1:
                                typeStr = "LIGHT";
                                break;
                            case 2:
                                typeStr = "MEDIUM";
                                break;
                            case 3:
                                typeStr = "HEAVY";
                                break;
                            case 4:
                                typeStr = "ASSAULT";
                                break;
                        }
                        string text = "S" + season +
                                      "_" + typeStr +
                                      ";0" +
                                      ";" + playerDataList.First().Name +
                                      ";0" +
                                      ";0" +
                                      ";0.0" +
                                      ";0" +
                                      ";0" +
                                      ";0.0" +
                                      ";0" +
                                      ";0" +
                                      ";0.0" +
                                      ";0.0";
                        Logger.PrintF(file.FullName, text, false);
                    }
                }
            }
            return file;
        }


        public static List<PlayerStatT> AddAbsoluteSeason(List<PlayerStatT> playerGlobal, string playerName)
        {
            PlayerStatT globalGeneral = new PlayerStatT();
            PlayerStatT globalLight = new PlayerStatT();
            PlayerStatT globalMedium = new PlayerStatT();
            PlayerStatT globalHeavy = new PlayerStatT();
            PlayerStatT globalAssault = new PlayerStatT();
            List<long> globalListPlayedGeneral = new List<long>();
            List<int> globalListAvMSGeneral = new List<int>();
            List<long> globalListPlayedLight = new List<long>();
            List<int> globalListAvMSLight = new List<int>();
            List<long> globalListPlayedMedium = new List<long>();
            List<int> globalListAvMSMedium = new List<int>();
            List<long> globalListPlayedHeavy = new List<long>();
            List<int> globalListAvMSHeavy = new List<int>();
            List<long> globalListPlayedAssault = new List<long>();
            List<int> globalListAvMSAssault = new List<int>();

            int tempGeneralWins = 0;
            globalGeneral.Initialize();
            globalLight.Initialize();
            globalMedium.Initialize();
            globalHeavy.Initialize();
            globalAssault.Initialize();
            try
            {
                for (int season = 1; season <= ConfigFile.SEASON_LAST; season++)
                {
                    List<PlayerStatT> listAllPlayer = new List<PlayerStatT>();
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).ToList(); ;
                    PlayerStatT actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Wins != null)
                            globalGeneral.Wins += actualPlayer.Wins;
                        if (actualPlayer.Losses != null)
                            globalGeneral.Losses += actualPlayer.Losses;
                        if (actualPlayer.Kills != null)
                            globalGeneral.Kills += actualPlayer.Kills;
                        if (actualPlayer.Deaths != null)
                            globalGeneral.Deaths += actualPlayer.Deaths;
                        if (actualPlayer.GamesPlayed != null)
                            globalListPlayedGeneral.Add((int)actualPlayer.GamesPlayed);
                        else
                            globalListPlayedGeneral.Add(0);
                        if (actualPlayer.AvarageMatchScore != null)
                            globalListAvMSGeneral.Add((int)actualPlayer.AvarageMatchScore);
                        else
                            globalListAvMSGeneral.Add(0);
                    }
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 1).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Wins != null)
                            globalLight.Wins += actualPlayer.Wins;
                        if (actualPlayer.Losses != null)
                            globalLight.Losses += actualPlayer.Losses;
                        if (actualPlayer.Kills != null)
                            globalLight.Kills += actualPlayer.Kills;
                        if (actualPlayer.Deaths != null)
                            globalLight.Deaths += actualPlayer.Deaths;
                        if (actualPlayer.GamesPlayed != null)
                            globalListPlayedLight.Add((long)actualPlayer.GamesPlayed);
                        else
                            globalListPlayedLight.Add(0);
                        if (actualPlayer.AvarageMatchScore != null)
                            globalListAvMSLight.Add((int)actualPlayer.AvarageMatchScore);
                        else
                            globalListAvMSLight.Add(0);
                    }
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 2).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Wins != null)
                            globalMedium.Wins += actualPlayer.Wins;
                        if (actualPlayer.Losses != null)
                            globalMedium.Losses += actualPlayer.Losses;
                        if (actualPlayer.Kills != null)
                            globalMedium.Kills += actualPlayer.Kills;
                        if (actualPlayer.Deaths != null)
                            globalMedium.Deaths += actualPlayer.Deaths;
                        if (actualPlayer.GamesPlayed != null)
                            globalListPlayedMedium.Add((long)actualPlayer.GamesPlayed);
                        else
                            globalListPlayedMedium.Add(0);
                        if (actualPlayer.AvarageMatchScore != null)
                            globalListAvMSMedium.Add((int)actualPlayer.AvarageMatchScore);
                        else
                            globalListAvMSMedium.Add(0);
                    }
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 3).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Wins != null)
                            globalHeavy.Wins += actualPlayer.Wins;
                        if (actualPlayer.Losses != null)
                            globalHeavy.Losses += actualPlayer.Losses;
                        if (actualPlayer.Kills != null)
                            globalHeavy.Kills += actualPlayer.Kills;
                        if (actualPlayer.Deaths != null)
                            globalHeavy.Deaths += actualPlayer.Deaths;
                        if (actualPlayer.GamesPlayed != null)
                            globalListPlayedHeavy.Add((long)actualPlayer.GamesPlayed);
                        else
                            globalListPlayedHeavy.Add(0);
                        if (actualPlayer.AvarageMatchScore != null)
                            globalListAvMSHeavy.Add((int)actualPlayer.AvarageMatchScore);
                        else
                            globalListAvMSHeavy.Add(0);
                    }
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 4).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Wins != null)
                            globalAssault.Wins += actualPlayer.Wins;
                        if (actualPlayer.Losses != null)
                            globalAssault.Losses += actualPlayer.Losses;
                        if (actualPlayer.Kills != null)
                            globalAssault.Kills += actualPlayer.Kills;
                        if (actualPlayer.Deaths != null)
                            globalAssault.Deaths += actualPlayer.Deaths;
                        if (actualPlayer.GamesPlayed != null)
                            globalListPlayedAssault.Add((long)actualPlayer.GamesPlayed);
                        else
                            globalListPlayedAssault.Add(0);
                        if (actualPlayer.AvarageMatchScore != null)
                            globalListAvMSAssault.Add((int)actualPlayer.AvarageMatchScore);
                        else
                            globalListAvMSAssault.Add(0);
                    }
                }

                globalGeneral.WLr = double.IsNaN(Math.Round((double)globalGeneral.Wins / (double)globalGeneral.Losses, 2)) ? 0 : Math.Round((double)globalGeneral.Wins / (double)globalGeneral.Losses, 2);
                globalGeneral.KDr = double.IsNaN(Math.Round((double)globalGeneral.Kills / (double)globalGeneral.Deaths, 2)) ? 0 : Math.Round((double)globalGeneral.Kills / (double)globalGeneral.Deaths, 2);
                globalListPlayedGeneral.ForEach(x => globalGeneral.GamesPlayed += x);
                globalGeneral.AvarageMatchScore = Convert.ToInt32(DataOps.WeightedAvarage(globalListAvMSGeneral, globalListPlayedGeneral));
                globalGeneral.Season = 0;
                globalGeneral.Category = 0;
                globalGeneral.Name = playerName;

                globalLight.WLr = double.IsNaN(Math.Round((double)globalLight.Wins / (double)globalLight.Losses, 2)) ? 0 : Math.Round((double)globalLight.Wins / (double)globalLight.Losses, 2);
                globalLight.KDr = double.IsNaN(Math.Round((double)globalLight.Kills / (double)globalLight.Deaths, 2)) ? 0 : Math.Round((double)globalLight.Kills / (double)globalLight.Deaths, 2);
                globalListPlayedLight.ForEach(x => globalLight.GamesPlayed += x);
                globalLight.AvarageMatchScore = Convert.ToInt32(DataOps.WeightedAvarage(globalListAvMSLight, globalListPlayedLight));
                globalLight.Season = 0;
                globalLight.Category = 1;
                globalLight.Name = playerName;

                globalMedium.WLr = double.IsNaN(Math.Round((double)globalMedium.Wins / (double)globalMedium.Losses, 2)) ? 0 : Math.Round((double)globalMedium.Wins / (double)globalMedium.Losses, 2);
                globalMedium.KDr = double.IsNaN(Math.Round((double)globalMedium.Kills / (double)globalMedium.Deaths, 2)) ? 0 : Math.Round((double)globalMedium.Kills / (double)globalMedium.Deaths, 2);
                globalListPlayedMedium.ForEach(x => globalMedium.GamesPlayed += x);
                globalMedium.AvarageMatchScore = Convert.ToInt32(DataOps.WeightedAvarage(globalListAvMSMedium, globalListPlayedMedium));
                globalMedium.Season = 0;
                globalMedium.Category = 2;
                globalMedium.Name = playerName;

                globalHeavy.WLr = double.IsNaN(Math.Round((double)globalHeavy.Wins / (double)globalHeavy.Losses, 2)) ? 0 : Math.Round((double)globalHeavy.Wins / (double)globalHeavy.Losses, 2);
                globalHeavy.KDr = double.IsNaN(Math.Round((double)globalHeavy.Kills / (double)globalHeavy.Deaths, 2)) ? 0 : Math.Round((double)globalHeavy.Kills / (double)globalHeavy.Deaths, 2);
                globalListPlayedHeavy.ForEach(x => globalHeavy.GamesPlayed += x);
                globalHeavy.AvarageMatchScore = Convert.ToInt32(DataOps.WeightedAvarage(globalListAvMSHeavy, globalListPlayedHeavy));
                globalHeavy.Season = 0;
                globalHeavy.Category = 3;
                globalHeavy.Name = playerName;

                globalAssault.WLr = double.IsNaN(Math.Round((double)globalAssault.Wins / (double)globalAssault.Losses, 2)) ? 0 : Math.Round((double)globalAssault.Wins / (double)globalAssault.Losses, 2);
                globalAssault.KDr = double.IsNaN(Math.Round((double)globalAssault.Kills / (double)globalAssault.Deaths, 2)) ? 0 : Math.Round((double)globalAssault.Kills / (double)globalAssault.Deaths, 2);
                globalListPlayedAssault.ForEach(x => globalAssault.GamesPlayed += x);
                globalAssault.AvarageMatchScore = Convert.ToInt32(DataOps.WeightedAvarage(globalListAvMSAssault, globalListPlayedAssault));
                globalAssault.Season = 0;
                globalAssault.Category = 4;
                globalAssault.Name = playerName;

                playerGlobal.Add(globalGeneral);
                playerGlobal.Add(globalLight);
                playerGlobal.Add(globalMedium);
                playerGlobal.Add(globalHeavy);
                playerGlobal.Add(globalAssault);
            }
            catch(Exception exp)
            {
                return playerGlobal;
            }
            return playerGlobal;
        }



        public static double WeightedAvarage(List<double> a, List<double> b)
        {
            if(a.Count == b.Count)
            {
                double[] aA = a.ToArray();
                double[] aB = b.ToArray();
                double Operand = 0;
                double Operator = 0;
                for(int i = 0; i < a.Count; i++)
                {
                    Operand += aA[i] * aB[i];
                }
                b.ForEach(x => Operator += x);
                if (Operator < 1)
                    return 0.0d;
                else
                    return Operand / Operator;
            }
            return 0.0d;
        }

        public static double WeightedAvarage(List<int> a, List<int> b)
        {
            List<double> dA = new List<double>();
            a.ForEach(x => dA.Add(x));
            List<double> dB = new List<double>();
            b.ForEach(x => dB.Add(x));
            return WeightedAvarage(dA, dB);
        }

        public static double WeightedAvarage(List<int> a, List<long> b)
        {
            List<double> dA = new List<double>();
            a.ForEach(x => dA.Add(x));
            List<double> dB = new List<double>();
            b.ForEach(x => dB.Add(x));
            return WeightedAvarage(dA, dB);
        }

        /// <summary>
        /// Prints data in a RichTextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="sImageText"></param>
        public static void PrintData(RichTextBox textBox, string sImageText /*List<PlayerStatT> playerGlobal*/)
        {
            string final = string.Empty;
            string[] lines = System.IO.File.ReadAllLines(sImageText);
            string[] type = new string[] { "  GENERAL: ", "  LIGHTS:  ", "  MEDIUMS: ", "  HEAVIES: ", "  ASSAULTS:" };
            int counter = 0;
            int season = 0;
            textBox.SelectionFont = new System.Drawing.Font("Courier New", 8f, FontStyle.Bold);
            textBox.AppendText(String.Format("{0,-4} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7} {9,-7} {10,-7}",
                                "  TYPE     ", "WINS", "LOSSES", "W/Lr", "KILLS", "DEATHS", "K/Dr", "GAMES", "AV.MS", "KpM", "DpM") + 
                                Environment.NewLine);
            textBox.SelectionFont = new System.Drawing.Font("Courier New", 8f, FontStyle.Underline | FontStyle.Italic);
            textBox.AppendText("ABSOLUTE:" + Environment.NewLine);
            int index = 0;
            foreach (string line in lines)
            {
                index++;
                string[] result = line.Split(';');
                textBox.SelectionFont = new System.Drawing.Font("Courier New", 8f, FontStyle.Regular);
                textBox.AppendText(String.Format("{0,-4} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7} {9,-7} {10,-7}",
                                type[counter], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10], result[11], result[12]) + 
                                Environment.NewLine);
                counter++;
                if (counter > 4)
                {
                    if (index + 1 <= lines.Count())
                    {
                        counter = 0;
                        season++;
                        if (season < 10)
                        {
                            textBox.SelectionFont = new System.Drawing.Font("Courier New", 8f, FontStyle.Underline | FontStyle.Italic);
                            textBox.AppendText("SEASON 0" + season + ":" + Environment.NewLine);
                        }
                        else
                        {
                            textBox.SelectionFont = new System.Drawing.Font("Courier New", 8f, FontStyle.Underline | FontStyle.Italic);
                            textBox.AppendText("SEASON " + season + ":" + Environment.NewLine);
                        }
                    }
                }
            }
            //textBox.Text.Remove(textBox.Text.TrimEnd().LastIndexOf(Environment.NewLine));

            //sImageText = final.Remove(final.TrimEnd().LastIndexOf(Environment.NewLine)); ;

            //for(int season = 0; season <= ConfigFile.SEASON_LAST; season++)
            //{
            //    for(int type = 0; type <= 4; type++)
            //    {
            //        List<PlayerStatT> tempList = new List<PlayerStatT>();
            //        PlayerStatT tempPlayer = new PlayerStatT();
            //        tempList = playerGlobal.Where(x => x.Season == season && x.Category == type).ToList();
            //        if(tempList.Count > 0)
            //        {
            //            tempPlayer.
            //        }
            //    }
            //}
        }


        public static string[] ParseByClass(string[] lines)
        {
            string[] retArray = null;
            List<string> light = new List<string>();
            List<string> medium = new List<string>();
            List<string> heavy = new List<string>();
            List<string> assault = new List<string>();
            List<string> general = new List<string>();
            if (lines.Count() > 0)
            {
                List<string> data = lines.ToList();
                light = data.Where(line => line.Substring(0,13).ToUpper().Contains("_LIGHT")).ToList();
                medium = data.Where(line => line.Substring(0, 13).ToUpper().Contains("_MEDIUM")).ToList();
                heavy = data.Where(line => line.Substring(0, 13).ToUpper().Contains("_HEAVY")).ToList();
                assault = data.Where(line => line.Substring(0, 13).ToUpper().Contains("_ASSAULT")).ToList();
                general = data.Where(line => line.Substring(0, 13).ToUpper().Contains("_GENERAL")).ToList();

            }
            List<string> ret = general;
            ret.AddRange(light);
            ret.AddRange(medium);
            ret.AddRange(heavy);
            ret.AddRange(assault);

            if (lines.Count() == ret.Count)
            {
                retArray = ret.ToArray();
            }
            return retArray;
        }


        public static Section PrintDataByCategory(Section section, string sImageText)
        {
            string final = string.Empty;
            string[] lines = System.IO.File.ReadAllLines(sImageText);
            string[] type = new string[] { "  GENERAL: ", "  LIGHTS:  ", "  MEDIUMS: ", "  HEAVIES: ", "  ASSAULTS:" };
            int counter = 0;
            int season = 0;
            int typeIndex = 0;

            string[] byClass = ParseByClass(lines);


            MigraDoc.DocumentObjectModel.Font font;
            MigraDoc.DocumentObjectModel.Font fontHeader;

            Table table = section.AddTable();
            table.Format.Alignment = ParagraphAlignment.Center;
            table.Style = "Table";
            table.Borders.Visible = false;
            table.Borders.Width = 0.2;
            //table.Borders.Left.Width = 0.2;
            //table.Borders.Right.Width = 0.2;
            table.Rows.LeftIndent = 20;

            // ## COLUMNS FORMAT SECTION
            Column column = table.AddColumn("2.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn("1.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;


            // ## START WRITING ROWS
            // HEADER ROW
            font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
            font.Bold = true;
            font.Italic = false;
            font.Underline = Underline.None;
            Row row = table.AddRow();

            int indexByClass = 0;
            counter = 0;
            // TITLE ROW
            row = table.AddRow();
            row.Format.PageBreakBefore = true;
            row.Cells[0].MergeRight = 10;
            row.Format.Font = new MigraDoc.DocumentObjectModel.Font("Courier New", 14);
            row.Format.Font.Bold = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].AddParagraph("Tables by Weight Class");
            row.Format.Shading.Color = Colors.AliceBlue;
            row.Format.Font.Color = Colors.DarkBlue;
            row.KeepWith = 3;
            row.Table.AddRow();



            int index = 0;


            font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
            font.Bold = true;
            font.Italic = true;
            font.Underline = Underline.Single;
            fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
            fontHeader.Bold = true;
            fontHeader.Italic = true;
            fontHeader.Underline = Underline.None;

            row = table.AddRow();
            row.Shading.Color = Colors.Red;
            row.Format.Font = fontHeader;
            row.Format.Font.Color = Colors.Black;
            row.VerticalAlignment = VerticalAlignment.Center;
            //row.Format.Alignment 
            row.Cells[0].AddParagraph("GENERAL:");
            row.Cells[0].Format.Font = font;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].AddParagraph("WINS");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[2].AddParagraph("LOSSES");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[3].AddParagraph("W/Lr");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[4].AddParagraph("KILLS");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[5].AddParagraph("DEATHS");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[6].AddParagraph("K/Dr");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[7].AddParagraph("GAMES");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[8].AddParagraph("AV.MS");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[9].AddParagraph("KpM");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[10].AddParagraph("DpM");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
            row.KeepWith = ConfigFile.SEASON_LAST > 2 ? ConfigFile.SEASON_LAST * 2 + 2 : ConfigFile.SEASON_LAST - 1;
            foreach (string line in byClass)
            {
                indexByClass++;
                string[] result = line.Split(';');

                //row.Cells[0].Shading.Color;
                MigraDoc.DocumentObjectModel.Color color = indexByClass % 2 != 0 ? Colors.LightGray : Colors.WhiteSmoke;

                // HEADER ROW
                font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                font.Bold = false;
                font.Italic = false;
                font.Underline = Underline.None;
                row = table.AddRow();
                row.Format.Font = font;
                row.Format.Alignment = ParagraphAlignment.Right;
                row.Shading.Color = color;
                row.Cells[0].AddParagraph(counter == 0 ? "ABSOLUTE" : counter < 10 ? "SEASON 0" + (counter).ToString() : "SEASON " + (counter).ToString());
                row.Cells[1].AddParagraph(result[3]);
                row.Cells[2].AddParagraph(result[4]);
                row.Cells[3].AddParagraph(result[5]);
                row.Cells[4].AddParagraph(result[6]);
                row.Cells[5].AddParagraph(result[7]);
                row.Cells[6].AddParagraph(result[8]);
                row.Cells[7].AddParagraph(result[9]);
                row.Cells[8].AddParagraph(result[10]);
                row.Cells[9].AddParagraph(result[11]);
                row.Cells[10].AddParagraph(result[12]);


                //font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                //font.Bold = false;
                //font.Italic = false;
                //font.Underline = Underline.None;
                //paragraph = section.AddParagraph();
                //paragraph.AddFormattedText(String.Format("{0,-4} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7} {9,-7} {10,-7}",
                //                type[counter], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10], result[11], result[12]) +
                //                Environment.NewLine, font);
                counter++;
                if (counter > ConfigFile.SEASON_LAST)
                {
                    if (indexByClass + 1 <= lines.Count())
                    {
                        string imageType = string.Empty;
                        switch (typeIndex)
                        {
                            case 1:
                                imageType = "Light.png";
                                break;
                            case 2:
                                imageType = "Medium.png";
                                break;
                            case 3:
                                imageType = "Heavy.png";
                                break;
                            case 4:
                                imageType = "Assault.png";
                                break;
                        }
                        //MigraDoc.DocumentObjectModel.Shapes.Image image = new MigraDoc.DocumentObjectModel.Shapes.Image();
                        if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, imageType)).Exists)
                        {
                            row.KeepWith = 1;
                            row = table.AddRow();
                            row.Cells[0].MergeRight = 10;
                            row.Cells[0].AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, imageType));
                            //image = section.AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"));
                            //image.Width = "18cm";
                            //image.LockAspectRatio = true;
                            //image.Left = MigraDoc.DocumentObjectModel.Shapes.ShapePosition.Center;
                            //image.LineFormat.Visible = true;
                            //image.LineFormat.Width = 1;
                            //image.LineFormat.Color = Colors.LightBlue;
                        }

                        counter = 0;
                        typeIndex++;
                        row = table.AddRow();
                        font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                        font.Bold = true;
                        font.Italic = true;
                        font.Underline = Underline.Single;
                        fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
                        fontHeader.Bold = true;
                        fontHeader.Italic = true;
                        fontHeader.Underline = Underline.None;

                        row = table.AddRow();
                        row.Shading.Color = Colors.Black;
                        row.Format.Font = fontHeader;
                        row.Format.Font.Color = Colors.WhiteSmoke;
                        row.VerticalAlignment = VerticalAlignment.Center;
                        //row.Format.Alignment 
                        row.Cells[0].AddParagraph(type[typeIndex]);

                        row.Cells[0].Format.Font = font;
                        row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                        row.Cells[1].AddParagraph("WINS");
                        row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[2].AddParagraph("LOSSES");
                        row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[3].AddParagraph("W/Lr");
                        row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[4].AddParagraph("KILLS");
                        row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[5].AddParagraph("DEATHS");
                        row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[6].AddParagraph("K/Dr");
                        row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[7].AddParagraph("GAMES");
                        row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[8].AddParagraph("AV.MS");
                        row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[9].AddParagraph("KpM");
                        row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                        row.Cells[10].AddParagraph("DpM");
                        row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                        row.KeepWith = ConfigFile.SEASON_LAST + 1;
                    }
                }
            }
            if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png")).Exists)
            {
                row.KeepWith = 1;
                row = table.AddRow();
                row.Cells[0].MergeRight = 10;
                row.Cells[0].AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png"));
            }

            return section;
        }

        /// <summary>
        /// Prints data in a PDF section
        /// </summary>
        /// <param name="section"></param>
        /// <param name="sImageText"></param>
        /// <returns></returns>
        public static Section PrintDataSeason(Section section, string sImageText)
        {
            try
            {
                MigraDoc.DocumentObjectModel.Font font;
                MigraDoc.DocumentObjectModel.Font fontHeader;

                Table table = section.AddTable();
                table.Format.Alignment = ParagraphAlignment.Center;
                table.Style = "Table";
                table.Borders.Visible = false;
                table.Borders.Width = 0.2;
                //table.Borders.Left.Width = 0.2;
                //table.Borders.Right.Width = 0.2;
                table.Rows.LeftIndent = 20;

                // ## COLUMNS FORMAT SECTION
                Column column = table.AddColumn("2.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("1.5cm");
                column.Format.Alignment = ParagraphAlignment.Right;


                // ## START WRITING ROWS
                // HEADER ROW
                font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                font.Bold = true;
                font.Italic = false;
                font.Underline = Underline.None;
                Row row = table.AddRow();

                // TITLE ROW
                row = table.AddRow();
                row.Cells[0].MergeRight = 10;
                row.Format.Font = new MigraDoc.DocumentObjectModel.Font("Courier New", 14);
                row.Format.Font.Bold = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Tables by Season");
                row.Format.Shading.Color = Colors.AliceBlue;
                row.Format.Font.Color = Colors.DarkBlue;
                row.KeepWith = 3;
                row.Table.AddRow();


                // ROWS
                font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                font.Bold = true;
                font.Italic = true;
                font.Underline = Underline.Single;
                fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
                fontHeader.Bold = true;
                fontHeader.Italic = true;
                fontHeader.Underline = Underline.None;

                row = table.AddRow();
                row.Shading.Color = Colors.Red;
                row.Format.Font = fontHeader;
                row.Format.Font.Color = Colors.Black;
                row.VerticalAlignment = VerticalAlignment.Center;
                //row.Format.Alignment 
                row.Cells[0].AddParagraph("ABSOLUTE:");
                row.Cells[0].Format.Font = font;
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].AddParagraph("WINS");
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[2].AddParagraph("LOSSES");
                row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[3].AddParagraph("W/Lr");
                row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[4].AddParagraph("KILLS");
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[5].AddParagraph("DEATHS");
                row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[6].AddParagraph("K/Dr");
                row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[7].AddParagraph("GAMES");
                row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[8].AddParagraph("AV.MS");
                row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[9].AddParagraph("KpM");
                row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[10].AddParagraph("DpM");
                row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                row.KeepWith = 4;



                string final = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(sImageText);
                string[] type = new string[] { "  GENERAL: ", "  LIGHTS:  ", "  MEDIUMS: ", "  HEAVIES: ", "  ASSAULTS:" };
                int counter = 0;
                int season = 0;
                int typeIndex = 0;

                string[] byClass = ParseByClass(lines);

                int index = 0;
                foreach (string line in lines)
                {
                    index++;
                    string[] result = line.Split(';');

                    //row.Cells[0].Shading.Color;
                    MigraDoc.DocumentObjectModel.Color color = index % 2 != 0 ? Colors.LightGray : Colors.WhiteSmoke;

                    // HEADER ROW
                    font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                    font.Bold = false;
                    font.Italic = false;
                    font.Underline = Underline.None;
                    row = table.AddRow();
                    row.Format.Font = font;
                    row.Format.Alignment = ParagraphAlignment.Right;
                    row.Shading.Color = color;
                    row.Cells[0].AddParagraph(type[counter].ToString());
                    row.Cells[1].AddParagraph(result[3]);
                    row.Cells[2].AddParagraph(result[4]);
                    row.Cells[3].AddParagraph(result[5]);
                    row.Cells[4].AddParagraph(result[6]);
                    row.Cells[5].AddParagraph(result[7]);
                    row.Cells[6].AddParagraph(result[8]);
                    row.Cells[7].AddParagraph(result[9]);
                    row.Cells[8].AddParagraph(result[10]);
                    row.Cells[9].AddParagraph(result[11]);
                    row.Cells[10].AddParagraph(result[12]);

                    counter++;
                    if (counter > 4)
                    {
                        if (index + 1 <= lines.Count())
                        {
                            counter = 0;
                            season++;
                            row = table.AddRow();
                            font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                            font.Bold = true;
                            font.Italic = true;
                            font.Underline = Underline.Single;
                            fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
                            fontHeader.Bold = true;
                            fontHeader.Italic = true;
                            fontHeader.Underline = Underline.None;

                            row = table.AddRow();
                            row.Shading.Color = Colors.Black;
                            row.Format.Font = fontHeader;
                            row.Format.Font.Color = Colors.WhiteSmoke;
                            row.VerticalAlignment = VerticalAlignment.Center;
                            //row.Format.Alignment 
                            row.Cells[0].AddParagraph(season < 10 ? "SEASON 0" + season + ":" : "SEASON " + season + ":");
                            row.Cells[0].Format.Font = font;
                            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                            row.Cells[1].AddParagraph("WINS");
                            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[2].AddParagraph("LOSSES");
                            row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[3].AddParagraph("W/Lr");
                            row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[4].AddParagraph("KILLS");
                            row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[5].AddParagraph("DEATHS");
                            row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[6].AddParagraph("K/Dr");
                            row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[7].AddParagraph("GAMES");
                            row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[8].AddParagraph("AV.MS");
                            row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[9].AddParagraph("KpM");
                            row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                            row.Cells[10].AddParagraph("DpM");
                            row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                            row.KeepWith = 5;

                        }
                    }
                }


                // ByClass Section
                //section.AddPageBreak();
                row = table.AddRow();
                row = table.AddRow();


                //int indexByClass = 0;
                //counter = 0;
                //// TITLE ROW
                //row = table.AddRow();
                //row.Format.PageBreakBefore = true;
                //row.Cells[0].MergeRight = 10;
                //row.Format.Font = new MigraDoc.DocumentObjectModel.Font("Courier New", 14);
                //row.Format.Font.Bold = true;
                //row.Format.Alignment = ParagraphAlignment.Center;
                //row.Cells[0].AddParagraph("Tables by Weight Class");
                //row.Format.Shading.Color = Colors.AliceBlue;
                //row.Format.Font.Color = Colors.DarkBlue;
                //row.KeepWith = 3;
                //row.Table.AddRow();

                //font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                //font.Bold = true;
                //font.Italic = true;
                //font.Underline = Underline.Single;
                //fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
                //fontHeader.Bold = true;
                //fontHeader.Italic = true;
                //fontHeader.Underline = Underline.None;

                //row = table.AddRow();
                //row.Shading.Color = Colors.Red;
                //row.Format.Font = fontHeader;
                //row.Format.Font.Color = Colors.Black;
                //row.VerticalAlignment = VerticalAlignment.Center;
                ////row.Format.Alignment 
                //row.Cells[0].AddParagraph("GENERAL:");
                //row.Cells[0].Format.Font = font;
                //row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                //row.Cells[1].AddParagraph("WINS");
                //row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[2].AddParagraph("LOSSES");
                //row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[3].AddParagraph("W/Lr");
                //row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[4].AddParagraph("KILLS");
                //row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[5].AddParagraph("DEATHS");
                //row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[6].AddParagraph("K/Dr");
                //row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[7].AddParagraph("GAMES");
                //row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[8].AddParagraph("AV.MS");
                //row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[9].AddParagraph("KpM");
                //row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                //row.Cells[10].AddParagraph("DpM");
                //row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                //row.KeepWith = ConfigFile.SEASON_LAST > 2 ? ConfigFile.SEASON_LAST * 2 + 2 : ConfigFile.SEASON_LAST - 1;
                //foreach (string line in byClass)
                //{
                //    indexByClass++;
                //    string[] result = line.Split(';');

                //    //row.Cells[0].Shading.Color;
                //    MigraDoc.DocumentObjectModel.Color color = indexByClass % 2 != 0 ? Colors.LightGray : Colors.WhiteSmoke;

                //    // HEADER ROW
                //    font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                //    font.Bold = false;
                //    font.Italic = false;
                //    font.Underline = Underline.None;
                //    row = table.AddRow();
                //    row.Format.Font = font;
                //    row.Format.Alignment = ParagraphAlignment.Right;
                //    row.Shading.Color = color;
                //    row.Cells[0].AddParagraph(counter == 0 ? "ABSOLUTE" : counter < 10 ? "SEASON 0" + (counter).ToString() : "SEASON " + (counter).ToString());
                //    row.Cells[1].AddParagraph(result[3]);
                //    row.Cells[2].AddParagraph(result[4]);
                //    row.Cells[3].AddParagraph(result[5]);
                //    row.Cells[4].AddParagraph(result[6]);
                //    row.Cells[5].AddParagraph(result[7]);
                //    row.Cells[6].AddParagraph(result[8]);
                //    row.Cells[7].AddParagraph(result[9]);
                //    row.Cells[8].AddParagraph(result[10]);
                //    row.Cells[9].AddParagraph(result[11]);
                //    row.Cells[10].AddParagraph(result[12]);


                //    //font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                //    //font.Bold = false;
                //    //font.Italic = false;
                //    //font.Underline = Underline.None;
                //    //paragraph = section.AddParagraph();
                //    //paragraph.AddFormattedText(String.Format("{0,-4} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7} {9,-7} {10,-7}",
                //    //                type[counter], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10], result[11], result[12]) +
                //    //                Environment.NewLine, font);
                //    counter++;
                //    if (counter > ConfigFile.SEASON_LAST)
                //    {
                //        if (indexByClass + 1 <= lines.Count())
                //        {
                //            string imageType = string.Empty;
                //            switch (typeIndex)
                //            {
                //                case 1:
                //                    imageType = "Light.png";
                //                    break;
                //                case 2:
                //                    imageType = "Medium.png";
                //                    break;
                //                case 3:
                //                    imageType = "Heavy.png";
                //                    break;
                //                case 4:
                //                    imageType = "Assault.png";
                //                    break;
                //            }
                //            //MigraDoc.DocumentObjectModel.Shapes.Image image = new MigraDoc.DocumentObjectModel.Shapes.Image();
                //            if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, imageType)).Exists)
                //            {
                //                row.KeepWith = 1;
                //                row = table.AddRow();
                //                row.Cells[0].MergeRight = 10;
                //                row.Cells[0].AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, imageType));
                //                //image = section.AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"));
                //                //image.Width = "18cm";
                //                //image.LockAspectRatio = true;
                //                //image.Left = MigraDoc.DocumentObjectModel.Shapes.ShapePosition.Center;
                //                //image.LineFormat.Visible = true;
                //                //image.LineFormat.Width = 1;
                //                //image.LineFormat.Color = Colors.LightBlue;
                //            }

                //            counter = 0;
                //            typeIndex++;
                //            row = table.AddRow();
                //            font = new MigraDoc.DocumentObjectModel.Font("Courier New", 9);
                //            font.Bold = true;
                //            font.Italic = true;
                //            font.Underline = Underline.Single;
                //            fontHeader = new MigraDoc.DocumentObjectModel.Font("Courier New", 8);
                //            fontHeader.Bold = true;
                //            fontHeader.Italic = true;
                //            fontHeader.Underline = Underline.None;

                //            row = table.AddRow();
                //            row.Shading.Color = Colors.Black;
                //            row.Format.Font = fontHeader;
                //            row.Format.Font.Color = Colors.WhiteSmoke;
                //            row.VerticalAlignment = VerticalAlignment.Center;
                //            //row.Format.Alignment 
                //            row.Cells[0].AddParagraph(type[typeIndex]);

                //            row.Cells[0].Format.Font = font;
                //            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                //            row.Cells[1].AddParagraph("WINS");
                //            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[2].AddParagraph("LOSSES");
                //            row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[3].AddParagraph("W/Lr");
                //            row.Cells[3].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[4].AddParagraph("KILLS");
                //            row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[5].AddParagraph("DEATHS");
                //            row.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[6].AddParagraph("K/Dr");
                //            row.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[7].AddParagraph("GAMES");
                //            row.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[8].AddParagraph("AV.MS");
                //            row.Cells[8].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[9].AddParagraph("KpM");
                //            row.Cells[9].Format.Alignment = ParagraphAlignment.Right;
                //            row.Cells[10].AddParagraph("DpM");
                //            row.Cells[10].Format.Alignment = ParagraphAlignment.Right;
                //            row.KeepWith = ConfigFile.SEASON_LAST + 1;
                //        }
                //    }
                //}
                //if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png")).Exists)
                //{
                //    row.KeepWith = 1;
                //    row = table.AddRow();
                //    row.Cells[0].MergeRight = 10;
                //    row.Cells[0].AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png"));
                //}

            }
            catch (Exception exp)
            {
                Logger.PrintC(exp.Message);
            }

            return section;
        }


        public static List<PlayerStatT> PopulateKDpM(List<PlayerStatT> playerGlobal)
        {
            foreach(PlayerStatT player in playerGlobal)
            {
                try
                {
                    if (player.Deaths > 0 && player.GamesPlayed > 0)
                    {
                        if(player.DpM == 0 || player.DpM == null)
                            player.DpM = Math.Round((double)(player.Deaths / (double)player.GamesPlayed),2);
                    }
                    if (player.Kills > 0 && player.GamesPlayed > 0)
                    {
                        if(player.KpM == 0 || player.KpM == null)
                            player.KpM = Math.Round((double)(player.Kills / (double)player.GamesPlayed), 2);
                    }
                }
                catch (Exception exp)
                {
                }
            }
            return playerGlobal;
        }

    }
}
