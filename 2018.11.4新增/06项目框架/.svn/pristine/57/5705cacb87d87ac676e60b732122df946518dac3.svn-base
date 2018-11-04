<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CafeteriaStaffAdd.aspx.cs" Inherits="Background_Staff_CafeteriaStaffAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />返回食堂人员管理</asp:LinkButton>
            </td>
        </tr>
    </table>

    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1">机构名称：</td>
            <td class="input1">
                <asp:Label ID="OrganizationName" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td class="title2">食堂：</td>
            <td class="input2">
                <asp:DropDownList ID="ddlCafeters" runat="server" DataTextField="Name" DataValueField="Id" />
                <span class="alert">*必填项</span></td>
        </tr>
        
        <tr>
            <td class="title2">姓名：</td>
            <td class="input2">
                <asp:TextBox ID="txtName" runat="server" Width="250px" MaxLength="100" Height="24px"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>

        <tr>
            <td class="title1">头像：</td>
            <td class="input1">
                <asp:FileUpload ID="fileIcon" runat="server" Height="24px" />
                <asp:Image ID="imgIcon" runat="server" Height="60" Width="60" Visible="False" />

            </td>
        </tr>
        <tr>
            <td class="title2">电话：</td>
            <td class="input2">
                <asp:TextBox ID="txtTel" runat="server" Width="500px" MaxLength="100" Height="24px"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="title1">微信号：</td>
            <td class="input1">
                <asp:TextBox ID="txtWechat" runat="server" Width="500px" MaxLength="100" Height="24px"></asp:TextBox></td>
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

