using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_UserPopedomManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new PopedomManagerBLL();

            bindAdminUserList(bll);

            // 绑字用户列表
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                // 获取所选定的用户
                var selectedUser = bll.GetAdminUser(int.Parse(Request["id"].Trim()));
                if (selectedUser != null && ListBox1.Items.FindByValue(selectedUser.ID.ToString()) != null)
                    ListBox1.SelectedValue = selectedUser.ID.ToString();
            }

            displayModuleTree(bll);
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayModuleTree(new PopedomManagerBLL());
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem == null)
        {
            lblError.Text = "请选择用户!以对所选择的用户进行权限分配!";
            return;
        }

        var bll = new PopedomManagerBLL();

        var selectedUser = bll.GetAdminUser(int.Parse(ListBox1.SelectedValue));
        if (selectedUser == null)
        {
            lblError.Text = "请选择用户!以对所选择的用户进行权限分配!";
            return;
        }

        // 获取分配给用户权限的模块ID列表

        // 保存至数据库
        selectedUser.PopedomIDList = (from TreeNode node in TreeView1.CheckedNodes 
                                      where node.Checked 
                                      select int.Parse(node.Value.Trim())).ToArray();

        try
        {
            bll.ModifyUserPopedom(selectedUser);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManager.aspx");
    }

    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        //TreeView1.TreeNodeCheckChanged -= new TreeNodeEventHandler(TreeView1_TreeNodeCheckChanged);

        //updateDownNodeCheckBox(e.Node, e.Node.Checked);
        //updateUpNodeCheckBox(e.Node, e.Node.Checked);

        //TreeView1.TreeNodeCheckChanged += new TreeNodeEventHandler(TreeView1_TreeNodeCheckChanged);
    }

    #region Private methods.

    private void updateDownNodeCheckBox(TreeNode node, bool isChecked)
    {
        node.Checked = isChecked;
        foreach (TreeNode childNode in node.ChildNodes)
        {
            updateDownNodeCheckBox(node, isChecked);
        }
    }

    private void updateUpNodeCheckBox(TreeNode node, bool isChecked)
    {
        node.Checked = isChecked;
        if (node.Parent == null) return;


        // 查找同级节点，如果所有节点选定，则父结点也选定
        // 如果所有节点中有一个不选定，则父结点也不选定
        bool parentChecked = true;
        foreach (TreeNode childNode in node.Parent.ChildNodes)
        {
            if (!childNode.Checked)
            {
                parentChecked = false;
                break;
            }
        }

        updateUpNodeCheckBox(node.Parent, parentChecked);
    }


    private void displayModuleTree(PopedomManagerBLL BLL)
    {
        if (ListBox1.SelectedItem == null) return;

        // 获取所选定的用户
        UserInfo selectedUser = BLL.GetAdminUser(int.Parse(ListBox1.SelectedValue));

        Tree<ModuleInfo> moduleTree = new AccountBLL().GetModulesTree();

        // 递归加载子模块显示树结点
        TreeView1.Nodes.Clear();
        bindMenuTree(selectedUser, TreeView1.Nodes, moduleTree.SubList);

        lblSelectedUser.Text = ListBox1.SelectedItem.Text;
    }

    /// <summary>
    ///  绑定数据树,显示管理目录
    /// </summary>
    /// <param name="childNodes"></param>
    /// <param name="accessableModuleList"></param>
    private void bindMenuTree(UserInfo user, TreeNodeCollection childNodes, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
    {
        if (accessableModuleList.Count == 0) return;

        foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in accessableModuleList)
        {
            ModuleInfo module = subTreeKeyValuePair.Value.Item;

            // 不进行权限控制的页面，不显示
            if (module.IsPopedom) continue;

            TreeNode node = new TreeNode(module.Name, module.ID.ToString());

            // 粗体显示菜单文件夹
            node.Text = string.Format("<b>{0}</b>({1})", module.Name, module.IsFloder ? "菜单组" : module.IsMenu ? "菜单项" : "非菜单项，页面不显示");

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
            node.Checked = (user != null && user.HasPopedom(module));

            // 加入到树结点下
            childNodes.Add(node);

            // 递归加载子模块显示树结点
            bindMenuTree(user, node.ChildNodes, subTreeKeyValuePair.Value.SubList);
            node.Expanded = true;
        }
    }

    private void bindAdminUserList(PopedomManagerBLL BLL)
    {
        ListBox1.Items.Clear();

        IList<UserInfo> users = BLL.GetAdminUserList();
        foreach (UserInfo user in users)
        {
            if (user.IsSystem) continue;

            ListBox1.Items.Add(new ListItem(string.Format("{0}（{1}）", user.Alias, user.UserName), user.ID.ToString()));
        }

        if (ListBox1.Items.Count > 0) ListBox1.SelectedIndex = 0;
    }

    #endregion
}