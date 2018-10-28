// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库异常处理接口
// Modify History: 
// ============================================================================

using System;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a exception handler.
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Format exception to a string.
        /// </summary>
        /// <param name="exception">The exception to format.</param>
        string FormatingException(Exception exception);

        /// <summary>
        /// Logging exception using passed parameter logger object.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="logger">Using it to log exception.</param>
        void LoggingException(Exception exception, ILogger logger);

        /// <summary>
        /// <para>When implemented by a class, handles an <see cref="Exception"/>.</para>
        /// </summary>
        /// <param name="exception"><para>The exception to handle.</para></param>        
        /// <returns><para>Modified exception to pass to the next exceptionHandlerData in the chain.</para></returns>
        Exception HandleException(Exception exception);


        /// <summary>
        /// <para>When implemented by a class, handles an <see cref="Exception"/>.</para>
        /// </summary>
        /// <param name="exception"><para>The exception to handle.</para></param>        
        /// <param name="handlingInstanceId">
        /// <para>The unique ID attached to the handling chain for this handling instance.</para>
        /// </param>
        /// <returns><para>Modified exception to pass to the next exceptionHandlerData in the chain.</para></returns>
        Exception HandleException(Exception exception, Guid handlingInstanceId);
    }
}
