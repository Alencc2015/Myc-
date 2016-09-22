using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using SimpleWare.DbMethod;
using SimpleWare.BaseClass;
using SimpleWare.ClassInfo;
using DevComponents.DotNetBar.SuperGrid;
namespace SimpleWare.Menu
{
    public partial class frmUserGroups : Office2007Form
    {
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        BaseGroup group = new BaseGroup();
        BaseGroupMethod groupMethod = new BaseGroupMethod();
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        private BindingManagerBase _Bm;
        internal BindingManagerBase Bm
        {
            get { return (_Bm); }

            set
            {
                if (_Bm != null)
                    _Bm.PositionChanged -= BmPositionChanged;

                _Bm = value;

                if (_Bm != null)
                    _Bm.PositionChanged += BmPositionChanged;
            }

        }
        void BmPositionChanged(object sender, EventArgs e)
        {
            toolbar1.btnedit.Enabled = true;
            toolbar1.btndelete.Enabled = true;
            ///*MessageUtil.ShowTips(Bm.Position.ToString());
            if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);

            }
            // * */

        }
        public frmUserGroups()
        {
            InitializeComponent();
        }

        private void frmUserGroups_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnImport.Visible = true;
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;

            this.Resize += new EventHandler(frmUserGroups_Resize);
            asc.Load(this);
            //InitializeGrid();

            FreshGroups();
            UpdateBindings(context);
            SetControlsReadOnly(true);
        }

        private void FreshGroups()
        {
            string sql = @"SELECT GroupId 
                                  , Name 
                                  , IsStop 
                                  , Admin
                                  , Memo
                              FROM  BaseGroup   order by GroupId";
            ds = dbl.GetDataset(sql, "BaseGroup");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;

                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "BaseGroup";
                Bm = (dataSource != null)
                         ? superGridControl1.BindingContext[context]
                         : null;
                if (Bm.Count >= 0)
                {
                    toolbar1.btnEditEnabled = true;
                    toolbar1.btndelete.Enabled = true;
                }
            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
            }
        }

        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbGroupid.DataBindings.Add(new Binding("Text", context, "Groupid"));
                tbMemo.DataBindings.Add(new Binding("Text", context, "Memo"));
                tbName.DataBindings.Add(new Binding("Text", context, "Name"));

                //ckbIsstop.DataBindings.Add(new Binding("CheckedValue", context, "FTypeSteps3"));
                ckbIsStop.DataBindings.Add(new Binding("Checked", context, "IsStop"));
                ckbAdmin.DataBindings.Add(new Binding("Checked", context, "Admin"));

            }
            else
            {
                ClearControls();

            }
        }

        private void ClearControls()
        {
            tbGroupid.Text = "";
            tbName.Text = "";
            tbMemo.Text = "";
            ckbAdmin.Checked = false;
            ckbIsStop.Checked = false;
        }

        private void ClearBindings()
        {
            tbGroupid.DataBindings.Clear();
            tbName.DataBindings.Clear();
            tbMemo.DataBindings.Clear();
            ckbAdmin.DataBindings.Clear();
            ckbIsStop.DataBindings.Clear();
        }
        private void btnCancleClick(object sender, EventArgs e)
        {
            //新增取消
            if (toolbar1.flag == 0)
            {
                ClearControls();
                SetControlsReadOnly(true);
            }
            else
            {
                //BindControls();
                //FreshJch();
                //UpdateBindings(context);
                GridRow selectRow = superGridControl1.PrimaryGrid.ActiveRow as GridRow;

                //BaseGroup group
                group = groupMethod.Find(Convert.ToInt16(selectRow["GroupId"].Value));
                if (group != null)
                {
                    tbGroupid.Text = group.GroupId.ToString();
                    tbMemo.Text = group.Memo;
                    tbName.Text = group.Name;
                    ckbAdmin.Checked = group.Admin == 1;
                    ckbIsStop.Checked = group.IsStop == 1;
                }
                SetControlsReadOnly(true);
            }
        }
        private void btnEditClick(object sender, EventArgs e)
        {
            if (group != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            tbMemo.Focus();
        }
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        int index = superGridControl1.PrimaryGrid.ActiveRow.Index;
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;

                        if (ds != null)
                        {
                            DataTable table = ds.Tables[0];
                            groupMethod.Delete(Convert.ToInt16(table.Rows[index]["GroupId"]));
                            table.Rows.RemoveAt(index);

                            ds.AcceptChanges();

                            //superGridControl1.PrimaryGrid.PurgeDeletedRows(true);
                        }

                        if (Bm.Count == 0)
                        {
                            toolbar1.btndelete.Enabled = false;
                            toolbar1.btnedit.Enabled = false;
                        }
                    }
                }
            }
        }

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            //djcdate.Value = System.DateTime.Today;
            tbMemo.Focus();
            toolbar1.flag = 0;
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (checkSave())
                {
                    if (toolbar1.flag == 0)//新增
                    {
                        group.Memo = tbMemo.Text.Trim();
                        group.Name = tbName.Text.Trim();
                        group.IsStop = ckbIsStop.Checked ? 1 : 0;
                        group.Admin = ckbAdmin.Checked ? 1 : 0;
                        //Ms.Close();
                        if (groupMethod.Add(group) != 1)
                            MessageUtil.ShowTips("保存失败！");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                            tbName.Focus();
                        }
                        //Freshgroups();
                    }
                    else
                    {
                        group.Memo = tbMemo.Text.Trim();
                        group.Name = tbName.Text.Trim();
                        group.IsStop = ckbIsStop.Checked ? 1 : 0;
                        group.Admin = ckbAdmin.Checked ? 1 : 0;

                        if (groupMethod.Update(group) != 1)
                            MessageUtil.ShowTips("保存失败！");
                        SetControlsReadOnly(true);
                    }
                    FreshGroups();
                }
            }
            catch (Exception)
            {
                MessageUtil.ShowWarning("保存失败!");
            }
        }

        private bool checkSave()
        {
            if (tbName.Text.Trim() == "")
            {
                MessageUtil.ShowError("请输入名称!");
                return false;

            }
            return true;
        }

        private void SetControlsReadOnly(bool p)
        {
            //pictureBox1.Enabled = !p;
            //tbGroupid.ReadOnly = p;
            tbMemo.ReadOnly = p;
            tbName.ReadOnly = p;
            ckbAdmin.Enabled = !p;
            ckbIsStop.Enabled = !p;
        }

        private void frmUserGroups_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }

    }
}
