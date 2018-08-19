using System;
using System.Diagnostics;
using IPTools.International;

namespace IPTools.Heavyweight.ConsoleApp
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
            Console.WriteLine(ipinfo.Country);
            Console.WriteLine(ipinfo.CountryCode);
            Console.WriteLine(ipinfo.Province);
            Console.WriteLine(ipinfo.ProvinceCode);
            Console.WriteLine(ipinfo.City);
            Console.WriteLine(ipinfo.Latitude);
            Console.WriteLine(ipinfo.Longitude);
            Console.WriteLine(ipinfo.AccuracyRadius);
            Console.Read();
        }
    }
}
