<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="Background_SysManager_UserManager" %>

<%@ Register Assembly="Spotmau.Framework.Web.Controls" Namespace="Spotmau.Framework.Web.Controls" TagPrefix="apex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="title">
        <tr>
            <td class="left" style="width: 80px"></td>
            <td class="center"><asp:Label ID="lblError" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            <td class="right"><asp:LinkButton ID="lnkAddUser" PostBackUrl="UserAdd.aspx" runat="server"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加新用户</asp:LinkButton></td>
        </tr>
    </table>
    
    <table width="98%">
        <tr>    
            <td style="width: 100px" align="right"></td>
            <td style="width: 520px">
                <asp:RadioButton ID="rbtnViewAll" GroupName="ViewUserType" runat="server" Text="显示所有用户" Checked="true"/>
                <asp:RadioButton ID="rbtnViewAdmin" GroupName="ViewUserType" runat="server" Text="仅显示管理员" />
                <asp:RadioButton ID="rbtnViewMember" GroupName="ViewUserType" runat="server" Text="仅显示注册会员"  /></td>
            <td><asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查  询" OnClick="btnSearch_Click" /></td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" CssClass="floatleft" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="98%" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="用户账号" ><ItemStyle HorizontalAlign="Center" Width="120px" /></asp:BoundField>
            <asp:BoundField DataField="Alias" HeaderText="用户姓名" ><ItemStyle HorizontalAlign="Center" Width="120px" /></asp:BoundField>
            <asp:BoundField DataField="OrganizationName" HeaderText="管理机构"><ItemStyle HorizontalAlign="Center" Width="200px" /></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="邮箱"> <ItemStyle HorizontalAlign="Center" Width="150px" /></asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="描述"><ItemStyle HorizontalAlign="Center" Width="400px" /></asp:BoundField>
            <asp:BoundField DataField="CreatedDate" HeaderText="注册日期" ><ItemStyle HorizontalAlign="Center" Width="250px" /></asp:BoundField>
            <asp:CheckBoxField DataField="IsAdmin" HeaderText="管理员" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="锁定" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
            <asp:TemplateField>
                <ItemTemplate><asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "UserAdd.aspx?id=" + DataBinder.Eval(Container.DataItem,"ID").ToString() %>'><img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改</asp:HyperLink></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate><asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' OnClientClick="if (confirm('删除用户，将会直接删除与之相关的信息！您是否确定要彻底删除该用户？')) return true; else return false;" ><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkLock" runat="server" CommandName="Lock" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"IsAdmin") && !(bool)DataBinder.Eval(Container.DataItem,"IsLockedOut") %>' OnClientClick="if (confirm('锁定的账户不能正确登录系统！您是否确定要“锁定”该用户？')) return true; else return false;" ><img alt="" src="../img/edit/lock.gif" border="0" align="absmiddle" />锁定</asp:LinkButton>
                    <asp:LinkButton ID="lnkUnlock" runat="server" CommandName="Unlock" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"IsAdmin") && (bool)DataBinder.Eval(Container.DataItem,"IsLockedOut") %>' OnClientClick="if (confirm('您是否确定要“解锁”该用户？')) return true; else return false;" ><img alt="" src="../img/edit/lock.gif" border="0" align="absmiddle" />解锁</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>            
            <asp:TemplateField>
                <ItemTemplate><asp:LinkButton ID="lnkPopedom" runat="server" CommandName="Popedom" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"IsAdmin") %>' ><img alt="" src="../img/edit/popedom.gif" border="0" align="absmiddle" />分配权限</asp:LinkButton></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" Height="24px" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Height="30px" />
    </asp:GridView>
    
    <apex:Navigation ID="Navigation1" runat="server" OnNavigationStatusChanged="Navigation1_NavigationStatusChanged" />

</asp:Content>