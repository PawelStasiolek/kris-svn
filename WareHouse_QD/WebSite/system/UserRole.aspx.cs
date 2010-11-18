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
using EBest.Persistent;
using eBest.Business;
using eBest.Entity;

public partial class system_UserRole :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (string.IsNullOrEmpty(Request["id"]))
            {
                Response.Write("非法访问!");
                Response.End();
                return;
            }

            SYS_Group group = new RoleManager().GetGroupByID(int.Parse(Request["id"].ToString()));

            if (group == null)
            {
                Response.Write("该用户组不存在!");
                Response.End();
                return;
            }

            lblGroup.InnerText = group.GroupName;
            BindModule();
        }
    }

    #region 绑定模块
    protected void BindModule()
    {
        RptModule.DataSource = new RoleManager().LoadModules();
        RptModule.DataBind();
    }
    #endregion

    #region 绑定列表
    protected void RptModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int i = 0;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //获取模块
            SYS_MODULE module = (SYS_MODULE)e.Item.DataItem;

            //获取用户组的权限
            DataTable auths = new RoleManager().LoadAuth(int.Parse(Request["id"]), 2);

            if (module != null)
            {
                CheckBoxList cbx = (CheckBoxList)e.Item.FindControl("chkRole");
                cbx.Items.Clear();

                //获取当前模块下的所有页面
                ObjectTable items = new RoleManager().LoadItems(module.ModuleID, 2);

                foreach (ObjectRow row in items)
                {
                    SYS_MENU item = (SYS_MENU)row;

                    ListItem list = new ListItem(item.MenuName, item.MenuID.ToString());

                    //遍历是否选中
                    foreach (DataRow row2 in auths.Rows)
                    {
                        if ((int)row2["MenuID"] == item.MenuID)
                        {
                            list.Selected = true;
                            i++;
                            break;
                        }
                    }
                    cbx.Items.Add(list);
                }

                HtmlInputCheckBox check = (HtmlInputCheckBox)e.Item.FindControl("Checkbox1");
                if (i == items.Count)
                    check.Checked = true;
            }
        }


    }
    #endregion

    #region 保存
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //遍历Repeater
        foreach (RepeaterItem item in RptModule.Items)
        {
            CheckBoxList cbxList = (CheckBoxList)item.FindControl("chkRole");

            //遍历checkbox
            foreach (ListItem cbx in cbxList.Items)
            {
                //设置权限
                RoleManager.SetRole(Request["id"], cbx.Value, cbx.Selected);
            }
        }
        Response.Redirect("UserGroup.aspx");
    }
    #endregion
}
