using System;
using System.Collections.Generic;
using System.Text;
using EBest.Persistent;
using eBest.Entity;

namespace eBest.Business
{
    public class ConfigManager
    {
        /// <summary>
        /// 读取系统配置文件
        /// </summary>
        /// <param name="type">配置类型</param>
        /// <returns></returns>
        public static SYS_Config Load(string configType)
        {
            return (SYS_Config)ObjectRow.Load(typeof(SYS_Config), "this.Name='" + configType + "'");
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="type">配置类型</param>
        public static void SaveConfig(string type, string value)
        {
            SYS_Config config = Load(type);

            if (!string.IsNullOrEmpty(value))
                config.Value = value;

            config.Save();
        }

    }
}
