<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserPopedomView.aspx.cs" Inherits="Background_SysManager_UserPopedomView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="title" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="left" style="width: 210px; padding-left: 0px;"></td>
            <td class="center" style="width: 449px"><asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label></td>
            <td class="right" align="right"><asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><img alt="" border="0" align="absMiddle" src="../img/edit/back.gif" />返回</asp:LinkButton></td>
        </tr>
    </table>
    
    <table class="content" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title1" style="width: 200px;text-align:left;">请选择用户：</td>
            <td class="input1">所选择管理用户<asp:Label ID="lblSelectedUser" runat="server" Font-Bold="True" ForeColor="#804040"></asp:Label>所拥有的权限如下（包括角色权限）：</td>
        </tr>
        <tr>
            <td class="title2" style="width: 200px; text-align:left; vertical-align: top;"><asp:ListBox ID="ListBox1" runat="server" Width="95%" Height="355px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox></td>
            <td class="input2" style=" text-align:left; vertical-align: top;">
                <div style=" width: 98%; height: 350px; overflow: auto; overflow-x:hidden; border: solid 1px black;">
                    <asp:TreeView ID="TreeView1" runat="server" Width="99%" ShowCheckBoxes="All" ShowLines="True" Enabled="False">
                        <SelectedNodeStyle Font-Bold="True" ForeColor="Red" />
                    </asp:TreeView></div>
            </td>
        </tr>
    </table>
    
</asp:Content>

