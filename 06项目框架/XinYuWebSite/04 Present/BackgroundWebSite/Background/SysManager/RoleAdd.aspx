<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="RoleAdd.aspx.cs" Inherits="Background_SysManager_RoleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"><img alt="" src="../img/edit/warning.gif" border="0" align="absMiddle" /><span class="fontred">*</span><span class="fontblack">为必填项</span></td>
            <td class="right" align="right"><asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hdnRoleNo" runat="server" />
    
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1">角色名称：</td>
            <td class="input1"><asp:TextBox ID="txtName" runat="server" Width="200px" MaxLength="100"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">角色描述：</td>
            <td class="input2"><asp:TextBox ID="txtDesc" runat="server" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="title1">排序数值：</td>
            <td class="input1"><asp:TextBox ID="txtOrder" runat="server" MaxLength="10" Width="80px" Text="100"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">创建人：</td>
            <td class="input2"><asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">创建时间：</td>
            <td class="input1"><asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">最后修改人：</td>
            <td class="input2"><asp:Label ID="lblLastUpdBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">最后修改时间：</td>
            <td class="input1"><asp:Label ID="lblLastUpdDate" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td class="title2"></td>
            <td class="input2"><asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
        </tr>
       <tr>
            <td class="title1"></td>
            <td class="input1">
                <asp:Button CssClass="button" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添  加" />
                <asp:Button CssClass="button" ID="btnPopedom" runat="server" OnClick="btnPopedom_Click" Text="分配权限" />
                <asp:Button CssClass="button" ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" /></td>
        </tr>
    </table>
    
    
</asp:Content>