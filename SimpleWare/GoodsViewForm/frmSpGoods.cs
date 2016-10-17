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
using SimpleWare.BaseClass;
using System.IO;
using DevComponents.DotNetBar.SuperGrid;
using System.Data.OleDb;
using System.Configuration;

namespace SimpleWare.GoodsViewForm
{
    public partial class frmSpGoods : Office2007Form
    {
        public frmSpGoods()
        {
            InitializeComponent();
        }
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        FormAutoSizeClass fasc = new FormAutoSizeClass();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        tb_SpGoodsInfo good = new tb_SpGoodsInfo();
        tb_SpGoodInfoMethod goodmethod = new tb_SpGoodInfoMethod();
        
        tb_SettingsMethod settingMethod = new tb_SettingsMethod();
        tb_settings setting = null;
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        string pathName;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["picPath"].Value;
        private BindingManagerBase _Bm;
        Boolean isEdit;
        string editGoodID;
        string usercode = frmLogin.userCode;
        string username = frmLogin.userName;
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathName = this.openFileDialog1.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(pathName);
                this.pictureBox1.Image = img;


            }
        }


        private void frmSpGoods_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;
            toolbar1.btnImport.Visible = true;
            toolbar1.btnImportClick += new Toolbar.BtnImportClick(btnImportClick);
            this.Resize += new EventHandler(frmSpGoods_Resize);
            asc.Load(this);
            //fasc.controllInitializeSize(this);
            BindModel();
            BindColor();
            //BidnMaterial();
            InitializeGrid();
            FreshGoods();
            tb_BaseMgr.SetCombox("material", cmbMaterial);
            tb_BaseMgr.SetCombox("TypeStep", tbftypestep1);
            tb_BaseMgr.SetCombox("TypeStep", tbftypestep2);
            tb_BaseMgr.SetCombox("TypeStep", tbftypestep3);
            tb_BaseMgr.SetCombox("TypeStep", tbfcolorsteps);
            SetControlsReadOnly(true);
            UpdateBindings(context);

        }
        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column1 = panel.Columns["FTypeSteps1"];
            column1.EditorType = typeof(TypeStepComboxControl);

            column1 = panel.Columns["FTypeSteps2"];
            column1.EditorType = typeof(TypeStepComboxControl);

            column1 = panel.Columns["FTypeSteps3"];
            column1.EditorType = typeof(TypeStepComboxControl);

            column1 = panel.Columns["FColorSteps"];
            column1.EditorType = typeof(TypeStepComboxControl);

            GridColumn column2 = panel.Columns["FColor"];
            column2.EditorType = typeof(ColorComboxControl);
            GridColumn column3 = panel.Columns["GoodMaterial"];
            column3.EditorType = typeof(MaterialComboxControl);

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
                    cmbColor.DataSource = ds.Tables[0];
                    cmbColor.DisplayMember = "ColorName";
                    cmbColor.ValueMember = "ColorNo";
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
                    cmbColor.AutoCompleteCustomSource.AddRange(myarr);
                    cmbColor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }

        }
        private void BindModel()
        {
            string sql = "select ModelNo,ModelName from tb_ModelInfo where fisstop = 0 ";
            ds = dbl.GetDatasetReport(sql, "tb_ModelInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    //tbgoodname.DataSource = ds.Tables[0];
                    //tbgoodname.DisplayMember = "ModelName";
                    //tbgoodname.ValueMember = "ModelNo";
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
                    tbgoodname.AutoCompleteCustomSource.AddRange(myarr);
                    tbgoodname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbgoodname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }

        }


        private void ClearBindings()
        {
            tbgoodid.DataBindings.Clear();
           // tbgoodsname.DataBindings.Clear();
            tbmono.DataBindings.Clear();
            tbgoodname.DataBindings.Clear();
            cmbColor.DataBindings.Clear();
            tbfcolorsteps.DataBindings.Clear();
            tbftypestep1.DataBindings.Clear();
            tbftypestep2.DataBindings.Clear();
            tbftypestep3.DataBindings.Clear();
            ckbifstop.DataBindings.Clear();
            cmbMaterial.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            tbmqty.DataBindings.Clear();

        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbgoodid.DataBindings.Add(new Binding("Text", context, "GoodId"));
                //tbgoodsname.DataBindings.Add(new Binding("Text", context, "GoodName"));
                tbmono.DataBindings.Add(new Binding("Text", context, "ModelNO"));
                tbgoodname.DataBindings.Add(new Binding("Text", context, "GoodName"));
                //cmbColor.DataBindings.Add(new Binding("Text", context, "FColor"));
                cmbColor.DataBindings.Add(new Binding("SelectedValue", context, "FColor"));
                tbftypestep1.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps1"));
                tbftypestep2.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps2"));
                tbftypestep3.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps3"));
                tbfcolorsteps.DataBindings.Add(new Binding("SelectedValue", context, "FColorSteps"));
                ckbifstop.DataBindings.Add(new Binding("Checked", context, "FIsStop"));
                cmbMaterial.DataBindings.Add(new Binding("SelectedValue", context, "GoodMaterial"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation", context, "FImagePath"));
                tbmqty.DataBindings.Add(new Binding("Text", context, "FMaterialQty"));

            }
            else
            {
                tbgoodid.Text = "";
                //tbgoodsname.Text = "";
                tbmono.Text = "";
                tbgoodname.Text = "";
                tbftypestep1.Text = "";
                tbftypestep2.Text = "";
                tbftypestep3.Text = "";
                tbfcolorsteps.Text = "";
                cmbColor.Text = "";
                ckbifstop.Checked = false;
                cmbMaterial.Text = "";
                tbmqty.Text = "";
                pictureBox1.Image = null;
            }

        }
        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            //djcdate.Value = System.DateTime.Today;
            tbgoodid.Focus();
            toolbar1.flag = 0;
            isEdit = true;
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
                isEdit = false;
            }
            else
            {
                //BindControls();
                //FreshJch();
                GridRow selectRow = superGridControl1.PrimaryGrid.ActiveRow as GridRow ;
                good = goodmethod.FindByID(selectRow["GoodId"].Value.ToString());
                //good = goodmethod.Find(superGridControl1.PrimaryGrid.ActiveRow.GetCell(superGridControl1.PrimaryGrid.ActiveRow.RowIndex,2).ToString());
                if (good != null)
                {
                    tbgoodid.Text = good.strGoodsId;
                    tbgoodname.Text = good.strGoodsName;
                    cmbColor.SelectedValue = good.strFColor == null ? "" : good.strFColor;
                    tbftypestep1.SelectedValue = good.strFTypeSteps1 == null ? "" : good.strFTypeSteps1;
                    tbftypestep2.SelectedValue = good.strFTypeSteps2 == null ? "" : good.strFTypeSteps2;
                    tbftypestep3.SelectedValue = good.strFTypeSteps3 == null ? "" : good.strFTypeSteps3;

                    tbfcolorsteps.SelectedValue = good.strFColorSteps == null ? "" : good.strFColorSteps;
                    tbmono.Text = good.strModelNO;
                    cmbMaterial.SelectedValue = good.strGoodMaterial == null ? "" : good.strGoodMaterial;
                    pictureBox1.ImageLocation = good.strFImagePath;
                    ckbifstop.Checked = good.iFIsStop == 1;
                    tbmqty.Text = good.strFMaterialQty;
                }
                //UpdateBindings(context);

                SetControlsReadOnly(true);
                isEdit = false;
            }
        }

        private void FreshGoods()
        {

            string sql = "select  GoodId,GoodName,ModelNO,GoodMaterial,FImagePath,FColor,FTypeSteps1,FTypeSteps2,FTypeSteps3,FColorSteps,FIsStop,FMaterialQty from tb_SpGoodsInfo where FIsStop = 0 order by FCreateDate desc,GoodName asc";
            ds = dbl.GetDataset(sql, "tb_SpGoodsInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_SpGoodsInfo";
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
        private void ClearControls()
        {
            pictureBox1.Image = null;
            tbgoodid.Text = "";
            //tbgoodsname.Text = "";
            tbmono.Text = "";
            tbgoodname.Text = "";
            tbftypestep1.Text = "";
            tbftypestep2.Text = "";
            tbftypestep3.Text = "";
            tbfcolorsteps.Text = "";
            ckbifstop.CheckValue = false;
            cmbColor.Text = "";
            cmbMaterial.Text = "";
            tbmqty.Text = "";
        }
        private void SetControlsReadOnly(Boolean isEnabled)
        {
            pictureBox1.Enabled = !isEnabled;
            tbgoodid.ReadOnly = isEnabled;
            //tbgoodsname.ReadOnly = isEnabled;
            tbmono.ReadOnly = isEnabled;
            tbgoodname.Enabled = !isEnabled;
            cmbColor.Enabled = !isEnabled;
            tbftypestep1.Enabled = !isEnabled;
            tbftypestep2.Enabled = !isEnabled;
            tbftypestep3.Enabled = !isEnabled;
            tbfcolorsteps.Enabled = !isEnabled;
            ckbifstop.Enabled = !isEnabled;
            cmbMaterial.Enabled = !isEnabled;
            tbmqty.ReadOnly = isEnabled;
        }
        private void frmGoods_Resize(object sender, EventArgs e)
        {
            //asc.Resize(this);
        }


        private void btnEditClick(object sender, EventArgs e)
        {
            if (good != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            editGoodID = tbgoodid.Text.Trim();
            tbgoodid.Focus();
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {

            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        //int index = superGridControl1.PrimaryGrid.ActiveRow.Index;
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;
                        string id = tbgoodid.Text.Trim();
                        if (!string.IsNullOrEmpty(id))
                            goodmethod.tb_SpgoodDelete(id);
                        FreshGoods();
                        GridRow gr = (GridRow)superGridControl1.PrimaryGrid.GetRowFromIndex(0);
                        SetControlsValueFromGrid(gr);
                        ccLogHelper.Warning(username + " 删除选瓷产品【产品编号:" + id + "器型名称:" + tbgoodname.Text.Trim() + " 花色:" + cmbColor.Text.Trim()  + "】");

                        if (Bm.Count == 0)
                        {
                            toolbar1.btndelete.Enabled = false;
                            toolbar1.btnedit.Enabled = false;
                        }
                    }
                }
            }

        }

        private void SetControlsValueFromGrid(GridRow gr)
        {
            if (gr != null)
            {
                tbgoodid.Text = gr["GoodId"].Value.ToString();
                tbgoodname.SelectedValue = gr["ModelNO"].Value.ToString();
                tbmono.Text = gr["ModelNO"].Value.ToString();
                cmbColor.SelectedValue = gr["FColor"].Value.ToString();
                tbftypestep1.SelectedValue = gr["FTypeSteps1"].Value.ToString();
                tbftypestep2.SelectedValue = gr["FTypeSteps2"].Value.ToString();
                tbftypestep3.SelectedValue = gr["FTypeSteps3"].Value.ToString();
                tbfcolorsteps.SelectedValue = gr["FColorSteps"].Value.ToString();
                cmbMaterial.SelectedValue = gr["GoodMaterial"].Value.ToString();
                ckbifstop.Checked = Convert.ToInt16(gr["FIsStop"].Value) == 1;
                pictureBox1.ImageLocation = gr["FImagePath"].Value.ToString();
                tbmqty.Text = gr["FMaterialQty"].Value.ToString();
            }
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidate())
                {
                    setting = settingMethod.Find();
                    if (toolbar1.flag == 0)//新增
                    {
                        good.strGoodsId = tbgoodid.Text.Trim();
                        good.strGoodsName = tbgoodname.Text.Trim();
                        //good.strItemNO =
                        good.strModelNO = tbmono.Text.Trim();
                        good.strFColor = cmbColor.SelectedValue.ToString();
                        good.strFTypeSteps1 = tbftypestep1.Text != "" ? tbftypestep1.SelectedValue.ToString() : "";
                        good.strFTypeSteps2 = tbftypestep2.Text != "" ? tbftypestep2.SelectedValue.ToString() : "";
                        good.strFTypeSteps3 = tbftypestep3.Text != "" ? tbftypestep3.SelectedValue.ToString() : "";
                        good.strFColorSteps = tbfcolorsteps.Text != "" ? tbfcolorsteps.SelectedValue.ToString() : "";
                        good.iFIsStop = ckbifstop.Checked ? 1 : 0;
                        good.strGoodMaterial = cmbMaterial.Text != "" ? cmbMaterial.SelectedValue.ToString() : "" ;
                        good.strFMaterialQty = tbmqty.Text.Trim();
                        good.strFCreater = frmLogin1.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        System.IO.MemoryStream Ms = new MemoryStream();

                        if (setting.PicSaveStyle == 0)
                        {
                            if (pathName != "")
                                good.strFImagePath = UploadImage();
                        }
                        else
                        {
                            good.strFImagePath = setting.PicPath + good.strGoodsId +  ".jpg";
                        }
                        //Ms.Close();
                        if (goodmethod.tb_SpGoodsInfoAdd(good) == 1)
                            MessageUtil.ShowTips("保存成功！");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                            tbgoodid.Focus();
                        }
                        //FreshGoods();
                    }
                    else
                    {
                        good.strGoodsId = tbgoodid.Text.Trim();
                        good.strGoodsName = tbgoodname.Text.Trim();
                        //good.strItemNO =
                        good.strModelNO = tbmono.Text.Trim();
                        good.strFColor = cmbColor.SelectedValue.ToString();
                        good.strFTypeSteps1 = tbftypestep1.Text != "" ? tbftypestep1.SelectedValue.ToString() : "";
                        good.strFTypeSteps2 = tbftypestep2.Text != "" ? tbftypestep2.SelectedValue.ToString() : "";
                        good.strFTypeSteps3 = tbftypestep3.Text != "" ? tbftypestep3.SelectedValue.ToString() : "";
                        good.strFColorSteps = tbfcolorsteps.Text != "" ? tbfcolorsteps.SelectedValue.ToString() : "";
                        good.iFIsStop = ckbifstop.Checked ? 1 : 0;
                        good.strGoodMaterial = cmbMaterial.Text != "" ? cmbMaterial.SelectedValue.ToString() : "";
                        good.strFCreater = frmLogin1.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        good.strFMaterialQty = tbmqty.Text.Trim();
                        if (setting.PicSaveStyle == 0)
                        {
                            if (pathName != "")
                                good.strFImagePath = UploadImage();
                        }
                        else
                        {
                            good.strFImagePath = setting.PicPath + good.strGoodsId + ".jpg";
                        }
                        if (!string.IsNullOrEmpty(editGoodID))
                        {
                            if (goodmethod.tb_SpgoodUpdate(good, editGoodID) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        }
                        else
                            if (goodmethod.tb_SpgoodUpdate(good) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        SetControlsReadOnly(true);
                    }
                    FreshGoods();
                }
            }
            catch (Exception)
            {
                MessageUtil.ShowWarning("保存失败!");
            }

        }

        private bool CheckValidate()
        {
            if (tbgoodid.Text.Trim() == "")
            {
                MessageUtil.ShowError("请输入编号！");
                return false;
            }
            if (tbgoodname.Text.Trim() == "")
            {
                MessageUtil.ShowError("请选择器型！");
                return false;
            }
            if (cmbColor.Text.Trim() == "")
            {
                MessageUtil.ShowError("请选择花色！");
                return false;
            }
            return true;
        }

        private string UploadImage()
        {
            try
            {

                string newFileName = tbgoodid.Text.Trim();
                //string path = "D:\\SimpleWare\\";

                //string fileNameExt = pathName.Substring(pathName.LastIndexOf("\\") + 1);
                string filenameExt = Path.GetExtension(pathName);
                string pathSaveImg = path + newFileName + filenameExt;
                File.Copy(pathName, pathSaveImg);
                return pathSaveImg;
            }
            catch (Exception e)
            {
                //throw e;
                //MessageBox.Show(e.Message);
                //MessageUtil.ShowWarning("上传图片失败!");
                return "";
                //throw e.ToString();
                //Response.Write(e.ToString()); 
            }

            //this.FileUpload1.SaveAs(path);

            //        [数据库字段]= "[服务器端存储图片的路径]" + newFileName;
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, "找不到此图片"); return;
            //    }
            // }
        }
        private void btnImportClick(object sender, EventArgs e)
        {
            string file = FileDialogHelper.OpenExcel();
            if (!string.IsNullOrEmpty(file))
            {

                try
                {
                    //DataTable importtable = NpoiExcelHelper.Import(file);
                    //if (importtable != null)
                    //{
                    //    for (int i = 0; i < importtable.Rows.Count; i++)
                    //    {
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
                                good.strGoodsId = myDs.Tables[0].Rows[i][0].ToString();
                                good.strModelNO = myDs.Tables[0].Rows[i][1].ToString();
                                good.strFColor = myDs.Tables[0].Rows[i][2].ToString();
                                //good.strModelName = myDs.Tables[0].Rows[i][3].ToString();
                                //good.strf
                                good.strGoodMaterial = myDs.Tables[0].Rows[i][3].ToString();
                                good.strFTypeSteps1 = myDs.Tables[0].Rows[i][4].ToString();
                                good.strFTypeSteps2 = myDs.Tables[0].Rows[i][5].ToString();
                                good.strFTypeSteps3 = myDs.Tables[0].Rows[i][6].ToString();
                                good.strFColorSteps = myDs.Tables[0].Rows[i][7].ToString();
                                good.strFImagePath = path + good.strGoodsId + ".jpg";
                                good.strFCreater = frmLogin.userName;
                                good.dFCreateDate = System.DateTime.Now;
                               // good.strFMaterialQty = 
                                goodmethod.tb_SpGoodsInfoAdd(good);
                            }
                        }
                    }
                    FreshGoods();
                    //this.gridControl1.DataSource = myDs.Tables[0];
                    //this.gridView1.PopulateColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmSpGoods_Resize(object sender, EventArgs e)
        {
            //fasc.controlAutoSize(this);
            asc.Resize(this);
        }

        private void tbmodelno_Leave(object sender, EventArgs e)
        {
            tb_ModelInfo model = new tb_ModelInfo();
            tb_ModelInfoMethod modeMethod = new tb_ModelInfoMethod();
            if (tbgoodname.Enabled)
            {
                if (tbgoodname.Text != "")
                {
                    model = modeMethod.Find(tbgoodname.Text);
                    tbmono.Text = model.strModelNo;
                    tbftypestep1.SelectedValue = model.strFTypeSteps1 == null ? "" : model.strFTypeSteps1;
                    tbftypestep2.SelectedValue = model.strFTypeSteps2 == null ? "" : model.strFTypeSteps2;
                    tbftypestep3.SelectedValue = model.strFTypeSteps3 == null ? "" : model.strFTypeSteps3;
                    //tbfcolorsteps.SelectedValue = model.str
                    pictureBox1.ImageLocation = model.strFImagePath;
                    tbmqty.Text = model.strFMaterialQty;
                }
                else
                {
                    //tbModelNo1.Text = "";
                    tbftypestep1.Text = "";
                    tbftypestep2.Text = "";
                    tbftypestep3.Text = "";
                    pictureBox1.ImageLocation = "";
                    tbmqty.Text = "";
                }
            }
        }

        private void cmbColor_Leave(object sender, EventArgs e)
        {
            tb_ColorInfo color = new tb_ColorInfo();
            tb_ColorInfoMethod colorM = new tb_ColorInfoMethod();
            if (cmbColor.SelectedValue != null)
            {
                color = colorM.Find(cmbColor.SelectedValue.ToString());
                tbfcolorsteps.SelectedValue = color.strFColorSteps == null ? "" : color.strFColorSteps;
            }
            else
            {
                tbfcolorsteps.Text = "";
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathName = this.openFileDialog1.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(pathName);
                this.pictureBox1.Image = img;

            }
        }

        private void tbgoodid_Leave(object sender, EventArgs e)
        {
            if (isEdit == true && tbgoodid.Text.Trim() != "" )
            {
                string[] IDS = tbgoodid.Text.Trim().Split('.');
                if (IDS.Length > 0)
                {
                    tb_ColorInfoMethod colorMethod = new tb_ColorInfoMethod();
                    tb_ColorInfo color = colorMethod.Find(IDS[0]);
                    if (!string.IsNullOrEmpty(color.strColorNo))
                    {
                        cmbColor.SelectedValue = color.strColorNo;
                        cmbColor.Text = color.strColorName;
                        if (IDS.Length > 1)
                        {
                            tb_ModelInfoMethod modelmethod = new tb_ModelInfoMethod();
                            tb_ModelInfo model = modelmethod.FindByID(IDS[1]);
                            if (!string.IsNullOrEmpty(model.strModelNo))
                            {
                                tbgoodname.SelectedValue = model.strModelNo;
                                tbgoodname.Text = model.strModelName;
                                tbmono.Text = model.strModelNo;
                                tbftypestep1.SelectedValue = model.strFTypeSteps1 == null ? "" : model.strFTypeSteps1;
                                tbftypestep2.SelectedValue = model.strFTypeSteps2 == null ? "" : model.strFTypeSteps2;
                                tbftypestep3.SelectedValue = model.strFTypeSteps3 == null ? "" : model.strFTypeSteps3;
                                tbmqty.Text = model.strFMaterialQty;
                            }
                        }
                    }
                }
            }
        }



    }
}
