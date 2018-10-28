using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Spotmau.Framework.Web.Controls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;

public partial class Background_Cookbook_CookbookSetInDateManager : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }

    private void BindList(int pageIndex, int pageSize)
    {
        var loginedUser = PageUtility.User;

        int total;

        gdCookbookDate.DataSource = _cookbookBLL.GetCookbookSetInDateList(null, null, loginedUser.OrganizationId, null, pageIndex, pageSize, out total);
        gdCookbookDate.DataBind();

        Navigation1.DataBind(pageIndex, pageSize, total);
    }

    protected void gdCookbookDate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":
                _cookbookBLL.RemoveCookbookSetInDate(id);
                _cookbookBLL.RemoveCookbookSetInDateDetailByCookbookDateId(id);
                BindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
                break;
        }
    }

    protected void gdCookbookDate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var csdInfo = e.Row.DataItem as CookbookSetInDateInfo;
            if (csdInfo == null)
                return;

            var lblDate = e.Row.FindControl("lblDate") as Label;
            if (lblDate != null)
                lblDate.Text = csdInfo.ChooseDate.ToShortDateString();

            var lblCookbookEnum = e.Row.FindControl("lblCookbookEnum") as Label;
            if (lblCookbookEnum != null)
                lblCookbookEnum.Text = GetDescription(csdInfo.CookbookEnum);

            var lblPrice = e.Row.FindControl("lblPrice") as Label;
            if (csdInfo.Price.HasValue && lblPrice != null)
                lblPrice.Text = string.Format("自助餐 " + csdInfo.Price);

        }
    }

    protected void Navigation1_NavigationStatusChanged(object sender, NavigationEventArgs e)
    {
        BindList(e.PageIndex, e.PageSize);
    }

    public string GetDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        var result = attributes.Length > 0 ? attributes[0].Description : null;
        return result;
    }


    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookSetInDateAdd.aspx");
    }
}