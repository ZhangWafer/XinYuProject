using System;

namespace XinYu.LogService.Interface
{
    /// <summary> 日志接口，定义了日志的基本功能
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>输出错误日志。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="exception">要输出的异常对象</param>
        void WriteException(string title, Exception exception);

        /// <summary>输出文本日志。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">要输出的信息</param>
        void WriteText(string title, string text);

        /// <summary>输出文本日志（只在调试状态下执行）。
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="debugText">要输出的信息</param>
        void WriterDebugText(string title, string debugText);
    }
}
