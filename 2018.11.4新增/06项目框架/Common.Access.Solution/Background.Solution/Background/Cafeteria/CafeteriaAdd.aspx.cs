﻿using System;
using System.Linq;
using XinYu.Framework.Cafeteria.BLL;
using XinYu.Framework.Cafeteria.Model;
using XinYu.Framework.Membership.Model;

public partial class Background_Cafeteria_Add : System.Web.UI.Page
{
    private CafeteriBLL _cafeteriBLL = new CafeteriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var id = int.Parse(Request["id"]);
                DisplayCafeteri(id);
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

    private void DisplayCafeteri(int id)
    {
        var list = _cafeteriBLL.GetCafeteriList(string.Empty, "order by DisplayOrder");
        if (list == null)
            return;

        var cafeInfo = list.FirstOrDefault(i => i.Id == id);
        if (cafeInfo != null)
        {
            OrganizationName.Text = PageUtility.User.OrganizationName;

            txtName.Text = cafeInfo.Name;
            txtDesc.Text = cafeInfo.Description;
            ddlCafeteriaTypeEnum.SelectedValue = cafeInfo.CafeteriaTypeEnum.ToString();
            txtOrder.Text = cafeInfo.DisplayOrder.ToString();
            lblCreatedBy.Text = cafeInfo.CreatedByName;
            lblCreatedDate.Text = cafeInfo.CreatedDate.ToString();
            lblLastUpdBy.Text = cafeInfo.LastUpdByName;
            lblLastUpdDate.Text = cafeInfo.LastUpdDate.ToString();
        }
    }

    private void ClearOrg(UserInfo loginedUser)
    {
        txtName.Text = string.Empty;
        txtDesc.Text = string.Empty;
        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    private CafeteriInfo GetOrg(UserInfo loginedUser)
    {
        // 检查用户的输入情况
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblError.Text = "请输入食堂名称！";
            return null;
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsNumric(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return null;
        }

        var ret = new CafeteriInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var list = _cafeteriBLL.GetCafeteriList(string.Empty, "order by DisplayOrder Desc");
            if (list == null)
                return null;

            var orgInfo = list.FirstOrDefault(i => i.Id == int.Parse(Request["id"]));
            ret = orgInfo;
        }

        if (ret == null)
            return null;

        ret.Name = txtName.Text.Trim();
        ret.Description = txtDesc.Text.Trim();

        if (loginedUser.OrganizationId != null)
            ret.OrganizationId = loginedUser.OrganizationId.Value;

        ret.OrganizationName = loginedUser.OrganizationName;

        ret.CafeteriaTypeEnum = (CafeteriaTypeEnum)Enum.Parse(typeof(CafeteriaTypeEnum), ddlCafeteriaTypeEnum.SelectedValue);

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CafeteriaManager.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cafeInfo = GetOrg(PageUtility.User);
        if (cafeInfo == null) return;

        try
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _cafeteriBLL.AddCafeteri(cafeInfo);
            }
            else
            {
                _cafeteriBLL.ModifyCafeteri(cafeInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        Response.Redirect("CafeteriaManager.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearOrg(PageUtility.User);
    }
}