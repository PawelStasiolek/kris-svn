<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="system_UserList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="wsd_title">
            <tr>
                <td class="wsd_titlefont">
                    您当前的位置
                </td>
                <td class="wsd_2rightarrow">
                    &nbsp;
                </td>
                <td class="wsd_titlefont2">
                    系统管理
                </td>
                <td class="wsd_1rightarrow">
                    &nbsp;
                </td>
                <td class="wsd_titlefont1">
                    用户管理
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td class="tabletitle" colspan="4">
                    查询条件
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 20%">
                    姓名:
                </td>
                <td style="width: 20%">
                    <input class="wsd_input" id="txtName" type="text" runat="server" />
                </td>
                <td class="tablefield" style="width: 14%">
                    用户组:
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddlGroup" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tablefield" colspan="2">
                </td>
                <td>
                </td>
                <td>
                    <input id="rdActive" type="radio" onclick="Hidden1.value=this.value" value="1" name="rd"
                        runat="server" />启用
                    <input id="rdInActive" type="radio" onclick="Hidden1.value=this.value" value="0"
                        name="rd" runat="server" />禁用
                    <input id="rdAll" type="radio" onclick="Hidden1.value=this.value" value="2" name="rd"
                        checked runat="server" />全部
                    <input id="Hidden1" type="hidden" runat="server" value="2" />
                </td>
            </tr>
            <tr>
                <td class="buttonarea" colspan="4">
                    <asp:Button ID="btnQuery" runat="server" Text="查  询" CssClass="wsd_button2" OnClick="btnQuery_Click" />
                    <input id="btnAdd" type="button" value="新  增" class="wsd_button2" onclick="location.href='EditUser.aspx'" />
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td class="tabletitle" style="height: 21px" width="100%">
                    用户列表
                </td>
            </tr>
        </table>
        <table id="wsd_listtable">
            <tr>
                <td>
                    <div style="overflow-y: auto; height: 240px">
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                            <tr width="100%">
                                <td>
                                    <asp:GridView Width="100%" ID="GvUserList" runat="server" AutoGenerateColumns="False"
                                        OnRowCommand="GvUserList_RowCommand">
                                        <HeaderStyle CssClass="titlist" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="姓名">
                                                <ItemTemplate>
                                                    <a href='EditUser.aspx?id=<%# Eval("ID") %>'>
                                                        <%# Eval("Name")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="登录帐号" DataField="LoginName" />
                                            <asp:BoundField HeaderText="邮件地址" DataField="Email" />
                                            <asp:BoundField HeaderText="所属用户组" DataField="GroupName" />
                                            <asp:TemplateField HeaderText="禁用">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# !Convert.ToBoolean((Eval("Valid").ToString()=="1")?"True":"False") %>'
                                                        Enabled="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" CssClass="wsd_pagebutton" runat="server" Text="重置密码" CommandArgument='<%# Eval("ID") %>'
                                                        CommandName="reset" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="evenline" />
                                        <AlternatingRowStyle CssClass="oddline" />
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
