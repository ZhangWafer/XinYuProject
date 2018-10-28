using System;
using XinYu.Framework.Membership.BLL;

public partial class Background_SysManager_UserUpdPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblUserName.Text = string.Format("{0}({1})", PageUtility.User.Alias, PageUtility.User.UserName);
        }
    }

    protected void SubBtn_Click(object sender, EventArgs e)
    {
        var user = PageUtility.User;

        var bll = new AccountBLL();
        if (user != null)
        {
            string curpassword = txtcurpwd.Text.Trim().ToLower();
            string newpassword = txtnewpwd.Text.Trim().ToLower();
            string newpassword1 = txtnewpwd1.Text.Trim().ToLower();

            // 首先判断用户原始密码正确
            if (!bll.CheckPassword(user, curpassword))
            {
                lblError.Text = "原始密码不正确!";
                return;
            }

            if (newpassword != newpassword1)
            {
                lblError.Text = "两次输入的新密码不相同!";
                return;
            }

            try
            {
                bll.ModifyPassword(user, curpassword, newpassword);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                return;
            }

            lblError.Text = "修改成功！";
        }
    }

    protected void RunBtn_Click(object sender, EventArgs e)
    {

    }
}