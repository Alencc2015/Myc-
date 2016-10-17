using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
using SimpleWare.BaseClass;
using SimpleWare.ClassInfo;
using SimpleWare.DbMethod;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using DevComponents.DotNetBar.SuperGrid;

namespace SimpleWare.SelPorcelain
{
    public partial class frmModel : Office2007Form
    {
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        tb_ModelInfo good = new tb_ModelInfo();
        tb_ModelInfoMethod goodmethod = new tb_ModelInfoMethod();
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        string pathName;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["picPath"].Value;
        string lastModelNo;
        private BindingManagerBase _Bm;
        Boolean isEdit;
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
        public frmModel()
        {
            InitializeComponent();
        }

        private void frmModel_Load(object sender, EventArgs e)
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
            this.Resize += new EventHandler(frmModel_Resize);
            asc.Load(this);
            InitializeGrid();
            tb_BaseMgr.SetCombox("TypeStep", cbtypestep1);
            tb_BaseMgr.SetCombox("TypeStep", cbtypestep2);
            tb_BaseMgr.SetCombox("TypeStep", cbtypestep3);
            
            FreshModels();
            UpdateBindings(context);
            SetControlsReadOnly(true);
        }
        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column1 = panel.Columns["FTypeSteps1"];
            column1.EditorType = typeof(TypeStepComboxControl);
            GridColumn column2 = panel.Columns["FTypeSteps2"];
            column2.EditorType = typeof(TypeStepComboxControl);
            GridColumn column3 = panel.Columns["FTypeSteps3"];
            column3.EditorType = typeof(TypeStepComboxControl);
        }
        private void btnImportClick(object sender, EventArgs e)
        {

            string file = FileDialogHelper.OpenExcel();
            if (!string.IsNullOrEmpty(file))
            {

                try
                {
                    //if(file.Contains(".Xl"))
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
                                good.strModelNo = myDs.Tables[0].Rows[i][0].ToString();
                                good.strModelName = myDs.Tables[0].Rows[i][1].ToString();
                                good.strFTypeSteps1 = myDs.Tables[0].Rows[i][2].ToString();
                                good.strFTypeSteps2 = myDs.Tables[0].Rows[i][3].ToString();
                                good.strFTypeSteps3 = myDs.Tables[0].Rows[i][4].ToString();
                                //good.strGoodMaterial = importtable.Rows[i][4].ToString();
                                good.strFImagePath = path + good.strModelName + ".jpg";
                                good.strFCreater = frmLogin.userName;
                                good.dFCreateDate = System.DateTime.Now;
                                good.strFModifier = frmLogin.userName;
                                good.dFModifydate = System.DateTime.Now;
                                goodmethod.tb_ModelInfoAdd(good);
                            }
                        }
                        FreshModels();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void FreshModels()
        {
            string sql = @"SELECT  ModelNo 
                                  ,ModelName 
                                  ,FImagePath 
                                  ,FTypeSteps1 
                                  ,FTypeSteps2 
                                  ,FTypeSteps3 
                                  ,FIsStop 
                                  ,FMaterialQty
                             FROM tb_ModelInfo ORDER BY ModelName asc";
            ds = dbl.GetDataset(sql, "tb_ModelInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_ModelInfo";
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
                tbModelName.DataBindings.Add(new Binding("Text", context, "ModelName"));
                tbModelNo.DataBindings.Add(new Binding("Text", context, "ModelNo"));
                cbtypestep1.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps1"));
                cbtypestep2.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps2"));
                cbtypestep3.DataBindings.Add(new Binding("SelectedValue", context, "FTypeSteps3"));
                //ckbIsstop.DataBindings.Add(new Binding("CheckedValue", context, "FTypeSteps3"));
                ckbIsstop.DataBindings.Add(new Binding("Checked", context, "FIsStop"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation", context, "FImagePath"));
                tbmqty.DataBindings.Add(new Binding("Text", context, "FMaterialQty"));


            }
            else
            {
                ClearControls();

                pictureBox1.Image = null;
            }
        }

        private void ClearControls()
        {
            tbModelName.Text = "" ;
            tbModelNo.Text = "" ;
            cbtypestep1.Text = "" ;
            cbtypestep2.Text = "" ;
            cbtypestep3.Text = "" ;
            tbmqty.Text = "";
            ckbIsstop.Checked = false;
        }

        private void ClearBindings()
        {
            tbModelName.DataBindings.Clear();
            tbModelNo.DataBindings.Clear();
            cbtypestep1.DataBindings.Clear();
            cbtypestep2.DataBindings.Clear();
            cbtypestep3.DataBindings.Clear();
            ckbIsstop.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            tbmqty.DataBindings.Clear();
        }

        private void btnCancleClick(object sender, EventArgs e)
        {
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
                GridRow selectRow = superGridControl1.PrimaryGrid.ActiveRow as GridRow;
                good = goodmethod.Find(selectRow["ModelName"].Value.ToString());
                if (good != null)
                {
                    tbModelNo.Text = good.strModelNo;
                    tbModelName.Text = good.strModelName;
                    cbtypestep1.SelectedValue = good.strFTypeSteps1 == null ? "" : good.strFTypeSteps1;
                    cbtypestep2.SelectedValue = good.strFTypeSteps2 == null ? "" : good.strFTypeSteps2;
                    cbtypestep3.SelectedValue = good.strFTypeSteps3 == null ? "" : good.strFTypeSteps3;
                    pictureBox1.ImageLocation = good.strFImagePath;
                    ckbIsstop.Checked = good.iFIsStop == 1;
                    tbmqty.Text = good.strFMaterialQty;
                }
                //UpdateBindings(context);
                SetControlsReadOnly(true);
                isEdit = false;
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (good != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            lastModelNo = tbModelNo.Text.Trim();
            tbModelNo.Focus();
            isEdit = true;
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        int index = Bm.Position;
                        string id = tbModelNo.Text.Trim();
                        if(!string.IsNullOrEmpty(id))
                            goodmethod.tb_ModelDelete(id);
                        ccLogHelper.Warning(username + " 删除器型【编号:" + id + " 名称:" + tbModelName.Text.Trim() + "】");
                        FreshModels();
                        GridRow gr = (GridRow)superGridControl1.PrimaryGrid.GetRowFromIndex(0);
                        SetControlsValueFromGrid(gr);
                        //UpdateBindings(context);
                        //ClearControls();
                        //if (ds != null)
                        //{
                        //    DataTable table = ds.Tables[0];
                        //    goodmethod.tb_ModelDelete(id);
                        //    table.Rows.RemoveAt(index);

                        //    ds.AcceptChanges();

                        //    superGridControl1.PrimaryGrid.PurgeDeletedRows(true);
                        //}

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
            tbModelNo.Text = gr["ModelNo"].Value.ToString();
            tbModelName.Text = gr["ModelName"].Value.ToString();
            ckbIsstop.Checked = Convert.ToInt16(gr["FIsStop"].Value) == 1;
            cbtypestep1.SelectedValue = gr["FTypeSteps1"].Value.ToString();
            cbtypestep2.SelectedValue = gr["FTypeSteps2"].Value.ToString();
            cbtypestep3.SelectedValue = gr["FTypeSteps3"].Value.ToString();
            tbmqty.Text = gr["FMaterialQty"].Value.ToString();
        }

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            //djcdate.Value = System.DateTime.Today;
            tbModelNo.Focus();
            toolbar1.flag = 0;
            isEdit = true;
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (checkSave())
                {
                    if (toolbar1.flag == 0)//新增
                    {
                        good.strModelNo = tbModelNo.Text.Trim();
                        good.strModelName = tbModelName.Text.Trim();
                        good.strFTypeSteps1 = cbtypestep1.Text == "" ?"": cbtypestep1.SelectedValue.ToString();
                        good.strFTypeSteps2 = cbtypestep2.Text == "" ? "" : cbtypestep2.SelectedValue.ToString();
                        good.strFTypeSteps3 = cbtypestep3.Text == "" ? "" : cbtypestep3.SelectedValue.ToString();
                        good.iFIsStop = ckbIsstop.Checked ? 1 : 0;
                        good.strFMaterialQty = tbmqty.Text.Trim();
                        good.strFCreater = frmLogin1.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        good.strFModifier = frmLogin1.userName;
                        good.dFModifydate = System.DateTime.Now;
                           if (pathName != "")
                            good.strFImagePath = UploadImage();
                        //Ms.Close();
                        if (goodmethod.tb_ModelInfoAdd(good) == 1)
                            MessageUtil.ShowTips("保存成功！");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                            tbModelNo.Focus();
                            isEdit = true;
                        }
                        //FreshGoods();
                    }
                    else
                    {
                        good.strModelNo = tbModelNo.Text.Trim();
                        good.strModelName = tbModelName.Text.Trim();
                        good.strFTypeSteps1 = cbtypestep1.Text == "" ? "" : cbtypestep1.SelectedValue.ToString();
                        good.strFTypeSteps2 = cbtypestep2.Text == "" ? "" : cbtypestep2.SelectedValue.ToString();
                        good.strFTypeSteps3 = cbtypestep3.Text == "" ? "" : cbtypestep3.SelectedValue.ToString();
                        good.iFIsStop = ckbIsstop.Checked ? 1 : 0;
                        good.strFMaterialQty = tbmqty.Text.Trim();
                        good.strFModifier = frmLogin1.userName;
                        good.dFModifydate = System.DateTime.Now;
                        //System.IO.MemoryStream Ms = new MemoryStream();
                        // pictureBox1.Image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (pathName != "")
                            good.strFImagePath = UploadImage();
                        if (string.IsNullOrEmpty(lastModelNo))
                        {
                            if (goodmethod.tb_ModelUpdate(good) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        }
                        else
                            if (goodmethod.tb_ModelUpdate(good, lastModelNo) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        SetControlsReadOnly(true);
                        isEdit = false;
                    }
                    FreshModels();
                    
                }
            }
            catch (Exception)
            {
                MessageUtil.ShowWarning("保存失败!");
            }
        }

        private bool checkSave()
        {
            if (tbModelNo.Text.Trim() == "")
            {
                MessageUtil.ShowError("请输入编号!");
                return false;

            }
            if (tbModelName.Text.Trim() == "")
            {
                MessageUtil.ShowError("请输入名称!");
                return false;
            }
            if (tbmqty.Text.Trim() == "")
            {
                MessageUtil.ShowError("请输入瓷重!");
                return false;
            }
            return true;
        }

        private string UploadImage()
        {
            try
            {

                string newFileName = tbModelNo.Text.Trim();
                //string path = "D:\\SimpleWare\\";

                //string fileNameExt = pathName.Substring(pathName.LastIndexOf("\\") + 1);
                string filenameExt = Path.GetExtension(pathName);
                string pathSaveImg = path + newFileName + filenameExt;
                File.Copy(pathName, pathSaveImg);
                return pathSaveImg;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        private void SetControlsReadOnly(bool p)
        {
            pictureBox1.Enabled = !p;
            tbModelNo.ReadOnly = p;
            tbModelName.ReadOnly = p;
            cbtypestep1.Enabled = !p;
            cbtypestep2.Enabled = !p;
            cbtypestep3.Enabled = !p;
            ckbIsstop.Enabled = !p;
            tbmqty.ReadOnly = p;
        }

        private void frmModel_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
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


    }
}
