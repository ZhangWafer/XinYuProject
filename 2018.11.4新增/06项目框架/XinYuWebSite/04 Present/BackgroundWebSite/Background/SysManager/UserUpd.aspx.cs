using System;

using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_UserUpd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new UserManagerBLL();

            // 显示要修改的模块内容
            DisplayUser(PageUtility.User);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var bll = new UserManagerBLL();

        var newUser = GetUser(bll);
        if (newUser == null) return;

        try
        {
            bll.ModifyUser(newUser);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        lblError.Text = "修改成功！";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearUser();
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Calendar.htm");
    }


    #region Private methods.

    private void DisplayUser(UserInfo displayUser)
    {
        if (displayUser == null) return;

        txtUserName.Text = displayUser.UserName;
        txtAlias.Text = displayUser.Alias;
        txtEmail.Text = displayUser.Email;
        txtDescription.Text = displayUser.Description;

        lblCreatedBy.Text = displayUser.CreatedByName;
        lblCreatedDate.Text = displayUser.CreatedDate.ToString();
        lblLastUpdBy.Text = displayUser.LastUpdByName;
        lblLastUpdDate.Text = displayUser.LastUpdDate.ToString();
    }

    private void ClearUser()
    {
        txtAlias.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }

    private UserInfo GetUser(UserManagerBLL bll)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtAlias.Text.Trim()))
        {
            lblError.Text = "请输入用户账号和用户姓名！";
            return null;
        }
        if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && !ValidationUtility.IsValidEmail(txtEmail.Text.Trim()))
        {
            lblError.Text = "请输入有效的用户邮箱！";
            return null;
        }

        var ret = PageUtility.User;

        ret.Alias = txtAlias.Text.Trim();
        ret.Email = txtEmail.Text.Trim();
        ret.Description = txtDescription.Text.Trim();

        ret.LastUpdByID = ret.ID;
        ret.LastUpdByName = ret.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    #endregion
}