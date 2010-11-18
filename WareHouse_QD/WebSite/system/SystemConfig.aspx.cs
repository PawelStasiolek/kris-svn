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

public partial class system_SystemConfig : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSave.OnClientClick = "Submit(this);";

            txtComany.Text = ConfigManager.Load(ConfigType.CompanyName).Value;
            txtComanyUrl.Text = ConfigManager.Load(ConfigType.CompanyUrl).Value;
            txtTelePhone.Text = ConfigManager.Load(ConfigType.CompanyTel).Value;
            txtFax.Text = ConfigManager.Load(ConfigType.CompanyFax).Value;

            ddlMobileGroup.DataSource = ddlMobileGroup.DataSource = new RoleManager().GetUserGroup(1);
            ddlMobileGroup.DataTextField = ddlMobileGroup.DataTextField = "GroupName";
            ddlMobileGroup.DataValueField = ddlMobileGroup.DataValueField = "GroupID";
            ddlMobileGroup.DataBind();
            ddlMobileGroup.SelectedValue = ConfigManager.Load(ConfigType.MobileGroup).Value;


        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ConfigManager.SaveConfig(ConfigType.CompanyName, txtComany.Text.Trim());
            ConfigManager.SaveConfig(ConfigType.CompanyUrl, txtComanyUrl.Text.Trim());
            ConfigManager.SaveConfig(ConfigType.CompanyTel, txtTelePhone.Text.Trim());
            ConfigManager.SaveConfig(ConfigType.CompanyFax, txtFax.Text.Trim());

            ConfigManager.SaveConfig(ConfigType.MobileGroup, ddlMobileGroup.SelectedValue);

            Response.Write("<script>alert('保存成功!')</script>");
            Server.Transfer(Request.RawUrl);
        }
        catch (Exception error)
        {
            ShowMessage("保存失败,请联系管理员!");
        }
    }
}
