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

public partial class Head : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text = UserInfo.Name;
        Response.Write("<script>var current_ms=" + (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds + "</script>");

    }
}
