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
    public partial class frmColor : Office2007Form
    {
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        tb_ColorInfo good = new tb_ColorInfo();
        tb_ColorInfoMethod goodmethod = new tb_ColorInfoMethod();
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        string pathName;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["picPath"].Value;
        string editColorID;
        string usercode = frmLogin.userCode;
        string username = frmLogin.userName;
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
        public frmColor()
        {
            InitializeComponent();
        }
        private void frmColor_Load(object sender, EventArgs e)
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
            toolbar1.controlsValue = new Dictionary<string, object>();
            this.Resize += new EventHandler(frmColor_Resize);
            asc.Load(this);
            InitializeGrid();
            tb_BaseMgr.SetCombox("TypeStep", cmbtypestep);

            FreshModels();
            UpdateBindings(context);
            SetControlsReadOnly(true);

        }
        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column3 = panel.Columns["FColorSteps"];
            column3.EditorType = typeof(TypeStepComboxControl);
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
                                //for (int i = 0; i < importtable.Rows.Count; i++)
                                //{
                                good.strColorNo = myDs.Tables[0].Rows[i][0].ToString();
                                good.strColorName = myDs.Tables[0].Rows[i][1].ToString();
                                good.strFColorSteps = myDs.Tables[0].Rows[i][2].ToString();
                                //good.strGoodMaterial = importtable.Rows[i][4].ToString();
                                good.strFImagePath = path + good.strColorNo + ".jpg";
                                good.strFCreater = frmLogin.userName;
                                good.strFModifier = frmLogin.userName;
                                good.dFCreateDate = System.DateTime.Now;
                                good.dFModifydate = System.DateTime.Now;
                                goodmethod.tb_ColorInfoAdd(good);
                            }
                            FreshModels();
                        }
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
            string sql = @"SELECT ColorNo 
                                  , ColorName 
                                  , FColorSteps 
                                  , FIsStop 
                              FROM  tb_ColorInfo   order by FCreateDate desc,ColorNo asc";
            ds = dbl.GetDataset(sql, "tb_ColorInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_ColorInfo";
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
                tbColorName.DataBindings.Add(new Binding("Text", context, "ColorName"));
                tbColorNo.DataBindings.Add(new Binding("Text", context, "ColorNo"));
                cmbtypestep.DataBindings.Add(new Binding("SelectedValue", context, "FColorSteps"));

                //ckbIsstop.DataBindings.Add(new Binding("CheckedValue", context, "FTypeSteps3"));
                ckbIsStop.DataBindings.Add(new Binding("Checked", context, "FIsStop"));
   

            }
            else
            {
                ClearControls();

            }
        }

        private void ClearControls()
        {
            tbColorName.Text = "";
            tbColorNo.Text = "";
            cmbtypestep.Text = "";
            ckbIsStop.Checked = false;
        }

        private void ClearBindings()
        {
            tbColorName.DataBindings.Clear();
            tbColorNo.DataBindings.Clear();
            cmbtypestep.DataBindings.Clear();
            ckbIsStop.DataBindings.Clear();
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
                //UpdateBindings(context);
                GridRow  selectRow = superGridControl1.PrimaryGrid.ActiveRow as GridRow;

                good = goodmethod.Find(selectRow["ColorNo"].Value.ToString());
                if (good != null)
                {
                    tbColorNo.Text = good.strColorNo;
                    tbColorName.Text = good.strColorName;
                    cmbtypestep.SelectedValue = string.IsNullOrEmpty(good.strFColorSteps) ? "" : good.strFColorSteps;
                    ckbIsStop.Checked = good.iFIsStop == 1;
                }
                SetControlsReadOnly(true);
            }
        }

        private void SetControlsValue(Control.ControlCollection controlCollection)
        {
            foreach (Control con in controlCollection)
            {
                if (!con.HasChildren)
                {
                    if (con is DevComponents.DotNetBar.Controls.TextBoxX && con.Visible == true)
                        con.Text = toolbar1.controlsValue[con.Name].ToString();
                    if (con is DevComponents.DotNetBar.Controls.ComboBoxEx && con.Visible == true)
                        (con as DevComponents.DotNetBar.Controls.ComboBoxEx).SelectedValue = toolbar1.controlsValue[con.Name] == null ? "" : toolbar1.controlsValue[con.Name];
                    if (con is DevComponents.DotNetBar.Controls.CheckBoxX && con.Visible == true)
                        (con as DevComponents.DotNetBar.Controls.CheckBoxX).Checked = (toolbar1.controlsValue[con.Name].ToString() == "1");
                    if (con is PictureBox && con.Visible == true)
                        (con as PictureBox).ImageLocation = toolbar1.controlsValue[con.Name].ToString();
                }
                else
                    SetControlsValue(con.Controls);
            }
        }

        private void btnEditClick(object sender, EventArgs e)
        {
            if (good != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            editColorID = tbColorNo.Text.Trim();
            tbColorNo.Focus();
            //toolbar1.controlsValue.Clear();
            //GetControlsValue(this.Controls);
        }

        private void GetControlsValue(Control.ControlCollection ctc)
        {
            foreach (Control control in ctc)
            {
                if (!control.HasChildren)
                {
                    if (control is DevComponents.DotNetBar.Controls.TextBoxX && control.Visible == true)
                        toolbar1.controlsValue.Add(control.Name, (control as DevComponents.DotNetBar.Controls.TextBoxX).Text);
                    if (control is DevComponents.DotNetBar.Controls.ComboBoxEx && control.Visible == true)
                    {
                        DevComponents.DotNetBar.Controls.ComboBoxEx con = control as DevComponents.DotNetBar.Controls.ComboBoxEx;
                        toolbar1.controlsValue.Add(control.Name,con.Text != "" ? con.SelectedValue : "");
                    }
                    if (control is DevComponents.DotNetBar.Controls.CheckBoxX && control.Visible == true)
                        toolbar1.controlsValue.Add(control.Name, (control as DevComponents.DotNetBar.Controls.CheckBoxX).Checked);
                    if (control is PictureBox && control.Visible == true)
                        toolbar1.controlsValue.Add(control.Name, (control as PictureBox).ImageLocation);
                }
                else
                    GetControlsValue(control.Controls);
            }
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                int index = superGridControl1.PrimaryGrid.ActiveRow.Index;
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        //int index = Math.Max(0, Bm.Position);
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;
                        string id = tbColorNo.Text.Trim();
                        if (!string.IsNullOrEmpty(id))
                            goodmethod.tb_ColorDelete(id);
                        LogHelper.WriteLog(username + " 删除花色【编号:" + id + " 名称:" + tbColorName.Text.Trim() +  "】");
                        FreshModels();
                        GridRow gr = (GridRow)superGridControl1.PrimaryGrid.GetRowFromIndex(0);
                        if (gr != null)
                            SetControlsValueFromGrid(gr);


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
            tbColorNo.Text = gr["ColorNo"].Value.ToString();
            tbColorName.Text = gr["ColorName"].Value.ToString();
            cmbtypestep.SelectedValue = gr["FColorSteps"].Value.ToString();
            ckbIsStop.Checked = Convert.ToInt16(gr["FIsStop"].Value) == 1;

        }

        private void btnNewClick(object sender, EventArgs e)
        {
            ClearControls();
            ClearBindings();
            SetControlsReadOnly(false);
            //djcdate.Value = System.DateTime.Today;
            tbColorNo.Focus();
            toolbar1.flag = 0;
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    if (toolbar1.flag == 0)//新增
                    {
                        good.strColorNo = tbColorNo.Text.Trim();
                        good.strColorName = tbColorName.Text.Trim();
                        good.strFColorSteps = cmbtypestep.Text == "" ? "" : cmbtypestep.SelectedValue.ToString();
                        good.iFIsStop = ckbIsStop.Checked ? 1 : 0;
                        good.strFCreater = frmLogin.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        good.strFModifier = frmLogin.userName;
                        good.dFModifydate = System.DateTime.Now;
                        //Ms.Close();
                        if (goodmethod.tb_ColorInfoAdd(good) == 1)
                            MessageUtil.ShowTips("保存成功！");
                        if (toolbar1.cbcontinue.Checked)
                        {
                            ClearControls();
                            ClearBindings();
                            tbColorNo.Focus();
                        }
                        //FreshGoods();
                    }
                    else
                    {
                        good.strColorNo = tbColorNo.Text.Trim();
                        good.strColorName = tbColorName.Text.Trim();
                        good.strFColorSteps = cmbtypestep.Text == "" ? "" : cmbtypestep.SelectedValue.ToString();
                        good.iFIsStop = ckbIsStop.Checked ? 1 : 0;
                        good.strFModifier = frmLogin.userName;
                        good.dFModifydate = System.DateTime.Now;
                        //System.IO.MemoryStream Ms = new MemoryStream();
                        // pictureBox1.Image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (string.IsNullOrEmpty(editColorID))
                        {
                            if (goodmethod.tb_ColorUpdate(good) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        }
                        else
                            if (goodmethod.tb_ColorUpdate(good, editColorID) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        SetControlsReadOnly(true);
                    }
                    FreshModels();
                }
            }
            catch (Exception)
            {
                MessageUtil.ShowWarning("保存失败!");
            }
        }



        private void SetControlsReadOnly(bool p)
        {
            //pictureBox1.Enabled = !p;
            tbColorNo.ReadOnly = p;
            tbColorName.ReadOnly = p;
            cmbtypestep.Enabled = !p;
            ckbIsStop.Enabled = !p;
        }

        private void frmColor_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }



    }
}
