using System;
using System.Web.UI.WebControls;
using Spotmau.Framework.Web.Controls;
using XinYu.Framework.Staff.BLL;
using XinYu.Framework.Staff.Model;

public partial class Background_Staff_CafeteriaStaffManager : System.Web.UI.Page
{
    private StaffBLL _staffBLL = new StaffBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":
                _staffBLL.RemovePCStaff(id);
                bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
                break;
        }
    }

    private void bindList(int pageIndex, int pageSize)
    {
        var loginedUser = PageUtility.User;

        int total;

        GridView1.DataSource = _staffBLL.GetCafeteriaStaffList(string.Empty, loginedUser.OrganizationId, null, "order by DisplayOrder Desc", pageIndex, pageSize, out total);
        GridView1.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        bindList(e.PageIndex, e.PageSize);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CafeteriaStaffAdd.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var cafeInfo = e.Row.DataItem as CafeteriaStaffInfo;
            if (cafeInfo == null)
                return;

            var imgIcon = e.Row.FindControl("imgIcon") as Image;
            if (imgIcon != null)
            {
                imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCafeteriaStaffIcon, cafeInfo.IconThum);
            }
        }
    }
}