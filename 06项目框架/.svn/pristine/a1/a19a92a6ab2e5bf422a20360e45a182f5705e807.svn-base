using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.Model;
using XinYu.Framework.Membership.BLL;

public partial class Background_Framework : System.Web.UI.Page
{
    const string CONST_MENU_IMAGE = PageUtility.CONST_MENU_IMAGE;
    const string CONST_SUBMENU_IMAGE1 = PageUtility.CONST_SUBMENU_IMAGE1;
    const string CONST_SUBMENU_IMAGE2 = PageUtility.CONST_SUBMENU_IMAGE2;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // 检查用户是否登录，如果没有，返回至登录页面
            // 考虑安全性，每次刷新页面时都进行检查
            if (!PageUtility.IsLogin)
            {
                Response.Redirect("~/default.aspx");
                return;
            }
            UserInfo user = PageUtility.User;

            // 显示菜单内容     
            treeMenu.Nodes.Clear();
            bindMenuTree(user, treeMenu.Nodes, PageUtility.SessionModuleTree.SubList);

            lblUserAlias.Text = string.Format("{0}", user.Alias);
        }
    }

    /// <summary>
    /// 绑定数据树,显示管理目录
    /// </summary>
    /// <param name="user"></param>
    private void bindMenuTree(UserInfo user, TreeNodeCollection childNodes, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
    {
        if (accessableModuleList.Count == 0) return;

        foreach (var subTreeKeyValuePair in accessableModuleList)
        {
            var module = subTreeKeyValuePair.Value.Item;

            // 非菜单项，不进行显示
            if (!module.IsMenu) continue;

            var node = new TreeNode(module.Name, module.ID.ToString());

            // 粗体显示菜单文件夹
            if (module.IsFloder) node.Text = string.Format("<b>{0}</b>", module.Name);

            if (string.IsNullOrEmpty(module.Icon))
            {
                if (module.IsFloder) node.ImageUrl = CONST_MENU_IMAGE;
                else if (module.IsPopedom) node.ImageUrl = CONST_SUBMENU_IMAGE1;
                else node.ImageUrl = CONST_SUBMENU_IMAGE2;
            }
            else
            {
                node.ImageUrl = module.Icon;
            }

            node.Target = "main";
            node.NavigateUrl = module.Url;

            // 加入到树结点下
            childNodes.Add(node);

            // 递归加载子模块显示树结点
            bindMenuTree(user, node.ChildNodes, subTreeKeyValuePair.Value.SubList);
            if (node.ChildNodes.Count > 0) node.Expanded = true;
        }
    }
}