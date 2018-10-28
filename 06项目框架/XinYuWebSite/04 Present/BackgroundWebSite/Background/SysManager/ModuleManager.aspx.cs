using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using XinYu.Framework.Membership.Model;
using XinYu.Framework.Membership.BLL;

public partial class Background_SysManager_ModuleManager : System.Web.UI.Page
{
    const string CONST_MENU_IMAGE = "../" + PageUtility.CONST_MENU_IMAGE;
    const string CONST_SUBMENU_IMAGE1 = "../" + PageUtility.CONST_SUBMENU_IMAGE1;
    const string CONST_SUBMENU_IMAGE2 = "../" + PageUtility.CONST_SUBMENU_IMAGE2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 检查是否要绑定指定的模块ID列表
            int selectedParentID = (string.IsNullOrEmpty(Request["parentid"])) ? ModuleInfo.CONST_EMPTY_ID : int.Parse(Request["parentid"]);

            // 显示模块树
            DisplayMenuTree(selectedParentID);

            // 绑字模块列表
            BindModule();
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        BindModule();
    }

    protected void lnkAddModule_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModuleAdd.aspx?parentid=" + ModuleInfo.CONST_EMPTY_ID);
    }

    protected void lnkAddChild_Click(object sender, EventArgs e)
    {
        if (TreeView1.Nodes.Count == 0) return;

        TreeNode selectedNode = TreeView1.SelectedNode ?? TreeView1.Nodes[0];

        Response.Redirect("ModuleAdd.aspx?parentid=" + selectedNode.Value);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int moduleID = int.Parse(e.CommandArgument.ToString().Trim());

        switch (e.CommandName)
        {
            case "Remove":
                new ModuleManagerBLL().RemoveModule(moduleID);
                // 重新绑定菜单树
                var selectedNode = TreeView1.SelectedNode ?? TreeView1.Nodes[0];

                DisplayMenuTree(int.Parse(selectedNode.Value.Trim()));
                BindModule();
                break;
        }
    }

    private void DisplayMenuTree(int selectedParentID)
    {
        // 显示模块树
        var moduleTree = new AccountBLL().GetModulesTree();

        TreeView1.Nodes.Clear();

        // 首先添加一个根结点
        var node = new TreeNode("菜单目录", ModuleInfo.CONST_EMPTY_ID.ToString())
        {
            Selected = (selectedParentID == ModuleInfo.CONST_EMPTY_ID),
            ImageUrl = CONST_MENU_IMAGE
        };
        TreeView1.Nodes.Add(node);

        // 递归加载字模块显示树结点
        bindMenuTree(selectedParentID, node.ChildNodes, moduleTree.SubList);
        TreeView1.ExpandDepth = 2;
    }

    /// <summary>
    ///  绑定数据树,显示管理目录
    /// </summary>
    private void bindMenuTree(int selectedID, TreeNodeCollection childNodes, IDictionary<int, Tree<ModuleInfo>> accessableModuleList)
    {
        if (accessableModuleList.Count == 0) return;

        foreach (KeyValuePair<int, Tree<ModuleInfo>> subTreeKeyValuePair in accessableModuleList)
        {
            var module = subTreeKeyValuePair.Value.Item;

            //// 非菜单项，不进行显示
            //if (!module.IsMenu) continue;

            var node = new TreeNode(module.Name, module.ID.ToString());

            // 粗体显示菜单文件夹
            if (module.IsFloder) node.Text = string.Format("{0}（文件夹）", module.Name);
            if (module.IsPopedom) node.Text = string.Format("{0}（公共模块）", module.Name);

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

            node.Selected = (selectedID == module.ID);

            // 加入到树结点下
            childNodes.Add(node);

            // 递归加载字模块显示树结点
            bindMenuTree(selectedID, node.ChildNodes, subTreeKeyValuePair.Value.SubList);
        }
    }

    private void BindModule()
    {
        if (TreeView1.Nodes.Count == 0) return;

        TreeNode selectedNode = TreeView1.SelectedNode ?? TreeView1.Nodes[0];

        lblParentModule.Text = string.Format("{0}", selectedNode.Text);

        var bll = new ModuleManagerBLL();
        GridView1.DataSource = bll.GetModuleList(int.Parse(selectedNode.Value));
        GridView1.DataBind();
    }
}