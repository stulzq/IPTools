// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpLightweightSearcher.cs
// 
// Project：IPTools.China
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using System;
using System.IO;
using System.Reflection;
using IP2Region.Ex;
using IPTools.Core;
using IPTools.Core.Exception;

namespace IPTools.China
{
    public class IpSimpleSearcher:IIpSearcher
    {
        private readonly DbSearcher _search;

        public IpSimpleSearcher()
        {
            /*Assembly assembly = Assembly.GetExecutingAssembly();
            var dbResourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.ip2region.db");
            _search = new DbSearcher(dbResourceStream);*/
#if NETSTANDARD2_0
            var dbPath = Path.Combine(AppContext.BaseDirectory, "ip2region.db");
#else
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ip2region.db");
#endif
            if (!string.IsNullOrEmpty(IpToolSettings.ChinaDbPath))
            {
                dbPath = IpToolSettings.ChinaDbPath;
            }
            if (!File.Exists(dbPath))
            {
                throw new IpToolException($"IPTools.China initialize failed. Can not find database file from {dbPath}. Please download the file to your application root directory, then set it can be copied to the output directory. Url: https://github.com/stulzq/IPTools/raw/master/db/ip2region.db");
            }

            _search = new DbSearcher(dbPath);
        }

        public IpInfo Search(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException(nameof(ip));
            }

            var region = _search.MemorySearch(ip).Region;
            var ipinfo = RegionStrToIpInfo(region);
            ipinfo.IpAddress = ip;
            return ipinfo;
        }

        public IpInfo SearchWithI18N(string ip, string langCode)
        {
            throw new NotImplementedException();
        }

        private IpInfo RegionStrToIpInfo(string region)
        {
            try
            {
                var array = region.Split('|');
                var info = new IpInfo()
                {
                    Country = array[0],
                    Province = array[2],
                    City = array[3],
                    NetworkOperator = array[4]
                };
                return info;
            }
            catch(Exception e)
            {
                throw new IpToolException("Error converting ip address information to ipinfo object",e);
            }
        }

        public void Dispose()
        {
            _search?.Dispose();
        }
    }
}