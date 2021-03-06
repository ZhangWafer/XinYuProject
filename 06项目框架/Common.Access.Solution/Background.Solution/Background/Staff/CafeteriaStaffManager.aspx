﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CafeteriaStaffManager.aspx.cs" Inherits="Background_Staff_CafeteriaStaffManager" %>

<%@ Register Assembly="Spotmau.Framework.Web.Controls" Namespace="Spotmau.Framework.Web.Controls" TagPrefix="apex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加食管人员</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="98%"
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:TemplateField HeaderText="头像" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                <ItemTemplate>
                    <div style="margin: 2px 2px 2px 2px;">
                        <asp:Image runat="server" ID="imgIcon" BorderWidth="1" BorderColor="Black" />
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="食管姓名" ItemStyle-Width="80px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="80px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="OrganizationName" HeaderText="所在机构" ItemStyle-Width="120px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="120px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="CafeteriaName" HeaderText="所在食堂" ItemStyle-Width="120px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="120px"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Tel" HeaderText="联系电话" ItemStyle-Width="100px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Height="25px" Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Wechat" HeaderText="微信号" ItemStyle-Width="100px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Height="25px" Width="100px"></ItemStyle>
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
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "CafeteriaStaffAdd.aspx?id=" + DataBinder.Eval(Container.DataItem,"Id") %>'>
                        <img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改
                    </asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClientClick="if (confirm('您是否确定要彻底删除该食管人员信息？')) return true; else return false;"><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton>
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
                        <b>没有食管人员数据</b>
                    </td>
                </tr>
                <tr align="center">
                    <td style="height: 40px;">
                        <img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />
                        <a href="CafeteriaStaffAdd.aspx">添加食管人员</a>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>

    <div>
        <apex:Navigation ID="Navigation1" runat="server" OnNavigationStatusChanged="Navigation1_NavigationStatusChanged" Height="26px" />
    </div>
</asp:Content>

