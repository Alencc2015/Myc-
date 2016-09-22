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
using SimpleWare.DbMethod;
using SimpleWare.BaseClass;
using DevComponents.DotNetBar.SuperGrid;
namespace SimpleWare
{
    public partial class frmWareDetailRpt : Office2007Form
    {
        public frmWareDetailRpt()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        Dblink dbl = new Dblink();
        Object dataSource = null;
        object context = null;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FreshJch();
        }

        private void FreshJch()
        {
            //string tosql = "select * , case when (cksl + pssl)=0 then 0 else convert(numeric(18,4),convert(numeric(18,4),pssl)/convert(numeric(18,4),(cksl + pssl))) end as psl from ({0}) as a ";
            string sql = "select b.warename ,a.FDate,FGoodsName  , case when FType = 0 then FHGSL else 0 end as rksl,  FPssl as pssl,case when FType = 1 then FHGSL else 0 end as CKSL ," +
                        "case when (FHGSL + FPSSL)=0 then 0 else convert(numeric(18,4),convert(numeric(18,4),FPSSL)/convert(numeric(18,4),(FHGSL + FPSSL))) end as psl," +
                        " sum(case when FType = 0 then FHGSL else -(FHGSL+FPSSL) end) over(partition by a.FGOODSNAME ORDER BY A.ID) as JCSL " +
                        "from WareInOut a  "+
                        " left join tb_warehouse b on a.FWareID = b.wareid  "+
                        " where 1= 1  ";
           /* if (date.Text.Trim() != "" && enddate.Text.Trim() == "")
            {
                sql = "select b.warename ,FGoodsName , " +
                             " (select sum(case when FType = 0 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName and FDate ='" + date.Text.Trim() + "') as rksl, (select sum(case when FType = 1 then ISNULL(FPSSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName    and FDate ='" + date.Text.Trim() + "') as pssl, (select sum(case when FType = 1 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName   and FDate ='" + date.Text.Trim() + "') as CKSL ," +
                             "  sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end) as JCSL" +
                             " from WareInOut a " +
                             " left join tb_warehouse b on a.FWareID = b.wareid " +
                             " where 1= 1 ";
                sql += string.Format(" and FDate <= '{0}'",date.Text.Trim());
                sql = string.Format(sql, date.Value);
            }
            if (date.Text.Trim() == "" && enddate.Text.Trim() != "")
            {
                sql = "select b.warename ,FGoodsName , " +
                            " (select sum(case when FType = 0 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName and FDate ='" + date.Text.Trim() + "') as rksl, (select sum(case when FType = 1 then ISNULL(FPSSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName   and FDate ='" + date.Text.Trim() + "') as pssl, (select sum(case when FType = 1 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName   and FDate ='" + date.Text.Trim() + "') as CKSL ,"+
                            " sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end) as JCSL" +
                            " from WareInOut a " +
                            " left join tb_warehouse b on a.FWareID = b.wareid " +
                            " where 1= 1 ";
                sql += string.Format(" and FDate <= '{0}'", date.Text.Trim());
                sql = string.Format(sql, enddate.Value, "(select sum(case when FType = 0 then FHGSL else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName  and FDate ='" + date.Text.Trim() + "') as rksl");
            }
            if (date.Text.Trim() != "" && enddate.Text.Trim() != "")
            {
                sql = "select b.warename ,FGoodsName  ," +
                             " sum(case when FType = 0 then FHGSL else 0 end) as rksl, sum(fpssl) as pssl,sum(case when FType = 1 then FHGSL else 0 end) as CKSL ,(select sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName   and FDate<='{1}') as  JCSL" +
                             " from WareInOut a " +
                             " left join tb_warehouse b on a.FWareID = b.wareid " +
                             " where 1= 1 ";
                sql += " and FDate >= '" + date.Text.Trim() + "' and FDate <= '" + enddate.Text.Trim() + "'";
                sql = string.Format(sql, date.Value,enddate.Value);
            }
            * */
            if (date.Text.Trim() != "")
            {
                sql += "and FDate >= '" + date.Text.Trim() + "' ";
            }
            if (enddate.Text.Trim() != "")
            {
                sql +=  "and FDate <= '" + enddate.Text.Trim() + "'";
            }
            if (tbgoodsname.Text.Trim() != "")
            {
                sql += " and a.FGoodsname = '" + tbgoodsname.Text.Trim() + "'";
            }
            if (cbwarehouse.Text.Trim() != "")
            {
                sql += " and a.FWareID = '" + cbwarehouse.SelectedValue.ToString() + "'";
            }
            //sql += " group by a.FWareID, b.warename,FGoodsname ";
            //sql = string.Format(sql, date.Value.AddDays(-1), date.Value);
            //tosql = string.Format(tosql, sql);
            ds = dbl.GetDataset(sql, "WareInOut");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "WareInOut";

            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
            }
        }

        private void frmWareDayRpt_Load(object sender, EventArgs e)
        {
            date.Value = System.DateTime.Now;
            enddate.Value = System.DateTime.Now;
            BindGoods();
            BindWareHouse();
            cbwarehouse.Text = "";
            FreshJch();
            //InitializeGrid();
        }
        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            GridColumn column2 = panel.Columns["FMaterial"];
            column2.EditorType = typeof(MaterialComboxControl);

        }
        private void BindWareHouse()
        {
            string sql = "select WareID,WareName from tb_WareHouse order by wareid ";
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

        private void BindGoods()
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
                        }
                    }
                    string[] myarr = listArr.ToArray();
                    tbgoodsname.AutoCompleteCustomSource.AddRange(myarr);
                    tbgoodsname.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbgoodsname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)superGridControl1.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(superGridControl1, "出入库明细表");
            }
        }
    }
}
