using System;
using XinYu.LogService.Interface;

namespace XinYu.LogService.EntLibLog
{
    /// <summary> 企业库日志处理实现
    /// </summary>
    public sealed class EntLibLogWriterAdapter : ILogWriter
    {
        #region ILogWriter 成员

        /// <summary>输出错误日志。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="exception">要输出的异常对象</param>
        public void WriteException(string title, Exception exception)
        {
            EntLibLogWriter.WriteError(exception, title);
        }

        /// <summary>输出文本日志。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">要输出的信息</param>
        public void WriteText(string title, string text)
        {
            EntLibLogWriter.WriteInfo(text, title);
        }

        /// <summary>输出文本日志（只在调试状态下执行）。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="debugText">要输出的信息</param>
        public void WriterDebugText(string title, string debugText)
        {
            EntLibLogWriter.WriteDebug(debugText, title);
        }

        #endregion
    }
}
