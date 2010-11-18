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

public partial class system_SystemLog : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnQuery.OnClientClick = "Submit(this);";
            ddlLogType.DataSource = new LogManager().GetLogType();
            ddlLogType.DataValueField = "LogTypeID";
            ddlLogType.DataTextField = "TypeName";
            ddlLogType.DataBind();
            txtStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        DateTime start = txtStart.Value.Trim() == string.Empty ? DateTime.MinValue : DateTime.Parse(txtStart.Value.Trim());
        DateTime end = txtEnd.Value.Trim() == string.Empty ? DateTime.MinValue : DateTime.Parse(txtEnd.Value.Trim());

        GvLogList.DataSource = new LogManager().GetLogByType((LogType)Enum.Parse(typeof(LogType), ddlLogType.SelectedValue), start, end);
        GvLogList.DataBind();


    }
}
