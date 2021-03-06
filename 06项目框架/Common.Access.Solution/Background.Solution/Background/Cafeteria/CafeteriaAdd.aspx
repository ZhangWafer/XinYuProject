﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CafeteriaAdd.aspx.cs" Inherits="Background_Cafeteria_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />返回食堂管理</asp:LinkButton>
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
            <td class="title1">食堂名称：</td>
            <td class="input1">
                <asp:TextBox ID="txtName" runat="server" Width="500px" MaxLength="100" Height="24px"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">食堂描述：</td>
            <td class="input2">
                <asp:TextBox ID="txtDesc" runat="server" Width="500px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>

            <td class="title2">供餐类型：</td>
            <td class="input2">
                <asp:DropDownList ID="ddlCafeteriaTypeEnum" runat="server">
                    <asp:ListItem Selected="True" Value="Common">普通用餐</asp:ListItem>
                    <asp:ListItem Value="Buffet">自助餐</asp:ListItem>

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="title1">排序数值：</td>
            <td class="input1">
                <asp:TextBox ID="txtOrder" runat="server" MaxLength="10" Width="80px" Text="100"></asp:TextBox><span class="alert">*必填项</span></td>
        </tr>
        <tr>
            <td class="title2">创建人：</td>
            <td class="input2">
                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">创建时间：</td>
            <td class="input1">
                <asp:Label ID="lblCreatedDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2">最后修改人：</td>
            <td class="input2">
                <asp:Label ID="lblLastUpdBy" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1">最后修改时间：</td>
            <td class="input1">
                <asp:Label ID="lblLastUpdDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="title2"></td>
            <td class="input2">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
        </tr>
        <tr>
            <td class="title1"></td>
            <td class="input1">
                <asp:Button CssClass="button" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="保  存" />
                <asp:Button CssClass="button" ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重  置" /></td>
        </tr>
    </table>
</asp:Content>

