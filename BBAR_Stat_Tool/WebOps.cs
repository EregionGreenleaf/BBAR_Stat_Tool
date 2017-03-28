//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;


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

        public static async Task SearchPlayer(string playerName, List<int> seasons, List<int> category, string email, string password)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;
            List<PlayerStatT> ThisPlayer = new List<PlayerStatT>();
            ConfigFile.GLOBAL_PLAYER = new List<PlayerStatT>();
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
                    HttpResponseMessage risposta = new HttpResponseMessage();
                    try
                    {
                        risposta = await client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                                new[]
                                {
                            new KeyValuePair<string,string> ("email", email),
                            new KeyValuePair<string,string> ("password", password)
                                })
                            );
                    }
                    catch(Exception exp)
                    {
                        Logger.PrintC("Error: " + exp.Message);
                    }
                    string responseBodyAsText = await risposta.Content.ReadAsStringAsync();

                    //Logger.PrintF(DirDestination + fileName, "** STARTING DOWNLOAD", true);
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

                        ConfigFile.GLOBAL_PLAYER.Add(actualPlayerStat);
                    }
                }
            }
        }



        public static async void LoginAndDownload(int? season = null, int? type = null, string email = null, 
                                                  string password = null, int? startPage = null, int? finishPage = null, 
                                                  int? taskNumber = null, DownloadData dData = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;
            // VALIDATION SECTION
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
            if (season == null)
                season = 1;
            if (type == null)
                type = 0;
            if (startPage == null)
                startPage = ConfigFile.START_PAGE;
            if (finishPage == null)
                finishPage = ConfigFile.END_PAGE;
            if (taskNumber == null)
            {
                ConfigFile.ACTUAL_TASK++;
                taskNumber = ConfigFile.ACTUAL_TASK;
            }
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if(string.IsNullOrWhiteSpace(email))
                    Mex.AddMessage("Task " + (taskNumber != null ? taskNumber : 0) + " is missing the user email. Skipping", Mex.ERROR);
                if(string.IsNullOrWhiteSpace(password))
                    Mex.AddMessage("Task " + (taskNumber != null ? taskNumber : 0) + " is missing the user password. Skipping", Mex.ERROR);
                Mex.PrintErrorMessagesInForm();
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

            string DirDestination = @"C:\TEST\Output\";
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

                Logger.PrintF(DirDestination + fileName, "** STARTING DOWNLOAD", true);
                string ownRank = "<tr class=\"yourRankRow\">";
                string endPages = "<td colspan='10'>No results found";
                string resp = null;
                int lastPage = 0;
                for (int page = (startPage==null?0:(int)startPage); page < (finishPage==null?10000:(int)finishPage); page++)
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
                        Logger.PrintF(DirDestination + fileName, resp, false);
                        break;
                    }
                    Logger.PrintF(DirDestination + fileName, resp, false);
                }
                Logger.PrintF(DirDestination + fileName, "** FINISH DOWNLOADING", true);
            }
        }
        
        public static async Task FindLastSeason()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                    | SecurityProtocolType.Tls11
                                    | SecurityProtocolType.Tls12
                                    | SecurityProtocolType.Ssl3;
            List<int> seasonZ = new List<int>();
            int? type = 0;
            string email = "eregiongreenleafthegray@yahoo.it";
            string password = "chupa33";
            string lastResp = string.Empty;

            for (int seasonIndex = 0; seasonIndex < 200; seasonIndex++)
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
                    if(resp != lastResp)
                    {
                        lastResp = resp;
                        ConfigFile.SEASON_LAST = seasonIndex+1;
                    }
                    else
                    {
                        seasonIndex = 200;
                    }
                }
            }
            return;
        }

        /*public static void GetPage()
        {
            //Run selenium
            //ChromeDriver cd = new ChromeDriver(@"chromedriver_win32");

            FirefoxDriver cd = new FirefoxDriver();
            cd.Url = @"https://mwomercs.com/login";
            cd.Navigate();
            IWebElement e = cd.FindElementById("email");

            e.SendKeys("eregiongreenleafthegray@yahoo.it");
            e = cd.FindElementById("password");
            e.SendKeys("chupa33");
            e = cd.FindElementByCssSelector("button.btn");
            //e = cd.FindElementByXPath(@"//a[contains(text(), 'Sign in') or contains(text(), 'sign in')]");
            //e = cd.FindElementByXPath(@"//*[@id=""main""]/div/div/div[2]/table/tbody/tr/td[1]/div/form/fieldset/table/tbody/tr[6]/td/button");
            e.Click();

            List<PlayerStatT> players = new List<PlayerStatT>();

            long tempLong = 0;
            int tempInt = 0;
            double tempDouble = 0;


            for (int? page = ConfigFile.START_PAGE; page < ConfigFile.END_PAGE; page++)
            {
                cd.Url = @"https://mwomercs.com/profile/leaderboards?page=" + page + "&type=0";
                cd.Navigate();
                for (int x = 1; x < 21; x++)
                {
                    PlayerStatT player = new PlayerStatT();
                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(1)");
                    long.TryParse(e.Text, out tempLong);
                    player.Rank = tempLong;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(2)");
                    player.Name = e.Text;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(3)");
                    int.TryParse(e.Text, out tempInt);
                    player.Wins = tempInt;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(4)");
                    int.TryParse(e.Text, out tempInt);
                    player.Losses = tempInt;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(5)");
                    double.TryParse(e.Text.Replace(".", ","), out tempDouble);
                    player.WLr = tempDouble;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(6)");
                    int.TryParse(e.Text, out tempInt);
                    player.Kills = tempInt;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(7)");
                    int.TryParse(e.Text, out tempInt);
                    player.Deaths = tempInt;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(8)");
                    double.TryParse(e.Text.Replace(".", ","), out tempDouble);
                    player.KDr = tempDouble;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(9)");
                    int.TryParse(e.Text, out tempInt);
                    player.GamesPlayed = tempInt;

                    e = cd.FindElementByCssSelector(".table > tbody:nth-child(2) > tr:nth-child(" + x + ") > td:nth-child(10)");
                    int.TryParse(e.Text, out tempInt);
                    player.AvarageMatchScore = tempInt;
                    WriteLine(player);
                    players.Add(player);
                }
            }



            //Get the cookies
            foreach (OpenQA.Selenium.Cookie c in cd.Manage().Cookies.AllCookies)
            {
                string name = c.Name;
                string value = c.Value;

                //cd.Add(new System.Net.Cookie(name, value, c.Path, c.Domain));
            }

            //Fire off the request
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create("https://fif.com/components/com_fif/tools/capacity/values/");
            //hwr.CookieContainer = cc;
            hwr.Method = "POST";
            hwr.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swr = new StreamWriter(hwr.GetRequestStream());
            swr.Write("feeds=35");
            swr.Close();

            WebResponse wr = hwr.GetResponse();
            string s = new System.IO.StreamReader(wr.GetResponseStream()).ReadToEnd();
        }
        */

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
