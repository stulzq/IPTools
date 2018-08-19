// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpToolExtension.cs
// 
// Project：IPTools.Heavyweight
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using IPTools.Core;
using Microsoft.AspNetCore.Http;

namespace IPTools.International.Extensions
{
    public static class IpToolExtension
    {
        public static IpInfo GetRemoteIpInfo(this HttpContext context)
        {
            return IpTool.Search(context.Connection.RemoteIpAddress.ToString());
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