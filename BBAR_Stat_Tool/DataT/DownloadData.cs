using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    public class DownloadData
    {
        public string User { get; set; }
        public string Password { get; set; }
        public int? Season { get; set; }
        public int? Type { get; set; }
        public int? StartPage { get; set; }
        public int? EndPage { get; set; }
        public int? TaskNumber { get; set; }

        public DownloadData(string user = null, string password = null,
                            int? season = null, int? type = null,
                            int? startPage = null,  int? endPage = null,
                            int? taskNumber = null, DownloadData dData = null)
        {
            if (dData == null)
            {
                User = user;
                Password = password;
                Season = season;
                Type = type;
                StartPage = startPage;
                EndPage = endPage;
                TaskNumber = taskNumber;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(dData.User) && user == null)
                    User = dData.User;
                else
                    User = user;
                if (!string.IsNullOrWhiteSpace(dData.Password) && password == null)
                    Password = dData.Password;
                else
                    Password = password;
                if (dData.Season != null && season == null)
                    Season = dData.Season;
                else
                    Season = season;
                if (dData.Type != null && type == null)
                    Type = dData.Type;
                else
                    Type = type;
                if (dData.StartPage != null && startPage == null)
                    StartPage = dData.StartPage;
                else
                    StartPage = startPage;
                if (dData.EndPage != null && endPage == null)
                    EndPage = dData.EndPage;
                else
                    EndPage = endPage;
                if (dData.TaskNumber != null && taskNumber == null)
                    TaskNumber = dData.TaskNumber + 1;
                else
                    TaskNumber = taskNumber;
            }
        }

    }
}
