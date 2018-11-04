using System.Collections.Generic;
using System.Diagnostics;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.Logger
{
    /// <summary>
    /// Abstract Logger implements from Ilogger.
    /// </summary>
    public abstract class AbstractLogger : ILogger
    {
        #region class property
        public virtual EventLogEntryType DefaultLogEntryType
        {
            get { return EventLogEntryType.Information; }
        }
        //Give a defaultCategory value
        public virtual string DefaultCategory
        {
            get { return "300"; }
        }

        public virtual int DefaultEventId
        {
            get { return 0; }
        }

        public virtual int DefaultPriority
        {
            get { return 100; }
        }

        #endregion
       

        #region ILogger element.

        public abstract bool IsLoggingEnabled();

        public void Write(object message)
        {
            this.Write(message, this.DefaultLogEntryType, this.DefaultCategory, this.DefaultEventId, this.DefaultPriority, null);
        }

        public void Write(object message, EventLogEntryType eventType)
        {
            this.Write(message, eventType, this.DefaultCategory, this.DefaultEventId, this.DefaultPriority, null);
        }

        public void Write(object message, EventLogEntryType eventType, string category)
        {
            this.Write(message, eventType, category, this.DefaultEventId, this.DefaultPriority, null);
        }

        public void Write(object message, EventLogEntryType eventType, string category, int eventId)
        {
            this.Write(message, eventType, category, eventId, this.DefaultPriority, null);
        }

        public void Write(object message, EventLogEntryType eventType, string category, int eventId, int priority)
        {
            this.Write(message, eventType, category, eventId, priority, null);
        }

        public void Write(object message, IDictionary<string, object> properties)
        {
            this.Write(message, this.DefaultLogEntryType, this.DefaultCategory, this.DefaultEventId, this.DefaultPriority, properties);
        }

        public void Write(object message, EventLogEntryType eventType, IDictionary<string, object> properties)
        {
            this.Write(message, eventType, this.DefaultCategory, this.DefaultEventId, this.DefaultPriority, properties);
        }

        public void Write(object message, EventLogEntryType eventType, string category, IDictionary<string, object> properties)
        {
            this.Write(message, eventType, category, this.DefaultEventId, this.DefaultPriority, properties);
        }

        public void Write(object message, EventLogEntryType eventType, string category, int eventId, IDictionary<string, object> properties)
        {
            this.Write(message, eventType, category, eventId, this.DefaultPriority, properties);
        }
        
        public abstract void Write(object message, EventLogEntryType eventType, string category, int eventId, int priority, IDictionary<string, object> properties);

        #endregion
    }
}
