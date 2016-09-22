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
using SimpleWare.DbMethod;
using SimpleWare.BaseClass;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
namespace SimpleWare
{
    public partial class frmWareHouse : Office2007Form
    {
        public frmWareHouse()
        {
            InitializeComponent();
        }
        tb_WareHouse warehouse = new tb_WareHouse();
        tb_WareHouseMethod warehousemethod = new tb_WareHouseMethod();
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
        private void frmWareHouse_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;

            SetControlsReadOnly(true);
            this.Resize += new EventHandler(frmWareHouse_Resize);
            asc.Load(this);
     
            InitializeGrid();
        }
        private void InitializeGrid()
        {
            FreshWare();
        }

        void BmPositionChanged(object sender, EventArgs e)
        {
            toolbar1.btnedit.Enabled = true;
            toolbar1.btndelete.Enabled = true;
            /*if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);
            }*/
        }

        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbwareid.DataBindings.Add(new Binding("Text", context, "WareID"));
                tbwarename.DataBindings.Add(new Binding("Text", context, "WareName"));
                tbremark.DataBindings.Add(new Binding("Text", context, "Remark"));
            }
            else
            {
                ClearControls();
            }
        }
        private void ClearBindings()
        {
            tbwareid.DataBindings.Clear();
            tbwarename.DataBindings.Clear();
            tbremark.DataBindings.Clear();
        }
        private void SetControlsReadOnly(bool p)
        {
            tbwareid.ReadOnly = p;
            tbwarename.ReadOnly = p;
            tbremark.ReadOnly = p;
        }
        private void FreshWare()
        {
            string sql = "select WareID,WareName,Remark from tb_WareHouse";
            ds = dbl.GetDataset(sql, "tb_WareHouse");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_WareHouse";
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
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }

        }

        private void BindControls()
        {
            throw new NotImplementedException();
        }

        private void ClearControls()
        {
            tbwareid.Text = "";
            tbwarename.Text = "";
            tbremark.Text = "";
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (warehouse != null)
            {
                SetControlsReadOnly(false);
            }
            toolbar1.flag = 1;
            tbwareid.ReadOnly = true;
            tbwarename.Focus();
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
                            warehousemethod.tb_WareHouseDelete(table.Rows[index][0].ToString());
                            table.Rows.RemoveAt(index);
                            ds.AcceptChanges();
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

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {


                    if (toolbar1.flag == 0)
                    {
                        //tbserialnum.Text = JCHMethod.tb_JCSerialNum(Convert.ToInt16(sbtntype.Value));
                        warehouse.strWareID = tbwareid.Text.Trim();
                        warehouse.strWareName = tbwarename.Text.Trim();
                        warehouse.strRemark = tbremark.Text.Trim();
                        if (warehousemethod.tb_WareHouseAdd(warehouse) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        //FreshWare();
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                        }
                    }
                    else
                    {
                        warehouse.strWareID = tbwareid.Text.Trim();
                        warehouse.strWareName = tbwarename.Text.Trim();
                        warehouse.strRemark = tbremark.Text.Trim();
                        if (warehousemethod.tb_WareHouseUpdate(warehouse) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        SetControlsReadOnly(true);
                    }
                    FreshWare();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            //djcdate.Value = System.DateTime.Today;
            toolbar1.flag = 0;
        }



        private void frmWareHouse_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }
    }
}
