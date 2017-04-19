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
                    InsertPlayerDataInDB(actualPlayer);
                }
            }
            return true;
        }


        public static bool InsertPlayerDataInDB(PlayerStatT actualPlayer)
        {
            //SQL SIDE
            //using (SqlConnection con = new SqlConnection("Data Source=" + ConfigFile.DB_NAME +
            //                                             ";Initial Catalog=" + ConfigFile.TABLE_NAME +
            //                                             ";" + ConfigFile.DB_CREDENTIALS))
            using (SqlConnection con = new SqlConnection("Data Source=WEPLUS19\\SQLEXPRESS;Initial Catalog=LEAD_DATA;Integrated Security=SSPI"))

            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO SEASONED VALUES(@season, @type, @name, @rank, @w, @l, @wlr, @k, @d, @kdr, @played, @avms)", con))
                    {
                        command.Parameters.Add(new SqlParameter("season", (int)actualPlayer.Season));
                        command.Parameters.Add(new SqlParameter("type", (int)actualPlayer.Category));
                        command.Parameters.Add(new SqlParameter("name", actualPlayer.Name));
                        command.Parameters.Add(new SqlParameter("rank", (long)actualPlayer.Rank));
                        command.Parameters.Add(new SqlParameter("w", (int)actualPlayer.Wins));
                        command.Parameters.Add(new SqlParameter("l", (int)actualPlayer.Losses));
                        command.Parameters.Add(new SqlParameter("wlr", (double)actualPlayer.WLr));
                        command.Parameters.Add(new SqlParameter("k", (int)actualPlayer.Kills));
                        command.Parameters.Add(new SqlParameter("d", (int)actualPlayer.Deaths));
                        command.Parameters.Add(new SqlParameter("kdr", (double)actualPlayer.KDr));
                        command.Parameters.Add(new SqlParameter("played", (int)actualPlayer.GamesPlayed));
                        command.Parameters.Add(new SqlParameter("avms", (int)actualPlayer.AvarageMatchScore));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Could not insert.");
                }
            }
            //##############
            return true;
        }


        public static List<PlayerStatT> RetrievePlayerStat(string name)
        {
            List<PlayerStatT> playerFound = new List<PlayerStatT>();
            using (SqlConnection con = new SqlConnection("Data Source=" + ConfigFile.DB_NAME + "\\SQLEXPRESS;Initial Catalog=LEAD_DATA;User Id=general;Password=33333333")) //Integrated Security=SSPI"))
            {
                try
                {
                    int type = 0;
                    using (SqlCommand command = new SqlCommand("SELECT * FROM LEAD_DATA.dbo.SEASONED WHERE pname LIKE @varName ORDER BY season, type", con))
                    {
                        command.Parameters.AddWithValue("@pType", type);
                        command.Parameters.Add(new SqlParameter("@varName", SqlDbType.Text) { Value = name });
                        con.Open();
                        using (SqlDataReader oReader = command.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                PlayerStatT newData = new PlayerStatT();
                                double tempDouble = 0.0;
                                long tempLong = 0;
                                newData.Name = oReader["pname"].ToString();
                                newData.Season = (int)oReader["season"];
                                newData.Category = (int)oReader["type"];
                                newData.AvarageMatchScore = (int)oReader["avms"];
                                newData.Deaths = (int)oReader["d"];
                                newData.Kills = (int)oReader["k"];
                                newData.Wins = (int)oReader["w"];
                                newData.Losses = (int)oReader["l"];
                                newData.GamesPlayed = long.TryParse(oReader["played"].ToString(), out tempLong) ? tempLong : 0;
                                newData.WLr = double.TryParse(oReader["kdr"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.KDr = double.TryParse(oReader["wlr"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.KpM = double.TryParse(oReader["kpm"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.DpM = double.TryParse(oReader["dpm"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                if (newData.Name == name)
                                    playerFound.Add(newData);
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Could not insert.");
                }
            }
            //##############
            return playerFound;
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
                for(int type = 0; type <= 5; type++)
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
                        
                        string text = "S" + orderedList.Last().Season +
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
                                      ";" + orderedList.Last().AvarageMatchScore;
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


    }
}
