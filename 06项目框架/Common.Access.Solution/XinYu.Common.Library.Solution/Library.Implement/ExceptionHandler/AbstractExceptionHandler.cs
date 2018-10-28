using System;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.ExceptionHandler
{
    /// <summary>
    /// AbstractExceptionHandler implements from IexceptionHandler 
    /// </summary>
    public abstract class AbstractExceptionHandler : IExceptionHandler
    {
        #region IExceptionHandler 成员

        public abstract string FormatingException(Exception exception);

        public virtual void LoggingException(Exception exception, ILogger logger)
        {
            string message = this.FormatingException(exception);
            logger.Write(message);
        }

        public abstract Exception HandleException(Exception exception);

        public abstract Exception HandleException(Exception exception, Guid handlingInstanceId);

        #endregion
    }
}
