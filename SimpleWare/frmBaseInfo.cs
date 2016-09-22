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
using SimpleWare.BaseClass;
using SimpleWare.ClassInfo;
using SimpleWare.DbMethod;
using System.Data.OleDb;
namespace SimpleWare
{
    public partial class frmBaseInfo : Office2007Form
    {
        public frmBaseInfo()
        {
            InitializeComponent();
        }
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        tb_Base good = new tb_Base();
        tb_BaseMgr goodmethod = new tb_BaseMgr();
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        string pathName;
        string clsbase = "";
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
            if (ds != null)
            {
                context = ds.Tables[0];
                //UpdateBindings(context);

            }
        }
        private void frmBaseInfo_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnImportClick += new Toolbar.BtnImportClick(btnImportClick);
            toolbar1.btnImport.Visible = true;
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;
            this.Resize += new EventHandler(frmBaseInfo_Resize);
            asc.Load(this);
            InitializeGrid();
            FreshBase("worknum");
            SetControlsReadOnly(true);
            UpdateBindings(context);
        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbbaseid.DataBindings.Add(new Binding("Text", context, "FBaseID"));
                tbbasename.DataBindings.Add(new Binding("Text", context, "FBaseName"));
                tbremark.DataBindings.Add(new Binding("Text", context, "FRemark"));


            }
            else
            {
                ClearControls();

            }

        }

        private void ClearBindings()
        {
            tbbaseid.DataBindings.Clear();
            tbbasename.DataBindings.Clear();
            tbremark.DataBindings.Clear();
        }
        private void SetControlsReadOnly(bool p)
        {
            tbbaseid.ReadOnly = p;
            tbbasename.ReadOnly = p;
            tbremark.ReadOnly = p;
        }

        private void FreshBase(string _class)
        {
            string sql = "select  FBaseID,FBaseName,FRemark from tb_base  where FClass = '" + _class + "' order by FBaseID,FBaseName";
            ds = dbl.GetDataset(sql, "tb_base");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_Base";
                Bm = (dataSource != null)
                         ? superGridControl1.BindingContext[context]
                         : null;
                if (Bm.Count >= 0)
                {
                    toolbar1.btnEditEnabled = true;
                    toolbar1.btndelete.Enabled = true;
                }
                UpdateBindings(context);
            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
                ClearControls();
            }
            
        }

        private void InitializeGrid()
        {
            //throw new NotImplementedException();
        }

        private void btnCancleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //新增取消
            if (toolbar1.flag == 0)
            {
                ClearControls();
                SetControlsReadOnly(true);
            }
            else
            {
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (good != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            tbbaseid.Focus();
        }
        /// <summary>
        /// excel 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportClick(object sender, EventArgs e)
        {
            string file = FileDialogHelper.OpenExcel();
            if (!string.IsNullOrEmpty(file))
            {

                try
                {
                    string connectString = ExcelHelper.GetExcelConnectstring(file, true, ExcelHelper.ExcelType.Excel2007);
                    string firstSheet = ExcelHelper.GetExcelFirstTableName(connectString);

                    myDs.Tables.Clear();
                    myDs.Clear();
                    //this.gridControl1.DataSource = null;

                    OleDbConnection cnnxls = new OleDbConnection(connectString);
                    OleDbDataAdapter myDa = new OleDbDataAdapter(string.Format("select * from [{0}]", firstSheet), cnnxls);
                    myDa.Fill(myDs, "【导入表】");
                    if (myDs != null)
                    {
                        if (myDs.Tables[0].Rows.Count > 0)
                        {
                            //this.lbgoods.Visible = true;
                            //this.lbgoods.Items.Clear();
                            for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
                            {
                                good.strFClass = clsbase;
                                good.strFBaseID = myDs.Tables[0].Rows[i][0].ToString();
                                good.strFBaseName = myDs.Tables[0].Rows[i][1].ToString();
                                goodmethod.tb_BaseAdd(good);
                            }
                        }
                    }
                    FreshBase(clsbase); 
                    //this.gridControl1.DataSource = myDs.Tables[0];
                    //this.gridView1.PopulateColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        int index = Math.Max(0, Bm.Position);
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;

                        if (ds != null)
                        {
                            DataTable table = ds.Tables[0];
                            goodmethod.tb_baseDelete(table.Rows[index][0].ToString());
                            table.Rows.RemoveAt(index);

                            ds.AcceptChanges();

                            superGridControl1.PrimaryGrid.PurgeDeletedRows(true);
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
            tbbaseid.Focus();
            toolbar1.flag = 0;
        }

        private void ClearControls()
        {
            tbbaseid.Text = "";
            tbbasename.Text = "";
            tbremark.Text = "";
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    if (toolbar1.flag == 0)//新增
                    {
                        good.strFBaseID = tbbaseid.Text.Trim();
                        good.strFBaseName = tbbasename.Text.Trim();
                        good.strFRemark = tbremark.Text.Trim();
                        good.strFClass = clsbase;
                        if (goodmethod.tb_BaseAdd(good) == 1)
                            MessageUtil.ShowTips("保存成功！");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                            tbbaseid.Focus();
                        }
                        //FreshBase(clsbase);
                    }
                    else
                    {
                        good.strFBaseID = tbbaseid.Text.Trim();
                        good.strFBaseName = tbbasename.Text.Trim();
                        good.strFRemark = tbremark.Text.Trim();
                        good.strFClass = clsbase;
                        if (goodmethod.tb_goodUpdate(good) == 1)
                            MessageUtil.ShowTips("保存成功！");
                        SetControlsReadOnly(true);
                    }
                    FreshBase(clsbase);
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void frmBaseInfo_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "worknum";
            FreshBase(clsbase);

        }

        private void CancelBtnState()
        {
            if (toolbar1.flag == 0)
            {
                toolbar1.btnnew.Enabled = true;
                toolbar1.btnedit.Enabled = false;
                toolbar1.btnsave.Enabled = false;
                toolbar1.btndelete.Enabled = false;
                toolbar1.btncancel.Enabled = false;
            }
            else
            {
                toolbar1.btnnew.Enabled = true;
                toolbar1.btnedit.Enabled = true;
                toolbar1.btnsave.Enabled = false;
                toolbar1.btndelete.Enabled = true;
                toolbar1.btncancel.Enabled = false;
            }
            SetControlsReadOnly(true);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "material";
            FreshBase(clsbase);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "usertype";
            FreshBase(clsbase);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "KilnNO";
            FreshBase(clsbase);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "InvoiceType";
            FreshBase(clsbase);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "InvoiceTypeIn";
            FreshBase(clsbase);
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "Role";
            FreshBase(clsbase);
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "TypeStep";
            FreshBase(clsbase);
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            CancelBtnState();
            clsbase = "ProdLine";
            FreshBase(clsbase);
        }
    }
}
