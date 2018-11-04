using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Staff;
using XinYu.Framework.Staff.BLL;

public partial class Background_Cookbook_CookbookPreferentialWorkerAdd : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();
    private StaffBLL _staffBLL = new StaffBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetCookbooks();

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var id = int.Parse(Request["id"]);
                DisplayInfo(id);
            }
            else
            {
                lblCreatedBy.Text = PageUtility.User.Alias;
                lblCreatedDate.Text = DateTime.Now.ToString();
                lblLastUpdBy.Text = PageUtility.User.Alias;
                lblLastUpdDate.Text = DateTime.Now.ToString();
            }
        }
    }

    private void DisplayInfo(int id)
    {
        var cpwInfo = _cookbookBLL.GetCookbookPreferentialWorker(id);
        if (cpwInfo == null)
            return;

        txtName.Text = cpwInfo.Name;
        txtDescription.Text = cpwInfo.Description;

        this.ddlWorkerStaffEnum.SelectedValue = cpwInfo.WorkerStaffEnum.ToString();
        this.ddlCookbook.SelectedValue = cpwInfo.CookbookId.ToString();

        txtSalePrice.Text = cpwInfo.SalePrice.ToString();

        txtOrder.Text = cpwInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = cpwInfo.CreatedByName;
        lblCreatedDate.Text = cpwInfo.CreatedDate
            .ToString();
        lblLastUpdBy.Text = cpwInfo.LastUpdByName;
        lblLastUpdDate.Text = cpwInfo.LastUpdDate.ToString();
    }

    private CookbookPreferentialWorkerInfo getcprInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入优惠名称！";
            return null;
        }

        if (string.IsNullOrEmpty(ddlCookbook.SelectedValue))
        {
            lblError.Text = "请选择菜品！";
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

        var ret = new CookbookPreferentialWorkerInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        var cookbookId = Convert.ToInt32(this.ddlCookbook.SelectedValue);
        var workerType = (WorkerStaffEnum)Enum.Parse(typeof(WorkerStaffEnum), ddlWorkerStaffEnum.SelectedValue);

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cbrInfo = _cookbookBLL.GetCookbookPreferentialWorker(Convert.ToInt32(Request["id"]));
            if (cbrInfo == null)
                return null;

            ret = cbrInfo;
        }
        else
        {
            //判断是否已经存在了当前职工类型，当前菜品，当前机构的数据是否存在，如果存在，则给出修改链接
            if (loginedUser.OrganizationId != null)
            {
                var info = _cookbookBLL.GetCookbookPreferentialWorker(workerType, cookbookId, loginedUser.OrganizationId.Value);
                if (info != null)
                {
                    lblError.Text = "当前菜品的优惠已经存在，您可以进行修改菜品优惠处理";
                    return null;
                }
            }
        }

        ret.Name = txtName.Text.Trim();
        ret.Description = txtDescription.Text.Trim();

        ret.WorkerStaffEnum = workerType;

        ret.CookbookId = cookbookId;
        ret.CookbookName = this.ddlCookbook.SelectedItem.Text;

        ret.SalePrice = decimal.Parse(this.txtSalePrice.Text.Trim());

        //获取cookbook的实际价格
        var cbInfo = _cookbookBLL.GetCookbook(ret.CookbookId);
        if (cbInfo != null)
        {
            ret.RealPrice = cbInfo.Price - ret.SalePrice;
        }

        ret.SalePrice = decimal.Parse(txtSalePrice.Text.Trim());

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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cbInfo = getcprInfo(PageUtility.User);
        if (cbInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _cookbookBLL.AddCookbookPreferentialWorker(cbInfo);
            }
            else
            {
                _cookbookBLL.ModifyCookbookPreferentialWorker(cbInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("CookbookPreferentialWorkerManager.aspx");
    }

    private void GetCookbooks()
    {
        var cbList = new List<CookbookInfo>();

        cbList.AddRange(_cookbookBLL.GetCookbookList(string.Empty, PageUtility.User.OrganizationId, "order by id"));

        this.ddlCookbook.DataSource = cbList;
        this.ddlCookbook.DataBind();
    }

    private void ClearInfo(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;

        txtSalePrice.Text = string.Empty;

        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearInfo(PageUtility.User);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookPreferentialWorkerManager.aspx");
    }
}