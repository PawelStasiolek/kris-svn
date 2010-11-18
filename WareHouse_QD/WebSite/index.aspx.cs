using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using eBest.Business;
using eBest.Entity;

public partial class index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserInfo = null;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtValidCode.Text != Session["CheckCode"].ToString())
            {
                ShowMessage("验证码错误!");
                return;
            }
        }
        catch
        {
            Response.Redirect(Request.RawUrl);
        }

        //用户名
        string userName = txtUser.Text.Trim().Replace("'", "''");

        //密码
        string password = txtPwd.Text.Trim().Replace("'", "''");

        //验证登录
        string errorString = string.Empty;
        TB_User user = UserManager.Login(userName, comm.EncryptMd5(password), out errorString);

        //如果登录失败
        if (errorString != string.Empty)
        {
            ShowMessage(errorString);

            //写入系统日志
            LogManager.SaveLog(LogType.Login, "系统登录失败 IP:" + comm.GetClientIP(), DateTime.Now, userName);

            return;
        }

        UserInfo.LoginName = userName;
        UserInfo.UserID = user.ID;
        UserInfo.GroupID = user.GroupID;
        UserInfo.Name = user.Name;

        //写入系统日志
        LogManager.SaveLog(LogType.Login, "系统登录成功 IP:" + comm.GetClientIP(), DateTime.Now, UserInfo.Name);

        //转到首页
        Server.Transfer("Main.htm");
    }
}
