<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>仓库移动管理系统</title>
    <style type="text/css">
        div
        {
            padding-top: 5%;
            position: relative;
            z-index: 2;
        }
        table
        {
            font-size: 12px;
            font-family: Arial, Helvetica, sans-serif;
            position: relative;
        }
        #box
        {
            padding-top: 0px;
            padding-left: 10px;
            padding-bottom: 50px;
            padding-right: 50px;
            position: relative;
        }
        body
        {
            background-image: url(resources/images/login/background%20img.gif);
            text-align: center;
            position: relative;
        }
        .button
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            padding-top: 4px;
            color: #ffffff;
            background-image: url(resources/images/login/015.gif);
            font-weight: 400;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table style="width:553px; height:343px" border="0" cellpadding="0" cellspacing="0">
            <tr style="height:95px">
                <td style="background: url(resources/images/login/background_01.png) no-repeat; width:249px">
                    
                </td>
                <td style="background: url(resources/images/login/background_02.png) no-repeat; width:304px">
                </td>
            </tr>
            <tr>
                <td style="background: url(resources/images/login/background_03.png) no-repeat">
                    
                </td>
                <td style="background: url(resources/images/login/background_04.png) no-repeat">
                    <div id="box">
                        <table>
                            <tr>
                                <td align="right">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    密码：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPwd" runat="server" TextMode=Password></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    验证码：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtValidCode" runat="server" MaxLength="4" size="5"></asp:TextBox>
                                    <img src="ValidCode.aspx" width="48px" height="20px" onclick="location.href='index.aspx'" style="cursor:pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                    <br />
                                    <asp:Button ID="btnLogin" runat="server" Text="登  录" CssClass="button" OnClick="btnLogin_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input type="button" value="取  消" class="button" onclick="window.close();" />
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
