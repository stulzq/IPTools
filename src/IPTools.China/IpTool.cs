// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpTool.cs
// 
// Project：IPTools.Lightweight
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using IPTools.Core;

namespace IPTools.China
{
    public static class IpTool
    {
        public static readonly IIpSearcher Searcher;

        static IpTool()
        {
            Searcher = new IpLightweightSearcher();
        }

        public static IpInfo Search(string ip)
        {
            return Searcher.Search(ip);
        }
    }
}