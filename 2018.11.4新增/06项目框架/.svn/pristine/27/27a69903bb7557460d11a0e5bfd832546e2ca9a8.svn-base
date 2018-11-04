using System;
using System.Collections.Generic;
using XinYu.Framework.Membership.Model;
using XinYu.Framework.Membership.BLL;


public partial class Background_Common_Default : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        //检查用户是否登录，如果没有，返回至登录页面
        //考虑安全性，每次刷新页面时都进行检查
        if (!PageUtility.IsLogin)
        {
            Response.Redirect("~/Background/Logout.aspx");
            return;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 检查用户是否登录，如果没有，返回至登录页面
        // 考虑安全性，每次刷新页面时都进行检查
        if (!PageUtility.IsLogin)
        {
            Response.Redirect("~/Background/Logout.aspx");
            return;
        }

        if (!this.IsPostBack)
        {
            AccountBLL BLL = new AccountBLL();

            // 检查当前用户是否具有对当前页面的访问权限
            // 1、首先根据URL地址获取Module对象
            ModuleInfo curModule = BLL.GetModule(this.Request.Url);
            IList<RoleInfo> roleList = BLL.GetCachingRoleList();

            // 如果未找到相应的模块对象，且当前登录用户为系统管理员，则不进行进一上的检测
            //if (curModule == null && PageUtility.User.IsSystem)
            if (curModule == null)
                return;

            // 2、判断登录用户是否具有访问权限
            if (curModule == null || !PageUtility.User.HasPopedom(curModule, roleList))
                Response.Redirect("~/Background/Common/ErrorAccess.aspx");


            // 获取当前位置
            string localtionName = curModule.Name;
            this.calcateModuleLocation(curModule.ParentID,
                PageUtility.SessionModuleTree, ref localtionName);

            this.lblLocation.Text = localtionName;
        }
    }

    private bool calcateModuleLocation(int moduleID, Tree<ModuleInfo> moduleTree, ref string locationName)
    {
        if (moduleID == ModuleInfo.CONST_EMPTY_ID)
            return false;

        if (moduleTree.Item != null && moduleTree.Item.ID == moduleID)
        {
            //locationName = moduleTree.Item.Name + " >> " + locationName;
            locationName = string.Format("{0} >> {1}",
                (!moduleTree.Item.IsFloder && moduleTree.Item.IsMenu) ? string.Format("<a href='{0}' target='main'>{1}</a>", moduleTree.Item.Url, moduleTree.Item.Name) : moduleTree.Item.Name,
                locationName);
            return true;
        }

        foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in moduleTree.SubList)
        {
            if (this.calcateModuleLocation(moduleID, subTreeKeyValuePair.Value, ref locationName))
            {
                if (moduleTree.Item != null)
                {
                    //locationName = moduleTree.Item.Name + " >> " + locationName;
                    //locationName = moduleTree.Item.Name + " >> " + locationName;
                    ModuleInfo module = moduleTree.Item;
                    locationName = string.Format("{0} >> {1}",
                        (!module.IsFloder && !module.IsMenu) ? string.Format("<a href='{0}' target='main'>{1}</a>", module.Url, module.Name) : module.Name,
                        locationName);

                }
                return true;
            }
        }

        return false;
    }
}
