using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using eBest.Business;

/// <summary>
///UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    private decimal _UserID;
    private string _Name;
    private string _LoginName;
    private int _GroupID;
    public UserInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取或设置用户编号
    /// </summary>
    public decimal UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    /// <summary>
    /// 获取或设置用户名称
    /// </summary>
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    /// <summary>
    /// 获取或设置用户帐号
    /// </summary>
    public string LoginName
    {
        get { return _LoginName; }
        set { _LoginName = value; }
    }
    
    /// <summary>
    /// 设置或获取用户组
    /// </summary>
    public int GroupID
    {
        get { return _GroupID; }
        set { _GroupID = value; }
    }
}
