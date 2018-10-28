using System;
using XinYu.Cache.Cache;

namespace XinYu.InvokeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCacheService.Instance.Set("cache1", DateTime.Now);
            Console.WriteLine(InMemoryCacheService.Instance.Get<DateTime>("cache1"));
        }
    }
}
