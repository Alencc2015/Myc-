using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.BaseClass
{
    class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        static readonly log4net.ILog logError = log4net.LogManager.GetLogger("DailyLog");
        static readonly log4net.ILog logDaily = log4net.LogManager.GetLogger("LoginLog");

        public static void WriteLog(string info)
        {
            if (logError.IsInfoEnabled)
            {
                logError.Info(info);
            }
        }
        public static void Error(string info)
        {
            if (logError.IsInfoEnabled)
            {
                logError.Info(info);
            }
        }
        public static void Error(LogType logType, string format, params object[] args)
        {
            logError.ErrorFormat(logType.ToString() + "|"
                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|"
                + format, args);
        }
        public static void Info(LogType logType, string format, params object[] args)
        {
            logDaily.InfoFormat(logType.ToString() + "|"
                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|"
                + format, args);
        }
    }
}
