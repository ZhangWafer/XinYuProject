<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Background_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>XinYu 统一后台管理信息系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=u" />
    <link type="text/css" rel="stylesheet" href="css/default.css" />
    <script type="text/javascript" language="javascript">
        function chkLoginForm() {
            if (document.getElementById("<%= this.txtUserName.ClientID %>").value == "") {
                document.getElementById("<%= this.lblError.ClientID %>").innerHTML = "请输入您的用户名!";
                document.getElementById("<%= this.txtUserName.ClientID %>").focus();
                return false;
            }
            return true;
        }

        window.onload = function () {
            var arr = document.getElementsByTagName("IFRAME");
            for (var i = 0; i < arr.length; i++) {
                arr.parentNode.removeChild(arr);
            }
        } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="loginbg01">
            <div class="loginbg02"></div>
            <div id="divLoginHeader"></div>
            <div id="divLoginFooter"> 
                <table border="0" cellspacing="0" cellpadding="0" style="float: left; width: 554px; height: 90px; margin-top: 25px;">
                    <tr valign="middle">  
                        <td style="height: 20px; padding-right: 5px;" colspan="3" align="right">&nbsp;<asp:Label ID="lblError" runat="server" CssClass="fontred" EnableViewState="False"></asp:Label></td>
                    </tr>
                    <tr valign="middle">
                        <td style="height: 27px; width: 350px; "></td>
                        <td style="height: 27px; width: 55px;"><span class="fontor">用户名:</span></td>
                        <td style="height: 27px"><asp:TextBox ID="txtUserName" runat="server" CssClass="username" Text="Supper"></asp:TextBox></td>
                    </tr>
                    <tr valign="middle">
                        <td style="height: 27px; width: 350px; "></td>
                        <td style="height: 27px; width: 55px;"><span class="fontor">密&nbsp;&nbsp;码:</span></td>
                        <td style="height: 27px"><asp:TextBox ID="txtPassword" runat="server" CssClass="password" Text="pcwatch2010" TextMode="Password"></asp:TextBox></td>
                    </tr>
                </table>
                <div style="float: left; width: 55px; height: 78px; margin-top: 55px;"><asp:ImageButton ID="ibtnLogin" runat="server" BorderWidth="0" ImageUrl="img/login/button_login.gif" OnClientClick="if (chkLoginForm()) return true; else return false;" OnClick="ibtnLogin_Click" /></div>
            </div>
        </div>
    </form>
</body>
</html>
