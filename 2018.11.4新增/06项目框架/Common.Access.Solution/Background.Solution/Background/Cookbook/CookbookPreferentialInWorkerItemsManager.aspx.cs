using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Staff;

public partial class Background_Cookbook_CookbookPreferentialInWorkerItemsManager : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["id"] == null)
                return;

            bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
        }
    }


    private void bindList(int pageIndex, int pageSize)
    {
        var loginedUser = PageUtility.User;

        var cid = Convert.ToInt32(Request["id"]);

        int total;

        GridView1.DataSource = _cookbookBLL.GetCookbookPreferentialWorkerList(string.Empty, null, cid, loginedUser.OrganizationId, "order by DisplayOrder Desc", pageIndex, pageSize, out total);
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var cprInfo = e.Row.DataItem as CookbookPreferentialWorkerInfo;
            if (cprInfo != null)
            {
                var lblWorkerStaffEnum = e.Row.FindControl("lblWorkerStaffEnum") as Label;
                if (lblWorkerStaffEnum != null)
                {
                    if (cprInfo.WorkerStaffEnum == WorkerStaffEnum.Emploee)
                    {
                        lblWorkerStaffEnum.Text = "职工";
                    }
                    else if (cprInfo.WorkerStaffEnum == WorkerStaffEnum.Stationed)
                    {
                        lblWorkerStaffEnum.Text = "驻场人员";
                    }
                    else if (cprInfo.WorkerStaffEnum == WorkerStaffEnum.Worker)
                    {
                        lblWorkerStaffEnum.Text = "工作人员";
                    }
                }
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":
                _cookbookBLL.RemoveCookbookPreferentialWorker(id);
                bindList(PageUtility.NAVIGATION_DEFAULT_PAGEINDEX, PageUtility.NAVIGATION_DEFAULT_PAGESIZE);
                break;
        }
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookPreferentialWorkerAdd.aspx");
    }
}