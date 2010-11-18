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

public partial class system_UserList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGroup();
        }
    }

    protected void BindGroup()
    {
        ddlGroup.DataSource = new RoleManager().GetUserGroup(1);
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "GroupID";
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("--全部--", ""));
    }

    protected void BindData()
    {
        GvUserList.DataSource = new UserManager().GetUserList(txtName.Value.Trim(), ddlGroup.SelectedValue, int.Parse(Hidden1.Value));
        GvUserList.DataBind();
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void GvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reset")
        {
            TB_User user = new UserManager().GetUserByID(e.CommandArgument.ToString());

            string pwd = UserManager.GetRandom(6);

            user.Passsword = comm.EncryptMd5("111");
            user.LastDate = DateTime.Now;
            user.UpdateBy = UserInfo.Name;
            user.Save();

            #region 写日志

            LogManager.SaveLog(LogType.Operation, "重置登录帐号 " + user.Name, DateTime.Now, UserInfo.Name);

            #endregion

            LogManager.SaveLog(LogType.Operation, "重置 \"" + user.LoginName + "\" 登录密码", DateTime.Now, UserInfo.Name);
            ShowMessage("密码初始化成功！");



        }
    }
}
