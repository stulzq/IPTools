// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpToolSettings.cs
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
    public class IpToolSettings
    {
        /// <summary>
        /// Default language code, eg. zh-CN, en
        /// </summary>
        public static string DefaultLanguage = "zh-CN";

        /// <summary>
        /// Only when IPTools.International and IPTools.China are applied at the same time will they take effect.
        /// </summary>
        public static IpSearcherType DefalutSearcherType = IpSearcherType.China;

        /// <summary>
        /// It can double the query speed. Only using IPTools.International will take effect.
        /// </summary>
        public static bool LoadInternationalDbToMemory = false;

        public static string ChinaDbPath = string.Empty;

        public static string InternationalDbPath = string.Empty;
    }
}