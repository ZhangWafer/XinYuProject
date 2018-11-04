using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Organization.BLL;

public partial class Background_SysManager_UserAdd : System.Web.UI.Page
{
    const string COSNT_BUTTON_TEXT_ADD = PageUtility.COSNT_BUTTON_TEXT_ADD;
    const string COSNT_BUTTON_TEXT_SAVE = PageUtility.COSNT_BUTTON_TEXT_SAVE;

    private OrganizationBLL _orgBll = new OrganizationBLL();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PageUtility.IsLogin)
        {
            Response.Redirect("~/logout.aspx");
            return;
        }

        if (!IsPostBack)
        {
            var bll = new UserManagerBLL();

            // *******************************************************************
            // 检查id是否存在参数
            UserInfo selectedUser = null;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                selectedUser = bll.GetUser(int.Parse(Request["id"]));

                // 未找到对象
                if (selectedUser == null)
                    Response.Redirect("~/common/erroraccess.aspx");
            }

            // *******************************************************************
            // 显示要修改的模块内容

            bindOrg();  //显示构件数据
            bindRoleList(bll);
            displayUser(PageUtility.User, selectedUser);
        }
    }

    private void bindOrg()
    {
        ddlOrg.DataSource = _orgBll.GetOrganizationList(string.Empty, "order by DisplayOrder Desc");
        ddlOrg.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var bll = new UserManagerBLL();

        var newUser = getUser(PageUtility.User, bll);
        if (newUser == null) return;

        try
        {
            if (string.IsNullOrEmpty(hdnEditingUserNo.Value.Trim()))
            {
                bll.AddUser(newUser);
            }
            else   ///修改用户操作
            {
                bll.ModifyUser(newUser);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("UserManager.aspx");
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearUser(PageUtility.User);
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManager.aspx");
    }

    protected void btnPopedom_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPopedomManager.aspx?id=" + hdnEditingUserNo.Value.Trim());
    }

    protected void btnViewPopedom_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPopedomView.aspx?id=" + hdnEditingUserNo.Value.Trim());
    }

    #region Private methods.

    private void bindRoleList(UserManagerBLL BLL)
    {
        chklstRoleList.DataSource = BLL.GetCachingRoleList();
        chklstRoleList.DataTextField = "RoleName";
        chklstRoleList.DataValueField = "ID";
        chklstRoleList.DataBind();
    }

    private void displayUser(UserInfo loginedUser, UserInfo displayUser)
    {
        hdnEditingUserNo.Value = string.Empty;
        lblCreatedBy.Text = loginedUser.Alias;
        lblCreatedDate.Text = DateTime.Now.ToString();
        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
        btnPopedom.Visible = false;
        btnViewPopedom.Visible = false;

        // 清空角色选项
        if (displayUser == null) return;

        hdnEditingUserNo.Value = displayUser.ID.ToString();

        txtUserName.Text = displayUser.UserName;

        ddlOrg.SelectedValue = displayUser.OrganizationId.ToString();
        txtAlias.Text = displayUser.Alias;
        txtEmail.Text = displayUser.Email;
        txtDescription.Text = displayUser.Description;
        cbxIsLockout.Checked = displayUser.IsLockedOut;

        foreach (int roleID in displayUser.RoleIDList)
        {
            var item = chklstRoleList.Items.FindByValue(roleID.ToString());
            if (item != null) item.Selected = true;
        }

        lblCreatedBy.Text = displayUser.CreatedByName;
        lblCreatedDate.Text = displayUser.CreatedDate.ToString();
        lblLastUpdBy.Text = displayUser.LastUpdByName;
        lblLastUpdDate.Text = displayUser.LastUpdDate.ToString();

        btnAdd.Text = COSNT_BUTTON_TEXT_SAVE;
        btnPopedom.Visible = (displayUser.IsAdmin);
        btnViewPopedom.Visible = (displayUser.IsAdmin);
    }

    private void clearUser(UserInfo loginedUser)
    {
        txtUserName.Text = string.Empty;
        txtAlias.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtDescription.Text = string.Empty;
        cbxIsLockout.Checked = false;

        //lblCreatedBy.Text = displayUser.CreatedBy;
        //lblCreatedDate.Text = displayUser.CreatedDate.ToString();
        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private UserInfo getUser(UserInfo loginedUser, UserManagerBLL BLL)
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

        if (ddlOrg.SelectedItem == null || string.IsNullOrEmpty(ddlOrg.SelectedValue))
        {
            lblError.Text = "请选择管理机构！";
            return null;
        }

        var ret = new UserInfo
        {
            ID = 0,
            EncryptedPassword = "",
            PasswordAnswer = string.Empty,
            PasswordQuestion = string.Empty,
            SessionIdentify = Guid.NewGuid().ToString(),
            IsSystem = false,
            IsAdmin = true,
            IsApproved = true,
            PopedomIDs = string.Empty,
            FailedPwdAttemptCount = 0,
            FailedPwdAttemptDate = DateTime.Now,
            FailedAnswerAttemptCount = 0,
            FailedAnswerAttemptDate = DateTime.Now,
            LastLoginDate = DateTime.Now,
            LastLockoutDate = DateTime.Now,
            LastActivityDate = DateTime.Now,
            LastPwdChangedDate = DateTime.Now,
            DisplayOrder = 100,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象            
        if (!string.IsNullOrEmpty(hdnEditingUserNo.Value.Trim()))
        {
            UserInfo existUser = BLL.GetUser(int.Parse(hdnEditingUserNo.Value.Trim()));
            if (existUser == null)
            {
                lblError.Text = "修改的对象未找到！请确认该对象是否被其它用户删除！";
                return null;
            }
            ret = existUser;
        }

        ret.UserName = txtUserName.Text.Trim();

        ret.OrganizationId = Convert.ToInt32(ddlOrg.SelectedValue);
        ret.OrganizationName = ddlOrg.SelectedItem.Text;

        ret.Alias = txtAlias.Text.Trim();
        ret.Email = txtEmail.Text.Trim();
        ret.Description = txtDescription.Text.Trim();
        ret.IsLockedOut = cbxIsLockout.Checked;

        // 加入会员的管理角色
        var roleList = new List<RoleInfo>();
        foreach (ListItem item in chklstRoleList.Items)
        {
            if (item.Selected) ret.AddRole(int.Parse(item.Value.Trim()));
        }

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    #endregion
}