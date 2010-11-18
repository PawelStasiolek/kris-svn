using System;
using System.Collections.Generic;
using System.Text;

namespace eBest.Business
{

    /// <summary>
    /// 配置类型
    /// </summary>
    public static class ConfigType
    {
        public static string CompanyName="CompanyName";
        public static string CompanyUrl = "CompanyUrl";
        public static string CompanyTel = "CompanyTel";
        public static string CompanyFax = "CompanyFax";
        public static string MobileGroup = "MobileGroup";
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 登录日志
        /// </summary>
        Login = 1,
        /// <summary>
        /// 操作日志
        /// </summary>
        Operation = 2,
        /// <summary>
        /// 系统错误
        /// </summary>
        Exception=3

    }
}
