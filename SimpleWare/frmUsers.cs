using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SimpleWare.ClassInfo;
using SimpleWare.BaseClass;
using SimpleWare.DbMethod;
using System.Data.SqlClient;
using DevComponents.DotNetBar.SuperGrid;
namespace SimpleWare
{
    public partial class frmUsers : Office2007Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }
        tb_EmpInfo user = new tb_EmpInfo();
        tb_EmpInfoMenthod usermethod = new tb_EmpInfoMenthod();
        SqlConnection conn = null;
        Dblink dbl = new Dblink();
        DataSet ds = new DataSet();
        private BindingManagerBase _Bm;
        Dbconnection dbc = new Dbconnection();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        object dataSource = null;
        string dataMember = null;
        object context = null;
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
        private void frmUsers_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;


            this.Resize += new EventHandler(frmUsers_Resize);
            asc.Load(this);
            tb_BaseMgr.SetCombox("usertype", comboBoxEx1);//
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);
            tb_BaseMgr.SetCombox("ProdLine", cmbSCX);
            //tb_BaseMgr.SetCombox("Role", cmbRole);//cmbRole
            BaseGroupMethod.SetGrpCombox(cmbRole);
            //BindCombox();
            InitializeGrid();

            
            SetControlsReadOnly(true);  
            FreshUsers();
            UpdateBindings(context);
     

        }

        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;
            GridColumn column = panel.Columns["EmpLoginPwd"];
            column.EditorType = typeof(MyTextBox);

            GridColumn column2 = panel.Columns["EmpGroupID"];
            column2.EditorType = typeof(BaseGroupComboxControl);

            GridColumn column3 = panel.Columns["EmpKilnNO"];
            column3.EditorType = typeof(KilnNoComboxControl);

            GridColumn column4 = panel.Columns["EmpWorshoId"];
            column4.EditorType = typeof(ProdlineComboxControl);
        }

        private void FreshUsers()
        {
            string sql = "SELECT EmpId,EmpName,EmpLoginPwd,EmpDept,EmpPost,EmpPhone,EmpGroupID,EmpWorshoId,EmpKilnNO,case when EmpFalg=0 then '一般用户' else '系统管理员' end as EmpFalg FROM tb_EmpInfo " +
                        " where isnull(active,1) <> 0 order by empid";
            ds = dbl.GetDataset(sql, "tb_EmpInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_EmpInfo";
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
        void BmPositionChanged(object sender, EventArgs e)
        {
            toolbar1.btnedit.Enabled = true;
            toolbar1.btndelete.Enabled = true;
            //toolbar1.btnnew.Enabled = true;
            //toolbar1.btnsave.Enabled = false;
            //toolbar1.btncancel.Enabled = false;
            //SetControlsReadOnly(true);
            if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);
            }
        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbname.DataBindings.Add(new Binding("Text", context, "EmpName"));
                tbemplid.DataBindings.Add(new Binding("Text", context, "EmpId"));
                tbpassword.DataBindings.Add(new Binding("Text", context, "EmpLoginPwd"));
                //confirmpassword.DataBindings.Add(new Binding("Text", context, "WareID"));

                comboBoxEx1.DataBindings.Add(new Binding("Text", context, "EmpFalg"));
                cmbRole.DataBindings.Add(new Binding("SelectedValue", context, "EmpGroupID"));
                tbpos.DataBindings.Add(new Binding("Text", context, "EmpPost"));
                tbdept.DataBindings.Add(new Binding("Text", context, "EmpDept"));
                tbphone.DataBindings.Add(new Binding("Text", context, "EmpPhone"));
                cmbkilnno.DataBindings.Add(new Binding("SelectedValue", context, "EmpKilnNO"));
                cmbSCX.DataBindings.Add(new Binding("SelectedValue", context, "EmpWorshoId"));
            }
            else
            {
                ClearControls();
            }
        }
        private void ClearBindings()
        {
            tbname.DataBindings.Clear();
            tbemplid.DataBindings.Clear();
            tbpassword.DataBindings.Clear();
            comboBoxEx1.DataBindings.Clear();
            tbpos.DataBindings.Clear();
            tbdept.DataBindings.Clear();
            tbphone.DataBindings.Clear();
            cmbRole.DataBindings.Clear();
            cmbkilnno.DataBindings.Clear();
            cmbSCX.DataBindings.Clear();
        }
        private void SetControlsReadOnly(bool p)
        {
            tbname.ReadOnly = p;
            tbemplid.ReadOnly = p;
            tbpassword.ReadOnly = p;
            confirmpassword.ReadOnly = p;
            comboBoxEx1.Enabled = !p;
            tbpos.ReadOnly = p;
            tbdept.ReadOnly = p;
            tbphone.ReadOnly = p;
            cmbRole.Enabled = !p;
            cmbkilnno.Enabled = !p;
            cmbSCX.Enabled = !p;
        }
        private void ClearControls()
        {
            tbname.Text = "";
            tbemplid.Text = "";
            tbpassword.Text = "";
            confirmpassword.Text = "";
            comboBoxEx1.Text = "";
            tbpos.Text = "";
            tbdept.Text = "";
            tbphone.Text = "";
            cmbRole.Text = "";
        }
        private void btnCancleClick(object sender, EventArgs e)
        {
            //新增取消
            if (toolbar1.flag == 0)
            {
                superValidator1.Enabled = false;
                ClearControls();
                SetControlsReadOnly(true);
            }
            else
            {
                superValidator1.Enabled = false;
                SetControlsReadOnly(true);
                FreshUsers();
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (user != null)
            {
                SetControlsReadOnly(false);
                tbemplid.ReadOnly = true;//用户名只读
                confirmpassword.Text = tbpassword.Text;
            }
            toolbar1.flag = 1;
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
                            usermethod.tb_EmpInfoDelete(table.Rows[index][0].ToString());
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

            toolbar1.flag = 0;
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    if (toolbar1.flag == 0)
                    {
                        //tbserialnum.Text = JCHMethod.tb_JCSerialNum(Convert.ToInt16(sbtntype.Value));
                        user.strEmpId = tbemplid.Text.Trim();
                        user.strEmpName = tbname.Text.Trim();
                        user.strEmpLoginPwd = tbpassword.Text.Trim();
                        user.strEmpPost = tbpos.Text.Trim();
                        user.strEmpDept = tbdept.Text.Trim();
                        user.strEmpPhone = tbphone.Text.Trim();
                        user.intEmpGroupID = Convert.ToInt16(cmbRole.SelectedValue);//.ToString();
                        user.intEmpFalg = Convert.ToInt16(comboBoxEx1.SelectedValue);
                        user.strEmpKilnNO = cmbkilnno.SelectedValue == null ? "" : cmbkilnno.SelectedValue.ToString();
                        user.strEmpWorshoId = cmbSCX.SelectedValue == null ? "" : cmbSCX.SelectedValue.ToString(); 
                        if (usermethod.tb_EmpInfoAdd(user) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                        }
                        
                        FreshUsers();

                    }
                    else
                    {
                        user.strEmpId = tbemplid.Text.Trim();
                        user.strEmpName = tbname.Text.Trim();
                        user.strEmpLoginPwd = tbpassword.Text.Trim();
                        user.strEmpPost = tbpos.Text.Trim();
                        user.strEmpDept = tbdept.Text.Trim();
                        user.strEmpPhone = tbphone.Text.Trim();
                        user.intEmpGroupID = Convert.ToInt16(cmbRole.SelectedValue);//.ToString();
                        user.intEmpFalg = Convert.ToInt16(comboBoxEx1.SelectedValue.ToString());
                        user.strEmpKilnNO = cmbkilnno.SelectedValue == null ? "" : cmbkilnno.SelectedValue.ToString();
                        user.strEmpWorshoId = cmbSCX.SelectedValue == null ? "" : cmbSCX.SelectedValue.ToString();
                        if (usermethod.tb_EmpInfoUpdate(user) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        
                        FreshUsers();
                        SetControlsReadOnly(true);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmUsers_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }

        private void confirmpassword_Leave(object sender, EventArgs e)
        {
            //superValidator1.Validate();
        }
        private class MyTextBox : TextBox
        {
            public MyTextBox()
            {
                PasswordChar = '*';
            }
        }
    } 
}
