﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="OrganizationManager.aspx.cs" Inherits="Background_Organization_OrganizationManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加新的机构</asp:LinkButton>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="98%"
        OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="机构名称" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Description" HeaderText="机构描述" />
            <asp:BoundField DataField="DisplayOrder" HeaderText="排序值" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="CreatedByName" HeaderText="创建人" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="创建时间" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"CreatedDate")).ToString("yyyy-MM-dd") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "Add.aspx?id=" + DataBinder.Eval(Container.DataItem,"Id").ToString() %>'><img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClientClick="if (confirm('您是否确定要彻底删除该机构？')) return true; else return false;"><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" Height="24px" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Height="30px" />

        <EmptyDataTemplate>
            <table width="100%" cellpadding="0" cellspacing="0" class="">
                <tr align="center">
                    <td style="height: 40px;">
                        <b>没有机构数据</b>
                    </td>
                </tr>
                <tr align="center">
                    <td style="height: 40px;">
                        <img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />
                        <a href="OrganizationAdd.aspx">添加新的机构</a>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>

