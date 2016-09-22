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
using SimpleWare.DbMethod;
using System.Data.SqlClient;
using SimpleWare.BaseClass;
using DevComponents.DotNetBar.SuperGrid;
using System.IO;
namespace SimpleWare
{
    public partial class frmWareOut : Office2007Form
    {
        public frmWareOut()
        {
            InitializeComponent();
        }

        WareInOut FH = new WareInOut();
        WareInOutDbMgr WareInOutDbMgr = new WareInOutDbMgr();
        tb_GoodsInfo good = new tb_GoodsInfo();
        tb_GoodsInfoMethods goodmethod = new tb_GoodsInfoMethods();
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

        private void frmWareInOut_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;

            SetControlsReadOnly(true);
            this.Resize += new EventHandler(frmWareInOut_Resize);
            asc.Load(this);
            BindCombox();
            BindWareHourse();
            tbware1.Text = "";
            
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            tb_BaseMgr.SetCombox("material", tbMaterial);
            tb_BaseMgr.SetCombox("InvoiceType", cmbinvoicetype);
            tb_BaseMgr.SetCombox("InvoiceType", cbintype);

            cbintype.Text = "";
            InitializeGrid();
            FreshFh();
            UpdateBindings(context);
        }
        private void InitializeGrid()
        {
            GridPanel panel = supergrid.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column = panel.Columns["FTYPE"];
            column.EditorType = typeof(MyGridSwitchButtonEditControl);

            GridColumn column1 = panel.Columns["FWorkNum"];
            column1.EditorType = typeof(MyGridComboxControl);

            GridColumn column2 = panel.Columns["FWareID"];
            column2.EditorType = typeof(WareComboxControl);

            GridColumn column3 = panel.Columns["FMaterial"];
            column3.EditorType = typeof(MaterialComboxControl);
            GridColumn column4 = panel.Columns["FInvoiceType"];
            column4.EditorType = typeof(InvoiceTypeComboxControl);
        }
        void BmPositionChanged(object sender, EventArgs e)
        {
            toolbar1.btnedit.Enabled = true;
            toolbar1.btndelete.Enabled = true;
            if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FreshFh();
            UpdateBindings(context);
        }
        private void FreshFh()
        {
            string sql = "select FDate,FWorkNum,FOperator,FWareID,FGoodID,FHGSL,FType,FSerialNum,FGoodsName,FItemID,FMaterial,FImagePath,FModelNo,FPssl,FPSL,FInvoiceType " +
             " from WareInOut where FTYPE = 1 ";
            if (dtdate.Text != "")
            {
                sql += "and FDate >= '" + dtdate.Value.Date.ToShortDateString() + "'";
            }
            if (dtdate2.Text != "")
            {
                sql += "and FDate <= '" + dtdate2.Value.Date.ToShortDateString() + "'";
            }
            if (cbgoods.Text.Trim() != "")
            {
                sql += " and FGoodsName = '" + cbgoods.Text.Trim() + "'";
            }
            if (tbware1.Text.Trim() != "")
            {
                sql += "and FWareID = '" + tbware1.SelectedValue + "'";
            }
            if (cbintype.Text.Trim() != "")
            {
                sql += "and FInvoiceType = '" + cbintype.SelectedValue + "'";
            }
            sql += " order by FSerialNum desc ";
            ds = dbl.GetDataset(sql, "WareInOut");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                supergrid.PrimaryGrid.DataSource = ds;
                supergrid.PrimaryGrid.DataMember = "WareInOut";
                Bm = (dataSource != null)
                         ? supergrid.BindingContext[context]
                         : null;
                if (Bm.Count >= 0)
                {
                    toolbar1.btnEditEnabled = true;
                    toolbar1.btndelete.Enabled = true;
                }
                //UpdateBindings(context);
                int sl = 0;
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    sl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[i]["FHGSL"].ToString()));

                }

                lblsl.Text = String.Format("{0} ", sl);//碰损数量： {1}
            }
            else
            {
                supergrid.PrimaryGrid.DataSource = null;
                lblsl.Text = "";
            }
        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbserialnum.DataBindings.Add(new Binding("Text", context, "FSerialNum"));
                tbGoodsname.DataBindings.Add(new Binding("Text", context, "FGoodsName"));
                tbgoodsid.DataBindings.Add(new Binding("Text", context, "FGoodID"));
                dFdate.DataBindings.Add(new Binding("Text", context, "FDate"));

                tbOperator.DataBindings.Add(new Binding("Text", context, "FOperator"));
                //tbCarno.DataBindings.Add(new Binding("Text", context, "FCarNO"));
                tbhgsl.DataBindings.Add(new Binding("Text", context, "FHGSL"));
                tbpssl.DataBindings.Add(new Binding("Text", context, "FPSSL"));
                tbpsl.DataBindings.Add(new Binding("Text", context, "FPSL"));
                //tbghsl.DataBindings.Add(new Binding("Text", context, "FKHSL"));
                //tbklsl.DataBindings.Add(new Binding("Text", context, "FKLSL"));

                tbModel.DataBindings.Add(new Binding("Text", context, "FModelno"));
                tbitemid.DataBindings.Add(new Binding("Text", context, "FItemID"));
                tbMaterial.DataBindings.Add(new Binding("selectedvalue", context, "FMaterial"));

                pictureBox1.DataBindings.Add(new Binding("ImageLocation",context,"FimagePath"));
 
                cbwarehouse.DataBindings.Add(new Binding("SelectedValue", context, "FWareID"));
                cbworknum.DataBindings.Add(new Binding("selectedvalue", context, "FWorkNum"));
                cmbinvoicetype.DataBindings.Add(new Binding("selectedvalue", context, "FInvoiceType"));
            }
            else
            {
                tbserialnum.Text = "";
                tbGoodsname.Text = "";
                tbgoodsid.Text = "";
                dFdate.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                tbOperator.Text = "";
                //tbCarno.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                tbhgsl.Value = 0;
                tbpssl.Value = 0;
                tbpsl.Value = 0;
                //tbghsl.Value = 0;
                //tbklsl.Value = 0;
                pictureBox1.Image = null;
                cmbinvoicetype.Text = "";
            }

        }

        private void ClearBindings()
        {
            tbserialnum.DataBindings.Clear();
            tbGoodsname.DataBindings.Clear();
            tbgoodsid.DataBindings.Clear();
            dFdate.DataBindings.Clear();
            tbModel.DataBindings.Clear();
            tbitemid.DataBindings.Clear();
            tbMaterial.DataBindings.Clear();
            tbOperator.DataBindings.Clear();
            //tbCarno.DataBindings.Clear();
            tbitemid.DataBindings.Clear();
            tbModel.DataBindings.Clear();
            tbMaterial.DataBindings.Clear();
            tbhgsl.DataBindings.Clear();
            cbworknum.DataBindings.Clear();
            tbpssl.DataBindings.Clear();
            tbpsl.DataBindings.Clear();
            //tbghsl.DataBindings.Clear();
            //tbklsl.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            cbwarehouse.DataBindings.Clear();
            tbware1.DataBindings.Clear();
            cmbinvoicetype.DataBindings.Clear();
        }


        private void btnCancleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //新增取消
            if (toolbar1.flag == 0)
            {
                ClearControls();
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }
            else
            {
                //BindControls();
                //FreshFh();
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }
        }

        private void BindControls()
        {

            if (FH != null)
            {
                tbserialnum.Text = FH.strFSerialNum;
                tbGoodsname.Text = FH.strFGoodsName;
                tbgoodsid.Text = FH.strFGoodsID;
                dFdate.Value = FH.dFDate;
                good = goodmethod.Find(FH.strFGoodsName);
                tbModel.Text = FH.strFModelno;
                tbitemid.Text = FH.strFItemID;
                tbMaterial.Text = FH.strFMaterial;

               // if (FH.imFimage != null)
              //  {
              //      MemoryStream buf = new MemoryStream((byte[])FH.imFimage);
              //      Image image = Image.FromStream(buf, true);
              //      pictureBox1.Image = image;
              //  }

                tbOperator.Text = FH.strFOperator;
                //tbCarno.Text = FH.strFCarNO;
                tbhgsl.Value = FH.dFHGSL;
                //tbpssl.Value = FH.dFPSSL;
                //tbghsl.Value = FH.dFKHSL;
                //tbklsl.Value = FH.dFKLSL;
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            //
            if (FH != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            tbGoodsname.Focus();
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
                            WareInOutDbMgr.WareInOutDelete(table.Rows[index]["FSerialNum"].ToString());
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

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            dFdate.Value = System.DateTime.Today;
            toolbar1.flag = 0;
            tbOperator.Text = frmLogin.userName;
            tbGoodsname.Focus();
        }

        private void ClearControls()
        {
            tbserialnum.Text = "";
            tbGoodsname.Text = "";
            tbgoodsid.Text = "";
            dFdate.Text = "";
            tbModel.Text = "";
            tbitemid.Text = "";
            tbMaterial.Text = "";
            tbOperator.Text = "";
            //tbCarno.Text = "";
            tbhgsl.Value = 0;
            tbpssl.Value = 0;
            //tbghsl.Value = 0;
            //tbklsl.Value = 0;
            pictureBox1.Image = null;
            cbworknum.Text = "";
            cbwarehouse.Text = "";
            lblkc.Text = "";
            //cmbinvoicetype.Text = "";
        }

        private void SetControlsReadOnly(bool p)
        {
            tbGoodsname.Enabled = !p;
            dFdate.Enabled = !p;
            //tbCarno.ReadOnly = p;
            cbworknum.Enabled = !p;
            tbhgsl.Enabled = !p;
           // tbpssl.Enabled = !p;
            //tbklsl.Enabled = !p;
            //tbghsl.Enabled = !p;
            sbtype.IsReadOnly = p;
            cbwarehouse.Enabled = !p;
            tbMaterial.Enabled = !p;
            cmbinvoicetype.Enabled = !p;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate() && checksaved())
                {
                    if (toolbar1.flag == 0)
                    {
                        tbserialnum.Text = WareInOutDbMgr.WareInOutSerialNum(Convert.ToInt16(sbtype.Value));
                        FH.strFGoodsID = tbgoodsid.Text.Trim();
                        FH.strFGoodsName = tbGoodsname.Text.Trim();
                        FH.strFOperator = tbOperator.Text;
                        FH.strFSerialNum = tbserialnum.Text;
                        FH.intFTYPE = sbtype.Value ? 1 : 0;
                        FH.strFWareID = cbwarehouse.SelectedValue.ToString();
                        FH.strFWorknum = cbworknum.SelectedValue.ToString();
                        //FH.strFCarNO = tbCarno.Text.Trim();
                        FH.strFModelno = tbModel.Text.Trim();
                        FH.strFMaterial = tbMaterial.SelectedValue.ToString();
                        FH.strFItemID = tbitemid.Text.Trim();
                        FH.dFDate = dFdate.Value;
                        FH.dFHGSL = tbhgsl.Value;
                        //FH.dFKHSL = tbghsl.Value;
                        FH.dFPSSL = tbpssl.Value;
                        FH.dFPSL = tbpsl.Value;
                        //FH.dFKLSL = tbklsl.Value;
                        FH.strFInvoiceType = cmbinvoicetype.SelectedValue.ToString();
                        FH.strFimagePath = pictureBox1.ImageLocation;
                        if (WareInOutDbMgr.WareInOutADD(FH) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            String ck = cbwarehouse.Text;
                            String bc = cbworknum.Text;
                            ClearControls();

                            ClearBindings();
                            tbGoodsname.Focus();
                            dFdate.Value = System.DateTime.Now;
                            tbOperator.Text = frmLogin.userName;
                            cbworknum.Text = bc;
                            cbwarehouse.Text = ck;
                        }
                        FreshFh();
                    }
                    else
                    {
                        FH.strFSerialNum = tbserialnum.Text;
                        FH.strFGoodsID = tbgoodsid.Text.Trim();
                        FH.strFOperator = tbOperator.Text;
                        FH.strFSerialNum = tbserialnum.Text;
                        FH.strFWorknum = cbworknum.SelectedValue.ToString();
                       // FH.strFCarNO = tbCarno.Text.Trim();
                        FH.intFTYPE = Convert.ToInt16(sbtype.Value);
                        FH.strFWareID = cbwarehouse.SelectedValue.ToString();
                        FH.strFModelno = tbModel.Text.Trim();
                        FH.strFMaterial = tbMaterial.SelectedValue.ToString();
                        FH.strFItemID = tbitemid.Text.Trim();
                        FH.dFDate = dFdate.Value;
                        FH.dFHGSL = tbhgsl.Value;
                        //FH.dFKHSL = tbghsl.Value;
                        FH.dFPSSL = tbpssl.Value;
                        FH.dFPSL = tbpsl.Value;
                        //FH.dFKLSL = tbklsl.Value;
                        FH.strFInvoiceType = cmbinvoicetype.SelectedValue.ToString();
                        FH.strFimagePath = pictureBox1.ImageLocation;
                        if (WareInOutDbMgr.WareInOutUpdate(FH) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        FreshFh();
                        SetControlsReadOnly(true);
                    }
                }
                else
                    throw new Exception("产品必须输入！");
            }
            catch (Exception)
            {

                return;
            }

        }
        private bool checksaved()
        {
            if (tbMaterial.Text.Trim() == "")
            {
                MessageUtil.ShowError("瓷质必须输入！");
                return false;
            }
            if (cbworknum.Text.Trim() == "")
            {
                MessageUtil.ShowError("班次必须输入！");
                return false;
            }
            if (cmbinvoicetype.Text.Trim() == "")
            {
                MessageUtil.ShowError("出库类型必须输入！");
                return false;
            }
            return true;
        }
        private void BindCombox()
        {
            string sql = "select GoodId,GoodName from tb_GoodsInfo ";
            ds = dbl.GetDatasetReport(sql, "tb_GoodsInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //this.lbgoods.Visible = true;
                        //this.lbgoods.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            listArr.Add(ds.Tables[0].Rows[i][1].ToString());
                            cbgoods.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                        }
                    }
                    string[] myarr = listArr.ToArray();
                    cbgoods.AutoCompleteCustomSource.AddRange(myarr);
                    cbgoods.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cbgoods.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbGoodsname.AutoCompleteCustomSource.AddRange(myarr);
                    tbGoodsname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbGoodsname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }

        }
        private void BindWareHourse()
        {
            string sql = "select WareID,WareName from tb_WareHouse ";
            DataSet ds1 = new DataSet();
            ds1 = dbl.GetDatasetReport(sql, "tb_WareHouse");
            List<string> listArr = new List<string>();
            if (ds1 != null)
            {
                if (ds.Tables.Count > 0)
                {
                   // cbwarehouse.AutoCompleteCustomSource.AddRange(myarr);
                    //cbwarehouse.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    // cbwarehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbwarehouse.DataSource = ds1.Tables[0];
                    cbwarehouse.DisplayMember = "WareName";
                    cbwarehouse.ValueMember = "WareID";
                    //tbwarehourse.DataSource =
                    tbware1.DataSource = ds1.Tables[0];
                    tbware1.DisplayMember = "WareName";
                    tbware1.ValueMember = "WareID";
                }

            }
        }

        private void frmWareInOut_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }

        private class MyGridSwitchButtonEditControl : GridSwitchButtonEditControl
        {
            public MyGridSwitchButtonEditControl()
            {
                // Lets have this one only stretch horizontally
                // and not vertically as well

                OnText = "出库";
                OffText = "入库";
            }

            /* public override bool EditorValueChanged
             {
                 get { return (base.EditorValueChanged); }

                 set
                 {
                     if (base.EditorValueChanged != value)
                     {
                         base.EditorValueChanged = value;

                         if (EditorCell != null)
                             EditorCell.GridRow.Cells[3].InvalidateRender();
                     }
                 }
             }*/
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)supergrid.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(supergrid, "出库登记");
            }
        }

        private void toolbar1_Load(object sender, EventArgs e)
        {

        }

        private void tbGoodsname_Leave(object sender, EventArgs e)
        {
            tb_GoodsInfo goods;
            tb_GoodsInfoMethods goodsmethod = new tb_GoodsInfoMethods();
            if (tbGoodsname.Text != "")
            {
                goods = goodsmethod.Find(tbGoodsname.Text.Trim());
                tbGoodsname.Text = goods.strGoodsName;
                tbgoodsid.Text = goods.strGoodsId;
                tbModel.Text = goods.strModelNO;
                tbitemid.Text = goods.strItemNO;
                tbMaterial.Text = goods.strGoodMaterial;
                pictureBox1.ImageLocation = goods.strFImagePath;

                GetKc();
            }
            else
            {
                tbgoodsid.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                pictureBox1.Image = null;
                lblkc.Text = "";
                /*tbhgsl.Value = 0;
                tbpssl.Value = 0;
                tbklsl.Value = 0;
                tbghsl.Value = 0;
                 */
            }
        }

        private void GetKc()
        {
            string sql = "select  isnull(sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end),0) as JCSL " +
                         " from WareInOut " +
                       //  " left join tb_warehouse b on a.FWareID = b.wareid " +
                         " where 1= 1 ";
            sql += string.Format(" and FDate <= '{0}'", System.DateTime.Now);
            if (tbgoodsid.Text.Trim() != "")
                sql += string.Format(" and FGoodID = '{0}'", tbgoodsid.Text);
            if (cbwarehouse.Text.Trim() != "")
                sql += string.Format(" and FWareID = '{0}'", cbwarehouse.SelectedValue.ToString());
            if (tbMaterial.Text.Trim() != "")
                sql += string.Format(" and FMaterial = '{0}'", tbMaterial.SelectedValue.ToString());
            sql = string.Format(sql, System.DateTime.Now);
            ds = dbl.GetDatasetReport(sql, "Ware");

            int sl = 0;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[0]["JCSL"].ToString()));
                    }
                }
            }
            lblkc.Text = sl.ToString();
        }

        private void supergrid_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            UpdateBindings(context);
            superTabControl1.SelectedTab = stbidetail;
        }

        private void tbhgsl_ValueChanged(object sender, EventArgs e)
        {
            if ((tbhgsl.Value + tbpssl.Value) > 0)
            {
                tbpsl.Value = Convert.ToDouble(tbpssl.Value) / Convert.ToDouble(tbhgsl.Value + tbpssl.Value);
            }
        }

        private void cbwarehouse_Leave(object sender, EventArgs e)
        {
            GetKc();
        }

        private void tbMaterial_Leave(object sender, EventArgs e)
        {
            GetKc();
        }
    }
}
