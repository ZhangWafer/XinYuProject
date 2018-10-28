using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cafeteria.BLL;

public partial class Background_Cafeteria_Manager : System.Web.UI.Page
{
    private CafeteriBLL _cafeteriBLL = new CafeteriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindList();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = int.Parse(e.CommandArgument.ToString());

        switch (e.CommandName)
        {
            case "Remove":
                _cafeteriBLL.RemoveCafeteri(id);
                bindList();
                break;
        }
    }

    private void bindList()
    {
        var loginedInfo = PageUtility.User;

        GridView1.DataSource =
            _cafeteriBLL.GetCafeteriList(string.Empty, "order by id")
                .Where(i => loginedInfo.OrganizationId != null && i.OrganizationId == loginedInfo.OrganizationId.Value);
        GridView1.DataBind();
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CafeteriaAdd.aspx");
    }
}