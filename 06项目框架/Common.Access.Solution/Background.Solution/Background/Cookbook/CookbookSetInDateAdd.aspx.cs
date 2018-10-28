using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Cafeteria.BLL;
using XinYu.Framework.Cafeteria.Model;
using XinYu.Framework.Cookbook;
using XinYu.Framework.Cookbook.BLL;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Membership.Model;

public partial class Background_Cookbook_CookbookSetInDateAdd : System.Web.UI.Page
{
    private CookbookBLL _cookbookBLL = new CookbookBLL();
    private CafeteriBLL _cafeteriBLL = new CafeteriBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Calendar1.SelectedDate = DateTime.Now;
            this.Calendar1.TodaysDate = DateTime.Now;

            this.GetCookbooks();
            this.GetCafeteria();

            this.hdnDate.Value = this.Calendar1.SelectedDate.Month.ToString();

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                var id = int.Parse(Request["id"]);
                DisplayInfo(id);
            }
            else
            {
                this.Calendar1.TodaysDate = DateTime.Now;
                this.Calendar1.SelectedDate = DateTime.Now;

                lblCreatedBy.Text = PageUtility.User.Alias;
                lblCreatedDate.Text = DateTime.Now.ToString();
                lblLastUpdBy.Text = PageUtility.User.Alias;
                lblLastUpdDate.Text = DateTime.Now.ToString();
            }
        }
    }

    private void GetCookbooks()
    {
        var loginedUser = PageUtility.User;

        int total;
        cbklCookbook.DataSource = _cookbookBLL.GetCookbookList(string.Empty, loginedUser.OrganizationId, "order by DisplayOrder Desc", 1, 1000, out total);
        cbklCookbook.DataBind();
    }

    private void GetCafeteria()
    {
        var loginedUser = PageUtility.User;
        if (loginedUser.OrganizationId.HasValue)
        {
            ddlCafeteria.DataSource = _cafeteriBLL.GetCafeteriList(string.Empty, "order by id")
                .Where(i => i.OrganizationId == loginedUser.OrganizationId.Value);
            ddlCafeteria.DataBind();

            ddlCafeteria.Items.Insert(0, new ListItem("请选择食堂", string.Empty));
        }
    }

    private void DisplayInfo(int id)
    {
        var cbsInfo = _cookbookBLL.GetCookbookSetInDate(id);
        if (cbsInfo != null)
        {
            this.Calendar1.SelectedDate = cbsInfo.ChooseDate;  //修改时，指定日历中的订餐日期
            this.Calendar1.TodaysDate = cbsInfo.ChooseDate;

            ddlCookbookEnum.SelectedValue = cbsInfo.CookbookEnum.ToString();
            ddlCafeteria.SelectedValue = cbsInfo.CafeteriaId.ToString();

            //获取当前排餐的所有菜品数据
            var cbList = _cookbookBLL.GetCookbookSetInDateDetailList(id);
            foreach (ListItem item in from ListItem item in cbklCookbook.Items
                                      let cbId = Convert.ToInt32(item.Value)
                                      where cbList.Any(i => i.CookbookId == cbId)
                                      select item)
            {
                item.Selected = true;
            }

            txtOrder.Text = cbsInfo.DisplayOrder.ToString();

            lblCreatedBy.Text = cbsInfo.CreatedByName;
            lblCreatedDate.Text = cbsInfo.CreatedDate.ToString();
            lblLastUpdBy.Text = cbsInfo.LastUpdByName;
            lblLastUpdDate.Text = cbsInfo.LastUpdDate.ToString();
        }
    }

    /// <summary>
    /// 验证模块
    /// </summary>
    /// <returns></returns>
    private new bool IsValid()
    {
        var selDate = Calendar1.SelectedDate;
        if (selDate.Date <= DateTime.Now.Date.Date)
        {
            lblError.Text = "选择的排餐日期必须大于今天！";
            return false;
        }

        if (string.IsNullOrEmpty(ddlCookbookEnum.SelectedValue))
        {
            lblError.Text = "请选择排餐时段！";
            return false;
        }

        if (string.IsNullOrEmpty(ddlCafeteria.SelectedValue))
        {
            lblError.Text = "请选择食堂！";
            return false;
        }

        if (cbklCookbook.SelectedItem == null)
        {
            lblError.Text = "请选择排餐菜品！";
            return false;
        }

        if (pnlPrice.Visible)
        {
            if (string.IsNullOrEmpty(tbxPrice.Text.Trim()) || !ValidationUtility.IsDecimal(tbxPrice.Text.Trim()))
            {
                lblError.Text = "请输入正确格式的自助餐价格！";
                return false;
            }
        }

        if (string.IsNullOrEmpty(txtOrder.Text.Trim()) || !ValidationUtility.IsDecimal(txtOrder.Text.Trim()))
        {
            lblError.Text = "请输入正确格式的排序数值！";
            return false;
        }

        //判断当前日期的三餐排餐信息是否已经存在
        var cbList = _cookbookBLL.GetCookbookSetInDateList((CookbookEnum)Enum.Parse(typeof(CookbookEnum), this.ddlCookbookEnum.SelectedValue),
            Calendar1.SelectedDate, PageUtility.User.OrganizationId, Convert.ToInt32(ddlCafeteria.SelectedValue));
        if (cbList.Count != 0)
        {
            lblError.Text = "当前排餐信息已经存在！";
            return false;
        }
        return true;
    }

    private CookbookSetInDateInfo GetInfo()
    {
        var loginedUser = PageUtility.User;

        var ret = new CookbookSetInDateInfo
        {
            Id = 0,
            CreatedByID = loginedUser.ID,
            CreatedByName = loginedUser.Alias,
            CreatedDate = DateTime.Now
        };

        // 如果是修改，则获取要修改的对象
        if (!string.IsNullOrEmpty(Request["id"]))
        {
            var cbsInfo = _cookbookBLL.GetCookbookSetInDate(Convert.ToInt32(Request["id"]));
            if (cbsInfo == null)
                return null;

            ret = cbsInfo;
        }

        ret.CafeteriaId = Convert.ToInt32(this.ddlCafeteria.SelectedValue);
        ret.CafeteriaName = this.ddlCafeteria.SelectedItem.Text;

        ret.ChooseDate = Calendar1.SelectedDate;  //订餐日期
        ret.CookbookEnum = (CookbookEnum)Enum.Parse(typeof(CookbookEnum), ddlCookbookEnum.SelectedValue); //订餐时段

        if (!loginedUser.IsSystem)
        {
            if (loginedUser.OrganizationId != null)
                ret.OrganizationId = loginedUser.OrganizationId.Value;
            ret.OrganizationName = loginedUser.OrganizationName;
        }

        ////获取食堂信息
        //var id = Convert.ToInt32(ddlCafeteria.SelectedValue);
        //var cafeInfo = GetCafeteria(id);

        ret.Price = pnlPrice.Visible ? (decimal?)Convert.ToDecimal(tbxPrice.Text.Trim()) : null;

        ret.DisplayOrder = int.Parse(txtOrder.Text.Trim());

        ret.LastUpdByID = loginedUser.ID;
        ret.LastUpdByName = loginedUser.Alias;
        ret.LastUpdDate = DateTime.Now;

        return ret;
    }

    private IEnumerable<CookbookSetInDateDetailInfo> GetCookbookSetInDateDetails(int cookbookDateId)
    {
        var loginedUser = PageUtility.User;

        //获取当次点餐菜品数据
        var detailInfos = (from ListItem item in cbklCookbook.Items
                           where item.Selected
                           select new CookbookSetInDateDetailInfo
                           {
                               CookbookDateId = cookbookDateId,
                               CookbookId = Convert.ToInt32(item.Value),
                               CookbookName = item.Text,
                               CreatedByName = loginedUser.Alias,
                               CreatedByID = loginedUser.ID,
                               CreatedDate = DateTime.Now,
                               LastUpdByID = loginedUser.ID,
                               LastUpdByName = loginedUser.Alias,
                               LastUpdDate = DateTime.Now
                           }).ToList();

        return detailInfos;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!IsValid())
            return;

        var csdInfo = GetInfo();
        if (csdInfo == null)
            return;

        try
        {
            //添加菜品信息
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _cookbookBLL.AddCookbookSetInDate(csdInfo);
            }
            else
            {
                _cookbookBLL.ModifyCookbookSetInDate(csdInfo);
            }

            //获取当前排餐的菜品信息（先删除CookbookSetInDateDetail表里已经存在的菜品信息，再添加菜品信息）
            _cookbookBLL.RemoveCookbookSetInDateDetail(csdInfo.Id);

            var detailInfos = GetCookbookSetInDateDetails(csdInfo.Id);
            foreach (var cookbookSetInDateDetailInfo in detailInfos)
            {
                _cookbookBLL.AddCookbookSetInDateDetail(cookbookSetInDateDetailInfo);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void ClearOrg(UserInfo loginedUser)
    {
        this.Calendar1.SelectedDate = DateTime.Now;
        this.Calendar1.TodaysDate = DateTime.Now;

        cbklCookbook.ClearSelection();

        txtOrder.Text = "100";

        lblLastUpdBy.Text = loginedUser.Alias;
        lblLastUpdDate.Text = DateTime.Now.ToString();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearOrg(PageUtility.User);
    }

    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("CookbookSetInDateManager.aspx");
    }

    /// <summary>
    /// 选择日期时
    /// </summary>
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }

    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        var month = Convert.ToInt32(this.hdnDate.Value);
        if (e.NewDate.Month > month)
        {
            //获取新月的订餐数据
            
        }

        this.hdnDate.Value = e.NewDate.Month.ToString();

    }

    protected void ddlCafeteria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlCafeteria.SelectedValue))
        {
            pnlPrice.Visible = false;
            return;
        }
        var id = Convert.ToInt32(ddlCafeteria.SelectedValue);
        var cafeInfo = GetCafeteria(id);
        if (cafeInfo != null)
        {
            pnlPrice.Visible = cafeInfo.CafeteriaTypeEnum == CafeteriaTypeEnum.Buffet;
        }
    }

    private CafeteriInfo GetCafeteria(int id)
    {
        return _cafeteriBLL.GetCafeteriList(string.Empty, "order by id").FirstOrDefault(c => c.Id == id);
    }

}