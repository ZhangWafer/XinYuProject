<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="CookbookSetInDateAdd.aspx.cs" Inherits="Background_Cookbook_CookbookSetInDateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left"></td>
            <td class="right" align="right">
                <asp:LinkButton ID="lnkAddHeader" runat="server" OnClick="lnkAddRole_Click"><img alt="" src="../img/edit/add.gif" border="0" align="absmiddle" />返回排餐管理</asp:LinkButton>
            </td>
        </tr>
    </table>

    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title2">日期选择：</td>
            <td class="input2">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="248px" Width="1085px" OnSelectionChanged="Calendar1_SelectionChanged" BorderWidth="1px" DayNameFormat="Shortest" ShowGridLines="True" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                    <DayHeaderStyle Font-Bold="True" Height="1px" BackColor="#FFCC66" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
                <span class="alert">*必填项</span></td>

            <asp:HiddenField ID="hdnDate" runat="server" Value="" />
        </tr>



        <tr>
            <td class="title1">排餐时段：</td>
            <td class="input1">
                <asp:DropDownList ID="ddlCookbookEnum" runat="server">
                    <asp:ListItem Text="早 餐" Value="Breakfast"></asp:ListItem>
                    <asp:ListItem Text="午 餐" Value="Lunch"></asp:ListItem>
                    <asp:ListItem Text="晚 餐" Value="Supper"></asp:ListItem>
                </asp:DropDownList>
                <span class="alert">*必填项</span>
            </td>
        </tr>

        <tr>
            <td class="title1">食堂：</td>
            <td class="input1">
                <asp:DropDownList ID="ddlCafeteria" runat="server" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlCafeteria_SelectedIndexChanged" AutoPostBack="True" />
                <span class="alert">*必填项</span>
            </td>
        </tr>

        <tr>
            <td class="title2">选择菜品：</td>
            <td class="input2">
                <asp:Panel ID="pnlCookbook" runat="server" Height="126px" ScrollBars="Auto" Width="652px">
                    <asp:CheckBoxList ID="cbklCookbook" runat="server" CellPadding="5" CellSpacing="5" DataTextField="Name" DataValueField="Id" RepeatColumns="7" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </asp:Panel>
                <span class="alert">*必填项</span></td>
        </tr>
        <asp:Panel ID="pnlPrice" runat="server" Visible="False">
            <tr>
                <td class="title1">自助餐定价：</td>
                <td class="input1">
                    <asp:TextBox ID="tbxPrice" runat="server" MaxLength="10" Width="80px"></asp:TextBox><span class="alert">*必填项</span></td>
            </tr>
        </asp:Panel>

        <tr>
            <td class="title1">排序数值：</td>
            <td class="input1">
                <asp:TextBox ID="txtOrder" runat="server" MaxLength="10" Width="80px" Text="100" Height="24px" /><span class="alert">*必填项</span></td>
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

    <script type="text/javascript">
        $(function () {
            alert('dfasf');
            var td = $("#ctl00_ContentPlaceHolder1_Calendar1 td a[title='7月18日']");
            td.html(td.text() + "|<b><font color='red'>已订</font></b>");
        });
    </script>


</asp:Content>


