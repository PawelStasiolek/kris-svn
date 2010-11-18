<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="system_ChangePassword" %>

<html>
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link href="../resources/styles/style.css" type="text/css" rel="stylesheet">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">

    <script language="javascript">
        function isSecurity(v){
                if (v.length < 3){iss.reset();return;}
                var lv = -1;
                if (v.match(/[a-z]/ig)){lv++;}
                if (v.match(/[0-9]/ig)){lv++;}
                if (v.match(/(.[^a-z0-9])/ig)){lv++;}
                if (v.length < 6 && lv > 0){lv--;}
                iss.reset();
                switch(lv)
                {                                
                        case 0:
                                iss.level0();
                                break;
                        case 1:
                                iss.level1();
                                break;
                        case 2:
                                iss.level2();
                                break;
                        default:
                                iss.reset();
                }
        }
        var iss = {
                color:["CC0000","FFCC33","66CC00","CCCCCC"],
                text:["弱","中","强"],
				width:["50","100","150","10"],
                reset:function(){
                        $("B").style.backgroundColor = iss.color[3];
						$("B").style.width = iss.width[3];
                        $("A").innerHTML = "长度太短";

                },
                level0:function(){
                        $("B").style.backgroundColor = iss.color[0];
						$("B").style.width = iss.width[0];
						$("A").innerHTML = iss.text[0];
                },
                level1:function(){
                        $("B").style.backgroundColor = iss.color[1];
						$("B").style.width = iss.width[1];
                        $("A").innerHTML = iss.text[1];          
                },
                level2:function(){
                        $("B").style.backgroundColor = iss.color[2];
						$("B").style.width = iss.width[2];
                        $("A").innerHTML = iss.text[2];
                        
                }
        }
        var $ = function(v){return document.getElementById(v);}
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
                    修改密码
                </td>
            </tr>
        </table>
    <br />
    <table id="wsd_inputtable">
        <tr>
            <td colspan="4" class="tabletitle">
                输入表单
            </td>
        </tr>
        <tr>
            <td class="tablefield" width="120">
                原始密码:
            </td>
            <td width="271">
                <input runat="server" class="wsd_input" id="txtOld" type="password" name="Text2">
            </td>
            <td class="tablefield" width="113">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="tablefield" width="120">
                新密码:
            </td>
            <td width="271">
                <br />
                <input runat="server" class="wsd_input" id="txtNew" type="password" name="Text2"
                    onpropertychange="isSecurity(this.value);">
                <font id="A"></font>
                <br />
                <span id="B" style=" height:1px"></span>

            </td>
            <td class="tablefield" width="113">
                密码确认:
            </td>
            <td>
                <input runat="server" class="wsd_input" id="txtConfirm" type="password" name="Text2" >
            </td>
        </tr>
        <tr>
            <td colspan="4" class="buttonarea">
                <asp:Button ID="btnChange" runat="server" Text="修改密码" CssClass="wsd_button2" OnClick="btnChange_Click" />
            </td>
        </tr>
    </table>
    <br />
    <table align="left">
        <tr>
            <td>
                <br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

