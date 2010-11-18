using System;
using System.Data;
using System.Web;
using System.Web.Security;
using eBest.Business;

/// <summary>
///MyModule 的摘要说明
/// </summary>
public class MyModule : IHttpModule
{
    public MyModule()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public void Init(HttpApplication context)
    {
        context.AcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
        context.Error += new EventHandler(this.Application_Error);
    }

    private void Application_Error(Object source, EventArgs e)
    {
        HttpContext context = ((HttpApplication)source).Context;
        System.Text.StringBuilder text = new System.Text.StringBuilder();

        text.AppendLine("引发异常页面: " + context.Request.Url.ToString());
        text.AppendLine("引发异常的方法: " + context.Error.InnerException.TargetSite.ToString());
        text.AppendLine("引发异常的对象: " + context.Error.InnerException.Source.ToString());
        text.AppendLine("引发异常的描述: " + context.Error.InnerException.Message);
        text.AppendLine("引发异常的堆栈: " + context.Error.InnerException.StackTrace);

        LogManager.SaveLog(LogType.Exception, text.ToString(), context.Timestamp, "System");

        context.Response.Clear();
        context.Response.Write("您访问的页面发生了错误！");
        context.Response.End();

    }

    private void Application_AcquireRequestState(Object source, EventArgs e)
    {
        HttpApplication Application = (HttpApplication)source;
        string path = Application.Context.Request.Path;
        string page = Application.Context.Request.AppRelativeCurrentExecutionFilePath;

        //非aspx页面不进行处理，放行
        if (!path.EndsWith(".aspx"))
            return;

        //在白名单里，放行
        if (filter(page))
            return;

        //未登录
        if (Application.Context.Session["_UserInfo"] == null)
        {
                Application.Context.Response.Write(string.Format("<a href=\"{0}://{1}/Index.aspx\" target=\"_parent\"=>您尚未登录或登录超时，请重新登录!</a>", Application.Context.Request.Url.Scheme, Application.Context.Request.Url.Authority + Application.Context.Request.ApplicationPath));
                Application.Context.Response.End();
        }
        //已登录
        else
        {
            
            UserInfo userinfo = (UserInfo)Application.Context.Session["_UserInfo"];

            DataTable roleTable = new RoleManager().GetUserRole(userinfo.GroupID, 2);

            foreach (DataRow row in roleTable.Rows)
            {
                if (page.ToLower() == "~/" + row["Link"].ToString().ToLower() || page.ToLower() == "~/index.aspx")
                    return;

            }

            Application.Context.Response.Write("对不起，您无权访问此页面!");
            Application.Context.Response.End();

        }


    }

    public void Dispose()
    {
    }

    public bool filter(string page)
    {
        bool success = false;
        string[] pass = { "~/Index.aspx", "~/head.aspx", "~/Menu.aspx", "~/ValidCode.aspx", "~/Bottom.aspx" };
        foreach (string str in pass)
        {
            if (str.ToLower() == page.ToLower())
            {
                success = true;
                break;
            }
        }
        return success;
    }


}
