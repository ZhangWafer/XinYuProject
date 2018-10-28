using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace XinYu.Framework.Library.Implement.Logger
{
    /// <summary>
    /// Writing the windows event log
    /// </summary>
   public class EventLogger : AbstractLogger
   {
       const string categoryKey = "category";
       const string sourceKey = "source";

       private int minPriorityLevel = 3;

       string logName = "SpotMauLog";
       string defaultSource = "SpotMauSystem";
       string defaultCategory = "200";

       public EventLogger(string logName, string defaultSource)
       {
           this.logName = logName;
       }

       public EventLogger(string logName, string defaultSource, int minPriorityLevel, string defaultCategory)
       {
           this.logName = logName;
           this.defaultSource = defaultSource;
           this.minPriorityLevel = minPriorityLevel;
           this.defaultCategory = defaultCategory;
       }

       //赋值一个默认的日志名
       public string LogName
       {
           get { return this.logName; }
       }
       //赋值一个默认的source
       public string DefaultSource
       {
           get { return this.defaultSource; }
       }
       //赋值一个默认的Category属性
       public override string DefaultCategory
       {
           get { return this.defaultCategory; }
       }
       

       public override bool IsLoggingEnabled()
       {
           return true;
       }
       
       /// <summary>
       /// Main method for windows wirte.
       /// </summary>
       /// <param name="message">Logging message</param>
       /// <param name="eventType">logging eventType</param>
       /// <param name="category">logging category</param>
       /// <param name="eventId">logging eventId</param>
       /// <param name="priority">logging priority(if no need to log set priority  smaller than default priority)</param>
       /// <param name="properties"></param>
       public override void Write(object message, EventLogEntryType eventType, string category, int eventId, int priority, IDictionary<string, object> properties)
       {
           if (this.minPriorityLevel > priority)
               return;

           if (message == null) throw new ArgumentNullException("message",Properties.Resources.EventLogger_MessageNull);

           if (string.IsNullOrEmpty(category))
           {
               //从Dictionary搜索，检查是否有category
               if (properties != null && properties.ContainsKey(categoryKey))
                   category = properties[categoryKey].ToString();
               else
                   category = this.DefaultCategory;//没有，给一个默认的
           }

           string source = this.DefaultSource;//先给一个默认的，
           if (properties != null && properties.ContainsKey(sourceKey))//再检查Dictionary如果有，再改source
               source = properties[sourceKey].ToString();


           EventLog log = new EventLog(this.LogName, System.Net.Dns.GetHostName(), source);
           StringBuilder value = new StringBuilder();
          

           
           if (properties != null)
           {

               Dictionary<string, object>.KeyCollection keyColl = (Dictionary<string, object>.KeyCollection)properties.Keys;

               //Construct a formating string in message.
               foreach (string key in keyColl)
               {
                   string value1 = string.Empty;
                   value1 = "Key:" + "(" + key + ")" + "   " + "Value:" + "(" + properties[key].ToString()+")";
                   value.AppendLine(value1);
               }

           }

           value.AppendLine(Properties.Resources .EventLogger_MessageDetail + message.ToString());
           log.WriteEntry(value.ToString(), eventType, eventId, short.Parse(category));
               
           
       }


   }
}
