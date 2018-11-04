<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="RoleManager.aspx.cs" Inherits="Background_SysManager_RoleManager" %>

<%@ Register Assembly="Spotmau.Framework.Web.Controls" Namespace="Spotmau.Framework.Web.Controls" TagPrefix="apex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right"><asp:LinkButton ID="lnkAddRole" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加新角色</asp:LinkButton></td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="98%" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="RoleName" HeaderText="角色名称" ItemStyle-Width="120px"  />
            <asp:BoundField DataField="Description" HeaderText="角色描述"  />
            <asp:BoundField DataField="DisplayOrder" HeaderText="排序值" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="CreatedByName" HeaderText="创建人" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="创建时间" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"CreatedDate")).ToString("yyyy-MM-dd") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "RoleAdd.aspx?id=" + DataBinder.Eval(Container.DataItem,"ID").ToString() %>'><img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' OnClientClick="if (confirm('您是否确定要彻底删除该角色？')) return true; else return false;" ><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>          
            <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPopedom" runat="server" CommandName="Popedom" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' ><img alt="" src="../img/edit/popedom.gif" border="0" align="absmiddle" />分配权限</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" Height="24px" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Height="30px" />
    </asp:GridView>
    
    <apex:Navigation ID="Navigation1" runat="server" OnNavigationStatusChanged="Navigation1_NavigationStatusChanged" />

</asp:Content>