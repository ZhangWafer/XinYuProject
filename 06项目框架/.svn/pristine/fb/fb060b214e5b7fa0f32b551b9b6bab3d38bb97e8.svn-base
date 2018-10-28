using System;
using System.Web.UI.WebControls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;

public partial class Background_Cookbook_CookbookSetInTodayDateManager : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindList();
        }
    }

    private void bindList()
    {
        var today = DateTime.Now.Date;

        var loginedUser = PageUtility.User;
        int total;
        gdCookbookDate.DataSource = _cookbookBLL.GetCookbookSetInDateList(null, today, loginedUser.OrganizationId, null, 1, 10, out total);
        gdCookbookDate.DataBind();

    }

    protected void gdCookbookDate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "Remove":

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



            var lblCookbookEnum = e.Row.FindControl("lblCookbookEnum") as Label;
            if (lblCookbookEnum != null)
            {
                lblCookbookEnum.Text = EnumUtility.GetDescription(csdInfo.CookbookEnum);
            }

            var gdcookbookDateDetails = e.Row.FindControl("gdcookbookDateDetails") as GridView;
            if (gdcookbookDateDetails == null) return;

            gdcookbookDateDetails.DataSource = _cookbookBLL.GetCookbookSetInDateDetailList(csdInfo.Id);
            gdcookbookDateDetails.DataBind();
        }
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookSetInTodayDateManager.aspx");
    }
}