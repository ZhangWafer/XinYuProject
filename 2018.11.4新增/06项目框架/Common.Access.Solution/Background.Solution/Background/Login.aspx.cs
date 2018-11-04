using System;
using System.Web.UI;
using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ICacheManager cache = CommonLibraryFactory.CreateInstance<ICacheManager>("httpRuntimeCacheManager");
        //ILogger logger = CommonLibraryFactory.CreateInstance<ILogger>("eventLogger");

        // 进入这个页面就会清空所有会话对象
        PageUtility.Logout();
    }


    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()) || string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
        //{
        //    this.lblError.Text = "请输入账号和密码!";
        //    return;
        //}

        var bll = new AccountBLL();
        var user = bll.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
        if (user == null)
        {
            this.lblError.Text = "账号不存在或密码错误!";
            return;
        }

        if (user.IsLockedOut)
        {
            this.lblError.Text = "您的账号已被锁定!请联系系统管理员!";
            return;
        }

        PageUtility.Login(user);
        Response.Redirect("~/Background/Framework.aspx");
    }
}