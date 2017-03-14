using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    public struct MessageT
    {
        public string Message { get; set; }
        public int Type { get; set; }
        public DateTime? Time { get; set; }

        public MessageT(string message = "", int type = 0, DateTime? time = null)
        {
            Message = message;
            Type = type;
            Time = time;

        }
    }
}
