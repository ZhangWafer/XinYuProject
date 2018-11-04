using System;
using System.IO;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Staff.BLL;
using XinYu.Framework.Staff.Model;

public partial class Background_Staff_PCStaffAdd : System.Web.UI.Page
{
    private StaffBLL _staffBLL = new StaffBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //var loginedInfo = PageUtility.User;

            this.GetRank();

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
        var pcInfo = _staffBLL.GetPCStaff(id);
        if (pcInfo == null)
            return;

        OrganizationName.Text = PageUtility.User.OrganizationName;

        txtName.Text = pcInfo.Name;
        ddlRank.SelectedValue = pcInfo.PcRankId.ToString();
        txtPCNum.Text = pcInfo.PCNum;

        if (!string.IsNullOrWhiteSpace(pcInfo.IconThum))
        {
            this.imgIcon.Visible = true;
            this.imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstPCStaffIcon, pcInfo.IconThum);
        }

        txtTel.Text = pcInfo.Tel;
        txtWechat.Text = pcInfo.Wechat;

        txtOrder.Text = pcInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = pcInfo.CreatedByName;
        lblCreatedDate.Text = pcInfo.CreatedDate.ToString();
        lblLastUpdBy.Text = pcInfo.LastUpdByName;
        lblLastUpdDate.Text = pcInfo.LastUpdDate.ToString();
    }

    private void ClearInfo(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtPCNum.Text = string.Empty;
        txtTel.Text = string.Empty;
        txtWechat.Text = string.Empty;
        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private void GetRank()
    {
        this.ddlRank.DataSource = _staffBLL.GetRankList(string.Empty, "order by id");
        this.ddlRank.DataBind();
    }

    private PCStaffInfo GetPcInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入警员名称！";
            return null;
        }

        if (string.IsNullOrEmpty(ddlRank.SelectedValue))
        {
            lblError.Text = "请选择警员的警衔！";
            return null;
        }

        if (string.IsNullOrEmpty(txtPCNum.Text.Trim()))
        {
            lblError.Text = "请输入警员的警号！";
            return null;
        }

        //if (string.IsNullOrEmpty(Request["id"]))  //警员添加时，必须上传Icon
        //{
        //    if (!fileIcon.HasFile)
        //    {
        //        lblError.Text = "请上传警员的头像！";
        //        return null;
        //    }
        //}

        if (string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            lblError.Text = "请输入警号的电话！";
            return null;
        }

        if (string.IsNullOrEmpty(txtWechat.Text.Trim()))
        {
            lblError.Text = "请输入警员的微信号！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new PCStaffInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var pcInfo = _staffBLL.GetPCStaff(Convert.ToInt32(Request["id"]));
            if (pcInfo == null)
                return null;

            ret = pcInfo;
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

            FileUtility.FileSave(FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstPCStaffIcon, filePath),
                this.fileIcon.PostedFile, 60, 60,
                FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstPCStaffIcon, filePathThum));

            ret.Icon = filePath;
            ret.IconThum = filePathThum;
        }

        ret.Name = txtName.Text.Trim();
        ret.PcRankId = Convert.ToInt32(ddlRank.SelectedValue);
        ret.PcRank = ddlRank.SelectedItem.Text;
        ret.PCNum = txtPCNum.Text.Trim();
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
        Response.Redirect("PCStaffManager.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cafeInfo = GetPcInfo(PageUtility.User);
        if (cafeInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _staffBLL.AddPCStaff(cafeInfo);
            }
            else
            {
                _staffBLL.ModifyPCStaff(cafeInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("PCStaffManager.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearInfo(PageUtility.User);
    }
}