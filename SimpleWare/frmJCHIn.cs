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
    public partial class frmJCHIn : Office2007Form
    {
        public frmJCHIn()
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

            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;
            //asc.controllInitializeSize(this);


            SetControlsReadOnly(true);
            this.Resize += new EventHandler(frmJCHEx_Resize);
            asc.Load(this);
            BindCombox();
            //BindWareHourse();
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            tb_BaseMgr.SetCombox("material", tbMaterial);
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);
            tb_BaseMgr.SetCombox("KilnNO", cbkilnno);
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

            //DataSet ds = null;

            //dgvlist.AutoGenerateColumns = false;
            //dgvlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dbl.InfoShow(sql, dgvlist);
            FreshJch();

            UpdateBindings(context);
            //TotalRow(supergrid);
        }

        private void TotalRow(DevComponents.DotNetBar.SuperGrid.SuperGridControl gridview)
        {

           /* GridRow gr = new GridRow();
            GridCell gc = new GridCell("合计");
            gr.Cells.Add(gc);
            for (int i = 0; i < 16; i++)
            {,
                GridCell gc1 = new GridCell();
                gr.Cells.Add(gc1);
            }
            gr.Cells[7].Value = zysl;
            gr.Cells[8].Value = pssl;
            supergrid.PrimaryGrid.Rows.Add(gr);
            */

        }

        private void FreshJch()
        {
            string sql = "select JCTYPE,JCDate ,JCGoodsName,JCGoodsID  ,JCHGSL ," +
            " JCCarNO , JCWorknum ,JCOperator ,JCSerialNum,JCModelno,JCItemID,JCMaterial,FImagePath,isnull(FPSSL,0) as FPSSL,FPSL,FKilnNO  " +
             " from tb_jch where JCTYPE = 0 ";
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
            sql += " order by JCDATE DESC,JCCarNO desc ";
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
                    toolbar1.btnEditEnabled = true;
                    toolbar1.btndelete.Enabled = true;
                }
                //UpdateBindings(context);
                int zysl = 0, pssl = 0;
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    zysl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[i]["JCHGSL"].ToString()));
                    pssl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[i]["FPSSL"].ToString()));
                }

                lblzysl.Text = String.Format("{0} ", zysl);//碰损数量： {1}
            }
            else
            {
                supergrid.PrimaryGrid.DataSource = null;
                lblzysl.Text = "";
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
                tbpssl.DataBindings.Add(new Binding("Text", context, "FPSSL"));
                tbpsl.DataBindings.Add(new Binding("Text", context, "FPSL"));
                tbModel.DataBindings.Add(new Binding("Text", context, "JCModelno"));
                tbitemid.DataBindings.Add(new Binding("Text", context, "JCItemID"));
                cbworknum.DataBindings.Add(new Binding("SelectedValue", context, "JCWorknum"));
                cmbkilnno.DataBindings.Add(new Binding("SelectedValue", context, "FKilnNo"));
                tbMaterial.DataBindings.Add(new Binding("SelectedValue", context, "JCMaterial"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation",context,"FImagePath"));
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
                }*/
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
                cmbkilnno.Text = "";
                tbModel.Text = "";
                tbitemid.Text = "";
                tbMaterial.Text = "";
                tbhgsl.Value = 0;
                tbpsl.Value = 0;
                tbpssl.Value = 0;
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
            tbpsl.DataBindings.Clear();
            cbworknum.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            cmbkilnno.DataBindings.Clear();
            //cbwarehouse.DataBindings.Clear();
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

                tbOperator.Text = JCH.strJCOperator;
                tbCarno.Text = JCH.strJCCarNO;
                tbhgsl.Value = JCH.dJCHGSL;

            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            //
            if (JCH != null)
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
                            JCHMethod.tb_JCHDelete(table.Rows[index]["JCSerialNum"].ToString());
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
            djcdate.Value = System.DateTime.Today;
            toolbar1.flag = 0;
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
            cmbkilnno.Enabled = !p;
            tbhgsl.Enabled = !p;
            tbMaterial.Enabled = !p;
            tbpssl.Enabled = !p;
            //tbpsl.Enabled = !p;
           /* tbpssl.Enabled = !p;
            tbklsl.Enabled = !p;
            tbghsl.Enabled = !p;
            sbtype.IsReadOnly = p;
            cbwarehouse.Enabled = !p;
            */ 
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate() && checksaveed())
                {
                    if (toolbar1.flag == 0)
                    {
                        tbserialnum.Text = JCHMethod.tb_JCSerialNum(0);
                        JCH.strJCGoodsID = tbgoodsid.Text.Trim();
                        JCH.strJCGoodsName = tbGoodsname.Text.Trim();
                        JCH.strJCOperator = tbOperator.Text;
                        JCH.strJCSerialNum = tbserialnum.Text;
                        JCH.intJCTYPE = 0;
                        //JCH.strJCWareID = cbwarehouse.SelectedValue.ToString();
                        JCH.strJCWorknum = cbworknum.SelectedValue.ToString();
                        JCH.strFKilnNo = cmbkilnno.SelectedValue.ToString();
                        JCH.strJCCarNO = tbCarno.Text.Trim();
                        JCH.strJCModelno = tbModel.Text.Trim();
                        JCH.strJCMaterial = tbMaterial.SelectedValue.ToString();
                        JCH.strJCItemID = tbitemid.Text.Trim();
                        JCH.dJCDate = djcdate.Value;
                        JCH.dJCHGSL = tbhgsl.Value;
                        JCH.dFPSL = tbpsl.Value;
                        JCH.iFPSSL = tbpssl.Value;
                        JCH.strFImagePath = pictureBox1.ImageLocation;
                        if (JCHMethod.tb_JCHADD(JCH) == 1)
                            MessageUtil.ShowTips("保存成功!");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            String ychh = cmbkilnno.Text;
                            String bc = cbworknum.Text;
                            String ych = tbCarno.Text;
                            ClearControls();

                            ClearBindings();
                            tbGoodsname.Focus();
                            djcdate.Value = System.DateTime.Now;
                            tbOperator.Text = frmLogin.userName;
                            cmbkilnno.Text = ychh;
                            cbworknum.Text = bc;
                            tbCarno.Text = ych;
                        }
                        FreshJch();

                    }
                    else
                    {
                        JCH.strJCSerialNum = tbserialnum.Text;
                        JCH.strJCGoodsID = tbgoodsid.Text.Trim();
                        JCH.strJCOperator = tbOperator.Text;
                        JCH.strJCSerialNum = tbserialnum.Text;
                        //JCH.strJCWareID = cbworknum.Text;
                        JCH.strJCCarNO = tbCarno.Text.Trim();
                        JCH.intJCTYPE = 0;
                        //JCH.strJCWareID = cbwarehouse.SelectedValue.ToString();
                        JCH.strJCWorknum = cbworknum.SelectedValue.ToString();
                        JCH.strFKilnNo = cmbkilnno.SelectedValue.ToString();
                        JCH.strJCModelno = tbModel.Text.Trim();
                        JCH.strJCMaterial = tbMaterial.SelectedValue.ToString();
                        JCH.strJCItemID = tbitemid.Text.Trim();
                        JCH.dJCDate = djcdate.Value;
                        JCH.dJCHGSL = tbhgsl.Value;
                        JCH.dFPSL = tbpsl.Value;
                        JCH.iFPSSL = tbpssl.Value;
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

        private bool checksaveed()
        {
            if (tbCarno.Text.Trim() == "")
            {
                MessageUtil.ShowError("窑车号必须输入！");
                return false;
            }
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
       /* private void BindWareHourse()
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
                            //cbwarehouse.Items.Add(ds.Tables[0].Rows[i][1].ToString());
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
                //tbMaterial.Text = goods.strGoodMaterial;
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
                //tbMaterial.Text = "";
                pictureBox1.ImageLocation = null;
                /*tbhgsl.Value = 0;
                tbpssl.Value = 0;
                tbklsl.Value = 0;
                tbghsl.Value = 0;
                 */
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            //Dblink dbl = new Dblink();
            //dbl.ShowDgvInfo(supergrid, true);
            DataSet ds = (DataSet)supergrid.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(supergrid, "装窑登记");
            }
        }

        private void toolbar1_Load(object sender, EventArgs e)
        {

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
                // Lets have this one only stretch horizontally
                // and not vertically as well

                OnText =  "出窑";
                OffText = "装窑";
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

        private void supergrid_Click(object sender, EventArgs e)
        {

        }

        private void dtdate2_Click(object sender, EventArgs e)
        {

        }

        private void dtdate_Click(object sender, EventArgs e)
        {

        }

        private void tbpssl_ValueChanged(object sender, EventArgs e)
        {
            if (tbhgsl.Value != 0)
            {
                tbpsl.Value = Convert.ToDouble(tbpssl.Value) / Convert.ToDouble(tbpssl.Value + tbhgsl.Value) ;
            }
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }
    }
}
