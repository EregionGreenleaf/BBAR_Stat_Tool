//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    class WebOps
    {
        /// <summary>
        /// Download the entire HTML code of a page.
        /// </summary>
        /// <param name="theURL"></param>
        /// <returns></returns>
        public static string downloadWebPage(string theURL)
        {
            //### download a web page to a string
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead(theURL);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            return s;
        }

        //public static async Task DoWorkSeason(int[][] seasonArray, int type, string playerName)
        //{
        //    await Task.WhenAll(seasonArray.Select((i,y) => new { WebOps.SearchPlayer(playerName, new List<int> { 1 }, new List<int> { i }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS)), });
        //    return;
        //}

        //public static async Task DoWorkType(int[] typeArray, int season, string playerName)
        //{
        //    await Task.WhenAll(typeArray.Select(i => WebOps.SearchPlayer(playerName, new List<int> { season }, new List<int> { i }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS)).ToArray());
        //    return;
        //}

        public static async Task<double> TestSpeed()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;
            ConfigFile.IncrementTaskStarted();
            double test = 0;
            int season = 1;
            string BaseAddress = "https://mwomercs.com/do/login";
            var cookieContainer = new CookieContainer();
            Uri uri = new Uri("https://mwomercs.com/profile/leaderboards");
            var handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;
            handler.CookieContainer.Add(uri, new System.Net.Cookie("leaderboard_season", season.ToString()));
            using (var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                HttpResponseMessage risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                            new[]
                            {
                                    new KeyValuePair<string,string> ("email", ConfigFile.DEFAULT_USER),
                                    new KeyValuePair<string,string> ("password", ConfigFile.DEFAULT_PASS)
                            })
                        );
                string responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                string resp = null;
                int lastPage = 0;
                DirectoryInfo outputDir = new DirectoryInfo(ConfigFile.APP_PATH + "\\Output");
                if (!outputDir.Exists)
                {
                    Directory.CreateDirectory(outputDir.FullName);
                }
                FileInfo testSpeed = new FileInfo(Path.Combine(outputDir.FullName, "TestSpeed.txt"));
                if (testSpeed.Exists)
                {
                    testSpeed.IsReadOnly = false;
                    try
                    {
                        testSpeed.Delete();
                    }
                    catch
                    {

                    }
                }
                Timer.SetFirstTime(DateTime.Now);
                for (int page = 0; page < 10; page++)
                {
                    string ownRank = "<tr class=\"yourRankRow\">";
                    string endPages = "<td colspan='10'>No results found";
                    string address = "https://mwomercs.com/profile/leaderboards?page=" + page.ToString() + "&type=0";
                    risposta = await client.GetAsync(address);
                    responseBodyAsText = risposta.Content.ReadAsStringAsync().Result;
                    resp = DataOps.ParseHTML(responseBodyAsText);
                    string statString = DataOps.SearchPlayerData(resp);
                    resp = DataOps.ParseHTML(responseBodyAsText);
                    if (resp.Contains(ownRank))
                        resp = resp.Replace(ownRank, string.Empty);

                    if (resp.Contains(endPages))
                    {
                        lastPage = page;
                        resp = resp.Replace(endPages, string.Empty);
                        Logger.PrintF(Path.Combine(testSpeed.FullName, "TestSpeed.txt"), resp, false);
                        break;
                    }
                    Logger.PrintF(testSpeed.FullName, resp, false);
                }
                Timer.SetSecondTime(DateTime.Now);
            }
            ConfigFile.IncrementTaskFinished();
            return Timer.GetTimeLapseTotalMilliseconds(Timer.GetFirstTime(), Timer.GetSecondTime()); ;
        }

        public static async Task<PlayerStatT> SearchPlayer(string playerName, List<int> seasons, List<int> category, string email, string password)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;
            ConfigFile.IncrementTaskStarted();
            string fileNameA = playerName + ".txt";
            FileInfo fileName = new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, fileNameA));

            List<PlayerStatT> ThisPlayer = new List<PlayerStatT>();
            foreach (int thisSeason in seasons)
            {

                int season = thisSeason - 1;
                string BaseAddress = "https://mwomercs.com/do/login";
                var cookieContainer = new CookieContainer();
                Uri uri = new Uri("https://mwomercs.com/profile/leaderboards");
                var handler = new HttpClientHandler();
                handler.CookieContainer = cookieContainer;
                handler.CookieContainer.Add(uri, new System.Net.Cookie("leaderboard_season", season.ToString()));
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) })
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                    HttpResponseMessage risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                                new[]
                                {
                                    new KeyValuePair<string,string> ("email", email),
                                    new KeyValuePair<string,string> ("password", password)
                                })
                            );
                    string responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                    string resp = null;
                    int lastPage = 0;
                    foreach (int thisCategory in category)
                    {
                        string address = "https://mwomercs.com/profile/leaderboards?type=" + thisCategory.ToString() + "&user=" + playerName;
                        risposta = await client.GetAsync(address);
                        responseBodyAsText = risposta.Content.ReadAsStringAsync().Result;
                        resp = DataOps.ParseHTML(responseBodyAsText);
                        string statString = DataOps.SearchPlayerData(resp);
                        PlayerStatT actualPlayerStat = DataOps.ParsePlayerStat(statString);
                        actualPlayerStat.Season = thisSeason;
                        actualPlayerStat.Category = thisCategory;
                        actualPlayerStat.WebPage = -666;
                        actualPlayerStat.WebAddress = address;

                        ConfigFile._Global.WaitOne();
                        ConfigFile.GLOBAL_PLAYER.Add(actualPlayerStat);
                        ConfigFile._Global.Release();
                    }
                }
            }
            ConfigFile.IncrementTaskFinished();
            return new PlayerStatT();
        }

        public static async Task<int> CheckCredentials(string email, string password)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                    | SecurityProtocolType.Tls11
                                    | SecurityProtocolType.Tls12
                                    | SecurityProtocolType.Ssl3;
            ConfigFile.IncrementTaskStarted();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    ConfigFile.IncrementTaskFinished();
                    return 1;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    ConfigFile.IncrementTaskFinished();
                    return 2;
                }
            }
            try
            {
                string BaseAddress = "https://mwomercs.com/do/login";
                var cookieContainer = new CookieContainer();
                Uri uri = new Uri("https://mwomercs.com/profile/leaderboards");
                var handler = new HttpClientHandler();
                handler.CookieContainer = cookieContainer;
                handler.CookieContainer.Add(uri, new System.Net.Cookie("leaderboard_season", "1"));
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) })
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                    HttpResponseMessage risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                            new[]
                            {
                            new KeyValuePair<string,string> ("email", email),
                            new KeyValuePair<string,string> ("password", password)
                            })
                        );
                    string responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                    if (responseBodyAsText.Contains("<title>MWO: Login</title>"))
                    {
                        ConfigFile.IncrementTaskFinished();
                        return 3;
                    }
                    else
                    {
                        ConfigFile.IncrementTaskFinished();
                        return 4;
                    }
                }
            }
            catch
            {
                ConfigFile.IncrementTaskFinished();
                return 5;
            }
        }

        /// <summary>
        /// Downloads all data inside a range determined by
        /// parameters.
        /// </summary>
        /// <param name="season"></param>
        /// <param name="type"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="startPage"></param>
        /// <param name="finishPage"></param>
        /// <param name="taskNumber"></param>
        /// <param name="dData"></param>
        /// <param name="bar"></param>
        /// <param name="writeDB"></param>
        public static async void LoginAndDownload(int? season = null, int? type = null, string email = null, 
                                                  string password = null, int? startPage = null, int? finishPage = null, 
                                                  int? taskNumber = null, DownloadData dData = null, ProgressBar bar = null,
                                                  bool writeDB = false)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;
            ConfigFile.IncrementTaskStarted();
            if (dData != null)
            {
                if (dData.Season != null && season == null)
                    season = dData.Season;
                if (dData.Type != null && type == null)
                    type = dData.Type;
                if (dData.User != null && email == null)
                    email = dData.User;
                if (dData.Password != null && password == null)
                    password = dData.Password;
                if (dData.StartPage != null && startPage == null)
                    startPage = dData.StartPage;
                if (dData.EndPage != null && finishPage == null)
                    finishPage = dData.EndPage;
                if (dData.TaskNumber != null && taskNumber == null)
                    taskNumber = dData.TaskNumber;
            }
            if (string.IsNullOrWhiteSpace(email))
                email = ConfigFile.DEFAULT_USER;
            if (string.IsNullOrWhiteSpace(password))
                password = ConfigFile.DEFAULT_PASS;
            if (season == null)
                season = 1;
            if (type == null)
                type = 0;
            if (startPage == null)
                startPage = ConfigFile.MIN_PAGES;
            if (finishPage == null)
                finishPage = ConfigFile.MAX_PAGES;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if(string.IsNullOrWhiteSpace(email))
                    Mex.AddMessage("Task " + (taskNumber != null ? taskNumber : 0) + " is missing the user email. Skipping", Mex.ERROR);
                if(string.IsNullOrWhiteSpace(password))
                    Mex.AddMessage("Task " + (taskNumber != null ? taskNumber : 0) + " is missing the user password. Skipping", Mex.ERROR);
                Mex.PrintErrorMessagesInForm();
                Mex.RemoveAll();
                return;
            }
            // END VALIDATION SECTION

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
            string fileName;
            if (season<10)
                fileName = "S0" + season + "_" + typeStr + ".txt";
            else
                fileName = "S" + season + "_" + typeStr + ".txt";

            //string DirDestination = @"C:\TEST\Output\";
            string DirDestination = ConfigFile.DIRECTORY_OUTPUT.FullName;

            FileInfo fileOutput = new FileInfo(Path.Combine(DirDestination, fileName));
            FileOps.CheckFile(fileOutput);

            season = season - 1; //adjust to 'base 0' web request
            finishPage += 1; //adjust to include last page
            string BaseAddress = "https://mwomercs.com/do/login";
            var cookieContainer = new CookieContainer();
            Uri uri = new Uri("https://mwomercs.com/profile/leaderboards");
            var handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;
            handler.CookieContainer.Add(uri, new System.Net.Cookie("leaderboard_season", season.ToString()));
            using (var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
                HttpResponseMessage risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                        new[]
                        {
                            new KeyValuePair<string,string> ("email", email),
                            new KeyValuePair<string,string> ("password", password)
                        })
                    );
                string responseBodyAsText = await risposta.Content.ReadAsStringAsync();

                Logger.PrintF(new FileInfo(Path.Combine(DirDestination, fileName)).FullName, "** STARTING DOWNLOAD", true);
                string ownRank = "<tr class=\"yourRankRow\">";
                string endPages = "<td colspan='10'>No results found";
                string resp = null;
                int lastPage = 0;
                int startPageReal = (startPage == null ? 0 : (int)startPage);
                int finishPageReal = (finishPage == null ? 10000 : (int)finishPage);
                bar.Maximum = finishPageReal - startPageReal;
                bar.Value = 0;
                for (int page = startPageReal; page < finishPageReal; page++)
                {
                    risposta = await client.GetAsync("https://mwomercs.com/profile/leaderboards?page=" + page.ToString() +"&type=" + type.ToString());
                    responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                    resp = DataOps.ParseHTML(responseBodyAsText);
                    if (resp.Contains(ownRank))
                        resp = resp.Replace(ownRank, string.Empty);

                    if (resp.Contains(endPages))
                    {
                        lastPage = page;
                        resp = resp.Replace(endPages, string.Empty);
                        Logger.PrintF(Path.Combine(DirDestination, fileName), resp, false);
                        if (bar != null)
                        {
                            bar.Value = bar.Maximum;
                        }
                        break;
                    }
                    Logger.PrintF(Path.Combine(DirDestination, fileName), resp, false);
                    if(bar != null)
                    {
                        bar.Value++;
                    }
                }
                Logger.PrintF(Path.Combine(DirDestination, fileName), "** FINISH DOWNLOADING", true);
            }
            if (writeDB)
            {
                //DataOps.WriteToDB(new FileInfo(Path.Combine(DirDestination, fileName).ToString()), (int)season + 1, (int)type);
            }
            ConfigFile.IncrementTaskFinished();
        }
        
        /// <summary>
        /// Searches for the last Season available to operate on.
        /// </summary>
        /// <returns></returns>
        public static async Task FindLastSeason()
        {
            ConfigFile.IncrementTaskStarted();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                    | SecurityProtocolType.Tls11
                                    | SecurityProtocolType.Tls12
                                    | SecurityProtocolType.Ssl3;
            List<int> seasonZ = new List<int>();
            int? type = 0;
            string email = "eregiongreenleafthegray@yahoo.it";
            string password = "chupa33";
            string lastResp = string.Empty;
            int lastSeason = 0;
            try
            {
                for (int seasonIndex = 8; seasonIndex < 200; seasonIndex++)
                {
                    string BaseAddress = "https://mwomercs.com/do/login";
                    var cookieContainer = new CookieContainer();
                    Uri uri = new Uri("https://mwomercs.com/profile/leaderboards");
                    var handler = new HttpClientHandler();
                    handler.CookieContainer = cookieContainer;
                    handler.CookieContainer.Add(uri, new System.Net.Cookie("leaderboard_season", seasonIndex.ToString()));
                    using (var client = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) })
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                        HttpResponseMessage risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                                new[]
                                {
                        new KeyValuePair<string,string> ("email", email),
                        new KeyValuePair<string,string> ("password", password)
                                })
                            );
                        string responseBodyAsText = await risposta.Content.ReadAsStringAsync();

                        string resp = null;
                        risposta = await client.GetAsync("https://mwomercs.com/profile/leaderboards?page=1" + "&type=" + type.ToString());
                        responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                        resp = DataOps.ParseHTML(responseBodyAsText);
                        if (resp != lastResp)
                        {
                            lastResp = resp;
                            lastSeason = seasonIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                lastSeason = 0;
                ConfigFile.LAST_SEASON_CHECKED = false;
            }
            if (lastSeason != 0)
            {
                ConfigFile.SEASON_LAST = lastSeason;
                ConfigFile.LAST_SEASON_CHECKED = true;
            }
            ConfigFile.IncrementTaskFinished();
            return;
        }

        /// <summary>
        /// ** DEPRECATED **
        /// Writes a single line of data on a file
        /// (determined in the ConfigFile)
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool WriteLine(PlayerStatT player)
        {
            string valore = player.Rank + ConfigFile.SEPARATOR +
                            player.Name + ConfigFile.SEPARATOR +
                            player.Wins + ConfigFile.SEPARATOR +
                            player.Losses + ConfigFile.SEPARATOR +
                            player.WLr + ConfigFile.SEPARATOR +
                            player.Kills + ConfigFile.SEPARATOR +
                            player.Deaths + ConfigFile.SEPARATOR +
                            player.KDr + ConfigFile.SEPARATOR +
                            player.GamesPlayed + ConfigFile.SEPARATOR +
                            player.AvarageMatchScore + ConfigFile.SEPARATOR;
            Logger.PrintF(ConfigFile.FILE_OUTPUT, valore, false);
            return true;
        }

    }
}
