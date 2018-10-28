using System;
using System.Web.UI.WebControls;
using XinYu.Framework.Organization.BLL;

public partial class Background_Organization_OrganizationManager : System.Web.UI.Page
{
    private OrganizationBLL _bll = new OrganizationBLL();

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
                _bll.RemoveOrganization(id);
                bindList();
                break;
        }
    }

    private void bindList()
    {
        GridView1.DataSource = _bll.GetOrganizationList(string.Empty, "order by DisplayOrder Desc");
        GridView1.DataBind();
    }


    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationAdd.aspx");
    }
}