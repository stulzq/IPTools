using System;
using System.Diagnostics;
using IPTools.Core;

namespace IPTools.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IpToolSettings.LoadInternationalDbToMemory = true;

            Console.WriteLine("Default Searcher："+ IpTool.Search("171.210.12.163").City);

            Console.WriteLine("IPTools.International Searcher：" + IpTool.IpAllSearcher.Search("171.210.12.163").City);
            Console.WriteLine("IPTools.International Searcher with i18n：" + IpTool.IpAllSearcher.SearchWithI18N("171.210.12.163").City);

            Console.WriteLine("IPTools.China Searcher：" + IpTool.IpChinaSearcher.Search("171.210.12.163").City);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 255; i++)
            {

                for (int j = 0; j < 255; j++)
                {
                    var info = IpTool.Search($"171.{i}.{j}.163");
                }
            }
            sw.Stop();
            Console.WriteLine("Query 65025 ip spend "+sw.ElapsedMilliseconds +" ms.");

            sw.Restart();
            for (int i = 0; i < 255; i++)
            {

                for (int j = 0; j < 255; j++)
                {
                    var info = IpTool.IpAllSearcher.Search($"171.{i}.{j}.163");
                }
            }
            sw.Stop();
            Console.WriteLine("Complex query 65025 ip spend " + sw.ElapsedMilliseconds + " ms.");
            Console.Read();
        }
    }
}
