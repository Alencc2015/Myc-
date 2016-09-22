using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using SimpleWare.BaseClass;
using DevComponents.DotNetBar.SuperGrid.Style;
using System.Data.SqlClient;
using SimpleWare.DbMethod;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using SimpleWare.ClassInfo;

namespace SimpleWare.SelPorcelainForms
{
    public partial class frmSelpainSumRpt :Office2007Form
    {
        Dblink dbl = new Dblink();
        public bool isNeedRate;
        tb_SettingsMethod settingmethod = new tb_SettingsMethod();
        tb_settings setting = new tb_settings();
        //FormAutoSizeClass asc = new FormAutoSizeClass();
        public frmSelpainSumRpt()
        {
            InitializeComponent();
        }

        private void frmSelpainSumRpt_Load(object sender, EventArgs e)
        {
            
            setting = settingmethod.Find();
            isNeedRate = setting.IsNeedRate == 1;
            //BindGood();
            BindColor();
            BindModel();
            tb_BaseMgr.SetCombox("material", cmbMaterial);
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);
            tb_BaseMgr.SetCombox("worknum", cbworknum);
            cmbMaterial.SelectedValue = "";
            //cmbgoodid.Text = "";
            cmbmodelrpt.Text = "";
            cmbcolorrpt.Text = "";
            cbworknum.SelectedValue = "";
            cmbkilnno.SelectedValue = "";

            Boolean IsGm = frmLogin.isGm || frmLogin.isSuperGm;
            string username = frmLogin.userName;
            string usercode = frmLogin.userCode;
            tb_EmpInfoMenthod.SetCombox(cmbOpr);
            if (!IsGm)
            {
                cmbOpr.Enabled = false;
                cmbOpr.SelectedValue = usercode;
            }
            else
                cmbOpr.SelectedValue = "";
            InitializeRptGrid();
            //asc.controllInitializeSize(this);
        }

        //private void BindGood()
        //{
        //    string sql = "select GoodId,GoodName from tb_SpGoodsInfo where fisstop = 0 ";
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
        //                    //tbmodelno.Items.Add(ds.Tables[0].Rows[i][1].ToString());
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
        private void InitializeRptGrid()
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

            GridColumn column4 = panel.Columns["FMaterial"];
            column4.EditorType = typeof(MaterialComboxControl);
            GridColumn column5 = panel.Columns["PlWorkNumID"];
            column5.EditorType = typeof(MyGridComboxControl);
            column3.Width = 50;
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlGoodsID", "产品编号", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlModelNo", "器型名称", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlColor", "花色名称", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlKilnNo", "窑炉编号", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("FMaterial", "瓷质", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetSingleInfoHeader("PlWorkNumID", "班次", columns));

            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajAqty", "A+", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajAdqty", "A等", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajBJqty", "B甲", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajBqty", "B等", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajCAqty", "CA等", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajBUqty", "补釉", columns));
            panel.ColumnHeader.GroupHeaders.Add(GetQtyInfoHeader("ajFPqty", "废品", columns));
            //setColumnWidth(columns,"");
        }
        private ColumnGroupHeader GetQtyInfoHeader(string fieldname, string headertext, GridColumnCollection columns)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = fieldname;
            //cgh.Name = "RegionalInfo";
            cgh.HeaderText = headertext;
            // Set the header to not show the root column headers, and
            // perform some misc Style/display related setup.
            //cgh.
            //cgh.ShowColumnHeaders = Tbool.False;
            cgh.MinRowHeight = 36;

            //cgh.HeaderStyles.Default.Image = imageList1.Images["Cog"];
            cgh.HeaderStyles.Default.ImageAlignment = Alignment.MiddleCenter;
            cgh.HeaderStyles.Default.Background = new Background(Color.LightYellow, Color.Khaki);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.Khaki, Color.LightYellow);

            // Set the header's start and end Display Indecees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, fieldname);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, fieldname) + 1;

            GridColumn column = columns[GetDisplayIndex(columns, fieldname)];
            column.Width = 50;
            //column.HeaderStyles.Styles.
            column = columns[GetDisplayIndex(columns, fieldname) + 1];
            column.Width = 50;

            return cgh;
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
            cgh.HeaderStyles.Default.Background = new Background(Color.LightBlue, Color.CadetBlue);
            cgh.HeaderStyles.MouseOver.Background = new Background(Color.CadetBlue, Color.LightBlue);

            // Set the header's start and end Display Indecees

            cgh.StartDisplayIndex = GetDisplayIndex(columns, fieldname);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, fieldname);
            return cgh;
        }
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Dbconnection.Dblink();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = conn;
            da.SelectCommand.CommandTimeout = 0;
            da.SelectCommand.CommandText = "SepPorceLainRpt";
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
            param.Value = cmbOpr.SelectedValue != null ? cmbOpr.SelectedValue.ToString() : ""; ;// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@kilnno", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbkilnno.SelectedValue != null ? cmbkilnno.SelectedValue.ToString() : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            param = new SqlParameter("@material", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.Value = cmbMaterial.SelectedValue != null ? cmbMaterial.SelectedValue.ToString() : "";// Convert.ToDateTime(inputdate); 
            da.SelectCommand.Parameters.Add(param);

            DataSet myds = new DataSet();
            da.Fill(myds, "SelporcelainRpt");
            if (myds != null)
            {
                rptGrid.PrimaryGrid.DataSource = myds;
            }

        }
        private void buttonX1_Click(object sender, System.EventArgs e)
        {
            string fileName = "";//保存的excel文件名
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "导出Excel(*.xls)|*.xls";
            sfd.FileName = "选瓷汇总表";

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

                    NpoiExcelHelper.setMergedRegion(sheet,row,0, "产品编号", 0, 1, 0, 0);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 1, "器型名称", 0, 1, 1, 1);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 2, "花色名称", 0, 1, 2, 2);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 3, "窑炉编号", 0, 1, 3, 3);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 4, "瓷质", 0, 1, 4, 4);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 5, "班次", 0, 1, 5, 5);

                    NpoiExcelHelper.setMergedRegion(sheet, row, 6, "A+", 0, 0, 6, 7);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 8, "A等", 0, 0, 8, 9);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 10, "CA等", 0, 0, 10, 11);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 12, "B甲", 0, 0, 12, 13);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 14, "B等", 0, 0, 14, 15);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 16, "补釉", 0, 0, 16, 17);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 18, "废品", 0, 0, 18, 19);
                    NpoiExcelHelper.setMergedRegion(sheet, row, 20, "总数", 0, 1, 20, 21);

                    IRow row2 = sheet.CreateRow(1);
                    NpoiExcelHelper.setQtyAndRate(row2, 4, 18,isNeedRate);
                    for (int i = 2; i < rowNums + 2; i++)//
                    {
                        IRow r = sheet.CreateRow(i);
                        if (isNeedRate)
                        {
                            for (int j = 0; j < columnNums; j++)
                            {
                                ICell c = r.CreateCell(j);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 2];
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
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                ICell c = r.CreateCell(j);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 2];
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
                            for (int j = 6; j < columnNums; j = j + 2)
                            {
                                ICell c = r.CreateCell(j);
                                CellRangeAddress region = new CellRangeAddress(i, i, j, j + 1);
                                sheet.AddMergedRegion(region);
                                GridRow gr = (GridRow)rptGrid.PrimaryGrid.Rows[i - 2];
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
                    //for (int i = 0; i <= rowNums + 2; i++)
                    //{
                    //    sheet.AutoSizeColumn(i);
                    //}
                    FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
                    book.Write(file);
                    file.Flush();
                    file.Close();
                    MessageUtil.ShowTips("导出成功!");
                }

	        }

        }

        private void frmSelpainSumRpt_Resize(object sender, EventArgs e)
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




       
        
    }
}
