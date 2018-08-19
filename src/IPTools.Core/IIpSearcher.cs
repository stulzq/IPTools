// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IIpSearcher.cs
// 
// Project：IPTools.Core
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using System.Threading.Tasks;

namespace IPTools.Core
{
    public interface IIpSearcher
    {
        IpInfo Search(string ip);

        IpInfo SearchWithI18N(string ip,string langCode);

        Task<IpInfo> SearchAsync(string ip);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="langCode">eg. zh-CN, en.</param>
        /// <returns></returns>
        Task<IpInfo> SearchWithI18NAsync(string ip, string langCode);
    }
}