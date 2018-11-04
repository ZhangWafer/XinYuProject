using XinYu.LogService.EntLibLog;
using XinYu.LogService.Interface;

namespace XinYu.LogService
{
    public class LogService
    {
        private static ILogWriter logWriter = new EntLibLogWriterAdapter();

        static LogService()
        {
            global::XinYu.LogService.Interface.LogService.LoadLogWritter(logWriter);
        }

        public static ILogWriter Instance
        {
            get { return global::XinYu.LogService.Interface.LogService.LogWriter; }
        }
    }
}
