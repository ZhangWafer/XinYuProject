using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XinYu.Framework.Membership.BLL;
using XinYu.Framework.Membership.Model;

public partial class Background_SysManager_RolePopedomManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var bll = new PopedomManagerBLL();

            bindAdminRoleList(bll);
            if (!string.IsNullOrEmpty(Request["id"]) && ListBox1.Items.FindByValue(Request["id"]) != null)
            {
                ListBox1.SelectedValue = Request["id"];
            }

            DisplayModuleTree(bll);
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayModuleTree(new PopedomManagerBLL());
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem == null)
        {
            lblError.Text = "请选择角色!以对所选择的角色进行权限分配!";
            return;
        }

        var bll = new PopedomManagerBLL();

        // 获取所选定的角色
        var selectedRole = bll.GetRole(int.Parse(ListBox1.SelectedValue));
        if (selectedRole == null)
        {
            lblError.Text = "请选择角色!以对所选择的角色进行权限分配!";
            return;
        }

        // 获取分配给用户权限的模块ID列表

        // 保存至数据库
        selectedRole.PopedomIDList = (from TreeNode node in TreeView1.CheckedNodes 
                                      where node.Checked 
                                      select int.Parse(node.Value.Trim())).ToArray();

        try
        {
            bll.ModifyRolePopedom(selectedRole);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleManager.aspx");
    }


    private void DisplayModuleTree(PopedomManagerBLL bll)
    {
        if (ListBox1.SelectedItem == null) return;

        // 获取所选定的角色
        var selectedRole = bll.GetRole(int.Parse(ListBox1.SelectedValue.Trim()));

        var moduleTree = new AccountBLL().GetModulesTree();

        // 递归加载字模块显示树结点
        TreeView1.Nodes.Clear();
        bindMenuTree(selectedRole, TreeView1.Nodes, moduleTree.SubList);

        lblSelectedUser.Text = ListBox1.SelectedItem.Text;
    }

    /// <summary>
    ///  绑定数据树,显示管理目录
    /// </summary>
    private void bindMenuTree(RoleInfo role, TreeNodeCollection childNodes, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
    {
        if (accessableModuleList.Count == 0) return;

        foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in accessableModuleList)
        {
            ModuleInfo module = subTreeKeyValuePair.Value.Item;

            // 不进行权限控制的页面，不显示
            if (module.IsPopedom) continue;

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
            node.Checked = (role != null && role.HasPopedom(module));

            // 加入到树结点下
            childNodes.Add(node);

            // 递归加载子模块显示树结点
            bindMenuTree(role, node.ChildNodes, subTreeKeyValuePair.Value.SubList);
            node.Expanded = true;
        }
    }

    private void bindAdminRoleList(PopedomManagerBLL bll)
    {
        ListBox1.Items.Clear();

        var roles = bll.GetCachingRoleList();
        foreach (var role in roles)
        {
            ListBox1.Items.Add(new ListItem(string.Format("{0}", role.RoleName), role.ID.ToString()));
        }

        if (ListBox1.Items.Count > 0) ListBox1.SelectedIndex = 0;
    }
}