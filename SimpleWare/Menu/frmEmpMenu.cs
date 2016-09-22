using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SimpleWare.ClassInfo;
using SimpleWare.DbMethod;
namespace SimpleWare.Menu
{
    public partial class frmEmpMenu :Office2007Form
    {
        Dbconnection dbc = new Dbconnection();
        BaseGroupMenuMethod bgM = new BaseGroupMenuMethod();
        private int selectGroupID;
        public int SelectGroupId
        {
            get 
            {
                return selectGroupID;
            }
            set
            {
                if (dataGridViewX1.CurrentCell != null)
                {
                    int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                    selectGroupID = Convert.ToInt32(dataGridViewX1["GroupID", rowindex].Value.ToString());
                }
                selectGroupID = value;

            }
        }
        public frmEmpMenu()
        {
            InitializeComponent();
        }

        private void frmEmpMenu_Load(object sender, EventArgs e)
        {
            FreshUserGroup();
            //LoadMenuTree();
        }

        private void LoadMenuTree(int groupid)
        {
            menuTree.Nodes.Clear();
            BaseModuleMethod basemoduleMethod = new BaseModuleMethod();
            List<BaseModule> moduleList = basemoduleMethod.GetList("");
            foreach (BaseModule bm in moduleList)
            {
                TreeNode node = new TreeNode();
                node.Text = bm.Name;
                node.Tag = bm;
                menuTree.Nodes.Add(node);
                BaseMenuMethod baseMenuMethod = new BaseMenuMethod();
                List<BaseMenu> menuList = baseMenuMethod.GetList(bm.ModuleId);
                foreach (BaseMenu menu in menuList)
                {
                    TreeNode nd = new TreeNode();
                    nd.Text = menu.Name;
                    nd.Tag = menu;
                    
                    if (bgM.exist(groupid, menu.ModuleId, menu.MenuId))
                        nd.Checked = true;
                    node.Nodes.Add(nd);
                    recursionMenu(groupid,bm.ModuleId, menu.MenuId, nd);
                }
            }
            menuTree.ExpandAll();
        }
        private void recursionMenu(int groupid,int moduleId, int menuID, TreeNode nd)
        {
            BaseMenuMethod baseMenuMethod = new BaseMenuMethod();
            List<BaseMenu> menuList = baseMenuMethod.GetList(moduleId, menuID);
            foreach (BaseMenu item in menuList)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Tag = item;
                
                if (bgM.exist(groupid, item.ModuleId, item.MenuId))
                    node.Checked = true;
                nd.Nodes.Add(node);
                recursionMenu(groupid,moduleId, item.MenuId, node);
            }
        }
        private void FreshUserGroup()
        {
            string sql = "select GroupId,Name,IsStop,Admin,Memo from BaseGroup ";
            DataSet ds = dbc.ds(sql);
            dataGridViewX1.DataSource = ds.Tables[0];
        }

        private void dataGridViewX1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell != null )
            {
                int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                if (dataGridViewX1["GroupID", rowindex].Value != null && dataGridViewX1["GroupID", rowindex].Value != "" && dataGridViewX1["GroupID", rowindex].Value != DBNull.Value)
                {
                    int groupId = Convert.ToInt32(dataGridViewX1["GroupID", rowindex].Value.ToString());
                    menuTree.BeginUpdate();
                    LoadMenuTree(groupId);
                    menuTree.EndUpdate();
                }
            }
        }

        private void LoadGroupMenuData(int groupId)
        {
            throw new NotImplementedException();
        }

        private void menuTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            menuTree.SelectedNode = e.Node;
            if (menuTree.SelectedNode != null)
            {
                bool check = menuTree.SelectedNode.Checked;
                //menuTree.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterCheck);
                recursionCheckNode(menuTree.SelectedNode, check);
                //menuTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterCheck);


                //if (dataGridViewX1.CurrentCell != null)
                //{
                //    int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                //    int groupId = Convert.ToInt32(dataGridViewX1["groupId", rowindex].Value.ToString());
                //    InvokeController("SetGroupMenu", groupId, GetNodeCheck());
                //}

            }
        }

        private void recursionCheckNode(TreeNode treeNode, bool check)
        {
            foreach (TreeNode _node in treeNode.Nodes)
            {

                _node.Checked = check;

                recursionCheckNode(_node, check);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in menuTree.Nodes)
            {
                recursionCheckNode(node, false);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewX1.CurrentCell != null)
                {
                    int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                    int groupId = Convert.ToInt32(dataGridViewX1["GroupID", rowindex].Value.ToString());
                    List<BaseMenu> menulist = new List<BaseMenu>();
                    getMenuList(menuTree.Nodes, menulist);
                    bgM.Delete(groupId);
                    bgM.Add(groupId, menulist);
                    SimpleWare.BaseClass.MessageUtil.ShowTips("保存设置成功！");
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void getMenuList(TreeNodeCollection nodes, List<BaseMenu> list)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.GetType() == typeof(BaseMenu) && node.Checked)
                {
                    list.Add((BaseMenu)node.Tag);

                }
                getMenuList(node.Nodes, list);
            }
        }
    }
}
