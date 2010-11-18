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
using System.Text;
using eBest.Business;
using eBest.Entity;

public partial class MenuPage : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string LoadMenuItem()
    {

        StringBuilder builder = new StringBuilder();
        builder.Append("    <script language=\"JavaScript\">");
        builder.Append(" function additemsto() {");
        builder.Append("");

        DataTable dt = null;
        dt = new RoleManager().GetUserRole(new UserManager().GetUserByID(UserInfo.UserID.ToString()).GroupID, 1);
        string TempModule = string.Empty;
        string Module = string.Empty;

        foreach (DataRow row in dt.Rows)
        {
            Module = row["ModuleName"].ToString();
            if (Module != TempModule)
            {
                builder.Append(string.Format("t=outlookbar.addtitle('{0}','{1}');", row["ModuleName"], row["ICON"]));
                builder.Append(string.Format("outlookbar.additem('{0}',t,'{1}');", row["MenuName"], row["Link"]));
                TempModule = Module;
            }
            else
            {
                builder.Append(string.Format("outlookbar.additem('{0}',t,'{1}');", row["MenuName"], row["Link"]));
            }
        }

        builder.Append("}    </script>");

        return builder.ToString();

    }

    protected string LoadTopMenu()
    {
        DataTable dt = null;
        dt = new RoleManager().GetUserRole(new UserManager().GetUserByID(UserInfo.UserID.ToString()).GroupID,1);
        string TempModule = string.Empty;

        if (dt.Rows.Count == 0)
        {
            return "<script>alert('未给该户分配角色')</script>";
        }
        else
            return "<script type=\"text/javascript\" language=\"javascript\">additemsto();locatefold(\"\");outlookbar.show();</script>";
    }
}
