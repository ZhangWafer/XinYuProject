<%@ Page Title="工作人员优惠添加" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CookbookPreferentialWorkerAdd.aspx.cs" Inherits="Background_Cookbook_CookbookPreferentialWorkerAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />返回优惠管理</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title2">优惠名称：</td>
            <td class="input2">
                <asp:TextBox ID="txtName" runat="server" Width="250px" MaxLength="100" Height="24px"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title1">优惠描述：</td>
            <td class="input1">
                <asp:TextBox ID="txtDescription" runat="server" Width="610px" Height="80px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="title1">菜品：</td>
            <td class="input1">
                <asp:DropDownList ID="ddlCookbook" runat="server" DataTextField="Name" DataValueField="Id" Height="26px" /></td>
        </tr>

        <tr>
            <td class="title2">工作人员类型：</td>
            <td class="input2">
                <asp:DropDownList ID="ddlWorkerStaffEnum" runat="server">
                    <asp:ListItem Text="职工" Value="Emploee" />
                    <asp:ListItem Text="工作人员" Value="Worker" />
                    <asp:ListItem Text="驻场人员" Value="Stationed" />
                </asp:DropDownList>
                <span class="alert">*必填项</span></td>
        </tr>

        <tr>
            <td class="title2">优惠价格：</td>
            <td class="input2">
                <asp:TextBox ID="txtSalePrice" runat="server" MaxLength="10" Width="80px" Height="24px" Text="0"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>

        <tr>
            <td class="title2">排序数值：</td>
            <td class="input2">
                <asp:TextBox ID="txtOrder" runat="server" MaxLength="10" Width="80px" Text="100" Height="24px" /><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title1">创建人：</td>
            <td class="input1">
                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">创建时间：</td>
            <td class="input2">
                <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">最后修改人：</td>
            <td class="input1">
                <asp:Label ID="lblLastUpdBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">最后修改时间：</td>
            <td class="input2">
                <asp:Label ID="lblLastUpdDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1"></td>
            <td class="input1">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2"></td>
            <td class="input2">
                <asp:Button CssClass="button" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="保  存" />
                <asp:Button CssClass="button" ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" /></td>
        </tr>
    </table>
</asp:Content>

