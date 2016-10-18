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
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using System.Data.SqlClient;
namespace SimpleWare
{
    public partial class frmSelPorcelain : Office2007Form
    {

        tb_SelPorcelain sp = new tb_SelPorcelain();
        SelPorcelainMethod spMethod = new SelPorcelainMethod();
        tb_GoodsInfo good = new tb_GoodsInfo();
        tb_GoodsInfoMethods goodmethod = new tb_GoodsInfoMethods();
        System.Data.SqlClient.SqlConnection conn = null;
        Dblink dbl = new Dblink();
        DataSet ds = new DataSet();
        private BindingManagerBase _Bm;
        Dbconnection dbc = new Dbconnection();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        FormAutoSizeClass fasc = new FormAutoSizeClass();
        object dataSource = null;
        string dataMember = null;
        object context = null;
        string usercode = frmLogin.userCode;
        string username = frmLogin.userName;
        public tb_EmpInfo curUser = new tb_EmpInfo();
        Boolean IsGm = frmLogin.isGm || frmLogin.isSuperGm;
        Boolean isEdit = false;
        //string checkedIDs = "";
        List<string> checkedIDs = new List<string>();    
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
        public frmSelPorcelain()
        {
            InitializeComponent();
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

        private void frmSelPorcelain_Load(object sender, EventArgs e)
        {
            curUser = frmLogin.curUser;
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;
            vKeyBoard1.lblclick += new VKeyBoard.labClick(lblClick);
            SetControlsReadOnly(true);
            this.Resize += new EventHandler(frmSelPorcelain_Resize);
            asc.Load(this);
             //fasc.controllInitializeSize(this);
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);
            tb_BaseMgr.SetCombox("ProdLine", cmbSCX);
            tb_BaseMgr.SetCombox("material", cmbMaterial);
            //string sql  = "select "
            tb_EmpInfoMenthod.SetCombox(cmbOpr);
            //tb_BaseMgr.SetCombox("Color", tbMaterial);
            BindModel();
            
            BindColor();
            cmbMaterial.SelectedValue = "";
            cmbcolor.SelectedValue = "";
            cmbcolor.Text = "";
            cbgoods.Text = "";
            if (!IsGm)
            {
                cmbOpr.Enabled = false;
                cmbOpr.Text = username;
            }
            else
                cmbOpr.Text = "";
            dtdate.Value = System.DateTime.Now;
            dtdate2.Value = System.DateTime.Now;
            btnDel.Visible = IsGm;
            FreshSp();

            UpdateBindings(context);
            //tb_BaseMgr.SetCombox("KilnNO", cbkilnno);
            InitializeGrid();
            //InitializeRptGrid();
        }

        private void lblClick(object sender, EventArgs e)
        {
            tbpssl.Focus();
        }
        private void InitializeGrid()
        {
            GridPanel panel = supergrid.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column1 = panel.Columns["PlModelNo"];
            column1.EditorType = typeof(ModelNoComboxControl);
            GridColumn column2 = panel.Columns["PlColor"];
            column2.EditorType = typeof(ColorComboxControl);
            GridColumn column3 = panel.Columns["PlWorkNumID"];
            column3.EditorType = typeof(MyGridComboxControl);
            GridColumn column4 = panel.Columns["PlKilnNo"];
            column4.EditorType = typeof(KilnNoComboxControl);
            GridColumn column5 = panel.Columns["PlWorkshopId"];
            column5.EditorType = typeof(ProdlineComboxControl);
            GridColumn column6 = panel.Columns["FMaterial"];
            column6.EditorType = typeof(MaterialComboxControl);
        }
        private void BindColor()
        {
            string sql = "select ColorNo,ColorName from tb_ColorInfo where fisstop = 0 ";
            ds = dbl.GetDatasetReport(sql, "tb_ColorInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    tbMaterial.DataSource = ds.Tables[0];
                    tbMaterial.DisplayMember = "ColorName";
                    tbMaterial.ValueMember = "ColorNo";

                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //this.lbgoods.Visible = true;
                        //this.lbgoods.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            listArr.Add(ds.Tables[0].Rows[i][1].ToString());
                            //tbmodelno.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                        }
                    }
                    string[] myarr = listArr.ToArray();
                    //cbgoods.AutoCompleteCustomSource.AddRange(myarr);
                    //cbgoods.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    //cbgoods.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbMaterial.AutoCompleteCustomSource.AddRange(myarr);
                    tbMaterial.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbMaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                }
            }

        }
        private void BindModel()
        {
            string sql = "select ModelNo,ModelName from tb_ModelInfo a where fisstop = 0  and exists (select 1 from tb_SpGoodsInfo where GoodName = a.ModelName) ";
            ds = dbl.GetDatasetReport(sql, "tb_ModelInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    tbmodelno.DataSource = ds.Tables[0];
                    tbmodelno.DisplayMember = "ModelName";
                    tbmodelno.ValueMember = "ModelNo";
                    //cbgoods.DataSource = ds.Tables[0];
                    //cbgoods.DisplayMember = "ModelName";
                    //cbgoods.ValueMember = "ModelNo";
                    //cmbQryModel.DataSource = ds.Tables[0];
                    //cmbQryModel.DisplayMember = "ModelName";
                    //cmbQryModel.ValueMember = "ModelNo";
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //this.lbgoods.Visible = true;
                        //this.lbgoods.Items.Clear();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            listArr.Add(ds.Tables[0].Rows[i][1].ToString());
                            //tbmodelno.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                        }
                    }
                    string[] myarr = listArr.ToArray();
                    cbgoods.AutoCompleteCustomSource.AddRange(myarr);
                    cbgoods.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cbgoods.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    tbmodelno.AutoCompleteCustomSource.AddRange(myarr);
                    tbmodelno.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbmodelno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    //cmbQryModel.AutoCompleteCustomSource.AddRange(myarr);
                    //cmbQryModel.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    //cmbQryModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }

        }

        private void btnCancleClick(object sender, EventArgs e)
        {
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
                //FreshJch();
                UpdateBindings(context);
                SetControlsReadOnly(true);
            }
            isEdit = false;
        }
        private void ClearBindings()
        {
            tbserialnum.DataBindings.Clear();
            optTime.DataBindings.Clear();
            tbmodno.DataBindings.Clear();
            tbgoodid.DataBindings.Clear();
            djcdate.DataBindings.Clear();
            tbmodelno.DataBindings.Clear();
            tbOperator.DataBindings.Clear();
            tbMaterial.DataBindings.Clear();
            tbpssl.DataBindings.Clear();
            cbworknum.DataBindings.Clear();
            cmbkilnno.DataBindings.Clear();
            tbmodelfaults.DataBindings.Clear();
            tbglazefaults.DataBindings.Clear();
            tbfirefaults.DataBindings.Clear();
            tblevel.DataBindings.Clear();
            tbthis.DataBindings.Clear();
            ckbif.DataBindings.Clear();
            cmbSCX.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbserialnum.DataBindings.Add(new Binding("Text", context, "PlSerialNum"));
                tbOperator.DataBindings.Add(new Binding("Text", context, "PlOperator"));
                cbworknum.DataBindings.Add(new Binding("SelectedValue", context, "PlWorkNumID"));
                djcdate.DataBindings.Add(new Binding("Text", context, "PlApplyDate"));
                optTime.DataBindings.Add(new Binding("Text", context, "PlApplytime"));
                ckbif.DataBindings.Add(new Binding("CheckValue", context, "PlNeedGlazed"));
                cmbSCX.DataBindings.Add(new Binding("SelectedValue", context, "PlWorkshopId"));
                tbmodelno.DataBindings.Add(new Binding("SelectedValue", context, "PlModelNo"));
                tbgoodid.DataBindings.Add(new Binding("Text", context, "PlGoodsID"));
                tbMaterial.DataBindings.Add(new Binding("SelectedValue", context, "PlColor"));
                cmbkilnno.DataBindings.Add(new Binding("SelectedValue", context, "PlKilnNo"));

                //tbCarno.DataBindings.Add(new Binding("Text", context, "JCCarNO"));
                tbmodelfaults.DataBindings.Add(new Binding("Text", context, "PlModelFaults"));
                tbglazefaults.DataBindings.Add(new Binding("Text", context, "PlGlazeFaults"));
                tbfirefaults.DataBindings.Add(new Binding("Text", context, "PlFireFaults"));
                tblevel.DataBindings.Add(new Binding("Text", context, "PlLevels"));
                tbpssl.DataBindings.Add(new Binding("Text", context, "PlQty"));
                tbthis.DataBindings.Add(new Binding("Text", context, "PlThisQty"));
 

                pictureBox1.DataBindings.Add(new Binding("ImageLocation", context, "FImagePath"));
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
                ClearControls();
            }

        }

        private void SetControlsReadOnly(bool p)
        {
            tbmodelno.Enabled = !p;
            djcdate.Enabled = !p;
            optTime.Enabled = !p;
            ckbif.Enabled = !p;
            //tbCarno.ReadOnly = p;
            cbworknum.Enabled = !p;
            cmbkilnno.Enabled = !p;
            cmbSCX.Enabled = !p;
            ckbif.Enabled = !p;
            tbMaterial.Enabled = !p;
            tbpssl.Enabled = !p;
            //tbmodelfaults.ReadOnly = p;
            //tbglazefaults.ReadOnly = p;
            //tbfirefaults.ReadOnly = p;
            //tblevel.ReadOnly = p;
            //tbthis.Enabled = !p;
            //pModel.Enabled = !p;
            //pGlaze.Enabled = !p;
            //pFire.Enabled = !p;
            //pLevel.Enabled = !p;
            btn1.Enabled = !p;
            btn2.Enabled = !p;
            btn3.Enabled = !p;
            btn4.Enabled = !p;
            btn5.Enabled = !p;
            btn6.Enabled = !p;

        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (sp != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            isEdit = true;
            tbmodelno.Focus();
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        int index = supergrid.PrimaryGrid.ActiveRow.Index;
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;

                        if (ds != null)
                        {
                            DataTable table = ds.Tables[0];
                            spMethod.SelPorcelainDelete(table.Rows[index]["PlSerialNum"].ToString());
                            table.Rows.RemoveAt(index);
                            ds.AcceptChanges();
                            LogHelper.WriteLog(username + " 删除选瓷单据【单号:" + table.Rows[index]["PlSerialNum"].ToString() + "器型:" + tbmodelno.Text.Trim() + " 花色:" + tbMaterial.Text.Trim() + " 件数:" + tbpssl.Value + "】");
                        }

                        if (Bm.Count == 0)
                        {
                            toolbar1.btndelete.Enabled = false;
                            toolbar1.btnedit.Enabled = false;
                        }
                    }
                }
            }
            isEdit = false;
        }

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            djcdate.Value = System.DateTime.Today;
            optTime.Value = Convert.ToDateTime(System.DateTime.Now.ToLongTimeString());
            toolbar1.flag = 0;
            tbOperator.Text = frmLogin.userName;
            cmbkilnno.SelectedValue = curUser.strEmpKilnNO == null ? "" : curUser.strEmpKilnNO;
            cmbSCX.SelectedValue = curUser.strEmpWorshoId == null ? "" : curUser.strEmpWorshoId;
            tbserialnum.Text = spMethod.SelPorceLainSerialNum();
            tbpssl.Value = 1;//20160425 选瓷的件数默认为1，这样只要是1件的产品就不要去输数量了，直接按保存
            tbthis.Value = spMethod.getThisworknumSumQty(usercode);

            tbmodelno.Focus();
            isEdit = true;
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (checksaveed())
                {
                    if (toolbar1.flag == 0)
                    {
                        //tbserialnum.Text = spMethod.SelPorceLainSerialNum();
                        sp.strPlSerialNum = spMethod.SelPorceLainSerialNum();//新增保存的时候再去取一遍最大编号，确保不会重复。ccm 20160527
                        //sp.strPlModelNo = tbmodelno.Text != "" ? tbmodelno.SelectedValue.ToString() : "";
                        sp.strPlGoodsName = tbmodelno.Text.Trim();
                        string sql = @"select GoodId,GoodName,FTypeSteps1,FTypeSteps2,FTypeSteps3,FColorSteps,FImagePath,GoodMaterial,ModelNO from tb_SpGoodsInfo 
                                where GoodName = '" + tbmodelno.Text.Trim() + "' and FColor = '" + tbMaterial.SelectedValue.ToString() + "'";
                        ds = dbl.GetDatasetReport(sql, "tb_SpGoodsInfo");
                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sp.strPlGoodsID = ds.Tables[0].Rows[0]["GoodId"].ToString();
                                    sp.strFTypeSteps1 = ds.Tables[0].Rows[0]["FTypeSteps1"].ToString();
                                    sp.strFTypeSteps2 = ds.Tables[0].Rows[0]["FTypeSteps2"].ToString();
                                    sp.strFTypeSteps3 = ds.Tables[0].Rows[0]["FTypeSteps3"].ToString();
                                    sp.strFColorSteps = ds.Tables[0].Rows[0]["FColorSteps"].ToString();
                                    sp.FMaterial = ds.Tables[0].Rows[0]["GoodMaterial"].ToString();
                                    sp.strPlModelNo = ds.Tables[0].Rows[0]["ModelNO"].ToString();
                                }
                            }
                        }
                        sp.strPlOperator  = tbOperator.Text;
                        sp.strPlOperatorID = frmLogin.userCode;
                        sp.strPlWorkNumID = cbworknum.SelectedValue.ToString();
                        sp.strPlKilnNo = cmbkilnno.SelectedValue.ToString();
                        sp.strPlColor = tbMaterial.SelectedValue.ToString();
                        sp.strPlWorkshopId = cmbSCX.SelectedValue.ToString();
                        sp.dPlApplyDate = djcdate.Value;
                        sp.strPlApplytime = optTime.Value.ToLongTimeString();
                        sp.strPlModelFaults = tbmodelfaults.Text.Trim();
                        sp.strPlModelFaultsID = modeltag.Text.Trim();
                        sp.strPlGlazeFaults = tbglazefaults.Text.Trim();
                        sp.strPlFireFaults = tbfirefaults.Text.Trim();
                        sp.strPlLevels = tblevel.Text.Trim();
                        sp.iPlQty = tbpssl.Value;
                        sp.iPlThisQty = tbthis.Value;
                        sp.iPlNeedGlazed = ckbif.Checked ? 1 : 0;
                        //图片为空
                        if (pictureBox1.ImageLocation == "")
                            GetRelPic();
                        sp.strFImagePath = pictureBox1.ImageLocation;
                        if (spMethod.SelPorcelainADD(sp) != 1)
                            MessageUtil.ShowTips("保存失败!");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearBindings();
                            tbserialnum.Text = spMethod.SelPorceLainSerialNum();
                            tbmodelfaults.Text = "";
                            tbglazefaults.Text = "";
                            tbfirefaults.Text = "";
                            tblevel.Text = "";
                            tbpssl.Value = 1;//20160425 选瓷的件数默认为1，这样只要是1件的产品就不要去输数量了，直接按保存
                            djcdate.Value = System.DateTime.Today;
                            optTime.Value = Convert.ToDateTime(System.DateTime.Now.ToLongTimeString());
                            tbthis.Value = spMethod.getThisworknumSumQty(usercode);
                            isEdit = true;
                            tbmodelno.Focus();
                        }
                        else
                            isEdit = false;
                        FreshSp();

                    }
                    else
                    {
                        
                        sp.strPlSerialNum = tbserialnum.Text.Trim();
                        //sp.strPlModelNo = tbmodelno.Text != "" ? tbmodelno.SelectedValue.ToString() : "";
                        sp.strPlGoodsName = tbmodelno.Text.Trim();
                        string sql = @"select GoodId,GoodName,FTypeSteps1,FTypeSteps2,FTypeSteps3,FColorSteps,FImagePath,GoodMaterial,ModelNO from tb_SpGoodsInfo 
                                where GoodName = '" + tbmodelno.Text.Trim() + "' and FColor = '" + tbMaterial.SelectedValue.ToString() + "'";
                        ds = dbl.GetDatasetReport(sql, "tb_SpGoodsInfo");
                        if (ds != null)
                        {
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sp.strPlGoodsID = ds.Tables[0].Rows[0]["GoodId"].ToString();
                                    sp.strFTypeSteps1 = ds.Tables[0].Rows[0]["FTypeSteps1"].ToString();
                                    sp.strFTypeSteps2 = ds.Tables[0].Rows[0]["FTypeSteps2"].ToString();
                                    sp.strFTypeSteps3 = ds.Tables[0].Rows[0]["FTypeSteps3"].ToString();
                                    sp.strFColorSteps = ds.Tables[0].Rows[0]["FColorSteps"].ToString();
                                    sp.FMaterial = ds.Tables[0].Rows[0]["GoodMaterial"].ToString();
                                    sp.strPlModelNo = ds.Tables[0].Rows[0]["ModelNO"].ToString();
                                }
                            }
                        }
                        sp.strPlOperator = tbOperator.Text;
                        sp.strPlOperatorID = tb_EmpInfoMenthod.userid(tbOperator.Text);
                        sp.strPlWorkNumID = cbworknum.SelectedValue.ToString();
                        sp.strPlKilnNo = cmbkilnno.SelectedValue.ToString();
                        sp.strPlColor = tbMaterial.SelectedValue.ToString();
                        sp.strPlWorkshopId = cmbSCX.SelectedValue.ToString();
                        sp.dPlApplyDate = djcdate.Value;
                        sp.strPlApplytime = optTime.Value.ToLongTimeString();
                        sp.strPlModelFaults = tbmodelfaults.Text.Trim();
                        sp.strPlModelFaultsID = modeltag.Text.Trim();
                        sp.strPlGlazeFaults = tbglazefaults.Text.Trim();
                        sp.strPlFireFaults = tbfirefaults.Text.Trim();
                        sp.strPlLevels = tblevel.Text.Trim();
                        sp.iPlQty = tbpssl.Value;
                        sp.iPlThisQty = tbthis.Value;
                        sp.iPlNeedGlazed = ckbif.Checked ? 1 : 0;
                        if (pictureBox1.ImageLocation == "")
                            GetRelPic();
                        sp.strFImagePath = pictureBox1.ImageLocation;
                        if (spMethod.SelPorcelainUpdate(sp) != 1)
                            MessageUtil.ShowTips("保存失败!");
                        FreshSp();
                        SetControlsReadOnly(true);
                        isEdit = false;
                    }
                }
                
            }
            catch (Exception)
            {
                MessageUtil.ShowError("保存失败!");
                return;
            }
        }

        private void FreshSp()
        {
            string sql = @"SELECT [PlApplyDate]
                                  ,[PlApplyTime]
                                  ,[PlOperator]
                                  ,[PlSerialNum]
                                  ,[PlWorkNumID]
                                  ,[PlGoodsID]
                                  ,[PlKilnNo]
                                  ,[PlColor]
                                  ,[PlWorkshopId]
                                  ,[PlNeedGlazed]
                                  ,[PlModelFaults]
                                  ,[PlGlazeFaults]
                                  ,[PlFireFaults]
                                  ,[PlLevels]
                                  ,PlModelNo 
                                  ,[PlQty]
                                  ,[PlThisQty]
                                  ,FImagePath
                                  ,FMaterial
                           FROM [dbo].[SelPorceLain] 
                          where 1=1 ";
            if (dtdate.Text != "")
            {
                sql += " and PlApplyDate >= '" + dtdate.Value.Date.ToShortDateString() + "'";
            }
            if (dtdate2.Text != "")
            {
                sql += " and PlApplyDate <= '" + dtdate2.Value.Date.ToShortDateString() + "'";
            }
            if (cbgoods.Text.Trim() != "")
            {
                sql += " and PlGoodsName = '" + cbgoods.Text.Trim() + "'";
            }
            if (cmbOpr.Text.Trim() != "")
            {
                sql += " and PlOperator like '%" + cmbOpr.Text.Trim() + "%' ";
            }
            if (cmbMaterial.SelectedValue != null)
            {
                sql += " and FMaterial = '" + cmbMaterial.SelectedValue.ToString() + "'";
            }
            if (cmbcolor.SelectedValue != null)
            {
                sql += " and PlColor = '" + cmbcolor.SelectedValue.ToString() + "'";
            }
            sql += " order by PlApplyDate DESC,PlSerialNum desc ";
             
            ds = dbl.GetDataset(sql, "SelPorceLain");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                supergrid.PrimaryGrid.DataSource = ds;
                supergrid.PrimaryGrid.DataMember = "SelPorceLain";
                Bm = (dataSource != null)
                         ? supergrid.BindingContext[context]
                         : null;
                if (Bm.Count >= 0)
                {
                    toolbar1.btnEditEnabled = true;
                    toolbar1.btndelete.Enabled = true;
                }

                int zysl = 0;
                int qtyA = 0;
                int qtyAd = 0;
                int qtyCa = 0;
                int qtyB = 0;
                int qtyBJ = 0;
                int qtyBu = 0;
                int qtyFp = 0;
                int qtyC = 0;
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    zysl += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "A+")
                        qtyA += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "A等")
                        qtyAd += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "CA等")
                        qtyCa += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "B甲")
                        qtyBJ += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "B等")
                        qtyB += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "C等")
                        qtyC += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "补釉")
                        qtyBu += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    if (ds.Tables[0].Rows[i]["PlLevels"].ToString() == "废品")
                        qtyFp += Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[i]["PlQty"].ToString()));
                    //pssl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[i]["FPSSL"].ToString()));
                }

                lblzysl.Text = String.Format("{0} ", zysl);//碰损数量： {1}
                lblA.Text = String.Format("{0} ", qtyA);//A+： {1}
                lblAd.Text = String.Format("{0} ", qtyAd);//A等： {1}
                lblCa.Text = String.Format("{0} ", qtyCa);//CA： {1}
                lblBJ.Text = String.Format("{0} ", qtyBJ);//B甲： {1}
                lblB.Text = String.Format("{0} ", qtyB);//B： {1}
                lblC.Text = String.Format("{0} ", qtyC);//B： {1}
                lblBu.Text = String.Format("{0} ", qtyBu);//补釉： {1}
                lblFp.Text = String.Format("{0} ", qtyFp);//废品： {1}

            }
            else
            {
                supergrid.PrimaryGrid.DataSource = null;
                lblzysl.Text = "";
            }
        }



        private void ClearControls()
        {
            tbserialnum.Text = "";
            tbmodelno.Text = "";
            tbgoodid.Text = "";
            tbmodno.Text = "";;
            //djcdate.Text = "";;
            tbMaterial.Text = "";;
            tbOperator.Text = "";;
            tbMaterial.Text = "";;
            tbpssl.Value = 0;
            //cbworknum.Text = "";;
            cmbkilnno.Text = "";;
            tbmodelfaults.Text = "";;
            modeltag.Text = "";
            tbglazefaults.Text = "";;
            tbfirefaults.Text = "";;
            tblevel.Text = "";;
            tbthis.Value =0;
            pictureBox1.ImageLocation = "";
            //sbif.Text = "";;
        }

        private bool checksaveed()
        {
            /*if (tbCarno.Text.Trim() == "")
            {
                MessageUtil.ShowError("窑车号必须输入！");
                return false;
            }*/
            if (tbmodelno.Text.Trim() == "")
            {
                MessageUtil.ShowError("器型名称必须输入！");
                return false;
            }
            if (tbmodelno.Text.Trim() != "" && !tb_ModelInfoMethod.exists(tbmodelno.Text.Trim()))
            {
                MessageUtil.ShowError("器型名称输入有误，请重新输入！");
                return false;
            }

            if (cbworknum.Text.Trim() == "")
            {
                MessageUtil.ShowError("班次必须输入！");
                return false;
            }
            if (cmbkilnno.Text.Trim() == "")
            {
                MessageUtil.ShowError("窑炉编号必须输入！");
                return false;
            }
            if (tblevel.Text.Trim() == "")
            {
                MessageUtil.ShowError("等级必须输入！");
                return false;
            }
            if (tbpssl.Value == 0)
            {
                MessageUtil.ShowError("件数必须输入！");
                return false;
            }
            if (tblevel.Text.Trim()!="A+" && tblevel.Text.Trim() != "A等" && tbmodelfaults.Text.Trim() == "" && tbglazefaults.Text.Trim() == "" && tbfirefaults.Text.Trim() == "")
            {
                MessageUtil.ShowError("非A等品请输入缺陷！");
                return false;
            }
            return true;
        }

        private void frmSelPorcelain_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
            //fasc.controlAutoSize(this);
        }

        private void labelX22_Click(object sender, EventArgs e)
        {

        }

        private void frmSelPorcelain_SizeChanged(object sender, EventArgs e)
        {
            //fasc.controlAutoSize(this);
        }



        private void labelX21_Click(object sender, EventArgs e)
        {
            setLabel(tbmodelfaults, sender as LabelX,modeltag);
        }
        private void setLabel(TextBoxX tb,LabelX lbl,TextBoxX tb1 = null)
        {
            if (isEdit)
            {
                if (!tb.Focus())
                    tb.Focus();
                if (tb.Text.Trim() == "")
                {
                    tb.Text = lbl.Text;
                    if (tb1 != null)
                        tb1.Text = lbl.Name;
                }
                else
                {
                    if (tb1 != null)
                    {
                        if (!tb1.Text.Contains(lbl.Name))
                        {
                            tb.Text += "," + lbl.Text;
                            tb1.Text += "," + lbl.Name;
                        }
                    }
                    else
                    {
                        if (!tb.Text.Contains(lbl.Text))
                            tb.Text += "," + lbl.Text;
                    }

                }
            }
        }
        private void labelX33_Click(object sender, EventArgs e)
        {
            setLabel(tbglazefaults, sender as LabelX);
        }

        private void labelX50_Click(object sender, EventArgs e)
        {
            setLabel(tbfirefaults, sender as LabelX);
        }

        private void labelX56_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!tblevel.Focus())
                    tblevel.Focus();
                tblevel.Text = (sender as LabelX).Text;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!tbmodelfaults.Focus())
                    tbmodelfaults.Focus();
                tbmodelfaults.Text = "";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!tbglazefaults.Focus())
                    tbglazefaults.Focus();
                tbglazefaults.Text = "";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!tbfirefaults.Focus())
                    tbfirefaults.Focus();
                tbfirefaults.Text = "";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (tbmodelfaults.Text.LastIndexOf(",") > 0)
                {
                    tbmodelfaults.Text = tbmodelfaults.Text.Substring(0, tbmodelfaults.Text.LastIndexOf(","));
                    modeltag.Text = modeltag.Text.Substring(0, modeltag.Text.LastIndexOf(","));
                }
                else
                    tbmodelfaults.Text = "";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (tbglazefaults.Text.LastIndexOf(",") > 0)
                    tbglazefaults.Text = tbglazefaults.Text.Substring(0, tbglazefaults.Text.LastIndexOf(","));
                else
                    tbglazefaults.Text = "";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (tbfirefaults.Text.LastIndexOf(",") > 0)
                    tbfirefaults.Text = tbfirefaults.Text.Substring(0, tbfirefaults.Text.LastIndexOf(","));
                else
                    tbfirefaults.Text = "";
            }
        }

        private void tbmodelno_Leave(object sender, EventArgs e)
        {
            tb_ModelInfo goods;
            tb_ModelInfoMethod goodsmethod = new tb_ModelInfoMethod();
            if (isEdit)
            {
                if (tbmodelno.Text != "")
                {
                    //goods = goodsmethod.Find(tbmodelno.Text.Trim());
                    string sql = "select a.FColor,b.ColorName from tb_SpGoodsInfo a " +
                                 " left join tb_ColorInfo b on a.FColor = b.ColorNo " +
                                 "where a.GoodName = '" + tbmodelno.Text.Trim() + "'";
                    ds = dbl.GetDatasetReport(sql, "good");
                    List<string> listArr = new List<string>();
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                tbMaterial.DataSource = ds.Tables[0];
                                tbMaterial.DisplayMember = "ColorName";
                                tbMaterial.ValueMember = "FColor";
                            }

                        }
                    }
                }
                else
                {
                    tbgoodid.Text = "";
                    tbMaterial.Text = "";
                    //pictureBox1.ImageLocation = null;
                }
            }
        }

        private void tbMaterial_Leave(object sender, EventArgs e)
        {
            if (isEdit)
            {
                GetRelPic();
                
            }
        }

        //抓取关联的产品图片
        private void GetRelPic()
        {
            if (tbmodelno.Enabled && tbMaterial.Enabled)
            {

                if (tbmodelno.Text != "" && tbmodelno.SelectedValue != null && tbMaterial.Text != "")
                {
                    string sql = @"select GoodId,GoodName,FImagePath from tb_SpGoodsInfo 
                                where ModelNO = '" + tbmodelno.SelectedValue.ToString() + "' and FColor = '" + tbMaterial.SelectedValue.ToString() + "'";
                    ds = dbl.GetDatasetReport(sql, "tb_SpGoodsInfo");
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                tbgoodid.Text = ds.Tables[0].Rows[0][0].ToString();
                                tbmodno.Text = ds.Tables[0].Rows[0][1].ToString();
                                pictureBox1.ImageLocation = ds.Tables[0].Rows[0][2].ToString();
                            }
                        }
                    }
                }
                else
                {
                    tbgoodid.Text = "";
                    tbmodno.Text = "";
                    pictureBox1.ImageLocation = "";
                }
            }
        }

        private void buttonX26_Click(object sender, EventArgs e)
        {
            FreshSp();
            UpdateBindings(context);
        }

        private void supergrid_DoubleClick(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = superTabItem1;
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX25_Click(object sender, EventArgs e)
        {
            //Dblink dbl = new Dblink();
            //dbl.ShowDgvInfo(supergrid, true);
            DataSet ds = (DataSet)supergrid.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(supergrid, "选瓷登记");
            }
            else
                MessageUtil.ShowWarning("请先输入条件进行搜索!");
        }
        private void tbmodelno_DropDown(object sender, EventArgs e)
        {
            string sql = "select ModelNo,ModelName from tb_ModelInfo a where fisstop = 0  and exists (select 1 from tb_SpGoodsInfo where GoodName = a.ModelName) ";

            sql += tbmodelno.Text.Trim() == "" ? "" : " and modelName like '%" + tbmodelno.Text.Trim().Substring(0,2) + "%'";
            sql += " order by ModelNo ";
            ds = dbl.GetDatasetReport(sql, "tb_ModelInfo");
            //tbmodelno.dr
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    tbmodelno.DataSource = ds.Tables[0];
                    tbmodelno.DisplayMember = "ModelName";
                    tbmodelno.ValueMember = "ModelNo";

                }
            }
        }

        private void tbMaterial_DropDown(object sender, EventArgs e)
        {
            //goods = goodsmethod.Find(tbmodelno.Text.Trim());
            if(tbmodelno.Text.Trim() != "")
            {
                string sql = "select a.FColor,b.ColorName from tb_SpGoodsInfo a " +
                             " left join tb_ColorInfo b on a.FColor = b.ColorNo " +
                             "where a.GoodName = '" + tbmodelno.Text.Trim() + "'";
                ds = dbl.GetDatasetReport(sql, "good");
                List<string> listArr = new List<string>();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            tbMaterial.DataSource = ds.Tables[0];
                            tbMaterial.DisplayMember = "ColorName";
                            tbMaterial.ValueMember = "FColor";
                        }

                    }
                }
            }
        }

        private void cmbcolor_DropDown(object sender, EventArgs e)
        {
            //goods = goodsmethod.Find(tbmodelno.Text.Trim());
            if (cbgoods.Text.Trim() != "")
            {
                string sql = "select a.FColor,b.ColorName from tb_SpGoodsInfo a " +
                             " left join tb_ColorInfo b on a.FColor = b.ColorNo " +
                             "where a.GoodName = '" + cbgoods.Text.Trim() + "'";
                ds = dbl.GetDatasetReport(sql, "good");
                List<string> listArr = new List<string>();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmbcolor.DataSource = ds.Tables[0];
                            cmbcolor.DisplayMember = "ColorName";
                            cmbcolor.ValueMember = "FColor";
                        }

                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (checkedIDs.Count != 0)
            {
                string ids = "";
                foreach (string item in checkedIDs)
                {
                    if (ids == "")
                        ids = "'"+item+"'";
                    else
                        ids += ",'" + item + "'";
                }
                if (spMethod.SelPorcelainDeleteIDs(ids) != 0)
                {
                    MessageUtil.ShowTips("批量删除成功!");
                    ccLogHelper.Error(username + "删除选瓷单据【" + ids + "】");
                    FreshSp();
                }
            }
                    ;
        }

        private void supergrid_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            //选择
            GridRow      gr = (GridRow)e.Item;
            string id = gr["PlSerialNum"].Value.ToString();
            if (gr.Checked)
            {
                if (!checkedIDs.Contains(id))
                    checkedIDs.Add(id);
            }
            else
            {
                if (checkedIDs.Contains(id))
                    checkedIDs.Remove(id);
            }
        }



    }
}
