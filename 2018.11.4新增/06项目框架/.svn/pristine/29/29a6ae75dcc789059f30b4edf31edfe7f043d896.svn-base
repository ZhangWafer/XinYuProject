<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master"
    AutoEventWireup="true" CodeFile="ModuleAdd.aspx.cs" Inherits="Background_SysManager_ModuleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left">
                <img alt="" src="../img/edit/warning.gif" border="0" align="absMiddle" /><span class="fontred">*</span><span
                    class="fontblack">为必填项</span></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnModuleNo" runat="server" />
    <asp:HiddenField ID="hdnParentModuleNo" runat="server" />
    <asp:HiddenField ID="hdnRootModuleNo" runat="server" />
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title2">
                父模块：</td>
            <td class="input2">
                <asp:Label ID="lblParentModule" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">
                模块名称：</td>
            <td class="input1">
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">
                模块URL：</td>
            <td class="input2">
                <asp:TextBox ID="txtUrl" runat="server" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="title1">
                模块图标：</td>
            <td class="input1">
                <asp:Image ID="imgIcon" runat="server" Height="15px" ImageUrl="~/img/framework/main_submenu1.gif"
                    Width="16px" /><br />
                <asp:FileUpload ID="fupIcon" runat="server" Width="400px" /></td>
        </tr>
        <tr>
            <td class="title2">
            </td>
            <td class="input2">
                <asp:CheckBox ID="cbxIsMenu" runat="server" Text="是否为菜单项，即是否在左侧菜单栏中显示为菜单" Checked="true" /></td>
        </tr>
        <tr>
            <td class="title1">
            </td>
            <td class="input1">
                <asp:CheckBox ID="cbxIsFloder" runat="server" Text="是否为菜单文件夹，即为一级菜单" /></td>
        </tr>
        <tr>
            <td class="title2">
            </td>
            <td class="input2">
                <asp:CheckBox ID="cbxIsPopedom" runat="server" Text="所有用户仅可访问，即不对该模块进行权限控制" /></td>
        </tr>
        <tr>
            <td class="title1">
                排序数值：</td>
            <td class="input1">
                <asp:TextBox ID="txtOrder" runat="server" MaxLength="10" Width="80px" Text="100"></asp:TextBox><span
                    class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">
                创建人：</td>
            <td class="input2">
                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">
                创建时间：</td>
            <td class="input1">
                <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">
                最后修改人：</td>
            <td class="input2">
                <asp:Label ID="lblLastUpdBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">
                最后修改时间：</td>
            <td class="input1">
                <asp:Label ID="lblLastUpdDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">
            </td>
            <td class="input2">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">
            </td>
            <td class="input1">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添  加" CssClass="button" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" CssClass="button" /></td>
        </tr>
    </table>

</asp:Content>
