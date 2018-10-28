// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库日志管理接口
// Modify History: 
// ============================================================================

using System.Collections.Generic;
using System.Diagnostics;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a logger.
    /// </summary>
    public interface ILogger
    {        
        /// <summary>
        /// Query whether logging is enabled.
        /// </summary>
        /// <returns><code>true</code> if logging is enabled.</returns>
        bool IsLoggingEnabled();

        /// <summary>
        /// Write a new log entry to the default category.
        /// </summary>
        /// <example>The following example demonstrates use of the Write method with one required parameter, message.
        /// <code>ILogger.Write("My message body");</code></example>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        void Write(object message);

        /// <summary>
        /// Write a new log entry with a specific event type.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        void Write(object message, EventLogEntryType eventType);

        /// <summary>
        /// Write a new log entry with a specific event type, category.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        void Write(object message, EventLogEntryType eventType, string category);

        /// <summary>
        /// Write a new log entry with a specific event type, category, priority.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        void Write(object message, EventLogEntryType eventType, string category, int eventId);

        /// <summary>
        /// Write a new log entry with a specific event type, category, priority, event Id.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        void Write(object message, EventLogEntryType eventType, string category, int eventId, int priority);

        /// <summary>
        /// Write a new log entry and a dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        void Write(object message, IDictionary<string, object> properties);

        /// <summary>
        /// Write a new log entry to a specific event type with a dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        void Write(object message, EventLogEntryType eventType, IDictionary<string, object> properties);

        /// <summary>
        /// Write a new log entry with a specific event type, category and dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        void Write(object message, EventLogEntryType eventType, string category, IDictionary<string, object> properties);

        /// <summary>
        /// Write a new log entry with a specific event type, category, event Id and dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        void Write(object message, EventLogEntryType eventType, string category, int eventId, IDictionary<string, object> properties);

        /// <summary>
        /// Write a new log entry with a specific event type, category, priority, event Id and dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="eventType">Message event type to log entry. See <see cref="EventLogEntryType" /> for more information.</param>
        /// <param name="category">Category name used to route the log entry if the Logger has the function.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        void Write(object message, EventLogEntryType eventType, string category, int eventId, int priority, IDictionary<string, object> properties);
    }
}
