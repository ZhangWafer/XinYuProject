using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_UserPopedomView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new PopedomManagerBLL();

            BindAdminUserList(bll);

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                // 获取所选定的用户
                UserInfo selectedUser = bll.GetAdminUser(int.Parse(Request["id"].Trim()));

                if (selectedUser != null && ListBox1.Items.FindByValue(selectedUser.ID.ToString()) != null)
                    ListBox1.SelectedValue = selectedUser.ID.ToString();
            }

            DisplayModuleTree(bll);
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayModuleTree(new PopedomManagerBLL());
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManager.aspx");
    }

    private void DisplayModuleTree(PopedomManagerBLL BLL)
    {
        if (ListBox1.SelectedItem == null) return;

        // 获取所选定的用户
        var selectedUser = BLL.GetAdminUser(int.Parse(ListBox1.SelectedValue));

        var allRoleList = BLL.GetCachingRoleList();
        var moduleTree = new AccountBLL().GetModulesTree();

        // 递归加载字模块显示树结点
        TreeView1.Nodes.Clear();
        bindMenuTree(selectedUser, allRoleList, TreeView1.Nodes, moduleTree.SubList);

        lblSelectedUser.Text = ListBox1.SelectedItem.Text;
    }

    /// <summary>
    ///  绑定数据树,显示管理目录
    /// </summary>
    /// <param name="childNodes"></param>
    /// <param name="accessableModuleList"></param>
    private void bindMenuTree(UserInfo user, IList<RoleInfo> allRoleList, TreeNodeCollection childNodes, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
    {
        if (accessableModuleList.Count == 0) return;

        foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in accessableModuleList)
        {
            var module = subTreeKeyValuePair.Value.Item;

            // 不进行权限控制的页面，不显示
            //if (module.IsPopedom) continue;

            var node = new TreeNode(module.Name, module.ID.ToString())
            {
                Text =
                    string.Format("<b>{0}</b>({1})", module.Name,
                        module.IsFloder ? "菜单组" : module.IsMenu ? "菜单项" : "非菜单项，页面不显示")
            };

            // 粗体显示菜单文件夹

            if (string.IsNullOrEmpty(module.Icon))
            {
                if (module.IsFloder) node.ImageUrl = "../" + PageUtility.CONST_MENU_IMAGE;
                else if (module.IsPopedom) node.ImageUrl = "../" + PageUtility.CONST_SUBMENU_IMAGE1;
                else node.ImageUrl = "../" + PageUtility.CONST_SUBMENU_IMAGE2;
            }
            else
            {
                node.ImageUrl = module.Icon;
            }

            // 检查当前用户是否有权限，有的话，置该结点的CheckBox为True
            node.Checked = (user != null && user.HasPopedom(module, allRoleList));

            // 加入到树结点下
            childNodes.Add(node);

            // 递归加载子模块显示树结点
            bindMenuTree(user, allRoleList, node.ChildNodes, subTreeKeyValuePair.Value.SubList);
            node.Expanded = true;
        }
    }

    private void BindAdminUserList(PopedomManagerBLL bll)
    {
        ListBox1.Items.Clear();

        var users = bll.GetAdminUserList();
        foreach (var user in users)
        {
            if (user.IsSystem) continue;

            ListBox1.Items.Add(new ListItem(string.Format("{0}（{1}）", user.Alias, user.UserName), user.ID.ToString()));
        }

        if (ListBox1.Items.Count > 0) ListBox1.SelectedIndex = 0;
    }
}