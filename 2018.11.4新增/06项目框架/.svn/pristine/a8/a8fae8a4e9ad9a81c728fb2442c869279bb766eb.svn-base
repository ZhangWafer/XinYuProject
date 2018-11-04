using System;

using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_RoleAdd : System.Web.UI.Page
{
    const string COSNT_BUTTON_TEXT_ADD = PageUtility.COSNT_BUTTON_TEXT_ADD;
    const string COSNT_BUTTON_TEXT_SAVE = PageUtility.COSNT_BUTTON_TEXT_SAVE;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var BLL = new RoleManagerBLL();

            // 检查mid是否存在参数
            RoleInfo selectedRole = null;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var selectedRoleID = int.Parse(Request["id"]);
                selectedRole = BLL.GetRole(selectedRoleID);

                // 未找到模块对象
                if (selectedRole == null)
                {
                    Response.Redirect("~/common/erroraccess.aspx");
                    return;
                }
            }

            // 显示要修改的模块内容
            DisplayRole(PageUtility.User, selectedRole);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var bll = new RoleManagerBLL();

        var role = GetRole(PageUtility.User, bll);
        if (role == null) return;

        try
        {
            if (hdnRoleNo.Value == string.Empty)
            {
                bll.AddRole(role);
            }
            else
            {
                bll.ModifyRole(role);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("RoleManager.aspx");
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearRole(PageUtility.User);
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleManager.aspx");
    }

    protected void btnPopedom_Click(object sender, EventArgs e)
    {
        Response.Redirect("RolePopedomManager.aspx?id=" + hdnRoleNo.Value.Trim());
    }

    private void DisplayRole(UserInfo loginUser, RoleInfo role)
    {
        hdnRoleNo.Value = string.Empty;
        lblCreatedBy.Text = loginUser.Alias;
        lblCreatedDate.Text = DateTime.Now.ToString();
        lblLastUpdBy.Text = loginUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
        btnPopedom.Visible = false;

        if (role == null) return;

        hdnRoleNo.Value = role.ID.ToString();

        txtName.Text = role.RoleName;
        txtDesc.Text = role.Description;

        txtOrder.Text = role.DisplayOrder.ToString();

        lblCreatedBy.Text = role.CreatedByName;
        lblCreatedDate.Text = role.CreatedDate.ToString();
        lblLastUpdBy.Text = role.LastUpdByName;
        lblLastUpdDate.Text = role.LastUpdDate.ToString();

        btnAdd.Text = COSNT_BUTTON_TEXT_SAVE;
        btnPopedom.Visible = true;
    }

    private void ClearRole(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtDesc.Text = string.Empty;
        txtOrder.Text = "100";

        //lblCreatedBy.Text = displayUser.CreatedBy;
        //lblCreatedDate.Text = displayUser.CreatedDate.ToString();
        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private RoleInfo GetRole(UserInfo loginedUser, RoleManagerBLL BLL)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入角色名称！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new RoleInfo
        {
            ID = 0,
            PopedomIDs = string.Empty,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(hdnRoleNo.Value.Trim()))
        {
            var existRole = BLL.GetRole(int.Parse(hdnRoleNo.Value.Trim()));
            if (existRole == null)
            {
                lblError.Text = "修改的对象未找到！请确认该对象是否被其它用户删除！";
                return null;
            }
            ret = existRole;
        }

        ret.RoleName = txtName.Text.Trim();
        ret.HeadImage = string.Empty;
        ret.Description = txtDesc.Text.Trim();

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }
}