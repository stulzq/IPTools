using System;
using System.Diagnostics;

namespace IPTools.China.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var searcher = IpTool.Searcher;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 255; i++)
            {

                for (int j = 0; j < 255; j++)
                {
                    var info = searcher.Search($"171.{i}.{j}.163");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            var ipinfo = IpTool.Search("171.210.12.163");
            Console.WriteLine(ipinfo.Country); // 中国
            Console.WriteLine(ipinfo.Province); // 四川省
            Console.WriteLine(ipinfo.City); // 成都市
            Console.WriteLine(ipinfo.NetworkOperator);// 电信
            Console.Read();
        }
    }
}
