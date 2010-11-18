<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="system_Inventory" %>

<%@ Register Assembly="SmartControl" Namespace="SmartControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet">

    <script src="../javascript/Calendar/calendar.js" type="text/javascript"></script>

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
                    入库查询
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
                    日期:
                </td>
                <td>
                    <input class="wsd_input" id="txtDate" type="text" runat="server" onfocus="calendar()" /><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="请选择日期!">*</asp:RequiredFieldValidator>
                </td>
                <td class="tablefield">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="buttonarea" colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
                <td class="buttonarea" colspan="2">
                    <asp:Button ID="btnQuery" runat="server" Text="查  询" CssClass="wsd_button2" OnClick="btnQuery_Click" />
                    &nbsp;
                    <asp:Button ID="btnExport" runat="server" Text="导出Excel" CssClass="wsd_button2" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_listtable">
            <tr>
                <td>
                    <div style="overflow-y: auto; height: 300px">
                        <table width="100%" cellpadding="0px" cellspacing="0px">
                            <tr width="100%">
                                <td>
                                    <cc1:SmartGridView Width="100%" ID="gvBarcodeList" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="没有可显示的数据...." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-HorizontalAlign="Center">
                                        <HeaderStyle CssClass="titlist" />
                                        <Columns>
                                            <asp:BoundField HeaderText="产品条码" DataField="PRODUCT_CODE">
                                                <ItemStyle Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="托盘数" DataField="SUM_PALLET">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="托盘条码" DataField="PALLET_CODE">
                                                <ItemStyle Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="扫描人" DataField="REC_USER_CODE">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="扫描时间" DataField="REC_TIME_STAMP" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="evenline" />
                                        <AlternatingRowStyle CssClass="oddline" />
                                        <PagerSettings Visible="False" />
                                    </cc1:SmartGridView>
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
