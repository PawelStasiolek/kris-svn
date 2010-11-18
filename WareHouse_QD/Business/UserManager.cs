using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EBest.Persistent;
using EBest.Data;
using eBest.Entity;

namespace eBest.Business
{
    public class UserManager
    {

        #region 登录是否成功
        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static TB_User Login(string name, string pwd, out string errorString)
        {
            errorString = string.Empty;

            //根据用户名从本地数据库中找出相应记录
            TB_User user = (TB_User)ObjectRow.Load(typeof(TB_User), "this.LoginName='" + name + "'");

            //未找到登录信息则登录失败
            if (user == null)
            {
                errorString = "此用户名不存在！";
                return user;
            }

            //帐号锁定
            if (user.Valid=="0")
                errorString = "拒绝登录，您的帐号已被锁定！";

            //密码错误
            if (pwd != user.Passsword)
                errorString = "密码不正确！";

            //如果登录失败，计算失败次数
            if (errorString != string.Empty)
            {
                if (user != null)
                    user.FailCount++;
            }
            else
            {
                user.FailCount = 0;
                user.LastLoginDate = DateTime.Now;
            }

            user.Save();

            return user;

        }
        #endregion

        /// <summary>
        /// 获取随机密码
        /// </summary>
        /// <param name="n">位数</param>
        /// <returns></returns>
        public static string GetRandom(int n)
        {
            string[] str = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string pwd = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                pwd += str[rnd.Next(str.Length)];

            return pwd;
        }

        /// <summary>
        /// 根据登录名查找用户信息
        /// </summary>
        /// <param name="uid">登录名</param>
        /// <returns></returns>
        public TB_User GetUserByLoginName(string loginName)
        {
            return (TB_User)ObjectRow.Load(typeof(TB_User), "this.LoginName='" + loginName + "'");
        }

        /// <summary>
        /// 根据UserID查找用户信息
        /// </summary>
        /// <param name="uid">UID</param>
        /// <returns></returns>
        public TB_User GetUserByID(string ID)
        {
            return (TB_User)ObjectRow.Load(typeof(TB_User), "this.ID='" + ID + "'");
        }

        public DataTable GetUserList(string userName, string groupID, int isActive)
        {
            string valid = null;

            if (isActive == 0)
                valid = "0";
            else if (isActive == 1)
                valid = "1";

            return EBest.Data.SqlData.OpenSP("[QueryUserList]", userName, groupID, valid).Tables[0];
        }



        /// <summary>
        /// 是否存在同名帐号
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistLoginName(string loginName)
        {
            TB_User employee = (TB_User)ObjectRow.Load(typeof(TB_User), "this.LoginName='" + loginName + "'");
            return employee == null ? false : true;
        }

        public static string GetCurrentSequence(string tableName)
        {
            return EBest.Data.SqlData.OpenSP("[GetCurrentSequence]", tableName).Tables[0].Rows[0][0].ToString();

        }

    }
}
