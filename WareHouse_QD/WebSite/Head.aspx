<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Head.aspx.cs" Inherits="Head" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>天合光能供应商业信息交换平台</title>
    <link href="resources/styles/style.css" type="text/css" rel="stylesheet">

    <script language="javascript">
        function GetDate()
        {
            var date=new Date(current_ms);
            var str;
            var day=new Array("日","一","二","三","四","五","六");
            str="服务器时间:"+date.getFullYear()+"年"+(date.getMonth()+1)+"月"+date.getDate()+"日  ";
            str=str+"星期"+day[date.getDay()]+"  ";
            str=str+date.getHours()+":";
            if (date.getMinutes()<10)
                str=str+"0"+date.getMinutes()+":";
            else
                str=str+date.getMinutes()+":";
            if (date.getSeconds()<10)
                str=str+"0"+date.getSeconds();
            else
                str=str+date.getSeconds();
            document.getElementById("clock").innerText=str;
            current_ms+=1000;
            setTimeout("GetDate()",1000);
        }
        
    </script>

</head>
<body class="wsd_head_body">
    <form id="head" runat="server">
    <iframe id="workFrame" width="0" height="0" src=""></iframe> 
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td background="resources/images/head/banner.jpg" width="100%" height="59">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" height="23" width="100%" background="resources/images/head/headbg.gif">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="23">
                    <tr>
                        <td width="228" style="height: 23px">
                            &nbsp;
                        </td>
                        <td class="wsd_head_fontsz" style="height: 23px">
                            欢迎您登录,<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>!&nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="wsd_head_fontsz" style="height: 23px">
                        </td>
                        <td id="clock" style="font-size: 12px; color: #000000;" align="right">

                            <script>
							GetDate();
                            </script>

                        </td>
                        <td width="40" style="height: 24px">
                            <a href="" onclick="if(window.confirm('你确定要注销出系统吗？')) {window.top.location.replace('index.aspx');} else return false; ">
                                <img src="resources/images/head/logout.gif" border="0" width="78" height="23"></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
