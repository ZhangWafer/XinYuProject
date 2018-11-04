using System;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.BLL;
using Spotmau.Framework.Web.Controls;

public partial class Background_SysManager_RoleManager : System.Web.UI.Page
{
    const string COSNT_BUTTON_TEXT_LOCK = "锁定";
    const string CONST_BUTTON_TEXT_UNLOCK = "解锁";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new RoleManagerBLL();

            bindRoleList(bll, PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleAdd.aspx");
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        bindRoleList(new RoleManagerBLL(), e.PageIndex, e.PageSize);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var bll = new RoleManagerBLL();
        var roleID = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":

                bll.RemoveRole(roleID);

                bindRoleList(bll, PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
                break;

            case "Popedom":

                Response.Redirect("RolePopedomManager.aspx?id=" + roleID);
                break;
        }
    }

    private void bindRoleList(RoleManagerBLL bll, int pageIndex, int pageSize)
    {
        int total;
        GridView1.DataSource = bll.GetRoleList(pageIndex, pageSize, out total);
        GridView1.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }
}