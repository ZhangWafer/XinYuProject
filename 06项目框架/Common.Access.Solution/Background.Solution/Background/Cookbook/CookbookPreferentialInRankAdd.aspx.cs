using System;
using System.Collections.Generic;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Staff.BLL;

public partial class Background_Cookbook_CookbookPreferentialInRankAdd : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();
    private StaffBLL _staffBLL = new StaffBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetRank();
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
        var cpfInfo = _cookbookBLL.GetCookbookPreferentialInRank(id);
        if (cpfInfo == null)
            return;

        txtName.Text = cpfInfo.Name;
        txtDescription.Text = cpfInfo.Description;

        this.ddlRank.SelectedValue = cpfInfo.RankId.ToString();
        this.ddlCookbook.SelectedValue = cpfInfo.CookbookId.ToString();

        txtSalePrice.Text = cpfInfo.SalePrice.ToString();

        txtOrder.Text = cpfInfo.DisplayOrder.ToString();

        lblCreatedBy.Text = cpfInfo.CreatedByName;
        lblCreatedDate.Text = cpfInfo.CreatedDate
            .ToString();
        lblLastUpdBy.Text = cpfInfo.LastUpdByName;
        lblLastUpdDate.Text = cpfInfo.LastUpdDate.ToString();
    }

    private CookbookPreferentialInRankInfo getcprInfo(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入优惠名称！";
            return null;
        }

        if (string.IsNullOrEmpty(ddlCookbook.SelectedValue))
        {
            lblError.Text = "请选择警衔！";
            return null;
        }

        if (string.IsNullOrEmpty(ddlRank.SelectedValue))
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

        var ret = new CookbookPreferentialInRankInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        var rankId = Convert.ToInt32(this.ddlRank.SelectedValue);
        var cookbookId = Convert.ToInt32(this.ddlCookbook.SelectedValue);

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cbrInfo = _cookbookBLL.GetCookbookPreferentialInRank(Convert.ToInt32(Request["id"]));
            if (cbrInfo == null)
                return null;

            ret = cbrInfo;
        }
        else
        {
            //判断是否已经存在了当前机构，当前菜品，当前警衔是的数据是否存在，如果存在，则给出修改链接
            if (loginedUser.OrganizationId != null)
            {
                var info = _cookbookBLL.GetCookbookPreferentialInRank(rankId, cookbookId, loginedUser.OrganizationId.Value);
                if (info != null)
                {
                    lblError.Text = "当前菜品的优惠已经存在，您可以进行修改菜品优惠处理";
                    return null;
                }
            }
        }

        ret.Name = txtName.Text.Trim();
        ret.Description = txtDescription.Text.Trim();

        ret.RankId = rankId;
        ret.RandName = this.ddlRank.SelectedItem.Text;

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

    private void GetCookbooks()
    {
        var cbList = new List<CookbookInfo>();

        cbList.AddRange(_cookbookBLL.GetCookbookList(string.Empty, PageUtility.User.OrganizationId, "order by id"));

        this.ddlCookbook.DataSource = cbList;
        this.ddlCookbook.DataBind();
    }

    private void GetRank()
    {
        this.ddlRank.DataSource = _staffBLL.GetRankList(string.Empty, "order by id");
        this.ddlRank.DataBind();
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cbInfo = getcprInfo(PageUtility.User);
        if (cbInfo == null)
            return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _cookbookBLL.AddCookbookPreferentialInRank(cbInfo);
            }
            else
            {
                _cookbookBLL.ModifyCookbookPreferentialInRank(cbInfo);
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
        ClearInfo(PageUtility.User);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookPreferentialInRankManager.aspx");
    }
}