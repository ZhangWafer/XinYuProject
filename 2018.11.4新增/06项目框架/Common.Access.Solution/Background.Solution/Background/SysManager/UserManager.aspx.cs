using System;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.BLL;
using Spotmau.Framework.Web.Controls;

public partial class Background_SysManager_UserManager : System.Web.UI.Page
{
    const string COSNT_BUTTON_TEXT_LOCK = "锁定";
    const string CONST_BUTTON_TEXT_UNLOCK = "解锁";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PageUtility.IsLogin)
        {
            Response.Redirect("~/logout.aspx");
            return;
        }

        if (!IsPostBack)
        {
            var bll = new UserManagerBLL();

            // 绑定显示用户/会员列表
            BindUseList(bll, PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindUseList(new UserManagerBLL(), PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        BindUseList(new UserManagerBLL(), e.PageIndex, e.PageSize);
    }

    private void BindUseList(UserManagerBLL bll, int pageIndex, int pageSize)
    {
        bool? isAdmin = null;
        if (rbtnViewAdmin.Checked) isAdmin = true;
        else if (rbtnViewMember.Checked) isAdmin = false;

        int total;
        GridView1.DataSource = bll.GetUserList(string.Empty, false, isAdmin, null, pageIndex, pageSize, out total);
        GridView1.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var bll = new UserManagerBLL();
        int userID = int.Parse(e.CommandArgument.ToString());

        try
        {
            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("UserAdd.aspx?id=" + userID);
                    break;

                case "Remove":

                    bll.RemoveUser(userID);
                    BindUseList(bll, Navigation1.PageIndex, Navigation1.PageSize);
                    break;

                case "Lock":

                    bll.LockUser(userID, true);
                    BindUseList(bll, Navigation1.PageIndex, Navigation1.PageSize);
                    break;

                case "Unlock":

                    bll.LockUser(userID, false);
                    BindUseList(bll, Navigation1.PageIndex, Navigation1.PageSize);
                    break;

                case "Popedom":
                    Response.Redirect("UserPopedomManager.aspx?id=" + userID);
                    break;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }
    }
}