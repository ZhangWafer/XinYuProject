<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserUpdPwd.aspx.cs" Inherits="Background_SysManager_UserUpdPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"><img alt="" src="../img/edit/warning.gif" border="0" align="absMiddle" /><span class="fontred">*</span><span class="fontblack">为必填项</span></td>
            <td class="right" align="right"><asp:LinkButton ID="lbtnBack" runat="server" PostBackUrl="~/SysManager/UserUpd.aspx"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    
    
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1" style="width: 100px">管理员名称：</td>
            <td class="input1" style="width: 260px"><asp:Label ID="lblUserName" runat="server"></asp:Label></td>
            <td class="desc1"></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">原始密码：</td>
            <td class="input2" style="width: 260px"><asp:TextBox ID="txtcurpwd" runat="server" CssClass="inputbg" TextMode="Password" Width="145px"></asp:TextBox><span class="alert">*</span></td>
            <td class="desc2"><asp:RegularExpressionValidator ID="RequiredUserPwd2" runat="server" ControlToValidate="txtcurpwd" Display="Dynamic" ErrorMessage="原始密码6-12个字符并规范" ForeColor="Gray" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">输入新密码：</td>
            <td class="input1" style="width: 260px"><asp:TextBox ID="txtnewpwd" runat="server" CssClass="inputbg" TextMode="Password" Width="145px"></asp:TextBox><span class="alert">*</span><br /><span class="tip">[6-12字符,数字、字母及下划线]</span></td>
            <td class="desc1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpwd" Display="Dynamic" ErrorMessage="新密码不能为空" ForeColor="Gray"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnewpwd" Display="Dynamic" ErrorMessage="新密码密码6-12个字符并规范" ForeColor="Gray" ValidationExpression="[a-zA-Z0-9_]{6,12}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">确认新密码：</td>
            <td class="input2" style="width: 260px"><asp:TextBox ID="txtnewpwd1" runat="server" CssClass="inputbg" TextMode="Password" Width="145px"></asp:TextBox><span class="alert"></span><br /><span class="tip">[6-12字符,数字、字母及下划线]</span></td>
            <td class="desc2"><asp:CompareValidator ID="compareuseranem" runat="server" ControlToCompare="txtnewpwd" ControlToValidate="txtnewpwd1" ErrorMessage="两次输入的密码不相同" ForeColor="Gray" Operator="Equal" Type="string"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px"></td>
            <td class="input1" style="width: 260px"><asp:Label ID="lblError" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            <td class="desc1"></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px"></td>
            <td class="input2" style="width: 260px">
                <asp:Button ID="SubBtn" runat="server" CssClass="button" Text="修改密码" OnClick="SubBtn_Click" />
                <asp:Button ID="RunBtn" runat="server" CausesValidation="false" CssClass="button" Text=" 重 置 " OnClick="RunBtn_Click" /> </td>
            <td class="desc2"></td>
        </tr>
    </table>
    
</asp:Content>

