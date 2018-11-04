using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace XinYu.LogService.EntLibLog
{
    public sealed class EntLibLogWriter
    {
        /// <summary> 输出错误日志
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="title">消息标题</param>
        public static LogEntry WriteError(Exception exception, string title)
        {
            var logEntity = new LogEntry {Title = title, TimeStamp = DateTime.Now};

            var messageBuilder = new StringBuilder();
            messageBuilder.Append(exception);
            var upperException = exception;
            //遍历InnerException
            while (upperException.InnerException != null)
            {
                messageBuilder.Append(upperException.InnerException);
                upperException = upperException.InnerException;
            }
            logEntity.Message = messageBuilder.ToString();
            logEntity.Severity = TraceEventType.Error;
            Logger.Write(logEntity);

            return logEntity;
        }

        /// <summary> 输出消息日志
        /// </summary>
        /// <param name="infoMessage">消息文本</param>
        /// <param name="title">消息标题</param>
        public static void WriteInfo(string infoMessage, string title)
        {
            WriteLog(infoMessage, title, TraceEventType.Information);
        }

        /// <summary> 输出调试日志
        /// </summary>
        /// <param name="debugMessage">调试信息文本</param>
        /// <param name="title">调试信息标题</param>
        public static void WriteDebug(string debugMessage, string title)
        {
            WriteLog(debugMessage, title, TraceEventType.Verbose);
        }

        /// <summary> 写日志
        /// </summary>
        /// <param name="logMessage">日志信息文本</param>
        /// <param name="title">日志信息标题</param>
        /// <param name="severity">日志类型</param>
        private static void WriteLog(string logMessage, string title, TraceEventType severity)
        {
            var logEntity = new LogEntry();
            logEntity.Title = title;
            logEntity.TimeStamp = DateTime.Now;
            logEntity.Message = logMessage;
            logEntity.Severity = severity;
            Logger.Write(logEntity);
            //消除生成的GUID的文件。并且使文件是每天一个日志文件
            if (Logger.Writer != null)
                Logger.Writer.Dispose();
        }
    }
}
