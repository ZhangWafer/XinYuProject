<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserUpd.aspx.cs" Inherits="Background_SysManager_UserUpd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"><img alt="" src="../img/edit/warning.gif" border="0" align="absMiddle" /><span class="fontred">*</span><span class="fontblack">为必填项</span></td>
            <td class="right" align="right"><asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1" style="width: 100px">用户角色：</td>
            <td class="input1"><span class="alert"><asp:CheckBoxList ID="chklstRoleList" runat="server" RepeatDirection="Horizontal" Enabled="False"></asp:CheckBoxList></span></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">登录账号：</td>
            <td class="input2"><asp:TextBox ID="txtUserName" runat="server" Width="200px" Enabled="False"></asp:TextBox><span class="alert">*</span></td>
        </tr>
        <tr>
            <td class="title1" style="width: 100px">用户姓名：</td>
            <td class="input1" style="width: 300px"><asp:TextBox ID="txtAlias" runat="server" Width="200px"></asp:TextBox><span class="alert">*</span></td>
        </tr>
        <tr>
            <td class="title2" style="width: 100px">用户邮箱：</td>
            <td class="input2" style="width: 300px"><asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox><span class="tip"></span></td>
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
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="修  改" CssClass="button" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" CssClass="button" /></td>
       </tr>
    </table>   
    
</asp:Content>