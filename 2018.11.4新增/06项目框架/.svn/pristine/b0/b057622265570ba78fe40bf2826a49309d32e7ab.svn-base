using System;

using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_ModuleAdd : System.Web.UI.Page
{
    const string COSNT_BUTTON_TEXT_ADD = PageUtility.COSNT_BUTTON_TEXT_ADD;
    const string COSNT_BUTTON_TEXT_SAVE = PageUtility.COSNT_BUTTON_TEXT_SAVE;

    const string CONST_EMPTY_PARENT_NAME = "NULL";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new ModuleManagerBLL();

            // 检查id是否存在参数
            ModuleInfo selectedModule = null;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int selectedModuleID = int.Parse(Request["id"]);
                selectedModule = bll.GetModule(selectedModuleID);

                // 未找到模块对象
                if (selectedModule == null)
                {
                    Response.Redirect("~/common/erroraccess.aspx");
                    return;
                }
            }

            // 检查parentid是否存在参数
            int parentModuleID = (selectedModule == null) ? ModuleInfo.CONST_EMPTY_ID : selectedModule.ParentID;
            if (selectedModule == null && !string.IsNullOrEmpty(Request["parentid"]))
                parentModuleID = int.Parse(Request["parentid"]);

            // 显示父级模块名称
            var parentModule = bll.GetModule(parentModuleID);

            lblParentModule.Text = (parentModule == null) ? CONST_EMPTY_PARENT_NAME : parentModule.Name;
            hdnParentModuleNo.Value = (parentModule == null) ? ModuleInfo.CONST_EMPTY_ID.ToString() : parentModule.ID.ToString();
            hdnRootModuleNo.Value = (parentModule == null) ? ModuleInfo.CONST_EMPTY_ID.ToString() : parentModule.RootID.ToString();

            // 显示要修改的模块内容
            DisplayModule(PageUtility.User, selectedModule);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var bll = new ModuleManagerBLL();

        var module = GetModule(PageUtility.User, bll);
        if (module == null) return;

        try
        {
            if (hdnModuleNo.Value.Trim() == string.Empty)
            {
                bll.AddModule(module);
            }
            else
            {
                bll.ModifyModule(module);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("ModuleManager.aspx?parentid=" + module.ParentID);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearModule(PageUtility.User);
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModuleManager.aspx?parentid=" + hdnParentModuleNo.Value);
    }



    private void DisplayModule(UserInfo user, ModuleInfo module)
    {
        hdnModuleNo.Value = string.Empty;
        lblCreatedBy.Text = user.Alias;
        lblCreatedDate.Text = DateTime.Now.ToString();
        lblLastUpdBy.Text = user.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();

        if (module == null) return;

        hdnModuleNo.Value = module.ID.ToString();

        txtName.Text = module.Name;
        txtUrl.Text = module.Url;

        imgIcon.ImageUrl = !string.IsNullOrEmpty(module.Icon) ? module.Icon 
            : PageUtility.CONST_MENU_IMAGE;

        cbxIsMenu.Checked = module.IsMenu;
        cbxIsFloder.Checked = module.IsFloder;
        cbxIsPopedom.Checked = module.IsPopedom;

        txtOrder.Text = module.DisplayOrder.ToString();

        lblCreatedBy.Text = module.CreatedByName;
        lblCreatedDate.Text = module.CreatedDate.ToString();
        lblLastUpdBy.Text = module.LastUpdByName;
        lblLastUpdDate.Text = module.LastUpdDate.ToString();

        btnAdd.Text = COSNT_BUTTON_TEXT_SAVE;
    }

    private void ClearModule(UserInfo user)
    {
        txtName.Text = string.Empty;
        txtUrl.Text = string.Empty;
        imgIcon.ImageUrl = PageUtility.CONST_MENU_IMAGE;

        cbxIsMenu.Checked = false;
        cbxIsFloder.Checked = false;
        cbxIsPopedom.Checked = false;

        txtOrder.Text = @"100";

        //lblCreatedBy.Text = module.CreatedBy;
        //lblCreatedDate.Text = module.CreatedDate.ToString();
        lblLastUpdBy.Text = user.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private ModuleInfo GetModule(UserInfo user, ModuleManagerBLL bll)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(hdnParentModuleNo.Value.Trim()))
        {
            lblError.Text = "请选择父模块！";
            return null;
        }

        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入模块名称！";
            return null;
        }

        if (cbxIsMenu.Checked && !cbxIsFloder.Checked && string.IsNullOrEmpty(txtUrl.Text.Trim()))
        {
            lblError.Text = "当模块为菜单项且不是菜单组时，请输入模块URL！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new ModuleInfo
        {
            ID = ModuleInfo.CONST_EMPTY_ID,
            CreatedByID = user.ID,
            CreatedByName = user.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象            
        if (!string.IsNullOrEmpty(hdnModuleNo.Value.Trim()))
        {
            var existModule = bll.GetModule(int.Parse(hdnModuleNo.Value.Trim()));
            if (existModule == null)
            {
                lblError.Text = "修改的对象未找到！请确认该对象是否被其它用户删除！";
                return null;
            }
            ret = existModule;
        }

        ret.ParentID = int.Parse(hdnParentModuleNo.Value.Trim());
        ret.RootID = int.Parse(hdnRootModuleNo.Value.Trim());
        ret.Name = txtName.Text.Trim();
        ret.Url = txtUrl.Text.Trim();

        // 获取ICON
        ret.Icon = FileUtility.SaveUploadingMenuIcon(fupIcon);


        ret.IsMenu = cbxIsMenu.Checked;
        ret.IsFloder = cbxIsFloder.Checked;
        ret.IsPopedom = cbxIsPopedom.Checked;

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = user.ID;
        ret.LastUpdByName = user.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }
}