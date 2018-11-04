using System.IO;
using XinYu.IniFileService;

namespace XinYu.InvokeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = System.Environment.CurrentDirectory;
            var iniFile = Path.Combine(currentDirectory, "system.ini");

            IniFileUtility.WriteToFile(iniFile, "WcfService", "IpAddress", "127.0.0.1");
            IniFileUtility.WriteToFile(iniFile, "WcfService", "Port", "9001");
        }
    }
}
