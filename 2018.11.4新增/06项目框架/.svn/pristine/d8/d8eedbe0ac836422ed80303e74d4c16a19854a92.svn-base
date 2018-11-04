<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CookbookSetInTodayDateManager.aspx.cs" Inherits="Background_Cookbook_CookbookSetInTodayDateManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />排餐管理</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gdCookbookDate" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="98%"
        OnRowCommand="gdCookbookDate_RowCommand" OnRowDataBound="gdCookbookDate_RowDataBound">
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="CafeteriaName" HeaderText="食堂" ItemStyle-Width="80px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Height="25px" Width="80px"></ItemStyle>
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

            <asp:TemplateField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" HeaderText="菜品信息">
                <ItemTemplate>
                    <!--gdcookbookDateDetails-->
                    <asp:GridView ID="gdcookbookDateDetails" Width="75%" runat="server"  ForeColor="#333333" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                        <RowStyle BackColor="#EFF3FB"/>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="CookbookName" ItemStyle-Width="140px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Height="25px" Width="80px"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <!--gdcookbookDateDetails-->
                </ItemTemplate>
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
</asp:Content>

