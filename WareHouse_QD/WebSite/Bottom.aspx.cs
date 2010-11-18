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

public partial class Bottom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            copyright.HRef = ConfigManager.Load(ConfigType.CompanyUrl).Value;
            copyright.InnerText = ConfigManager.Load(ConfigType.CompanyName).Value;
        }
    }
}
