using System;
using System.IO;
using System.Linq;
using XinYu.Framework.Cafeteria.BLL;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Staff.BLL;
using XinYu.Framework.Staff.Model;

public partial class Background_Staff_CafeteriaStaffAdd : System.Web.UI.Page
{
    private CafeteriBLL _cafeteriBLL = new CafeteriBLL();
    private StaffBLL _staffBLL = new StaffBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetCafeters();

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var id = int.Parse(Request["id"]);
                DisplayInfo(id);
            }
            else
            {
                OrganizationName.Text = PageUtility.User.OrganizationName;

                lblCreatedBy.Text = PageUtility.User.Alias;
                lblCreatedDate.Text = DateTime.Now.ToString();
                lblLastUpdBy.Text = PageUtility.User.Alias;
                lblLastUpdDate.Text = DateTime.Now.ToString();
            }
        }
    }

    private void DisplayInfo(int id)
    {
        var cafeInfo = _staffBLL.GetCafeteriaStaff(id);
        if (cafeInfo == null)
            return;

        OrganizationName.Text = PageUtility.User.OrganizationName;

        txtName.Text = cafeInfo.Name;
        ddlCafeters.SelectedValue = cafeInfo.CafeteriaId.ToString();

        if (!string.IsNullOrWhiteSpace(cafeInfo.IconThum))
        {
            this.imgIcon.Visible = true;
            this.imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCafeteriaStaffIcon, cafeInfo.IconThum);
        }

        txtTel.Text = cafeInfo.Tel;
        txtWechat.Text = cafeInfo.Wechat;

        txtOrder.Text = cafeInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = cafeInfo.CreatedByName;
        lblCreatedDate.Text = cafeInfo.CreatedDate.ToString();
        lblLastUpdBy.Text = cafeInfo.LastUpdByName;
        lblLastUpdDate.Text = cafeInfo.LastUpdDate.ToString();
    }

    private void GetCafeters()
    {
        var loginedInfo = PageUtility.User;

        this.ddlCafeters.DataSource =
            _cafeteriBLL.GetCafeteriList(string.Empty, "order by id")
                .Where(i => i.OrganizationId == loginedInfo.OrganizationId.Value);
        this.ddlCafeters.DataBind();
    }

    private void ClearInfo(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtTel.Text = string.Empty;
        txtWechat.Text = string.Empty;
        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private CafeteriaStaffInfo GetCafeInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入食管人员名称！";
            return null;
        }

        if (string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            lblError.Text = "请输入食管人员的电话！";
            return null;
        }

        if (string.IsNullOrEmpty(txtWechat.Text.Trim()))
        {
            lblError.Text = "请输入食管人员的微信号！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new CafeteriaStaffInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cateInfo = _staffBLL.GetCafeteriaStaff(Convert.ToInt32(Request["id"]));
            if (cateInfo == null)
                return null;

            ret = cateInfo;
        }

        if (fileIcon.HasFile)
        {
            var fileExt = FileUtility.GetExtension(fileIcon.FileName);
            if (fileExt.ToLower() != ".jpg" && fileExt.ToLower() != ".png")
            {
                lblError.Text = "请输入jpg或png图片！";
                return null;
            }

            var filePath = FileUtility.GetNewFileName(Path.GetFileName(fileIcon.FileName));
            var filePathThum = FileUtility.GetNewFileName(filePath);

            FileUtility.FileSave(FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstCafeteriaStaffIcon, filePath),
                this.fileIcon.PostedFile, 60, 60,
                FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstCafeteriaStaffIcon, filePathThum));

            ret.Icon = filePath;
            ret.IconThum = filePathThum;
        }

        ret.Name = txtName.Text.Trim();

        ret.CafeteriaId = Convert.ToInt32(ddlCafeters.SelectedValue);
        ret.CafeteriaName = ddlCafeters.SelectedItem.Text;

        ret.Tel = txtTel.Text.Trim();
        ret.Wechat = txtWechat.Text.Trim();

        if (loginedUser.OrganizationId != null)
            ret.OrganizationId = loginedUser.OrganizationId.Value;

        ret.OrganizationName = loginedUser.OrganizationName;

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CafeteriaStaffManager.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cafeInfo = GetCafeInfo(PageUtility.User);
        if (cafeInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _staffBLL.AddCafeteriaStaff(cafeInfo);
            }
            else
            {
                _staffBLL.ModifyCafeteriaStaff(cafeInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("CafeteriaStaffManager.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearInfo(PageUtility.User);
    }
}