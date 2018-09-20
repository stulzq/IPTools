// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpHeavyweightSearcher.cs
// 
// Project：IPTools.International
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using IPTools.Core;
using IPTools.Core.Exception;
using MaxMind.GeoIP2;

namespace IPTools.International
{
    public class IpComplexSearcher:IIpSearcher
    {
        private readonly DatabaseReader _search;

        public IpComplexSearcher()
        {
//            Assembly assembly = Assembly.GetExecutingAssembly();
//            var dbResourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.GeoLite2-City.mmdb");
//            _search = new DatabaseReader(dbResourceStream);
            
#if NETSTANDARD2_0
            var dbPath = Path.Combine(AppContext.BaseDirectory, "GeoLite2-City.mmdb");
#else
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeoLite2-City.mmdb");
#endif
            if (!string.IsNullOrEmpty(IpToolSettings.InternationalDbPath))
            {
                dbPath = IpToolSettings.InternationalDbPath;
            }
            if (!File.Exists(dbPath))
            {
                throw new IpToolException($"IPTools.International initialize failed. Can not find database file from {dbPath}. Please download the file to your application root directory, then set it can be copied to the output directory. Url: https://github.com/stulzq/IPTools/raw/master/db/GeoLite2-City.mmdb");
            }

            if (IpToolSettings.LoadInternationalDbToMemory)
            {
                MemoryMappedFile file = MemoryMappedFile.CreateFromFile(dbPath);
                _search = new DatabaseReader(file.CreateViewStream());
            }
            else
            {
                _search = new DatabaseReader(dbPath);
            }
            
        }

        public IpInfo Search(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException(nameof(ip));
            }

            if (_search.TryCity(ip, out var city))
            {
                var ipinfo = new IpInfo
                {
                    IpAddress = ip,
                    CountryCode = city.Country.IsoCode,
                    Country = city.Country.Name,
                    Province = city.MostSpecificSubdivision.Name,
                    ProvinceCode = city.MostSpecificSubdivision.IsoCode,
                    City =city.City.Name,
                    PostCode = city.Postal.Code,
                    Latitude = city.Location.Latitude,
                    Longitude = city.Location.Longitude,
                    AccuracyRadius = city.Location.AccuracyRadius
                };
                return ipinfo;
            }
            else
            {
                return new IpInfo();
            }
            
        }

        public IpInfo SearchWithI18N(string ip, string langCode="")
        {
            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException(nameof(ip));
            }

            if (string.IsNullOrEmpty(langCode))
            {
                langCode = IpToolSettings.DefaultLanguage;
            }

            if (_search.TryCity(ip, out var city))
            {
                var ipinfo = new IpInfo
                {
                    IpAddress = ip,
                    CountryCode = city.Country.IsoCode,
                    Country = city.Country.Names.ContainsKey(langCode) ? city.Country.Names[langCode] : city.Country.Name,
                    Province = city.MostSpecificSubdivision.Names.ContainsKey(langCode) ? city.MostSpecificSubdivision.Names[langCode] : city.MostSpecificSubdivision.Name,
                    ProvinceCode = city.MostSpecificSubdivision.IsoCode,
                    City = city.City.Names.ContainsKey(langCode) ? city.City.Names[langCode] : city.City.Name,
                    PostCode = city.Postal.Code,
                    Latitude = city.Location.Latitude,
                    Longitude = city.Location.Longitude,
                    AccuracyRadius = city.Location.AccuracyRadius
                };
                return ipinfo;
            }
            else
            {
                return new IpInfo();
            }
        }
    }
}