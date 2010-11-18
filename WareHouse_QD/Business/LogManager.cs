using System;
using System.Collections.Generic;
using System.Text;
using EBest.Persistent;
using EBest.Data;
using System.Data;
using eBest.Entity;

namespace eBest.Business
{
    public class LogManager
    {
        #region 读取日志类型
        /// <summary>
        /// 读取日志类型
        /// </summary>
        /// <returns></returns>
        public ObjectTable GetLogType()
        {
            return new ObjectTable(typeof(SYS_LogType), "");
        }
        #endregion

        #region 保存系统日志

        /// <summary>
        /// 保存系统日志
        /// </summary>
        /// <param name="typeNo">日志类型编号 </param>
        /// <param name="description">描述</param>
        /// <param name="createDate">创建日期</param>
        /// <param name="uid">操作人</param>
        /// <returns>是否成功</returns>
        public static bool SaveLog(LogType typeNo, string text, DateTime lastDate, string userName)
        {
            SYS_Log syslog = new SYS_Log();
            syslog.LogType = (int)typeNo;
            syslog.Text = text;
            syslog.UpdateBy = userName;
            syslog.LastDate = lastDate;

            try
            {
                syslog.Save();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        #endregion

        #region 读取系统日志
        public DataTable GetLogByType(LogType type, DateTime start, DateTime end)
        {
            string sql = @"select SYS_Log.LogType,SYS_LogType.TypeName,Text,LastDate,UpdateBy 
                             from SYS_Log 
	                            inner join SYS_LogType on SYS_LogType.LogTypeID=SYS_Log.LogType 
                            where 1=1 ";
            sql += "and SYS_LogType.LogTypeID='" + (int)type + "'";

            if (start != DateTime.MinValue)
                sql += "and LastDate>='" + start.ToString("yyyy-MM-dd") + "'";

            if (end != DateTime.MinValue)
                sql += "and LastDate<='" + end.AddDays(1).ToString("yyyy-MM-dd") + "'";

            sql += " order by LastDate desc";

            return EBest.Data.SqlData.OpenSql(sql).Tables[0];
        }
        #endregion
    }
}
