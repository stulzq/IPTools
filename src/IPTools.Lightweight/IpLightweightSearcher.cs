// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpLightweightSearcher.cs
// 
// Project：IPTools.Lightweight
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using System;
using System.Reflection;
using System.Threading.Tasks;
using IP2Region.Ex;
using IPTools.Core;
using IPTools.Core.Exception;

namespace IPTools.China
{
    public class IpLightweightSearcher:IIpSearcher,IDisposable
    {
        private readonly DbSearcher _search;

        public IpLightweightSearcher()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var dbResourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.ip2region.db");
            _search = new DbSearcher(dbResourceStream);
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

        public async Task<IpInfo> SearchAsync(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException(nameof(ip));
            }

            var dataBlack = await _search.MemorySearchAsync(ip).ConfigureAwait(false);
            var ipinfo = RegionStrToIpInfo(dataBlack.Region);
            ipinfo.IpAddress = ip;
            return ipinfo;
        }

        public Task<IpInfo> SearchWithI18NAsync(string ip, string langCode)
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