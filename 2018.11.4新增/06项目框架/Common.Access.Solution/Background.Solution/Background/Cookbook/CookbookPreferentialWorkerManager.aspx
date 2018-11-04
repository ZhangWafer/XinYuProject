<%@ Page Title="工作人员优惠管理" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CookbookPreferentialWorkerManager.aspx.cs" Inherits="Background_Cookbook_CookbookPreferentialWorkerManager" %>

<%@ Register Assembly="Spotmau.Framework.Web.Controls" Namespace="Spotmau.Framework.Web.Controls" TagPrefix="apex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divSupper">
        <asp:GridView ID="gdUserCookbook" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="98%"
            OnRowCommand="gdUserCookbook_RowCommand" OnRowDataBound="gdUserCookbook_RowDataBound">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField HeaderText="菜品图片" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <div style="margin: 2px 2px 2px 2px;">
                            <asp:Image runat="server" ID="imgIcon" BorderWidth="1" BorderColor="Black" />
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="Name" HeaderText="菜品名称" ItemStyle-Width="80px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" Height="25px" Width="80px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="Description" HeaderText="菜品描述" ItemStyle-Width="80px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center" Height="25px" Width="80px"></ItemStyle>
                </asp:BoundField>

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
                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "CookbookPreferentialInWorkerItemsManager.aspx?id=" + DataBinder.Eval(Container.DataItem,"Id") %>'>
                        <img alt="" src="../img/edit/edit.gif" border="0" align="absmiddle" />菜品优惠
                        </asp:HyperLink>
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
                            <b>没有菜品数据</b>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <div>
            <apex:Navigation ID="Navigation1" runat="server" OnNavigationStatusChanged="Navigation1_NavigationStatusChanged" Height="26px" />
        </div>
    </div>
</asp:Content>

