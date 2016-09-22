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
using System.IO;
using DevComponents.DotNetBar.SuperGrid;
namespace SimpleWare
{
    public partial class frmJCHEx : Office2007Form
    {
        public frmJCHEx()
        {
            InitializeComponent();
        }
 
        tb_JCH JCH = new tb_JCH();
        tb_JCHMethod JCHMethod = new tb_JCHMethod();
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
        int fzyid = 0;
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
        private void frmJCHEx_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
            toolbar.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar.btnEditEnabled = false;
            toolbar.btndelete.Enabled = false;


            SetControlsReadOnly(true);
            this.Resize += new EventHandler(frmJCHEx_Resize);
            asc.Load(this);
            BindCombox();
           // BindWareHourse();
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            tb_BaseMgr.SetCombox("material", tbMaterial);
            tb_BaseMgr.SetCombox("KilnNo", cmbkilnno);
            tb_BaseMgr.SetCombox("KilnNo", cbkilnno);
            InitializeGrid();

            dtdate.Value = DateTime.Now;
            dtdate2.Value = DateTime.Now;
            cbkilnno.Text = "";

            FreshJch();
            UpdateBindings(context);
           // sbtntype
        }
        void BmPositionChanged(object sender, EventArgs e)
        {
            toolbar.btnedit.Enabled = true;
            toolbar.btndelete.Enabled = true;
            if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);

            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {

            //DataSet ds = null;

            //dgvlist.AutoGenerateColumns = false;
            //dgvlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dbl.InfoShow(sql, dgvlist);
            FreshJch();
            UpdateBindings(context);
            //TotalRow();
        }


        private void FreshJch()
        {
            string sql = "select JCDate ,JCTYPE ,JCGoodsName,JCGoodsID  ,JCHGSL ,JCKLSL ,JCPSSL ," +
            " JCKHSL ,JCCarNO , JCWorknum ,JCOperator ,JCSerialNum,JCModelno,JCItemID,JCMaterial,FImagePath,FRYHGSL,FHGL,FKilnNO  " +
             " from tb_jch where JCTYPE = 1 ";
            if (dtdate.Text != "")
            {
                sql += "and JCDate >= '" + dtdate.Value.Date.ToShortDateString() + "'";
            }
            if (dtdate2.Text != "")
            {
                sql += "and JCDate <= '" + dtdate2.Value.Date.ToShortDateString() + "'";
            }
            if (cbgoods.Text.Trim() != "")
            {
                sql += "and JCGoodsName = '" + cbgoods.Text.Trim() + "'";
            }
            if (tbcar.Text.Trim() != "")
            {
                sql += "and JCCarNO like '%" + tbcar.Text.Trim() + "%'";
            }
            if (cbkilnno.Text.Trim() != "")
            {
                sql += "and FKilnNO = '" + cbkilnno.SelectedValue.ToString().Trim() + "'";
            }
            sql += " order by JCDate desc,JCCarNO desc ";
            ds = dbl.GetDataset(sql,"TB_JCH");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                supergrid.PrimaryGrid.DataSource = ds;
                supergrid.PrimaryGrid.DataMember = "TB_JCH";
                Bm = (dataSource != null)
                         ? supergrid.BindingContext[context]
                         : null;
                if (Bm.Count >= 0)
                {
                    toolbar.btnEditEnabled = true;
                    toolbar.btndelete.Enabled = true;
                }
                //UpdateBindings(context);
                int zysl = 0;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    zysl += Convert.ToInt16(ds.Tables[0].Rows[i]["JCHGSL"].ToString());
                    
                }

                lblcysl.Text = String.Format("{0}", zysl);
            }
            else
            {
                supergrid.PrimaryGrid.DataSource = null;
                lblcysl.Text = "";
            }
        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbserialnum.DataBindings.Add(new Binding("Text", context, "JCSerialNum"));
                tbGoodsname.DataBindings.Add(new Binding("Text", context, "JCGoodsName"));
                tbgoodsid.DataBindings.Add(new Binding("Text", context, "JCGoodsID"));
                djcdate.DataBindings.Add(new Binding("Text", context, "JCDate"));

                tbOperator.DataBindings.Add(new Binding("Text", context, "JCOperator"));
                tbCarno.DataBindings.Add(new Binding("Text", context, "JCCarNO"));
                tbhgsl.DataBindings.Add(new Binding("Text", context, "JCHGSL"));
                tbpssl.DataBindings.Add(new Binding("Text", context, "JCPSSL"));
                tbghsl.DataBindings.Add(new Binding("Text", context, "JCKHSL"));
                tbklsl.DataBindings.Add(new Binding("Text", context, "JCKLSL"));
                tbryhgsl.DataBindings.Add(new Binding("Text", context, "FRYHGSL"));
                tbhgl.DataBindings.Add(new Binding("Text", context, "FHGL"));
                tbModel.DataBindings.Add(new Binding("Text", context, "JCModelno"));
                tbitemid.DataBindings.Add(new Binding("Text", context, "JCItemID"));
                tbMaterial.DataBindings.Add(new Binding("SelectedValue", context, "JCMaterial"));
                cmbkilnno.DataBindings.Add(new Binding("SelectedValue", context, "FKilnNO"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation",context,"FImagePath"));
                cbworknum.DataBindings.Add(new Binding("SelectedValue", context, "JCWorknum"));
                //MemoryStream buf = new MemoryStream((byte[])context["iJCimage"]);
               // Image image = Image.FromStream(buf, true);
               // pictureBox1.Image = image;
               /* if (Bm.Position >= 0)
                {
                    int index = Math.Max(0, Bm.Position);
                    //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;

                    DataTable table = ds.Tables[0];
                    DataRow dr = table.Rows[index];
                    //DataColumn dc = dr["JCimage"];
                    if (!(dr["JCimage"] is System.DBNull))
                    {
                        MemoryStream buf = new MemoryStream((byte[])dr["JCimage"]);
                        Image image = Image.FromStream(buf, true);
                        pictureBox1.Image = image;
                    }
                }
                */
                //cbwarehouse.DataBindings.Add(new Binding("SelectedValue", context, "JCWareID"));


             }
            else
            {
                tbserialnum.Text = "";
                tbGoodsname.Text = "";
                tbgoodsid.Text = "";
                djcdate.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                tbOperator.Text = "";
                tbCarno.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                cmbkilnno.Text = "";
                tbhgsl.Value = 0;
                tbpssl.Value = 0;
                tbghsl.Value = 0;
                tbklsl.Value = 0;
                tbryhgsl.Value = 0;
                tbhgl.Value = 0;
                pictureBox1.Image = null;
            }

        }

        private void ClearBindings()
        {
            tbserialnum.DataBindings.Clear();
            tbGoodsname.DataBindings.Clear();
            tbgoodsid.DataBindings.Clear();
            djcdate.DataBindings.Clear();
            tbModel.DataBindings.Clear();
            tbitemid.DataBindings.Clear();
            tbMaterial.DataBindings.Clear();
            tbOperator.DataBindings.Clear();
            tbCarno.DataBindings.Clear();
            tbitemid.DataBindings.Clear();
            tbModel.DataBindings.Clear();
            tbMaterial.DataBindings.Clear();
            tbhgsl.DataBindings.Clear();
            tbpssl.DataBindings.Clear();
            tbghsl.DataBindings.Clear();
            tbklsl.DataBindings.Clear();
            tbryhgsl.DataBindings.Clear();
            tbhgl.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            cbworknum.DataBindings.Clear();
            cmbkilnno.DataBindings.Clear();
            //cbwarehouse.DataBindings.Clear();
        }


        private void btnCancleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //新增取消
            if (toolbar.flag == 0)
            {
                ClearControls();
                SetControlsReadOnly(true);
            }
            else
            {
                //BindControls();
                //FreshJch();
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }
        }

        private void BindControls()
        {

            if (JCH != null)
            {
                tbserialnum.Text = JCH.strJCSerialNum;
                tbGoodsname.Text = JCH.strJCGoodsName  ;
                tbgoodsid.Text = JCH.strJCGoodsID;
                djcdate.Value = JCH.dJCDate;
                good = goodmethod.Find(JCH.strJCGoodsName);
                tbModel.Text = JCH.strJCModelno;
                tbitemid.Text = JCH.strJCItemID;
                tbMaterial.Text = JCH.strJCMaterial;

                if (JCH.imJCimage != null)
                {
                    MemoryStream buf = new MemoryStream((byte[])JCH.imJCimage);
                    Image image = Image.FromStream(buf, true);
                    pictureBox1.Image = image;
                }

                tbOperator.Text = JCH.strJCOperator;
                tbCarno.Text = JCH.strJCCarNO;
                tbhgsl.Value = JCH.dJCHGSL;
                tbpssl.Value = JCH.dJCPSSL;
                tbghsl.Value = JCH.dJCKHSL;
                tbklsl.Value = JCH.dJCKLSL;
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            //
            if (JCH != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar.flag = 1;
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
                            JCHMethod.tb_JCHDelete(table.Rows[index]["JCSerialNum"].ToString());
                            table.Rows.RemoveAt(index);
                            
                            ds.AcceptChanges();
                        }

                        if (Bm.Count == 0)
                        {
                            toolbar.btndelete.Enabled = false;
                            toolbar.btnedit.Enabled = false;
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
            djcdate.Value = System.DateTime.Today;
            toolbar.flag = 0;
            tbOperator.Text = frmLogin.userName;
            tbGoodsname.Focus();
        }

        private void ClearControls()
        {
            tbserialnum.Text = "";
            tbGoodsname.Text = "";
            tbgoodsid.Text = "";
            djcdate.Text = "";
            tbModel.Text = "";
            tbitemid.Text = "";
            tbMaterial.Text = "";
            tbOperator.Text = "";
            tbCarno.Text = "";
            tbhgsl.Value = 0;
            tbpssl.Value = 0;
            tbghsl.Value = 0;
            tbklsl.Value = 0;
            tbryhgsl.Value = 0;
            tbhgl.Value = 0;
            pictureBox1.Image = null;
            cbworknum.Text = "";
            cmbkilnno.Text = "";
            //cbwarehouse.Text = "";
        }

        private void SetControlsReadOnly(bool p)
        {
            tbGoodsname.Enabled = !p;
            djcdate.Enabled = !p;
            tbCarno.ReadOnly = p;
            cbworknum.Enabled = !p;
            //tbhgsl.Enabled = !p;
            tbpssl.Enabled = !p;
            tbklsl.Enabled = !p;
            tbghsl.Enabled = !p;
            cmbkilnno.Enabled = !p;
            //tbryhgsl.Enabled = !p;
            //tbhgl.Enabled = !p;
            tbMaterial.Enabled = !p;
            //sbtype.IsReadOnly = p;
            //cbwarehouse.Enabled = !p;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate() && checkSL())
                {
                    if (toolbar.flag == 0)
                    {
                        tbserialnum.Text = JCHMethod.tb_JCSerialNum(1);
                        JCH.strJCGoodsID = tbgoodsid.Text.Trim();
                        JCH.strJCGoodsName = tbGoodsname.Text.Trim();
                        JCH.strJCOperator = tbOperator.Text;
                        JCH.strJCSerialNum = tbserialnum.Text;
                        JCH.intJCTYPE = 1;
                        //JCH.strJCWareID = cbwarehouse.SelectedValue.ToString();
                        JCH.strFKilnNo = cmbkilnno.SelectedValue.ToString();
                        JCH.strJCWorknum = cbworknum.SelectedValue.ToString();
                        JCH.strJCCarNO = tbCarno.Text.Trim();
                        JCH.strJCModelno = tbModel.Text.Trim();
                        JCH.strJCMaterial = tbMaterial.SelectedValue.ToString();
                        JCH.strJCItemID = tbitemid.Text.Trim();
                        JCH.dJCDate = djcdate.Value;
                        JCH.dJCHGSL = tbhgsl.Value;
                        JCH.dJCKHSL = tbghsl.Value;
                        JCH.dJCPSSL = tbpssl.Value;
                        JCH.dJCKLSL = tbklsl.Value;
                        JCH.dFRYHGSL = tbryhgsl.Value;
                        JCH.dFHGL = tbhgl.Value;
                        JCH.iFZYID = fzyid;
                        JCH.strFImagePath = pictureBox1.ImageLocation;
                        if (JCHMethod.tb_JCHADD(JCH) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        if (toolbar.cbcontinue.Checked)
                        {
                            String ylbh = cmbkilnno.Text;
                            String bc = cbworknum.Text;
                            String ych = tbCarno.Text;
                            ClearControls();

                            ClearBindings();
                            tbGoodsname.Focus();
                            djcdate.Value = System.DateTime.Now;
                            tbOperator.Text = frmLogin.userName;
                            cmbkilnno.Text = ylbh;
                            cbworknum.Text = bc;
                            tbCarno.Text = ych;
                        }
                        FreshJch(); 
                    }
                    else
                    {
                        JCH.strJCSerialNum = tbserialnum.Text;
                        JCH.strJCGoodsID = tbgoodsid.Text.Trim();
                        JCH.strJCGoodsName = tbGoodsname.Text.Trim();
                        JCH.strJCOperator = tbOperator.Text;
                        JCH.strJCSerialNum = tbserialnum.Text;
                        JCH.strJCWorknum = cbworknum.SelectedValue.ToString();
                        JCH.strFKilnNo = cmbkilnno.SelectedValue.ToString();
                        JCH.strJCCarNO = tbCarno.Text.Trim();
                        JCH.intJCTYPE = 1;
                        //JCH.strJCWareID = cbwarehouse.SelectedValue.ToString();
                        JCH.strJCModelno = tbModel.Text.Trim();
                        JCH.strJCMaterial = tbMaterial.SelectedValue.ToString();
                        JCH.strJCItemID = tbitemid.Text.Trim();
                        JCH.dJCDate = djcdate.Value;
                        JCH.dJCHGSL = tbhgsl.Value;
                        JCH.dJCKHSL = tbghsl.Value;
                        JCH.dJCPSSL = tbpssl.Value;
                        JCH.dJCKLSL = tbklsl.Value;
                        JCH.dFRYHGSL = tbryhgsl.Value;
                        JCH.dFHGL = tbhgl.Value;
                        JCH.strFImagePath = pictureBox1.ImageLocation;
                        if (JCHMethod.tb_JCHUpdate(JCH) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        FreshJch();
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

        private bool checkSL()
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
           /* if (tbryhgsl.Value == 0)
            {
                MessageUtil.ShowError("没有对应窑车的装窑记录,请输入正确的窑车号！");
                return false;
            }
            else
            {
            * 
                if ((tbhgsl.Value + tbpssl.Value + tbghsl.Value + tbklsl.Value) > tbryhgsl.Value)
                {
                    MessageUtil.ShowError("出窑数量或者缺陷数量输入有误，不能超过装窑数量！");
                    return false; ;
                }*/
                return true;
           // }
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
                 tbGoodsname.DataSource = ds.Tables[0];
                 tbGoodsname.DisplayMember = "GoodName";
                 tbGoodsname.ValueMember = "GoodId";
             }

        }
        /*private void BindWareHourse()
        {
            string sql = "select WareID,WareName from tb_WareHouse ";
            ds = dbl.GetDatasetReport(sql, "tb_WareHouse");
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
                            cbwarehouse.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                        }
                    }
                    string[] myarr = listArr.ToArray();
                    // cbwarehouse.AutoCompleteCustomSource.AddRange(myarr);
                    //cbwarehouse.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    // cbwarehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbwarehouse.DataSource = ds.Tables[0];
                    cbwarehouse.DisplayMember = "WareName";
                    cbwarehouse.ValueMember = "WareID";
                }

            }
        }
         */
        private void frmJCHEx_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

       

        void frmJCHEx_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);

        }

        private void supergrid_CellDoubleClick(object sender, DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs e)
        {
            UpdateBindings(context);
            superTabControl1.SelectedTab = stbidetail;
        }
        private void InitializeGrid()
        {
            GridPanel panel = supergrid.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column = panel.Columns["JCTYPE"];
            column.EditorType = typeof(MyGridSwitchButtonEditControl);
            GridColumn column1 = panel.Columns["JCWorknum"];
            column1.EditorType = typeof(MyGridComboxControl);
            GridColumn column2 = panel.Columns["JCMaterial"];
            column2.EditorType = typeof(MaterialComboxControl);
            GridColumn column3 = panel.Columns["FKilnNo"];
            column3.EditorType = typeof(KilnNoComboxControl);
        }
        private class MyGridSwitchButtonEditControl : GridSwitchButtonEditControl
        {
            public MyGridSwitchButtonEditControl()
            {
                OnText =  "出窑";
                OffText = "装窑";
            }
            
        }

        private void supergrid_Click(object sender, EventArgs e)
        {

        }

        private void dtdate2_Click(object sender, EventArgs e)
        {

        }

        private void dtdate_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click_1(object sender, EventArgs e)
        {
            //Dblink dbl = new Dblink();
            //dbl.ShowDgvInfo(supergrid, true);
            DataSet ds = (DataSet)supergrid.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(supergrid, "出窑登记");
            }
        }

        private void tbCarno_Leave(object sender, EventArgs e)
        {
            
            
        }

        private void tbklsl_ValueChanged(object sender, EventArgs e)
        {

            if (tbryhgsl.Value != 0)
            {
                tbhgsl.Value = tbryhgsl.Value - (tbpssl.Value + tbklsl.Value + tbghsl.Value);
                tbhgl.Value = Convert.ToDouble(tbpssl.Value + tbklsl.Value + tbghsl.Value)/Convert.ToDouble(tbryhgsl.Value);
            }
            else
            {
                tbhgl.Value = 0;
            }
        }

        private void tbhgsl_Validated(object sender, EventArgs e)
        {

        }

        private void tbhgsl_Validating(object sender, CancelEventArgs e)
        {

        }

        private void tbhgsl_Validated_1(object sender, EventArgs e)
        {
           /* if (tbryhgsl.Value == 0)
            {
                MessageUtil.ShowError("没有对应窑车的装窑记录,请输入正确的窑车号！");
            }
            else
            {
                if ((tbhgsl.Value + tbpssl.Value + tbghsl.Value + tbklsl.Value) > tbryhgsl.Value)
                {
                    MessageUtil.ShowError("出窑数量或者缺陷数量输入有误，不能超过装窑数量！");
                }
            }
            * */
        }
        private void tbGoodsname_TextChanged(object sender, EventArgs e)
        {
            if (tbGoodsname.Text.Trim() != "" && tbCarno.Text.Trim() != "" && cmbkilnno.Text.Trim() != "")
            {
                try
                {
                    //tbGoodsname.Items.Clear();
                    string sql = "select JCGoodsID,JCItemID,JCModelno,JCHGSL,id,JCGoodsName,JCCarNO from tb_jch a" +
                                " where jcgoodsname = '" + tbGoodsname.Text.Trim() + "' and jccarno = '" + tbCarno.Text.Trim() + "'and FKilnNO = '" + cmbkilnno.SelectedValue.ToString().Trim() + "' and jctype = 0 " +
                                " and not exists (select 1 from tb_jch where a.id = FZYID )";
                    DataSet ds = dbl.GetDataset(sql);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    //tbGoodsname.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                                    tbgoodsid.Text = ds.Tables[0].Rows[i][0].ToString();
                                    tbitemid.Text = ds.Tables[0].Rows[i][1].ToString();
                                    tbModel.Text = ds.Tables[0].Rows[i][2].ToString();
                                    tbryhgsl.Value = Convert.ToInt16(ds.Tables[0].Rows[i][3]);
                                    tbhgsl.Value = tbryhgsl.Value;
                                    fzyid = Convert.ToInt32(ds.Tables[0].Rows[i][4]);
                                }
                            }
                        }
                    }
                    else
                    {
                        tb_GoodsInfo tbgood = new tb_GoodsInfo();
                        tb_GoodsInfoMethods tbgoodmethod = new tb_GoodsInfoMethods();
                        tbgood = tbgoodmethod.Find(tbGoodsname.Text.Trim());
                        if (tbgood != null)
                        {
                            tbgoodsid.Text = tbgood.strGoodsId;
                            tbitemid.Text = tbgood.strItemNO;
                            tbModel.Text = tbgood.strModelNO;
                            tbryhgsl.Value = 0;
                        }
                        else
                        {
                            tbgoodsid.Text = "";
                            tbitemid.Text = "";
                            tbModel.Text = "";
                            tbryhgsl.Value = 0;
                        }
                        fzyid = 0;
                        tbhgsl.Value = 0;
                        tbpssl.Value = 0;
                        tbghsl.Value = 0;
                        tbklsl.Value = 0;
                        tbhgl.Value = 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            tb_GoodsInfo goods;
            tb_GoodsInfoMethods goodsmethod = new tb_GoodsInfoMethods();
            if (tbGoodsname.Text != "")
            {
                goods = goodsmethod.Find(tbGoodsname.Text.Trim());
                //tbGoodsname.Text = goods.strGoodsName;
                //tbgoodsid.Text = goods.strGoodsId;
                //tbModel.Text = goods.strModelNO;
                //tbitemid.Text = goods.strItemNO;
                // tbMaterial.Text = goods.strGoodMaterial;
                if (goods.strFImagePath != null)
                {
                    pictureBox1.ImageLocation = goods.strFImagePath;
                }
            }
            else
            {
                tbgoodsid.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                pictureBox1.ImageLocation = null;
                tbhgsl.Value = 0;
                tbpssl.Value = 0;
                tbklsl.Value = 0;
                tbghsl.Value = 0;

            }
        }

        private void tbGoodsname_DropDown(object sender, EventArgs e)
        {
            if (tbCarno.Text.Trim() != "" && cmbkilnno.Text.Trim() != "")
            {
                try
                {
                    DateTime begdate = DateTime.Now.AddDays(-4);
                    DateTime enddate = DateTime.Now;//.AddDays(-1)
                    tbGoodsname.DataSource = null;
                    tbGoodsname.DisplayMember = "";
                    tbGoodsname.ValueMember = "";
                    tbGoodsname.Items.Clear();
                    string sql = "select distinct JCGoodsID,JCGoodsName from tb_jch a" +
                                " where FKilnNo = '" + cmbkilnno.SelectedValue.ToString().Trim() + "' and jccarno = '" + tbCarno.Text.Trim() + "' and jctype = 0 " +
                                " and jcdate >='" + begdate.ToShortDateString() + "' and jcdate <=  '" + enddate.ToShortDateString() + "'" +
                                " and not exists (select 1 from tb_jch where a.id = FZYID )";
                    DataSet ds = dbl.GetDataset(sql);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    tbGoodsname.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        tbgoodsid.Text = "";
                        tbGoodsname.Text = "";
                        tbModel.Text = "";
                        tbitemid.Text = "";
                        tbMaterial.Text = "";
                        pictureBox1.ImageLocation = null;
                        tbhgsl.Value = 0;
                        tbpssl.Value = 0;
                        tbklsl.Value = 0;
                        tbghsl.Value = 0;
                        //tbhgsl.Value = 0;
                        tbryhgsl.Value = 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
