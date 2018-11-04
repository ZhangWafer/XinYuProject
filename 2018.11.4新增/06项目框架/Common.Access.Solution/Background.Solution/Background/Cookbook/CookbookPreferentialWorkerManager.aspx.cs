using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spotmau.Framework.Web.Controls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;

public partial class Background_Cookbook_CookbookPreferentialWorkerManager : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }

    #region user cookbook Manager
    protected void gdUserCookbook_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":

                break;
        }
    }

    private void bindList(int pageIndex, int pageSize)
    {
        var loginedUser = PageUtility.User;

        int total;

        gdUserCookbook.DataSource = _cookbookBLL.GetCookbookList(string.Empty, loginedUser.OrganizationId, "order by DisplayOrder Desc", pageIndex, pageSize, out total);
        gdUserCookbook.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        bindList(e.PageIndex, e.PageSize);
    }

    protected void gdUserCookbook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var cookbookInfo = e.Row.DataItem as CookbookInfo;
            if (cookbookInfo == null)
                return;

            var imgIcon = e.Row.FindControl("imgIcon") as Image;
            if (imgIcon != null)
            {
                imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCookbookImg, cookbookInfo.IconThum);
            }
        }
    }

    #endregion

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookAdd.aspx");
    }
}