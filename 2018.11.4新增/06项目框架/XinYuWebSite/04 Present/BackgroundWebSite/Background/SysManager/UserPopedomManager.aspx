<%@ Page Title="" Language="C#" MasterPageFile="~/Background/Common/Default.Master" AutoEventWireup="true" CodeFile="UserPopedomManager.aspx.cs" Inherits="Background_SysManager_UserPopedomManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function resizeModuleTreeView() {

            var bodyWidth = document.getElementById("divBody").clientWidth;
            var bodyHeight = document.getElementById("divBody").clientHeight;

            document.getElementById("divModuleTreeView").style.height = (bodyHeight) + "px";
        }    
    </script>

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
            <td class="input1">请为所选择管理用户<asp:Label ID="lblSelectedUser" runat="server" Font-Bold="True" ForeColor="#804040"></asp:Label>分配权限：</td>
        </tr>
        <tr>
            <td class="title2" style="width: 200px; text-align:left; vertical-align: top;"><asp:ListBox ID="ListBox1" runat="server" Width="95%" Height="355px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox></td>
            <td class="input2" style=" text-align:left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div id="divModuleTreeView" style="width: 98%; height: 350px; overflow: auto; overflow-x:hidden; border: solid 1px black;">
                        <asp:TreeView ID="TreeView1" runat="server" Width="99%" ShowCheckBoxes="All" ShowLines="True" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged">
                            <SelectedNodeStyle Font-Bold="True" ForeColor="Red" />
                        </asp:TreeView></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
       <tr>
            <td class="title1" style="width: 200px"></td>
            <td class="input1"><asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="提  交" CssClass="button" /></td>
        </tr>
    </table>

</asp:Content>

