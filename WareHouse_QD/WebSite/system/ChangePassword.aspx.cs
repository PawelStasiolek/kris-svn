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
using eBest.Entity;
using eBest.Business;

public partial class system_ChangePassword : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        TB_User user = new UserManager().GetUserByID(UserInfo.UserID.ToString());

        string oldPwd = txtOld.Value.Trim().Replace("'", "''");
        string newPwd = txtNew.Value.Trim().Replace("'", "''");
        string confirmPwd = txtConfirm.Value.Trim().Replace("'", "''");

        string result = Check(oldPwd, newPwd, confirmPwd, user.Passsword);

        if (result != string.Empty)
        {
            lblMessage.Text = result;
            return;
        }

        user.Passsword = comm.EncryptMd5(newPwd);
        user.UpdateBy = UserInfo.Name;
        user.LastDate = DateTime.Now;

        try
        {
            user.Save();
        }
        catch (Exception error)
        {
            lblMessage.Text="修改密码失败,请联系管理员!";
        }

        LogManager.SaveLog(LogType.Operation, "修改登录密码", DateTime.Now, UserInfo.Name);

        lblMessage.Text="修改密码成功!";

        


    }
    protected string Check(string oldPwd, string newPwd, string confirmPwd, string rightPwd)
    {
        if (string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirmPwd))
            return "请输入新密码!";
        if (newPwd != confirmPwd)
            return "两次密码输入不一致!";
        if (comm.EncryptMd5(oldPwd) != rightPwd)
            return "原密码输入错误!";
        return string.Empty;
    }
}
