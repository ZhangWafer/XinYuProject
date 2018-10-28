using System;
using System.IO;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Membership.Model;

public partial class Background_Cookbook_CookbookAdd : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var id = int.Parse(Request["id"]);
                DisplayInfo(id);
            }
            else
            {
                //OrganizationName.Text = PageUtility.User.OrganizationName;

                lblCreatedBy.Text = PageUtility.User.Alias;
                lblCreatedDate.Text = DateTime.Now.ToString();
                lblLastUpdBy.Text = PageUtility.User.Alias;
                lblLastUpdDate.Text = DateTime.Now.ToString();
            }
        }
    }

    private void DisplayInfo(int id)
    {
        var cbInfo = _cookbookBLL.GetCookbook(id);
        if (cbInfo == null)
            return;

        txtName.Text = cbInfo.Name;
        txtDescription.Text = cbInfo.Description;

        txtPrice.Text = cbInfo.Price.ToString();
        txtSalePrice.Text = cbInfo.SalePrice.ToString();

        txtOrder.Text = cbInfo.DisplayOrder.ToString();

        if (!string.IsNullOrWhiteSpace(cbInfo.IconThum))
        {
            this.imgIcon.Visible = true;
            this.imgIcon.ImageUrl = string.Format("{0}/{1}", FileUtility.ConstCookbookImg, cbInfo.IconThum);
        }

        txtOrder.Text = cbInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = cbInfo.CreatedByName;
        lblCreatedDate.Text = cbInfo.CreatedDate.ToString();
        lblLastUpdBy.Text = cbInfo.LastUpdByName;
        lblLastUpdDate.Text = cbInfo.LastUpdDate.ToString();
    }

    private void ClearInfo(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;

        txtPrice.Text = string.Empty;
        txtSalePrice.Text = string.Empty;

        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private CookbookInfo getCookbookInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入菜品名称！";
            return null;
        }

        if (string.IsNullOrEmpty(txtPrice.Text.Trim()) || !ValidationUtility.IsDecimal(txtPrice.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的价格数值！";
            return null;
        }


        if (string.IsNullOrEmpty(txtSalePrice.Text.Trim()) || !ValidationUtility.IsDecimal(txtSalePrice.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的优惠价格数值！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsDecimal(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new CookbookInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cbInfo = _cookbookBLL.GetCookbook(Convert.ToInt32(Request["id"]));
            if (cbInfo == null)
                return null;

            ret = cbInfo;
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

            FileUtility.FileSave(FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstCookbookImg, filePath),
                this.fileIcon.PostedFile, 60, 60,
                FileUtility.GetPhysicAbsoluteFullFileName(FileUtility.ConstCookbookImg, filePathThum));

            ret.Icon = filePath;
            ret.IconThum = filePathThum;
        }

        ret.Name = txtName.Text.Trim();
        ret.Description = txtDescription.Text.Trim();

        ret.Price = decimal.Parse(txtPrice.Text.Trim());
        ret.SalePrice = decimal.Parse(txtSalePrice.Text.Trim());
        ret.RealPrice = ret.Price - ret.SalePrice;

        if (!loginedUser.IsSystem)
        {
            if (loginedUser.OrganizationId != null)
                ret.OrganizationId = loginedUser.OrganizationId.Value;
            ret.OrganizationName = loginedUser.OrganizationName;
        }

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookManager.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cbInfo = getCookbookInfo(PageUtility.User);
        if (cbInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _cookbookBLL.AddCookbook(cbInfo);
            }
            else
            {
                _cookbookBLL.ModifyCookbook(cbInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("CookbookManager.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearInfo(PageUtility.User);
    }
}