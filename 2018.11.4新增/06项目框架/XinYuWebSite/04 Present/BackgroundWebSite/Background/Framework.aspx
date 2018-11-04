<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Framework.aspx.cs" Inherits="Background_Framework" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>XinYu 统一后台管理信息系统</title>
    <link type="text/css"  href="css/default.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function resize() {

            var bodyWidth = document.body.clientWidth;  // 网页可见区域宽
            var bodyHeight = document.body.clientHeight; // 网页可见区域高

            document.getElementById("divMenu").style.height = (bodyHeight - 80 - 30) + "px";
            document.getElementById("divMenuContent").style.height = (bodyHeight - 80 - 81 - 30) + "px";

            var iframe = document.getElementById("iframeMain");
            iframe.style.width = (bodyWidth - 220) + "px";
            iframe.style.height = (bodyHeight - 80 - 30) + "px";
            iframe.width = (bodyWidth - 220) + "px";
            iframe.height = (bodyHeight - 80 - 30) + "px";
        }

        function redirect(url) {
            alert("会话失效，请重新进行登录！");
            window.location.href = url;
        }
    </script>
</head>
<body style="overflow: hidden; position: absolute; width: 100%; height: 100%;">
    <form id="form1" runat="server">
        <div id="divBody" style="overflow: hidden; position: absolute; width: 100%; height: 100%;">
        
            <div id="divBanner">
                <div id="divBannerLogo"></div>
                <div id="divBannerStatus">
                    <table width="500" border="0" cellspacing="0" cellpadding="0" style="margin-right: 20px;float:right;">
                        <tr>
                            <td class="left">&nbsp;</td>
                            <td class="center">当前用户：[<asp:Label ID="lblUserAlias" CssClass="fontred" runat="server"></asp:Label>]</td>
                            <td class="center"><img alt="" src="img/framework/banner_user_updpwd.gif" width="16" height="8"  align="absmiddle" /><a href="SysManager/UserUpdPwd.aspx" class="b1" target="main">修改密码</a></td>
                            <td class="center"><img alt="" src="img/framework/banner_user_logout.gif" width="13" height="14" align="absmiddle" /><a href="Default.aspx" class="b1">安全退出</a></td>
                            <td class="right" align="right">&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </div>
            
            <div id="divMenu">
                <img height="81" src="img/framework/menu_top.gif" alt="menu" width="199" />
                <div id="divMenuContent" style="width: 100%; overflow: auto; overflow-x: hidden;">
                    <asp:TreeView ID="treeMenu" runat="server" Width="100%"></asp:TreeView>
                </div>
            </div>
            
            <iframe id="iframeMain" name="main" style="float: left; margin-left: 10px; width: 600px; height: 200px;" frameborder="0" marginheight="0" marginwidth="0" src="Calendar.htm"></iframe>

            <div id="divFooter"><div style="margin-top: 4px;">Copyright (C) 2009 All rights reserved.</div></div>
        </div>
        
        <script type="text/javascript" language="javascript">            resize(); window.onresize = resize;</script>
    </form>
</body>
</html>
