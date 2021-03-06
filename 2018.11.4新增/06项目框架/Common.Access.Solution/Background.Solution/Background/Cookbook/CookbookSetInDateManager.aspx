﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CookbookSetInDateManager.aspx.cs" Inherits="Background_Cookbook_CookbookSetInDateManager" %>

<%@ Register Assembly="Spotmau.Framework.Web.Controls" Namespace="Spotmau.Framework.Web.Controls" TagPrefix="apex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />排餐添加</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gdCookbookDate" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="98%"
        OnRowCommand="gdCookbookDate_RowCommand" OnRowDataBound="gdCookbookDate_RowDataBound">
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="CafeteriaName" HeaderText="食堂" ItemStyle-Width="110px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="110px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="排餐日期" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblDate" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="排餐时段" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblCookbookEnum" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="用餐价格" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text="--"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
            </asp:TemplateField>

            <asp:BoundField DataField="OrganizationName" HeaderText="所在机构" ItemStyle-Width="120px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="120px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CreatedByName" HeaderText="创建人" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="创建时间" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"CreatedDate")).ToString("yyyy-MM-dd") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkDetail" runat="server" NavigateUrl='<%# "CookbookSetInDateDetailManager.aspx?id=" + DataBinder.Eval(Container.DataItem,"Id") %>'>
                        <img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />菜品详情
                    </asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "CookbookSetInDateAdd.aspx?id=" + DataBinder.Eval(Container.DataItem,"Id") %>'>
                        <img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改
                    </asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClientClick="if (confirm('您是否确定要彻底删除排餐信息？')) return true; else return false;"><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Height="28" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" Height="30px" />

        <EmptyDataTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" class="">
                <tr align="center">
                    <td style="height: 40px;">
                        <b>没有排餐数据</b>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    <div>
        <apex:Navigation ID="Navigation1" runat="server" OnNavigationStatusChanged="Navigation1_NavigationStatusChanged" Height="26px" />
    </div>
</asp:Content>

