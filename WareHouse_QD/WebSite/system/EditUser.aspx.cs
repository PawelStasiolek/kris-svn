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

public partial class system_EditUser : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.OnClientClick = "Submit(this);";
            //绑定用户组
            BindGroup();

            //是否有参数传过来
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                //得到userID
                string id = Request["id"];

                TB_User employee = new UserManager().GetUserByID(id.ToString());

                txtLoginName.Disabled = true;
                chkActive.Disabled = false;
                chkAdd.Visible = false;
                txtAdd.InnerText = "";

                //用户信息是否存在
                if (employee != null)
                {
                    txtUser.Value = employee.Name;
                    txtLoginName.Value = employee.LoginName;
                    txtEmail.Value = employee.Email;
                    chkActive.Checked = employee.Valid == "1";
                    ddlGroup.SelectedValue = employee.GroupID.ToString();

                }
                else
                {
                    Response.Write("非法访问!");
                    Response.End();
                }

            }
            else
            {
                chkActive.Disabled = true;
                chkActive.Checked = true;
            }
        }
    }

    protected void BindGroup()
    {
        ddlGroup.DataSource = new RoleManager().GetUserGroup(1);
        ddlGroup.DataTextField = "GroupName";
        ddlGroup.DataValueField = "GroupID";
        ddlGroup.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isNew = false;
        TB_User employee;

        //生成随机密码
        string pwd = UserManager.GetRandom(6);

        //新增
        if (string.IsNullOrEmpty(Request["id"]))
        {
            isNew = true;
            employee = new TB_User();
            employee.Passsword = comm.EncryptMd5("111");
            employee.GroupID = int.Parse(ddlGroup.SelectedValue);


            employee.LoginName = txtLoginName.Value.Trim();

            //判断是否存在相同登录名
            if (new UserManager().ExistLoginName(txtLoginName.Value.Trim().Replace("'", "''")))
            {
                ShowMessage("该登录名已经存在");
                return;
            }

        }
        else
            employee = new UserManager().GetUserByID(Request["id"].ToString());

        employee.Name = txtUser.Value.Trim();
        employee.UpdateBy = UserInfo.Name;
        employee.LastDate = DateTime.Now;
        employee.Email = txtEmail.Value.Trim();
        employee.Valid = chkActive.Checked ? "1" : "0";


        employee.Save();

        if (isNew)
        {

            #region 写日志

            LogManager.SaveLog(LogType.Operation, "创建登录帐号 " + txtUser.Value.Trim(), DateTime.Now, UserInfo.Name);

            #endregion

        }

        if (chkAdd.Checked)
            Response.Redirect("EditUser.aspx");
        else
            Response.Redirect("UserList.aspx");



    }

}
