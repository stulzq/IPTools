// #region File Annotation
// 
// Author：Zhiqiang Li
// 
// FileName：IpTool.cs
// 
// Project：IPTools.Core
// 
// CreateDate：2018/08/19
// 
// Note: The reference to this document code must not delete this note, and indicate the source!
// 
// #endregion

using System;
using System.IO;
using System.Reflection;
#if !NETSTANDARD2_0
using System.Web;
#endif
using IPTools.Core.Exception;

namespace IPTools.Core
{
    public static class IpTool
    {
        //IPTools.International asm name
        private const string IpAllAsmName = "IPTools.International";
        //IPTools.China asm name
        private const string IpCnAsmName = "IPTools.China";

        /// <summary>
        /// If you add IPTools.International and IPTools.China to your project.The IPTools.China is Default IpSearcher.
        /// </summary>
        public static readonly IIpSearcher DefaultSearcher;

        /// <summary>
        /// IPTools.China
        /// </summary>
        public static readonly IIpSearcher IpChinaSearcher;

        /// <summary>
        /// IPTools.International
        /// </summary>
        public static readonly IIpSearcher IpAllSearcher;

        static IpTool()
        {
            try
            {
#if NETSTANDARD2_0
                var depJsonName = Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetEntryAssembly().GetName().Name}.deps.json");
                var depJsonStr = File.ReadAllText(depJsonName);
                if (File.Exists(Path.Combine(AppContext.BaseDirectory, IpCnAsmName + ".dll"))|| depJsonStr.Contains(IpCnAsmName))
                {
                    var ipCnAsm = Assembly.Load(IpCnAsmName);
                    IpChinaSearcher = (IIpSearcher)ipCnAsm.CreateInstance("IPTools.China.IpSimpleSearcher");
                }

                if (File.Exists(Path.Combine(AppContext.BaseDirectory, IpAllAsmName + ".dll"))|| depJsonStr.Contains(IpAllAsmName))
                {
                    var ipAllAsm = Assembly.Load(IpAllAsmName);
                    IpAllSearcher = (IIpSearcher)ipAllAsm.CreateInstance("IPTools.International.IpComplexSearcher");
                }
#else

                #region China

                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, IpCnAsmName + ".dll"))) //netfx console
                {
                    var ipCnAsm = Assembly.Load(IpCnAsmName);
                    IpChinaSearcher = (IIpSearcher)ipCnAsm.CreateInstance("IPTools.China.IpSimpleSearcher");
                }
                else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", IpCnAsmName + ".dll")))  // netfx asp.net
                {
                    var ipCnAsm = Assembly.Load(IpCnAsmName);
                    IpChinaSearcher = (IIpSearcher)ipCnAsm.CreateInstance("IPTools.China.IpSimpleSearcher");
                }

                #endregion

                #region All

                if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, IpAllAsmName + ".dll"))) //netfx console
                {
                    var ipAllAsm = Assembly.Load(IpAllAsmName);
                    IpAllSearcher = (IIpSearcher)ipAllAsm.CreateInstance("IPTools.International.IpComplexSearcher");
                }
                else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", IpAllAsmName + ".dll")))  // netfx asp.net
                {
                    var ipAllAsm = Assembly.Load(IpAllAsmName);
                    IpAllSearcher = (IIpSearcher)ipAllAsm.CreateInstance("IPTools.International.IpComplexSearcher");
                }

                #endregion
#endif


                if (IpChinaSearcher == null && IpAllSearcher == null)
                {
                    throw new IpToolException("Can not load any IpSearcher.");
                }
                else if (IpChinaSearcher != null && IpAllSearcher != null)
                {
                    DefaultSearcher = IpToolSettings.DefalutSearcherType == IpSearcherType.International ? IpAllSearcher : IpChinaSearcher;
                }
                else if (IpChinaSearcher != null)
                {
                    DefaultSearcher = IpChinaSearcher;
                }
                else
                {
                    DefaultSearcher = IpAllSearcher;
                }
            }
            catch (System.Exception e)
            {
                throw new IpToolException("IPTools initialize failed.", e);
            }

        }


        /// <summary>
        /// Use DefaultSearcher get ip addredd information.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static IpInfo Search(string ip)
        {
            return DefaultSearcher.Search(ip);
        }

        /// <summary>
        /// Use DefaultSearcher get ip addredd information with i8n.
        /// <para/>
        /// Now support IPTools.China.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="langCode">language code.eg. zh-CN, en.</param>
        /// <returns></returns>
        public static IpInfo SearchWithI18N(string ip, string langCode = "")
        {
            return DefaultSearcher.SearchWithI18N(ip, langCode);
        }
    }
}