using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.BaseClass;
using System.Configuration;

namespace SimpleWare.BaseClass
{
    class ccLogHelper
    {
        static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        static string strConn = config.AppSettings.Settings["logPath"].Value;
        static Log log = new Log(strConn, LogType.Daily);

        public static void Write(string info)
        {
            if (log != null)
            {
                log.Write(DateTime.Now, info, MsgType.Information);
            }
        }
        public static void Warning(string info)
        {
            if (log != null)
            {
                log.Write(DateTime.Now, info, MsgType.Warning);
            }
        }
        public static void Error(string info)
        {
            if (log != null)
            {
                log.Write(DateTime.Now, info, MsgType.Error);
            }
        }
    }
}
