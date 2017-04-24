using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace BBAR_Stat_Tool
{
    class SqlOps
    {
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
            using (SqlConnection con = new SqlConnection("Data Source=" + ConfigFile.DB_NAME + ";Initial Catalog=LEAD_DATA;User Id=general;Password=33333333")) //Integrated Security=SSPI"))
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
                                newData.Rank = (int)oReader["rank"];
                                newData.AvarageMatchScore = (int)oReader["avms"];
                                newData.Deaths = (int)oReader["d"];
                                newData.Kills = (int)oReader["k"];
                                newData.Wins = (int)oReader["w"];
                                newData.Losses = (int)oReader["l"];
                                newData.GamesPlayed = long.TryParse(oReader["played"].ToString(), out tempLong) ? tempLong : 0;
                                newData.WLr = double.TryParse(oReader["wlr"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.KDr = double.TryParse(oReader["kdr"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.KpM = double.TryParse(oReader["kpm"].ToString(), out tempDouble) ? tempDouble : 0.0;
                                newData.DpM = double.TryParse(oReader["dpm"].ToString(), out tempDouble) ? tempDouble : 0.0;
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
            return playerFound;
        }

    }
}
