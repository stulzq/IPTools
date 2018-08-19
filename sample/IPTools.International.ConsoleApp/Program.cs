using System;
using System.Diagnostics;
using IPTools.Core;

namespace IPTools.International.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var searcher = IpTool.Searcher;
            Stopwatch sw=new Stopwatch();
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
            Console.WriteLine(ipinfo.Country); // China
            Console.WriteLine(ipinfo.CountryCode); // CN
            Console.WriteLine(ipinfo.Province); // Sichuan
            Console.WriteLine(ipinfo.ProvinceCode); // SC
            Console.WriteLine(ipinfo.City); // Chengdu
            Console.WriteLine(ipinfo.Latitude); // 30.6667
            Console.WriteLine(ipinfo.Longitude); // 104.6667
            Console.WriteLine(ipinfo.AccuracyRadius);// 50

            Console.WriteLine();
            IpToolSettings.DefaultLanguage = "en";
            ipinfo = IpTool.SearchWithI18N("171.210.12.163");
            Console.WriteLine(ipinfo.Country); // 中国
            Console.WriteLine(ipinfo.CountryCode); // CN
            Console.WriteLine(ipinfo.Province); // 四川省
            Console.WriteLine(ipinfo.ProvinceCode); // SC
            Console.WriteLine(ipinfo.City); // 成都
            Console.WriteLine(ipinfo.Latitude); // 30.6667
            Console.WriteLine(ipinfo.Longitude); // 104.6667
            Console.WriteLine(ipinfo.AccuracyRadius);// 50
            Console.Read();
        }
    }
}
