using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBAR_Stat_Tool
{
    public static class Mex
    {

        private static List<MessageT> Messages = new List<MessageT>();
        public static int? ERROR = 0;
        public static int? WARNING = 1;
        public static int? INFO = 2;

        /// <summary>
        /// Removes a Message at Index or Last
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool RemoveMessage(int index = -1)
        {
            try
            {
                if (index == -1)
                {
                    Messages.RemoveRange(Messages.Count - 1, 1);
                }
                else
                {
                    Messages.RemoveAt(index);
                }
                return true;
            }
            catch
            {
                return true;
            }
        }
        public static bool RemoveType(int type)
        {

            return false;
        }

        /// <summary>
        /// Adds a Message to the List
        /// </summary>
        /// <param name="message">Text message</param>
        /// <param name="type">Type of message</param>
        /// <returns></returns>
        public static bool AddMessage(string message, int? type)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(message) && type != null)
                {
                    try
                    {
                        MessageT newMex = new MessageT(message, (int)type);
                        Messages.Add(newMex);
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
