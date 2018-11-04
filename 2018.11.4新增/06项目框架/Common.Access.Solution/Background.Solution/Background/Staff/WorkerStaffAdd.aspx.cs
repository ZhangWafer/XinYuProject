using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cafeteria.BLL;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Staff;
using XinYu.Framework.Staff.BLL;
using XinYu.Framework.Staff.Model;

public partial class Background_Staff_WorkerStaffAdd : System.Web.UI.Page
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
                lblOrganizationName.Text = PageUtility.User.OrganizationName;


                lblCreatedBy.Text = PageUtility.User.Alias;
                lblCreatedDate.Text = DateTime.Now.ToString();
                lblLastUpdBy.Text = PageUtility.User.Alias;
                lblLastUpdDate.Text = DateTime.Now.ToString();
            }
        }
    }

    private void DisplayInfo(int id)
    {
        var workerInfo = _staffBLL.GetWorkerStaff(id);
        if (workerInfo == null)
            return;


        txtInformationNum.Text = workerInfo.InformationNum;
        ddlWorkerStaffEnum.SelectedValue = workerInfo.WorkerStaffEnum.ToString();
        lblOrganizationName.Text = PageUtility.User.OrganizationName;

        txtName.Text = workerInfo.Name;
        ddlCafeters.SelectedValue = workerInfo.CafeteriaId.ToString();

        if (!string.IsNullOrWhiteSpace(workerInfo.IconThum))
        {
            this.imgIcon.Visible = true;
            this.imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCafeteriaStaffIcon, workerInfo.IconThum);
        }

        txtTel.Text = workerInfo.Tel;
        txtWechat.Text = workerInfo.Wechat;

        txtOrder.Text = workerInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = workerInfo.CreatedByName;
        lblCreatedDate.Text = workerInfo.CreatedDate.ToString();
        lblLastUpdBy.Text = workerInfo.LastUpdByName;
        lblLastUpdDate.Text = workerInfo.LastUpdDate.ToString();
    }

    private void GetCafeters()
    {
        var loginedInfo = PageUtility.User;

        this.ddlCafeters.DataSource =
            _cafeteriBLL.GetCafeteriList(string.Empty, "order by id")
                .Where(i => i.OrganizationId == loginedInfo.OrganizationId.Value);
        this.ddlCafeters.DataBind();
    }

    private WorkersStaffInfo GetWorkersStaffInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtInformationNum.Text.Trim()))
        {
            lblError.Text = "请输入工作人员身份证号码！";
            return null;
        }

        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入工作人员名称！";
            return null;
        }

        //if (string.IsNullOrEmpty(txtTel.Text.Trim()))
        //{
        //    lblError.Text = "请输入工作人员的电话！";
        //    return null;
        //}

        //if (string.IsNullOrEmpty(txtWechat.Text.Trim()))
        //{
        //    lblError.Text = "请输入工作人员的微信号！";
        //    return null;
        //}

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new WorkersStaffInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cateInfo = _staffBLL.GetWorkerStaff(Convert.ToInt32(Request["id"]));
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

        ret.InformationNum = this.txtInformationNum.Text.Trim();
        ret.WorkerStaffEnum = (WorkerStaffEnum)Enum.Parse(typeof(WorkerStaffEnum), ddlWorkerStaffEnum.SelectedValue);

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

    private void ClearInfo(UserInfo loginedUser)
    {
        txtInformationNum.Text = string.Empty;
        txtName.Text = string.Empty;
        txtTel.Text = string.Empty;
        txtWechat.Text = string.Empty;
        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var workerInfo = GetWorkersStaffInfo(PageUtility.User);
        if (workerInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _staffBLL.AddWorkerStaff(workerInfo);
            }
            else
            {
                _staffBLL.ModifyWorkerStaff(workerInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("WorkerStaffManager.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearInfo(PageUtility.User);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkerStaffManager.aspx");
    }
}