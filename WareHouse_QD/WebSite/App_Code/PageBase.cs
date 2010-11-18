using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : Page
{
    public PageBase()
    {

    }
    /// <summary>
    /// 用户信息
    /// </summary>
    public UserInfo UserInfo
    {
        get
        {
            if (Session["_UserInfo"] == null)
            {
                UserInfo info = new UserInfo();
                Session["_UserInfo"] = info;
            }
            return (UserInfo)Session["_UserInfo"];
        }
        set
        {
            Session["_UserInfo"] = value;
        }
    }

    /// <summary>
    /// 显示alert提示框
    /// </summary>
    /// <param name="message"></param>
    public void ShowMessage(string message)
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "", string.Format("alert(\"{0}\")", message), true);
    }

    #region "Export Excel"
    public void ExportGridView(GridView gv, string filename)
    {
        Response.Clear();

        string attachment = "attachment; filename=" + filename + ".xls";
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        //Response.Charset = "gb2312"; 
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");


        //HttpContext.Current.Response.ContentType = "application/ms-excel";
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=gb2312>");
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        // Create a form to contain the grid

        HtmlForm frm = new HtmlForm();
        gv.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(gv);
        frm.RenderControl(htw);

        //GridView1.RenderControl(htw);

        Response.Write(sw.ToString());
        Response.End();
    }
    #endregion

}
