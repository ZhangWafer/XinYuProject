using System;
public partial class Background_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Redirect("Login.aspx");
    }
}