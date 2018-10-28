using System;
using System.Collections.Generic;
using System.Diagnostics;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.ExceptionHandler
{
    /// <summary>
    ///Writing the Exception detail for logging 
    /// </summary>
    public class ExceptionLogging : AbstractExceptionHandler
    {
        #region IExceptionHandler 成员

        //Function for formating exception into string
        public override string FormatingException(Exception exception)
        {
           
           return exception.Message;
        }

        public override void LoggingException(Exception exception, ILogger logger)
        {

            //跟踪异常信息，将信息记录
            IDictionary<string, object> iDict = new Dictionary<string, object>();
            iDict.Add(Properties.Resources.ExceptionLogging_Source, exception.Source);
            iDict.Add(Properties.Resources.ExceptionLogging_TargetSite, exception.TargetSite.ToString());
            //检查是否存在导致异常实例，如果存在则记录。
            if (exception.InnerException != null)
                iDict.Add(Properties.Resources.ExceptionLogging_InnerException, exception.InnerException.ToString());
            //检查是否存在异常帮助链接，如果存在则记录。
            if (exception.HelpLink != null)
                iDict.Add(Properties.Resources.ExceptionLogging_HelpLink, exception.HelpLink);
            iDict.Add(Properties.Resources.ExceptionLogging_StackTrace, exception.StackTrace);

            logger.Write(FormatingException(exception), EventLogEntryType.Error, iDict);
        }

        public override Exception HandleException(Exception exception)
        {
            return null;
           
        }

        public override Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            return null;
           
        }

        #endregion
    }
}
