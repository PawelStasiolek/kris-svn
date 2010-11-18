<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRole.aspx.cs" Inherits="system_UserRole" %>

<html>
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
    function selectModule(obj)
    {
        var checks=obj.parentNode.parentNode.childNodes[1].childNodes[0].getElementsByTagName("input");
        
        for (i=0;i<checks.length;i++)
        {
            if (obj.checked==true)
                checks[i].checked=true;
            else
                checks[i].checked=false;
        }  

    }
    </script>

</head>
<body class="wsd_option_area">
    <form id="Form1" runat="server">
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
                    权限管理
                </td>
            </tr>
        </table>
    <br />
    <table id="wsd_inputtable">
        <tr>
            <td class="tabletitle" colspan="2">
                查询表单
            </td>
        </tr>
        <tr>
            <td width="16%" class="tablefield">
                用户组:
            </td>
            <td width="84%" id="lblGroup" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Repeater ID="RptModule" runat="server" OnItemDataBound="RptModule_ItemDataBound">
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td class="tablefield" width="16%">
                                    <%# Eval("ModuleName")%>:<input id="Checkbox1" type="checkbox" onclick="selectModule(this)"
                                        runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBoxList ID="chkRole" runat="server" RepeatColumns="5" RepeatLayout="Flow">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
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
                <asp:Button ID="btnSave" runat="server" class="wsd_button2" Text="保  存" OnClick="btnSave_Click" />
                <input id="Button1" type="button" class="wsd_button2" value="取  消" onclick="location.href='UserGroup.aspx'" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
