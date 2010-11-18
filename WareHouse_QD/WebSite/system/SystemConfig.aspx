<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemConfig.aspx.cs" Inherits="system_SystemConfig" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../resources/styles/style.css" rel="stylesheet" type="text/css" />

    <script src="../javascript/Comm.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            height: 35px;
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
                    系统配置
                </td>
            </tr>
        </table>
        <br />
        <div style="overflow-y: auto; height: 330px">
            <table id="wsd_inputtable" border="1">
                <tr>
                    <td colspan="2" class="tabletitle">
                        输入表单
                    </td>
                </tr>
                <tr>
                    <td class="tablefield" style="width: 15%; height: 35px;">
                        终端用户组:
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="ddlMobileGroup" runat="server">
                        </asp:DropDownList>
                        <span style="color:Red">* 只有该组的用户才能登录终端</span></td>
                </tr>
                <tr>
                    <td class="tablefield" style="width: 15%; height: 35px;">
                        公司名称:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtComany" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tablefield" style="width: 15%; height: 35px;">
                        公司网址:
                        <td class="style1">
                            <asp:TextBox ID="txtComanyUrl" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="tablefield" style="width: 15%; height: 35px;">
                        公司电话:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtTelePhone" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tablefield" style="width: 15%; height: 35px;">
                        公司传真:
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtFax" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td width="100%" class="tabletitle">
                    操作选项
                </td>
                <td class="buttonarea">
                    <asp:Button ID="btnSave" runat="server" class="wsd_button2" Text="保  存" OnClick="btnSave_Click"
                        UseSubmitBehavior="false" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
