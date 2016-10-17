using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using SimpleWare.DbMethod;
using DevComponents.DotNetBar.SuperGrid;
using SimpleWare.BaseClass;
using DevComponents.DotNetBar.SuperGrid.Style;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using SimpleWare.BaseClass;
using SimpleWare.ClassInfo;
using NPOI.SS.Util;
namespace SimpleWare.SelPorcelainForms
{
    public partial class frmZLFXB : Office2007Form
    {
        Dblink dbl = new Dblink();
        FormAutoSizeClass asc = new FormAutoSizeClass();
        tb_SettingsMethod settingMethod = new tb_SettingsMethod();
        tb_settings setting = new tb_settings();
        Boolean isNeedRate;
        public frmZLFXB()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Dbconnection.Dblink();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = conn;
            da.SelectCommand.CommandTimeout = 0;
            da.SelectCommand.CommandText = "ZLFXRBB";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            SqlParameter param;

            param = new SqlParameter("@begindate", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = begdate.Text != "" ? begdate.Text : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@enddate", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = enddate.Text != "" ? enddate.Text : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@goodid", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value =  "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@modelno", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbmodelrpt.Text != "" ? cmbmodelrpt.SelectedValue.ToString() : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@color", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbcolorrpt.Text != "" ? cmbcolorrpt.SelectedValue.ToString() : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@worknum", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cbworknum.SelectedValue != null ? cbworknum.SelectedValue.ToString() : ""; ;// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@prodline", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);


            param = new SqlParameter("@operator", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbOpr.SelectedValue != null ? cmbOpr.SelectedValue.ToString() : ""; 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@kilnno", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbkilnno.SelectedValue != null ? cmbkilnno.SelectedValue.ToString() : ""; 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@material", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbMaterial.SelectedValue != null ? cmbMaterial.SelectedValue.ToString() : "";
            da.SelectCommand.Parameters.Add(param);

            DataSet myds = new DataSet();
            da.Fill(myds, "ZLFXRBB");
            if (myds != null)
            {
                rptGrid.PrimaryGrid.DataSource = myds;
            }
        }

        private void frmZLFXB_Load(object sender, EventArgs e)
        {

            //BindGoods();
            BindColor();
            BindModel();
            tb_EmpInfoMenthod.SetCombox(cmbOpr);
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);

            tb_BaseMgr.SetCombox("material", cmbMaterial);
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            cmbMaterial.SelectedValue = "";
            cbworknum.SelectedValue = "";

            //cmbgoodid.Text = "";
            cmbmodelrpt.Text = "";
            cmbcolorrpt.Text = "";
            cmbkilnno.SelectedValue = "";
            Boolean IsGm = frmLogin.isGm || frmLogin.isSuperGm;
            string username = frmLogin.userName;
            string usercode = frmLogin.userCode;
            if (!IsGm)
            {
                cmbOpr.Enabled = false;
                cmbOpr.SelectedValue = usercode;
            }
            else
                cmbOpr.SelectedValue = "";
            InitGrid();
            //asc.controllInitializeSize(this);
            //this.Resize += new EventHandler(frmZLFXB_Resize);
        }
        //private void BindGoods()
        //{
        //    string sql = "select GoodId,GoodName from tb_SpGoodsInfo where FIsStop = 0 order by GoodId";
        //    DataSet ds = dbl.GetDatasetReport(sql, "tb_SpGoodsInfo");
        //    List<string> listArr = new List<string>();
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0)
        //        {
        //            cmbgoodid.DataSource = ds.Tables[0];
        //            cmbgoodid.DisplayMember = "GoodId";
        //            cmbgoodid.ValueMember = "GoodId";
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                //this.lbgoods.Visible = true;
        //                //this.lbgoods.Items.Clear();
        //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                {
        //                    listArr.Add(ds.Tables[0].Rows[i][1].ToString());
        //                }
        //            }
        //            string[] myarr = listArr.ToArray();
        //            cmbgoodid.AutoCompleteCustomSource.AddRange(myarr);
        //            cmbgoodid.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //            cmbgoodid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        }
        //    }

        //}
        private void BindColor()
        {
            string sql = "select ColorNo,ColorName from tb_ColorInfo where fisstop = 0 ";
            DataSet ds = dbl.GetDatasetReport(sql, "tb_ColorInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    cmbcolorrpt.DataSource = ds.Tables[0];
                    cmbcolorrpt.DisplayMember = "ColorName";
                    cmbcolorrpt.ValueMember = "ColorNo";
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
                    cmbcolorrpt.AutoCompleteCustomSource.AddRange(myarr);
                    cmbcolorrpt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbcolorrpt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }

        }
        private void BindModel()
        {
            string sql = "select ModelNo,ModelName from tb_ModelInfo where fisstop = 0 ";
            DataSet ds = dbl.GetDatasetReport(sql, "tb_ModelInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    cmbmodelrpt.DataSource = ds.Tables[0];
                    cmbmodelrpt.DisplayMember = "ModelName";
                    cmbmodelrpt.ValueMember = "ModelNo";
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

                    cmbmodelrpt.AutoCompleteCustomSource.AddRange(myarr);
                    cmbmodelrpt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbmodelrpt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
            }
        }
        private void InitGrid()
        {
            GridPanel panel = rptGrid.PrimaryGrid;
            GridColumnCollection columns = panel.Columns;

            // Set both the Slider and SwitchButton columns to
            // our own defined EditControls

            GridColumn column1 = panel.Columns["PlModelNo"];
            column1.EditorType = typeof(ModelNoComboxControl);
            column1.Width = 150;
            GridColumn column2 = panel.Columns["PlColor"];
            column2.EditorType = typeof(ColorComboxControl);
            column2.Width = 150;
            GridColumn column3 = panel.Columns["PlKilnNo"];
            column3.EditorType = typeof(KilnNoComboxControl);
            column3.Width = 50;
            //FTypeSteps
            GridColumn column4 = panel.Columns["FTypeSteps1"];
            column4.EditorType = typeof(TypeStepComboxControl);
            column4.Width = 100;

            GridColumn column6 = panel.Columns["FMaterial"];
            column6.EditorType = typeof(MaterialComboxControl);
            column6.Width = 50;
            GridColumn column5 = panel.Columns["PlWorkNumID"];
            column5.EditorType = typeof(MyGridComboxControl);
            column5.Width = 50;


            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlGoodsID", "产品编号", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlModelNo", "器型名称", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlColor", "花色名称", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlKilnNo", "窑炉编号", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("FMaterial", "瓷质", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlWorkNumID", "班次", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("FTypeSteps1", "成型工艺", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("FMaterialQty", "瓷重", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("sumQty", "开窑总数", columns));
            //panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("HJSqty", "合计", columns));
            columns["PlGoodsID"].HeaderStyles.MouseOver.Background = new Background(Color.Yellow);

            panel.ColumnHeader.GroupHeaders.Add(GetLevelHeader(columns));//A等品

            panel.ColumnHeader.GroupHeaders.Add(GetLevelBHeader(columns));//B等品
            //panel.ColumnHeader.GroupHeaders.Add(GetLevelCHeader(columns));//C等品
            panel.ColumnHeader.GroupHeaders.Add(GetHeader(columns, "C等品", GetDisplayIndex(columns, "CQty"), GetDisplayIndex(columns, "CRate"), Color.LightYellow));
            panel.ColumnHeader.GroupHeaders.Add(GetHeader(columns, "补釉", GetDisplayIndex(columns, "BUQty"), GetDisplayIndex(columns, "BURate"), Color.LightYellow));
            panel.ColumnHeader.GroupHeaders.Add(GetHeader(columns, "废品", GetDisplayIndex(columns, "FPQty"), GetDisplayIndex(columns, "FPRate"), Color.LightYellow));
            panel.ColumnHeader.GroupHeaders.Add(GetHeader(columns, "小计", GetDisplayIndex(columns, "sumQty1"), GetDisplayIndex(columns, "sumRate1"), Color.LightYellow));
            panel.ColumnHeader.GroupHeaders.Add(GetModelHeader(columns));//成型缺陷
            panel.ColumnHeader.GroupHeaders.Add(GetGlazeHeader(columns));//釉彩缺陷
            panel.ColumnHeader.GroupHeaders.Add(GetFireHeader(columns));//看火缺陷
        }

        private ColumnGroupHeader GetLevelCHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "LevelC";
            cgh.MinRowHeight = 28;

            // Enable MiniMarkup and set the header text as needed

            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">C等品</font> </div>";

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow);
            // Create and add the subordinate group headers

            //ColumnGroupHeader cshPop = GetHeader(columns, "B甲", GetDisplayIndex(columns, "BJQty"), GetDisplayIndex(columns, "BJRate"), Color.LightYellow);
            ColumnGroupHeader cshB = GetHeader(columns, "C等", GetDisplayIndex(columns, "CQty"), GetDisplayIndex(columns, "CRate"), Color.LightYellow);


            cgh.GroupHeaders.Add(cshB);
            //cgh.GroupHeaders.Add(cshPop);

            // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "CQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "CRate");
            return (cgh);
        }

        private ColumnGroupHeader GetFireHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            //cgh.Name = "LevelB";
            cgh.MinRowHeight = 28;


            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">看火缺陷</font> </div>";

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Gold);
            cgh.HeaderStyles.Default.Background = new Background(Color.Gold);

            // Create and add the subordinate group headers

            ColumnGroupHeader csh1 = GetHeader(columns, "欠火", GetDisplayIndex(columns, "QHQty"), GetDisplayIndex(columns, "QHRate"), Color.Gold);
            ColumnGroupHeader csh2 = GetHeader(columns, "过火", GetDisplayIndex(columns, "GHQTY"), GetDisplayIndex(columns, "GHRate"), Color.Gold);
            ColumnGroupHeader csh3 = GetHeader(columns, "釉泡", GetDisplayIndex(columns, "YPQty"), GetDisplayIndex(columns, "YPRate"), Color.Gold);
            ColumnGroupHeader csh4 = GetHeader(columns, "出损", GetDisplayIndex(columns, "CSQty"), GetDisplayIndex(columns, "CSRate"), Color.Gold);
            ColumnGroupHeader csh5 = GetHeader(columns, "其他", GetDisplayIndex(columns, "KHQTQty"), GetDisplayIndex(columns, "KHQTRate"), Color.Gold);
            ColumnGroupHeader csh6 = GetHeader(columns, "小计", GetDisplayIndex(columns, "sumQty4"), GetDisplayIndex(columns, "sumRate4"), Color.Gold);
            cgh.GroupHeaders.Add(csh1);
            cgh.GroupHeaders.Add(csh2);
            cgh.GroupHeaders.Add(csh3);
            cgh.GroupHeaders.Add(csh4);
            cgh.GroupHeaders.Add(csh5);
            cgh.GroupHeaders.Add(csh6);
             // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "QHQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "sumRate4");
            return (cgh);
        }

        private ColumnGroupHeader GetGlazeHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            //cgh.Name = "LevelB";
            cgh.MinRowHeight = 28;


            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">釉彩缺陷</font> </div>";

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.Aquamarine);
            // Create and add the subordinate group headers

            ColumnGroupHeader csh1 = GetHeader(columns, "色不均", GetDisplayIndex(columns, "SBJQty"), GetDisplayIndex(columns, "SBJRate"), Color.Aquamarine);
            ColumnGroupHeader csh2 = GetHeader(columns, "色脏", GetDisplayIndex(columns, "SZQty"), GetDisplayIndex(columns, "SZRate"), Color.Aquamarine);
            ColumnGroupHeader csh3 = GetHeader(columns, "缺釉", GetDisplayIndex(columns, "QYQty"), GetDisplayIndex(columns, "QYRate"), Color.Aquamarine);
            ColumnGroupHeader csh4 = GetHeader(columns, "釉彩斑点", GetDisplayIndex(columns, "YCBDQty"), GetDisplayIndex(columns, "YCBDRate"), Color.Aquamarine);
            ColumnGroupHeader csh5 = GetHeader(columns, "缩釉", GetDisplayIndex(columns, "SYQty"), GetDisplayIndex(columns, "SYRate"), Color.Aquamarine);
            ColumnGroupHeader csh6 = GetHeader(columns, "釉缕", GetDisplayIndex(columns, "YoLQty"), GetDisplayIndex(columns, "YoLRate"), Color.Aquamarine);
            ColumnGroupHeader csh7 = GetHeader(columns, "毛孔", GetDisplayIndex(columns, "MKQty"), GetDisplayIndex(columns, "MKRate"), Color.Aquamarine);
            ColumnGroupHeader csh8 = GetHeader(columns, "落渣", GetDisplayIndex(columns, "LZQty"), GetDisplayIndex(columns, "LZRate"), Color.Aquamarine);
            ColumnGroupHeader csh9 = GetHeader(columns, "粘疤", GetDisplayIndex(columns, "NBQty"), GetDisplayIndex(columns, "NBRate"), Color.Aquamarine);
            ColumnGroupHeader csh10 = GetHeader(columns, "粘渣脚", GetDisplayIndex(columns, "NZJQty"), GetDisplayIndex(columns, "NZJRate"), Color.Aquamarine);
            ColumnGroupHeader csh11 = GetHeader(columns, "伤裂", GetDisplayIndex(columns, "SLQty"), GetDisplayIndex(columns, "SLRate"), Color.Aquamarine);
            ColumnGroupHeader csh12 = GetHeader(columns, "薄釉", GetDisplayIndex(columns, "BOUQty"), GetDisplayIndex(columns, "BOURate"), Color.Aquamarine);
            ColumnGroupHeader csh13 = GetHeader(columns, "其他", GetDisplayIndex(columns, "YCQTQty"), GetDisplayIndex(columns, "YCQTRate"), Color.Aquamarine);
            ColumnGroupHeader csh14 = GetHeader(columns, "小计", GetDisplayIndex(columns, "sumQty3"), GetDisplayIndex(columns, "sumRate3"), Color.Aquamarine);
            cgh.GroupHeaders.Add(csh1);
            cgh.GroupHeaders.Add(csh2);
            cgh.GroupHeaders.Add(csh3);
            cgh.GroupHeaders.Add(csh4);
            cgh.GroupHeaders.Add(csh5);
            cgh.GroupHeaders.Add(csh6);
            cgh.GroupHeaders.Add(csh7);
            cgh.GroupHeaders.Add(csh8);
            cgh.GroupHeaders.Add(csh9);
            cgh.GroupHeaders.Add(csh10);
            cgh.GroupHeaders.Add(csh11);
            cgh.GroupHeaders.Add(csh12);
            cgh.GroupHeaders.Add(csh13);
            cgh.GroupHeaders.Add(csh14);
            // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "SBJQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "sumRate3");
            return (cgh);
        }

        private ColumnGroupHeader GetModelHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            //cgh.Name = "LevelB";
            cgh.MinRowHeight = 28;


            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">成型缺陷</font> </div>";

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.SandyBrown);
            // Create and add the subordinate group headers

            ColumnGroupHeader csh1 = GetHeader(columns, "加工斑点", GetDisplayIndex(columns, "JGBDQty"), GetDisplayIndex(columns, "JGBDRate"), Color.SandyBrown);
            ColumnGroupHeader csh2 = GetHeader(columns, "针孔", GetDisplayIndex(columns, "ZKQty"), GetDisplayIndex(columns, "ZKRate"), Color.SandyBrown);
            ColumnGroupHeader csh3 = GetHeader(columns, "斑点", GetDisplayIndex(columns, "BDQty"), GetDisplayIndex(columns, "BDRate"), Color.SandyBrown);
            ColumnGroupHeader csh4 = GetHeader(columns, "阴裂", GetDisplayIndex(columns, "YLQty"), GetDisplayIndex(columns, "YLRate"), Color.SandyBrown);
            ColumnGroupHeader csh5 = GetHeader(columns, "凹凸", GetDisplayIndex(columns, "ATQty"), GetDisplayIndex(columns, "ATRate"), Color.SandyBrown);
            ColumnGroupHeader csh6 = GetHeader(columns, "泥渣", GetDisplayIndex(columns, "NZQty"), GetDisplayIndex(columns, "NZRate"), Color.SandyBrown);
            ColumnGroupHeader csh7 = GetHeader(columns, "缺泥", GetDisplayIndex(columns, "QNQty"), GetDisplayIndex(columns, "QNRate"), Color.SandyBrown);
            ColumnGroupHeader csh8 = GetHeader(columns, "粗糙", GetDisplayIndex(columns, "CCQty"), GetDisplayIndex(columns, "CCRate"), Color.SandyBrown);
            ColumnGroupHeader csh9 = GetHeader(columns, "开裂", GetDisplayIndex(columns, "KLQty"), GetDisplayIndex(columns, "KLRate"), Color.SandyBrown);
            ColumnGroupHeader csh10 = GetHeader(columns, "裂耳", GetDisplayIndex(columns, "LEQty"), GetDisplayIndex(columns, "LERate"), Color.SandyBrown);
            ColumnGroupHeader csh11 = GetHeader(columns, "变形", GetDisplayIndex(columns, "BXQty"), GetDisplayIndex(columns, "BXRate"), Color.SandyBrown);
            ColumnGroupHeader csh12 = GetHeader(columns, "其他", GetDisplayIndex(columns, "CXQTQty"), GetDisplayIndex(columns, "CXQTRate"), Color.SandyBrown);
            ColumnGroupHeader csh13 = GetHeader(columns, "小计", GetDisplayIndex(columns, "sumQty2"), GetDisplayIndex(columns, "sumRate2"), Color.SandyBrown);
            cgh.GroupHeaders.Add(csh1);
            cgh.GroupHeaders.Add(csh2);
            cgh.GroupHeaders.Add(csh3);
            cgh.GroupHeaders.Add(csh4);
            cgh.GroupHeaders.Add(csh5);
            cgh.GroupHeaders.Add(csh6);
            cgh.GroupHeaders.Add(csh7);
            cgh.GroupHeaders.Add(csh8);
            cgh.GroupHeaders.Add(csh9);
            cgh.GroupHeaders.Add(csh10);
            cgh.GroupHeaders.Add(csh11);
            cgh.GroupHeaders.Add(csh12);
            cgh.GroupHeaders.Add(csh13);


            // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "JGBDQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "sumRate2");
            return (cgh);
        }

        private ColumnGroupHeader GetLevelBHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "LevelB";
            cgh.MinRowHeight = 28;

            // Enable MiniMarkup and set the header text as needed

            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">B等品</font> </div>";

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow);
            // Create and add the subordinate group headers

            ColumnGroupHeader cshPop = GetHeader(columns, "B甲", GetDisplayIndex(columns, "BJQty"), GetDisplayIndex(columns, "BJRate"), Color.LightYellow);
            ColumnGroupHeader cshB = GetHeader(columns, "B等", GetDisplayIndex(columns, "BQty"), GetDisplayIndex(columns, "BRate"), Color.LightYellow);


            cgh.GroupHeaders.Add(cshB);
            cgh.GroupHeaders.Add(cshPop);

            // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "BJQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "BRate");
            return (cgh);
        }

        private ColumnGroupHeader GetHeader(GridColumnCollection columns,string headertext, int p1, int p2,Color color)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "ch" + headertext;
            cgh.HeaderText = headertext;

            //cgh.HeaderStyles.Default.Background = new Background(Color.Goldenrod, Color.Yellow, BackFillType.HorizontalCenter);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(color);
            cgh.MinRowHeight = 28;

            // Set the group's start and end display indicees

            cgh.StartDisplayIndex = p1;
            cgh.EndDisplayIndex = p2;

            return (cgh);
        }

        private ColumnGroupHeader GetLevelHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "Levels";
            cgh.MinRowHeight = 28;

            // Enable MiniMarkup and set the header text as needed

            cgh.EnableHeaderMarkup = true;

            cgh.HeaderText = "<div align=\"center\"><font size=\"12\">A等品</font> </div>" ;

            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow);
            // Create and add the subordinate group headers

            ColumnGroupHeader cshArea = GetWXHeader(columns);
            ColumnGroupHeader cshPop = GetNXHeader(columns);

            cgh.GroupHeaders.Add(cshArea);
            cgh.GroupHeaders.Add(cshPop);

            // We want the header to also contain the 'City' column
            // so we must include it in the display range.

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "WXQTY");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "NXRATE");
            return (cgh);
        }

        private ColumnGroupHeader GetNXHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "WX";
            cgh.HeaderText = "外销";

            //cgh.HeaderStyles.Default.Background = new Background(Color.Goldenrod, Color.Yellow, BackFillType.HorizontalCenter);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow);
            cgh.MinRowHeight = 36;

            // Set the group's start and end display indicees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "WXQTY");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "WXRATE");

            return (cgh);
        }

        private ColumnGroupHeader GetWXHeader(GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = "NX";
            cgh.HeaderText = "内销";

            //cgh.HeaderStyles.Default.Background = new Background(Color.Goldenrod, Color.Yellow, BackFillType.HorizontalCenter);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Yellow);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow);
            cgh.MinRowHeight = 36;

            // Set the group's start and end display indicees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, "NXQty");
            cgh.EndDisplayIndex = GetDisplayIndex(columns, "NXRATE");

            return (cgh);
        }


        private ColumnGroupHeader GetSingleInfoHeader(string fieldname, string headertext, GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = fieldname;
            cgh.HeaderText = headertext;
            // Set the header to not show the root column headers, and
            // perform some misc Style/display related setup.

            cgh.ShowColumnHeaders = Tbool.False;
            cgh.MinRowHeight = 36;

            //cgh.HeaderStyles.Default.Image = imageList1.Images["Cog"];
            cgh.HeaderStyles.Default.ImageAlignment = Alignment.MiddleCenter;
            //cgh.HeaderStyles.Default.Background = new Background(Color.LightBlue, Color.CadetBlue);
            cgh.HeaderStyles.Default.Background = new Background(Color.LightBlue);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.CadetBlue, Color.LightBlue);

            // Set the header's start and end Display Indecees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, fieldname);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, fieldname);
            return cgh;
        }

        private int GetDisplayIndex(GridColumnCollection columns, string fieldname)
        {
            return (columns.GetDisplayIndex(columns[fieldname]));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string fileName = "";//保存的excel文件名
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = "质量分析日报表";
            string[] faltsArray = { "加工斑点", "针孔", "斑点", "阴裂", "凹凸", "泥渣", "缺泥", "粗糙", "开裂", "裂耳", "变形", "其他","小计",
                                    "色不均", "色脏", "缺釉", "釉彩斑点", "缩釉", "釉缕", "毛孔", "落渣", "粘疤", "粘渣脚", "伤裂", "薄釉", "其他","小计",
                                    "欠火", "过火", "釉泡", "出损", "其他","小计" };



            setting = settingMethod.Find();
            isNeedRate = setting.IsNeedRate == 0 ? false : true;

            DataSet ds = (DataSet)rptGrid.PrimaryGrid.DataSource;
            if (ds != null)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfd.FileName;
                    int columnNums = rptGrid.PrimaryGrid.Columns.Count;//列数;
                    int rowNums = rptGrid.PrimaryGrid.Rows.Count;//行数
                    HSSFWorkbook book = new HSSFWorkbook();
                    ISheet sheet = book.CreateSheet("sheet1");

                    IRow row = sheet.CreateRow(0);
                    ICellStyle style = book.CreateCellStyle();
                    style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                    style.FillPattern = FillPattern.SolidForeground;

                    NpoiExcelHelper.setMergedRegion(sheet, row, 0, "产品编号", 0, 2, 0, 0);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 1, "器型名称", 0, 2, 1, 1);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 2, "花色名称", 0, 2, 2, 2);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 3, "窑炉编号", 0, 2, 3, 3);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 4, "瓷质", 0, 2, 4, 4);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 5, "班次", 0, 2, 5, 5);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 6, "成型工艺", 0, 2, 6, 6);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 7, "瓷重", 0, 2, 7, 7);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 8, "总数", 0, 2, 8, 8);
                    //NpoiExcelHelper.setMergedRegion(sheet, row, 8, "合计", 0, 2, 8, 8);

                    NpoiExcelHelper.setMergedRegion(sheet, row, 9, "A等品", 0, 0, 9, 12);

                    NpoiExcelHelper.setMergedRegion(sheet, row, 13, "B等品", 0, 0, 13, 16);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 17, "C等品", 0, 1, 17, 18);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 19, "补釉", 0, 1, 19, 20);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 21, "废品", 0, 1, 21, 22);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 23, "小计", 0, 1, 23, 24);

                    NpoiExcelHelper.setMergedRegion(sheet, row, 25, "成型缺陷", 0, 0, 25, 50);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 51, "釉彩缺陷", 0, 0, 51, 78);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 79, "看火缺陷", 0, 0, 79, 88);

                    IRow row2 = sheet.CreateRow(1);
                    NpoiExcelHelper.setMergedRegion(sheet, row2, 9, "外销", 1, 1, 9, 10);
                    NpoiExcelHelper.setMergedRegion(sheet, row2, 11, "内销", 1, 1, 11, 12);
                    NpoiExcelHelper.setMergedRegion(sheet, row2, 13, "B甲", 1, 1, 13, 14);
                    NpoiExcelHelper.setMergedRegion(sheet, row2, 15, "B等", 1, 1, 15, 16);

                    for (int i = 0; i < faltsArray.Length; i++)
                    {
                        int j = i * 2 + 25;
                        NpoiExcelHelper.setMergedRegion(sheet, row2, j, faltsArray[i], 1, 1, j, j+1);
                    }


                    IRow row3 = sheet.CreateRow(2);
                    NpoiExcelHelper.setQtyAndRate(row3, 9, 88,isNeedRate);
                    for (int i = 3; i < rowNums + 3; i++)//
                    {
                        IRow r = sheet.CreateRow(i);
                        if (isNeedRate)
                        {
                            for (int j = 0; j < columnNums; j++)
                            {
                                ICell c = r.CreateCell(j);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 3];
                                //瓷质
                                if (gr[j].FormattedValue != "")// gc.DataPropertyName == "FMaterial")
                                {
                                    c.SetCellValue(gr[j].FormattedValue.ToString());
                                }
                                else
                                {
                                    c.SetCellValue(gr[j].Value == null ? "" : gr[j].Value.ToString());
                                }
                                string columnname = gr[j].GridColumn.Name;
                                if (columnname.ToUpper().Contains("RATE"))
                                {
                                    if (!Convert.IsDBNull(gr[j].Value) && Convert.ToDouble(gr[j].Value) >= 5)
                                        c.CellStyle = style;
                                }

                            }
                        }
                        else
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                ICell c = r.CreateCell(j);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 3];
                                //瓷质
                                if (gr[j].FormattedValue != "")// gc.DataPropertyName == "FMaterial")
                                {
                                    c.SetCellValue(gr[j].FormattedValue.ToString());
                                }
                                else
                                {
                                    c.SetCellValue(gr[j].Value == null ? "" : gr[j].Value.ToString());
                                }
                            }
                            for (int j = 9; j < columnNums; j= j+2)
                            {
                                ICell c = r.CreateCell(j);
                                CellRangeAddress region = new CellRangeAddress(i, i, j, j + 1);
                                sheet.AddMergedRegion(region);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 3];
                                //瓷质
                                if (gr[j].FormattedValue != "")// gc.DataPropertyName == "FMaterial")
                                {
                                    c.SetCellValue(gr[j].FormattedValue.ToString());
                                }
                                else
                                {
                                    c.SetCellValue(gr[j].Value == null ? "" : gr[j].Value.ToString());
                                }

                            }
                        }
                    }
                    FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                    book.Write(file);
                    file.Flush();
                    file.Close();
                    MessageUtil.ShowTips("导出成功!");
                }

            }

        }

        private void frmZLFXB_Resize(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        private void cmbcolorrpt_DropDown(object sender, EventArgs e)
        {
            if (cmbmodelrpt.Text.Trim() != "")
            {
                string sql = "select a.FColor,b.ColorName from tb_SpGoodsInfo a " +
                             " left join tb_ColorInfo b on a.FColor = b.ColorNo " +
                             "where a.GoodName = '" + cmbmodelrpt.Text.Trim() + "'";
                DataSet ds = dbl.GetDatasetReport(sql, "good");
                List<string> listArr = new List<string>();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmbcolorrpt.DataSource = ds.Tables[0];
                            cmbcolorrpt.DisplayMember = "ColorName";
                            cmbcolorrpt.ValueMember = "FColor";
                        }

                    }
                }
            }
        }

        private void frmZLFXB_Layout(object sender, LayoutEventArgs e)
        {
            //asc.Resize(this);
        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void frmZLFXB_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        private void rptGrid_PreRenderCell(object sender, GridPreRenderCellEventArgs e)
        {

        }

        private void rptGrid_PostRenderCell(object sender, GridPostRenderCellEventArgs e)
        {
            if (e.GridCell.GridColumn.Name.ToUpper().Contains("RATE") && !Convert.IsDBNull(e.GridCell.Value) && Convert.ToDouble(e.GridCell.Value) > 5)
            {
                (sender as SuperGridControl).BackColor = Color.Red;

            }
        }
    }
}
