// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpToolExtension.cs
// 
// Project：IPTools.Core
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion


#if NETSTANDARD2_0
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif

namespace IPTools.Core.Extensions
{
    public static class IpToolExtension
    {
        public static IpInfo GetRemoteIpInfo(this HttpContext context)
        {
#if NETSTANDARD2_0
            
            return IpTool.Search(context.Connection.RemoteIpAddress.ToString());
#else
            return IpTool.Search(context.Request.UserHostAddress);
#endif
        }

        /// <summary>
        /// Get ip info from request header.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="headerKey">request header key.</param>
        /// <returns></returns>
        public static IpInfo GetRemoteIpInfo(this HttpContext context,string headerKey)
        {
            return IpTool.Search(context.Request.Headers[headerKey]);
        }
    }
}