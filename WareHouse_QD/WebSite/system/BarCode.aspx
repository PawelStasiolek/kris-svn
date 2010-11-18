<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarCode.aspx.cs" Inherits="system_BarCode" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <input id="Hidden1" type="hidden" runat="server" value="2" />
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
                    拼柜查询
                </td>
            </tr>
        </table>
        <br />
        <table id="wsd_inputtable">
            <tr>
                <td class="tabletitle" colspan="3">
                    查询条件
                </td>
            </tr>
            <tr>
                <td class="tablefield" style="width: 20%">
                    柜号:
                </td>
                <td>
                    <input class="wsd_input" id="txtContainer" type="text" runat="server" />
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="buttonarea" colspan="3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContainer"
                        ErrorMessage="请输入柜号!"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnQuery" runat="server" Text="查  询" CssClass="wsd_button2" OnClick="btnQuery_Click" />
                    &nbsp;
                    <asp:Button ID="btnQuery0" runat="server" Text="导出Excel" CssClass="wsd_button2" OnClick="btnQuery0_Click" />
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
                                    <asp:GridView Width="100%" ID="gvBarcodeList" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="没有可显示的数据...." EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-HorizontalAlign="Center">
                                        <HeaderStyle CssClass="titlist" />
                                        <Columns>
                                            <asp:BoundField HeaderText="托盘号" DataField="PALLET_CODE" />
                                            <asp:BoundField HeaderText="产品编号" DataField="PRODUCT_CODE" />
                                            <asp:BoundField HeaderText="操作人" DataField="REC_USER_CODE" />
                                            <asp:BoundField HeaderText="扫描时间" DataField="REC_TIME_STAMP" HtmlEncode="false" DataFormatString="{0:yyyy年MM月dd日 HH:mm:ss}" />
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
