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

namespace SimpleWare
{
    public partial class frmGoods : Office2007Form
    {

        public frmGoods()
        {
            InitializeComponent();
        }
        Dblink dbl = new Dblink();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        OpenFileDialog  openFileDialog1 = new OpenFileDialog();
        tb_GoodsInfo good = new tb_GoodsInfo();
        tb_GoodsInfoMethods goodmethod = new tb_GoodsInfoMethods();
        frmLogin frmlogin = new frmLogin();
        Object dataSource = null;
        DataSet ds = new DataSet();
        DataSet myDs = new DataSet();
        object context = null;
        int flag = 0;//读写标志
        string pathName;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["picPath"].Value;
        string editGoodId;
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathName = this.openFileDialog1.FileName;
                System.Drawing.Image img = System.Drawing.Image.FromFile(pathName);
                this.pictureBox1.Image = img;


            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmGoods_Load(object sender, EventArgs e)
        {
            toolbar1.btnSaveClick += new Toolbar.BtnSaveClick(btnSaveClick);
            toolbar1.btnNewClick += new Toolbar.BtnNewClick(btnNewClick);
            toolbar1.btnDeleteClick += new Toolbar.BtnDeleteClick(btnDeleteClick);
            toolbar1.btnEditClick += new Toolbar.BtnEditClick(btnEditClick);
            toolbar1.btnCancelClick += new Toolbar.BtnCancelClick(btnCancleClick);
            toolbar1.btnImport.Visible = true;
            toolbar1.btnImportClick += new Toolbar.BtnImportClick(btnImportClick);
            toolbar1.btnEditEnabled = false;
            toolbar1.btndelete.Enabled = false;
            this.Resize += new EventHandler(frmGoods_Resize);
            asc.Load(this);

            UpdateBindings(context);  
            FreshGoods();
            SetControlsReadOnly(true);

            //ds.
            //FreshGoods();
        }



        private void ClearBindings()
        {
            tbgoodid.DataBindings.Clear();
            tbgoodsname.DataBindings.Clear();
            tbitemno.DataBindings.Clear();
            tbmodelno.DataBindings.Clear();
            //cbmaterial.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();

        }
        private void UpdateBindings(object context)
        {
            ClearBindings();
            if (context != null)
            {
                tbgoodid.DataBindings.Add(new Binding("Text", context, "GoodId"));
                tbgoodsname.DataBindings.Add(new Binding("Text", context, "GoodName"));
                tbitemno.DataBindings.Add(new Binding("Text", context, "ItemNO"));
                tbmodelno.DataBindings.Add(new Binding("Text", context, "ModelNO"));

                //cbmaterial.DataBindings.Add(new Binding("Text", context, "GoodMaterial"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation", context, "FImagePath"));
 

            }
            else
            {
                tbgoodid.Text = "";
                tbgoodsname.Text = "";
                tbitemno.Text = "";
                tbmodelno.Text = "";

                //cbmaterial.Text = "";

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

        private void FreshGoods()
        {

            string sql = "select  GoodId,GoodName,ItemNO,ModelNO,FImagePath from tb_GoodsInfo order by FCreateDate desc,GoodName asc";
            ds = dbl.GetDataset(sql, "tb_GoodsInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_GoodsInfo";
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
            tbgoodsname.Text = "";
            tbitemno.Text = "";
            tbmodelno.Text = "";
            //cbmaterial.SelectedText = "";
        }
        private void SetControlsReadOnly(Boolean isEnabled)
        {
            pictureBox1.Enabled = !isEnabled;
            tbgoodid.ReadOnly = isEnabled;
            tbgoodsname.ReadOnly = isEnabled;
            tbitemno.ReadOnly = isEnabled;
            tbmodelno.ReadOnly = isEnabled;

            //cbmaterial.Enabled = !isEnabled;
        }
        private void frmGoods_Resize(object sender, EventArgs e)
        {
            asc.Resize(this);
        }


        private void btnEditClick(object sender, EventArgs e)
        {
            if (good != null)
            {
                SetControlsReadOnly(false);

            }
            toolbar1.flag = 1;
            editGoodId = tbgoodid.Text.Trim();
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
                        string id = tbgoodid.Text.Trim();
                        if (!string.IsNullOrEmpty(id))
                            goodmethod.tb_goodDelete(id);
                        FreshGoods();
                        GridRow gr = (GridRow)superGridControl1.PrimaryGrid.GetRowFromIndex(0);
                        if (gr != null)
                            SetcontrolsValueFromGrid(gr);
                        LogHelper.WriteLog(username + " 删除产品【产品编号:" + id + " 名称:" + tbgoodsname.Text.Trim() + " 货号:" + tbitemno.Text.Trim() + "器型编号:" + tbmodelno.Text.Trim() + "】");
                        if (Bm.Count == 0)
                        {
                            toolbar1.btndelete.Enabled = false;
                            toolbar1.btnedit.Enabled = false;
                        }
                    }
                }
            }
 
        }

        private void SetcontrolsValueFromGrid(GridRow gr)
        {
            tbgoodid.Text = gr["GoodId"].Value.ToString();
            tbgoodsname.Text = gr["GoodName"].Value.ToString();
            tbitemno.Text = gr["ItemNO"].Value.ToString();
            tbmodelno.Text = gr["ModelNO"].Value.ToString();
            pictureBox1.ImageLocation = gr["FImagePath"].Value.ToString();
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (superValidator1.Validate())
                {
                    if (toolbar1.flag == 0)//新增
                    {
                        good.strGoodsId = tbgoodid.Text.Trim();
                        good.strGoodsName = tbgoodsname.Text.Trim();
                        good.strItemNO = tbitemno.Text.Trim();
                        good.strModelNO = tbmodelno.Text.Trim();

                        //good.strGoodMaterial = cbmaterial.Text;
                        good.strFCreater = frmLogin1.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        System.IO.MemoryStream Ms = new MemoryStream();
                        //pictureBox1.Image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                       // byte[] img = new byte[Ms.Length];
                       // Ms.Position = 0;
                       // Ms.Read(img, 0, Convert.ToInt32(Ms.Length));
                       // good.image = img;
                        if(pathName != "")
                            good.strFImagePath = UploadImage();
                        //Ms.Close();
                        if (goodmethod.tb_GoodsInfoAdd(good) == 1)
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
                        good.strGoodsName = tbgoodsname.Text.Trim();
                        good.strItemNO = tbitemno.Text.Trim();
                        good.strModelNO = tbmodelno.Text.Trim();

                        //good.strGoodMaterial = cbmaterial.Text;
                        good.strFCreater = frmLogin1.userName;
                        good.dFCreateDate = System.DateTime.Now;
                        //System.IO.MemoryStream Ms = new MemoryStream();
                       // pictureBox1.Image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (pathName != "")
                            good.strFImagePath = UploadImage();
                        if (string.IsNullOrEmpty(editGoodId))
                        {
                            if (goodmethod.tb_goodUpdate(good) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        }
                        else
                            if (goodmethod.tb_goodUpdate(good, editGoodId) == 1)
                                MessageUtil.ShowTips("保存成功！");
                        SetControlsReadOnly(true);
                        editGoodId = "";
                    }
                    FreshGoods();
                }
            }
            catch (Exception)
            {
                MessageUtil.ShowWarning("保存失败!");
            }

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


        private void buttonX1_Click(object sender, EventArgs e)
        {
            
        }
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
                                good.strGoodsId = myDs.Tables[0].Rows[i][0].ToString();
                                good.strGoodsName = myDs.Tables[0].Rows[i][1].ToString();
                                good.strItemNO = myDs.Tables[0].Rows[i][2].ToString();
                                good.strModelNO = myDs.Tables[0].Rows[i][3].ToString();
                                //good.strGoodMaterial = myDs.Tables[0].Rows[i][4].ToString();
                                good.strFImagePath = path + good.strGoodsId + ".jpg";
                                good.strFCreater = frmLogin.userName;
                                good.dFCreateDate = System.DateTime.Now;
                                goodmethod.tb_GoodsInfoAdd(good);
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
    }
}
