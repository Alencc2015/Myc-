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
using SimpleWare.BaseClass;

namespace SimpleWare.Menu
{
    public partial class frmBaseMenu : Office2007Form
    {
        BaseModule baseModule = new BaseModule();
        BaseModuleMethod bmMgr = new BaseModuleMethod();
        BaseMenuMethod baseMenuMgr = new BaseMenuMethod();
        string imClass = "";
        public BaseMenu _currentMenu;
        public BaseMenu CurrentMenu
        {
            get
            {
                //if (_currentMenu != null)
                //    SetControlsValue(_currentMenu);
                return _currentMenu;
            }
            set
            {
                _currentMenu = value;
            }
        }

        public TreeNode _selectNode;
        public TreeNode SelectNode
        {
            get { return _selectNode; }
            set { _selectNode = value; }
        }

        public frmBaseMenu()
        {
            InitializeComponent();
        }

        private void frmBaseMenu_Load(object sender, EventArgs e)
        {
            LoadMenuTree();
        }

        private void btnCancleClick(object sender, EventArgs e)
        {
            SetControlsReadOnly(false);
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            
            if (SelectNode != null)
            {
                SetControlsReadOnly(true);
                if (SelectNode.Tag.GetType() == typeof(BaseMenu))
                    imClass = "Menu";
                else
                    imClass = "Module";
            }
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            
        }

        private bool checkSaveValidate()
        {
            if (tbName.Text == "" && imClass == "Menu")
            {
                MessageUtil.ShowError("名称必须输入!");
                return false;
            }
            if (tbMName.Text == "" && imClass == "Module")
            {
                MessageUtil.ShowError("名称必须输入!");
                return false;
            }
            return true;
        }

        private void LoadMenuTree()
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
                    node.Nodes.Add(nd);
                    recursionMenu(bm.ModuleId, menu.MenuId, nd);
                }
            }
            menuTree.ExpandAll();
        }

        private void recursionMenu(int moduleId, int menuID, TreeNode nd)
        {
            BaseMenuMethod baseMenuMethod = new BaseMenuMethod();
            List<BaseMenu> menuList = baseMenuMethod.GetList(moduleId,menuID);
            foreach (BaseMenu  item in menuList)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Tag = item;
                nd.Nodes.Add(node);
                recursionMenu(moduleId, item.MenuId, node);
            }
        }

        private void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            object t = e.Node.Tag;
            if (t.GetType() == typeof(BaseModule))
            {
                pModule.Visible = true;
                pMenu.Visible = false;
                BaseModule bm = (BaseModule)t;
                tbMID.Text = bm.ModuleId.ToString();
                tbMName.Text = bm.Name;
                tbMSortid.Text = bm.SortId.ToString();
            }
            else
            {
                pModule.Visible = false;
                pMenu.Visible = true;
                BaseMenu menu = (BaseMenu)t;
                tbId.Text = Convert.ToString(menu.MenuId);
                tbName.Text = menu.Name;
                tbsortid.Text = menu.SortId.ToString();
                tbPID.Text = menu.PMenuId.ToString();
                tbRemark.Text = menu.Memo;
            }
            SelectNode = e.Node;
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            imClass = "Menu";
            SetControlsReadOnly(false);
            ClearControls();
            pMenu.Visible = true;
            pModule.Visible = false;
        }

        private void addModule_Click(object sender, EventArgs e)
        {
            imClass = "Module";
            SetControlsReadOnly(false);
            ClearControls();
            pModule.Visible = true;
            pMenu.Visible = false;
        }

        private void ClearControls()
        {
            if (imClass == "Module")
            {
                tbMID.Text = "";
                tbMName.Text = "";
                tbMSortid.Text = "";
            }
            else
            {
                tbId.Text = "";
                tbName.Text = "";
                tbsortid.Text = "";
                tbRemark.Text = "";
                tbPID.Text = "";
            }
        }

        private void SetControlsReadOnly(bool p)
        {
            tbId.ReadOnly = p;
            tbName.ReadOnly = p;
            tbRemark.ReadOnly = p;
            tbsortid.ReadOnly = p;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (checkSaveValidate())
            {
                if (imClass == "Module")//模块
                {
                    BaseModule bm = new BaseModule();
                    //bm.p
                    bm.Name = tbName.Text.Trim();
                    bm.Memo = tbRemark.Text.Trim();
                    bm.SortId = 1;
                    if (bmMgr.Add(bm) != 1)
                        MessageUtil.ShowError("保存失败!");
                }
                else
                {
                    BaseMenu bm = new BaseMenu();
                    if (SelectNode.Tag.GetType() == typeof(BaseMenu))
                    {
                        bm.PMenuId = (SelectNode.Tag as BaseMenu).MenuId;
                        bm.ModuleId = (SelectNode.Tag as BaseMenu).ModuleId;
                    }
                    else
                    {
                        bm.PMenuId = -1;
                        bm.ModuleId = (SelectNode.Tag as BaseModule).ModuleId;
                    }
                    bm.Name = tbName.Text.Trim();
                    bm.Memo = tbRemark.Text.Trim();
                    bm.SortId = 1;
                    
                    if (baseMenuMgr.Add(bm) != 1)
                        MessageUtil.ShowError("保存失败!");
                }
                LoadMenuTree();
            }
        }

    }
}
