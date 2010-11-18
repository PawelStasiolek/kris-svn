<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserGroup.aspx.cs" Inherits="system_UserGroup" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户组管理</title>
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
                    用户组
                </td>
            </tr>
        </table>
         <br />
        <table id="wsd_inputtable">
            <tr>
                <td class="tabletitle" style="height: 21px" width="100%">
                    用户组列表
                </td>
            </tr>
        </table>
        <table id="wsd_listtable">
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100%">
                                <asp:GridView Width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    EnableEmptyContentRender="true" DataKeyNames="GroupID">
                                    <HeaderStyle CssClass="titlist" />
                                    <Columns>
                                    <asp:TemplateField HeaderText="组名称">
                                            <ItemTemplate>
                                                <a href='UserGroup.aspx?id=<%# Eval("GroupID") %>'>
                                                    <%# Eval("GroupName")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否有效">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean((Eval("Valid").ToString()=="1")?"True":"False") %>'/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <a href='UserRole.aspx?id=<%# Eval("GroupID") %>'>
                                                    分配权限</a>
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
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td class="tabletitle" colspan="4">
                    <p runat="server" id="txtMsg">
                        
                    </p>
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="height: 10px; width: 15%;">
                    组名称:
                </td>
                <td width="15%" style="height: 10px">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="10"></asp:TextBox>
                    <span class="keyword">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ControlToValidate="txtName" ErrorMessage="组名称不能为空"></asp:RequiredFieldValidator>
                    </span>
                </td>
                <td class="tablefield" width="20%" style="height: 10px">
                    &nbsp;
                </td>
                <td width="15%" style="height: 10px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tablefield">
                    
                    禁用:</td>
                <td valign="top">
                    
                    <input id="chkActive" type="checkbox" runat="server" /></td>
                <td class="tablefield" colspan="2">
                    
                </td>
            </tr>
            <tr>
                <td class="buttonarea" valign="top" colspan="4">
                    
                    <asp:Button ID="btnSave" runat="server" Text="保  存" CssClass="wsd_button2" 
                        onclick="btnSave_Click"/>
                    <input id="btnCancel" type="button" value="取  消" class="wsd_button2" runat="server" onclick="location.href='UserGroup.aspx'"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

