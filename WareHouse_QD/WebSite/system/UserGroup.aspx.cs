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

public partial class system_UserGroup :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //编辑
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int id = int.Parse(Request["id"]);

                SYS_Group group = new RoleManager().GetGroupByID(id);

                if (group != null)
                {
                    txtMsg.InnerText = "编辑用户组";
                    txtName.Text = group.GroupName;
                    chkActive.Checked = group.Valid == "1";
                    btnSave.Text = "修  改";
                    btnCancel.Visible = true;
                }
                else
                {
                    Response.Write("非法访问!");
                    Response.End();
                }
            }
            else
            {
                txtMsg.InnerText = "新增用户组";
                btnSave.Text = "保  存";
                btnCancel.Visible = false;
                chkActive.Checked = false;
                chkActive.Disabled = true;
            }


            BindGroup();
        }
    }

    /// <summary>
    /// 绑定组
    /// </summary>
    protected void BindGroup()
    {
        GridView1.DataSource = new RoleManager().GetUserGroup(2);
        GridView1.DataBind();
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SYS_Group group;

        //新增
        if (string.IsNullOrEmpty(Request["id"]))
            group = new SYS_Group();
        else
            group = new RoleManager().GetGroupByID(int.Parse(Request["id"]));

        group.GroupName = txtName.Text.Trim();
        group.Valid = chkActive.Checked ? "1" : "0";
        group.UpdateBy = UserInfo.Name;
        group.LastDate = DateTime.Now;

        group.Save();

        Response.Redirect(Request.Path);



    }
}
