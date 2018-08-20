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

namespace IPTools.Core
{
    public interface IIpSearcher
    {
        IpInfo Search(string ip);

        IpInfo SearchWithI18N(string ip,string langCode="");
    }
}