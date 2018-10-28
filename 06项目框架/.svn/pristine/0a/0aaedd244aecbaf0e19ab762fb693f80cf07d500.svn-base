<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserAdd.aspx.cs" Inherits="Background_SysManager_UserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"><img alt="" src="../img/edit/warning.gif" border="0" align="absMiddle" /><span class="fontred">*</span><span class="fontblack">为必填项</span></td>
            <td class="right" align="right"><asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hdnEditingUserNo" runat="server" />
    
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1" style="width: 100px">用户角色：</td>
            <td class="input1"><asp:CheckBoxList ID="chklstRoleList" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList><span class="alert"></span></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">登录账号：</td>
            <td class="input2"><asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox><span class="alert">*</span></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">登录密码：</td>
            <td class="input1"><span class="alert">新建用户的默认密码为空！</span></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">用户姓名：</td>
            <td class="input2" style="width: 300px"><asp:TextBox ID="txtAlias" runat="server" Width="200px"></asp:TextBox><span class="alert">*</span></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">用户邮箱：</td>
            <td class="input1" style="width: 300px"><asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox><span class="tip"></span></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px"></td>
            <td class="input2"><asp:CheckBox ID="cbxIsLockout" runat="server" Text="锁定账号（锁定后用户无法登录）" /></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">用户描述：</td>
            <td class="input1" colspan="3"><asp:TextBox ID="txtDescription" runat="server" Width="610px" Height="80px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
    </table>
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title2" style="width: 100px">创建人：</td>
            <td class="input2" style="width: 300px"><asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
            <td class="title2" style="width: 100px">创建时间：</td>
            <td class="input2"><asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">修改人：</td>
            <td class="input1" style="width: 300px"><asp:Label ID="lblLastUpdBy" runat="server"></asp:Label></td>
            <td class="title1" style="width: 100px">修改时间：</td>
            <td class="input1"><asp:Label ID="lblLastUpdDate" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td class="title2" style="width: 100px"></td>
            <td class="input2" colspan="3"><asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
        </tr>
       <tr>
            <td class="title1" style="width: 100px"></td>
            <td class="input1" colspan="3">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添  加" CssClass="button" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" CssClass="button" />
                <asp:Button ID="btnPopedom" runat="server" OnClick="btnPopedom_Click" Text="分配权限" CssClass="button" />
                <asp:Button ID="btnViewPopedom" runat="server" OnClick="btnViewPopedom_Click" Text="查看权限" CssClass="button" /></td>
       </tr>
    </table>      
</asp:Content>