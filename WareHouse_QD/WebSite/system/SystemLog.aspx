<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemLog.aspx.cs" Inherits="system_SystemLog" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet" />

    <script src="../javascript/Calendar/calendar.js" type="text/javascript"></script>

    <script src="../javascript/Comm.js" type="text/javascript"></script>

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
                    系统日志
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
                    开始日期:
                </td>
                <td style="width: 20%">
                    <input class="wsd_input" id="txtStart" type="text" runat="server" onfocus="calendar()" />
                </td>
                <td class="tablefield" style="width: 14%">
                    结束日期:
                </td>
                <td class="style1">
                    <input class="wsd_input" id="txtEnd" type="text" runat="server" onfocus="calendar()" />
                </td>
            </tr>
            <tr>
                <td class="tablefield">
                    日志类型:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLogType" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="tablefield">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="buttonarea" colspan="4">
                    <asp:Button ID="btnQuery" runat="server" Text="查  询" CssClass="wsd_button2" OnClick="btnQuery_Click"
                        UseSubmitBehavior="false" />
                </td>
            </tr>
        </table>
        <br />
        
        <table id="wsd_listtable">
            <tr>
                <td>
                <div style="overflow:auto; height:270px">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr width="100%">
                            <td>
                                <asp:GridView Width="100%" ID="GvLogList" runat="server" AutoGenerateColumns="False" EnableViewState="false">
                                    <Columns>
                                        <asp:BoundField DataField="TypeName" HeaderText="日志类型">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Text" HeaderText="内容">
                                            <ItemStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LastDate" HeaderText="创建日期" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UpdateBy" HeaderText="执行人">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="titlist" />
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

