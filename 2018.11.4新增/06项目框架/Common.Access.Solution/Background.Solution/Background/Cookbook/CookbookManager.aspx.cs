using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spotmau.Framework.Web.Controls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;

public partial class Background_Cookbook_CookbookManager : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();

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
                _cookbookBLL.RemoveCookbook(id);
                bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
                break;
        }
    }

    private void bindList(int pageIndex, int pageSize)
    {
        var loginedUser = PageUtility.User;

        int total;

        GridView1.DataSource = _cookbookBLL.GetCookbookList(string.Empty, loginedUser.OrganizationId, "order by DisplayOrder Desc", pageIndex, pageSize, out total);
        GridView1.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        bindList(e.PageIndex, e.PageSize);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookAdd.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
}