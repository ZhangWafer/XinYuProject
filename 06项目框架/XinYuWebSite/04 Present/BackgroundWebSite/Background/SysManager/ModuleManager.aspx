<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="ModuleManager.aspx.cs" Inherits="Background_SysManager_ModuleManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="title">
        <tr>
            <td class="left" style="width: 280px;"><b>请选择父模块：</b></td>
            <td class="center">父模块：<asp:Label ID="lblParentModule" runat="server" ForeColor="Red"></asp:Label></td>
            <td class="right">
                <asp:LinkButton ID="lnkAddChild" runat="server" OnClick="lnkAddChild_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加子模块</asp:LinkButton>
                <asp:LinkButton ID="lnkAddModule" runat="server" OnClick="lnkAddModule_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />添加顶级模块</asp:LinkButton></td>
        </tr>
    </table>
    <table width="98%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
        <tr>
            <td style="width: 250px; vertical-align: top; " valign="top">
                <div id="divModuleTreeView" style=" width: 98%; height: 400px; overflow: auto; overflow-x:hidden; border: solid 1px black;">
                <asp:TreeView ID="TreeView1" runat="server" Width="90%" Height="100%" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ExpandDepth="2" Font-Size="11pt" ShowLines="True">
                    <SelectedNodeStyle Font-Bold="True" ForeColor="Red" Font-Italic="True" Font-Overline="False" Font-Size="11pt" Font-Underline="True" ImageUrl="~/img/edit/agree.gif" />
                </asp:TreeView>
                </div>
            </td>
            <td style="vertical-align: top; ">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="模块名称" ItemStyle-Width="140px" />
                        <asp:BoundField DataField="Url" HeaderText="URL" />
                        <asp:TemplateField HeaderText="菜单" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsMenu" Enabled="false" runat="server" Checked='<%# (bool)DataBinder.Eval(Container.DataItem,"IsMenu") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="文件夹" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsFloder" Enabled="false" runat="server" Checked='<%# (bool)DataBinder.Eval(Container.DataItem,"IsFloder") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公共" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsPopedom" Enabled="false" runat="server" Checked='<%# (bool)DataBinder.Eval(Container.DataItem,"IsPopedom") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DisplayOrder" HeaderText="排序" ItemStyle-Width="40px" />
                        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "ModuleAdd.aspx?id=" + DataBinder.Eval(Container.DataItem,"ID").ToString() + "&parentid=" + DataBinder.Eval(Container.DataItem,"ParentID").ToString() %>'><img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />修改</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID") %>' OnClientClick="if (confirm('您是否确定要删除该模块？')) return true; else return false;" ><img alt="" src="../img/edit/delete.gif" border="0" align="absmiddle" />删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" Height="24px" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Height="30px" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
</asp:Content>