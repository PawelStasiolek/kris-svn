using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EBest.Persistent;
using EBest.Data;
using eBest.Entity;

namespace eBest.Business
{
    public class RoleManager
    {
        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <param name="status">是否有效 0:无效 1:有效 2:全部</param>
        /// <returns></returns>
        public ObjectTable GetUserGroup(int status)
        {
            string sql = string.Empty;
            if (status != 2)
                sql += "this.Valid=" + status;
            return new ObjectTable(typeof(SYS_Group), sql);
        }

        /// <summary>
        /// 根据ID获取用户组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SYS_Group GetGroupByID(int id)
        {
            return (SYS_Group)ObjectRow.Load(typeof(SYS_Group), "this.GroupID='" + id + "'");
        }

        /// <summary>
        /// 根据用户组获取权限
        /// </summary>
        /// <param name="GroupID">用户组编号</param>
        /// <returns></returns>
        public DataTable LoadAuth(int GroupID, int isDisplay)
        {
            string sql = @"select *
                            from SYS_USER_ROLE
	                            inner join SYS_MENU on SYS_USER_ROLE.MenuID=SYS_MENU.MenuID
                            where 1=1";
            if (isDisplay != 2)
                sql += " and IsDisplay=" + isDisplay;

            if (GroupID != 0)
                sql += " and GroupID=" + GroupID;

            return EBest.Data.SqlData.OpenSql(sql).Tables[0];
        }

        /// <summary>
        /// 读取所有模块
        /// </summary>
        /// <returns></returns>
        public ObjectTable LoadModules()
        {
            return new ObjectTable(typeof(SYS_MODULE), "");
        }

        /// <summary>
        /// 根据模块编号获取菜单
        /// </summary>
        /// <param name="ModuleID">模块编号</param>
        /// <param name="isDisplay">是否显示 0:不显示 1:显示 2:全部</param>
        /// <returns></returns>
        public ObjectTable LoadItems(int ModuleID, int isDisplay)
        {
            string sql = "this.ModuleID='" + ModuleID + "' ";
            if (isDisplay != 2)
                sql += " and this.IsDisplay=" + isDisplay;
            return new ObjectTable(typeof(SYS_MENU), sql);
        }

        /// <summary>
        /// 某用户组对某个菜单是否已有权限
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public static bool IsExistRole(string GroupID, string MenuID)
        {
            SYS_USER_ROLE roles = (SYS_USER_ROLE)ObjectRow.Load(typeof(SYS_USER_ROLE), "this.GroupID='" + GroupID + "' and this.MenuID='" + MenuID + "'");

            return (roles == null) ? false : true;
        }

        /// <summary>
        /// 返回用户组的权限
        /// </summary>
        /// <param name="GroupID">用户组编号</param>
        /// <returns></returns>
        public DataTable GetUserRole(int GroupID, int isDisplay)
        {
            string sql = @"select GroupID,SYS_MODULE.ModuleName,SYS_MODULE.ICON,SYS_MENU.MenuName
		                            ,SYS_MENU.LINK
                            from SYS_USER_ROLE
		                            inner join SYS_MENU on SYS_USER_ROLE.MenuID=SYS_MENU.MenuID
		                            inner join SYS_MODULE on SYS_MENU.ModuleID=SYS_MODULE.ModuleID";
            sql += " where GroupID='" + GroupID + "' ";

            if (isDisplay != 2)
                sql += " and IsDisplay=" + isDisplay;

            sql += " ORDER BY SYS_MODULE.PageIndex,SYS_MENU.PageIndex";

            return EBest.Data.SqlData.OpenSql(sql).Tables[0];
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="GroupID">用户组</param>
        /// <param name="MenuID">菜单编号</param>
        /// <param name="IsAdd">是否添加</param>
        public static void SetRole(string GroupID, string MenuID, bool IsAdd)
        {
            //添加权限
            if (IsAdd)
            {
                //未有此权限
                if (!IsExistRole(GroupID, MenuID))
                {
                    SYS_USER_ROLE roles = new SYS_USER_ROLE();
                    roles.GroupID = int.Parse(GroupID);
                    roles.MenuID = int.Parse(MenuID);
                    roles.Save();
                }
            }
            //取消权限
            else
            {
                //有此权限
                if (IsExistRole(GroupID, MenuID))
                {
                    SYS_USER_ROLE roles = (SYS_USER_ROLE)ObjectRow.Load(typeof(SYS_USER_ROLE), "this.GroupID='" + GroupID + "' and this.MenuID='" + MenuID + "'");
                    roles.Delete();
                }
            }

        }

    }
}
