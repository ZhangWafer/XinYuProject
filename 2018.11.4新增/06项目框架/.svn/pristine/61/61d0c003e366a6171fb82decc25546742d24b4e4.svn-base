using System;

namespace XinYu.InvokeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            XinYu.LogService.LogService.Instance.WriteText("测试调用_WriteText", "您需要写入的内容");

            try
            {
                var i = 1;
                var j = 0;
                var z = i / j;
            }
            catch (Exception ex)
            {
                XinYu.LogService.LogService.Instance.WriteException("测试调用_WriteException", ex);
            }
        }
    }
}
