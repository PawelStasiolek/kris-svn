<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="system_EditUser" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增帐户</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet">

    <script src="../javascript/Comm.js" type="text/javascript"></script>
    <script src="../javascript/Comm.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
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
                    新增/编辑用户
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td colspan="2" class="tabletitle">
                    输入表单
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img src="../resources/images/prompt/notice.jpg" />
                    <font color="red" size="2"><b>提示:*为必填项</b></font>
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%; height: 25px;">
                    <span class="keyword">*</span>姓名:
                </td>
                <td class="style1">
                    <input id="txtUser" type="text" runat="server" /><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" 
                        ErrorMessage="请填写姓名!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trLoginName" runat="server">
                <td class="tablefield" style="width: 15%; height: 25px;">
                    <span class="keyword">*</span>
                    登录帐号:
                </td>
                <td nowrap="nowrap" class="style1">
                    <input id="txtLoginName" type="text" runat="server" /><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginName" 
                        ErrorMessage="请填写登录帐号!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%; height: 25px;">
                    电子邮件:
                </td>
                <td nowrap="nowrap" class="style1">
                    <input id="txtEmail" type="text" runat="server" size="30"/></td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%; height: 25px;">
                    所属用户组:
                </td>
                <td nowrap="nowrap" class="style1">
                    <asp:DropDownList ID="ddlGroup" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%; height: 25px;">
                    是否有效:
                </td>
                <td nowrap="nowrap" class="style1">
                    <input id="chkActive" type="checkbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%; height: 25px;" id="txtAdd" 
                    runat="server">
                    继续添加:
                </td>
                <td nowrap="nowrap" class="style1">
                    <input id="chkAdd" type="checkbox" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 15%" runat="server">
                    </td>
                <td nowrap="nowrap">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td width="100%" class="tabletitle">
                    操作选项
                </td>
            </tr>
            <tr>
                <td class="buttonarea">
                    <asp:Button ID="btnSave" runat="server" Text="保  存" CssClass="wsd_button2" OnClick="btnSave_Click" UseSubmitBehavior="false" /><input
                        id="Button2" type="button" value="返  回" class="wsd_button2" onclick="history.back()" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
