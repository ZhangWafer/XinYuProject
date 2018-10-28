using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;

public partial class Background_Cookbook_CookbookSetInDateDetailManager : System.Web.UI.Page
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
        gdCookbookDate.DataSource = _cookbookBLL.GetCookbookSetInDateDetailList(Convert.ToInt32(Request["id"]));
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
            var csddInfo = e.Row.DataItem as CookbookSetInDateDetailInfo;
            if (csddInfo == null)
                return;

            var cbInfo = _cookbookBLL.GetCookbook(csddInfo.CookbookId);
            if (cbInfo != null)
            {
                var imgIcon = e.Row.FindControl("imgIcon") as Image;
                if (imgIcon != null)
                    imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCookbookImg, cbInfo.IconThum);

                var lblPrice = e.Row.FindControl("lblPrice") as Label;
                if (lblPrice != null)
                    lblPrice.Text = cbInfo.Price.ToString();

                var lblSalePrice = e.Row.FindControl("lblSalePrice") as Label;
                if (lblSalePrice != null)
                    lblSalePrice.Text = cbInfo.SalePrice.ToString();
            }
        }
    }
    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookSetInDateManager.aspx");
    }
}