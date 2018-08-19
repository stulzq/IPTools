// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpToolException.cs
// 
// Project：IPTools.Core
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

namespace IPTools.Core.Exception
{
    public class IpToolException:System.Exception
    {
        public IpToolException(string message) : base(message)
        {
        }

        public IpToolException(string message,System.Exception innerException) : base(message, innerException)
        {
        }

    }
}