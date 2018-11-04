using System;

namespace XinYu.LogService.Interface
{
    public static class LogService
    {
        private static ILogWriter _logWriter = null;
        private static LogInvalid _logInvalid = null;

        /// <summary>获取当前写日志的实体。
        /// 若已经设置日志实体则返回该实体，否则返回的实体不做任何日志实现。
        /// </summary>
        public static ILogWriter LogWriter
        {
            get
            {
                if (_logWriter == null)
                {
                    if (_logInvalid == null)
                        _logInvalid = new LogInvalid();
                    return _logInvalid;
                }
                return _logWriter;
            }
        }

        /// <summary>装载写日志的实例到 LogWritter.
        /// </summary>
        /// <param name="log">要装载的ILogWriter实体。</param>
        public static void LoadLogWritter(ILogWriter log)
        {
            _logWriter = log;
        }
    }

    /// <summary> 虚的日志类，只实现接口，不做任何实现。
    /// </summary>
    internal class LogInvalid : ILogWriter
    {
        #region ILog 成员

        public void WriteException(string title, Exception exception)
        {
            // do nothing.
        }

        public void WriteText(string title, string text)
        {
            // do nothing.
        }

        public void WriterDebugText(string title, string debugText)
        {
            // do nothing.
        }

        #endregion
    }
}
