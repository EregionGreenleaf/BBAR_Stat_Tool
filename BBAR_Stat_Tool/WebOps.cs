using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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


        public static async void LoginAndDownload(int season, int type, string email, string password, int startPage = 0, int finishPage = 8000)
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
            string fileName;
            if (season<10)
                fileName = "S0" + season + "_" + typeStr + ".txt";
            else
                fileName = "S" + season + "_" + typeStr + ".txt";

            string DirDestination = @"C:\UTIL\BBAR_\Output\";
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

                HttpResponseMessage risposta = client.PostAsync(BaseAddress, new FormUrlEncodedContent(
                        new[]
                        {
                            new KeyValuePair<string,string> ("email", email),
                            new KeyValuePair<string,string> ("password", password)
                        })
                    ).Result;
                string responseBodyAsText = await risposta.Content.ReadAsStringAsync();

                Logger.PrintF(DirDestination + fileName, "** STARTING DOWNLOAD", true);
                string resp = null;
                int lastPage = 0;
                for(int page = startPage; page < finishPage; page++)
                {
                    risposta = client.GetAsync("https://mwomercs.com/profile/leaderboards?page=" + page.ToString() +"&type=" + type.ToString()).Result;
                    responseBodyAsText = await risposta.Content.ReadAsStringAsync();
                    resp = DataOps.ParseHTML(responseBodyAsText);
                    if (resp.Contains("<td colspan='10'>No results found"))
                    {
                        lastPage = page;
                        resp = resp.Replace("<td colspan='10'>No results found", "");
                        Logger.PrintF(DirDestination + fileName, resp, false);
                        break;
                    }
                    Logger.PrintF(DirDestination + fileName, resp, false);
                }
                Logger.PrintF(DirDestination + fileName, "** FINISH DOWNLOADING", true);
            }
        }
        
        public static void GetPage()
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
