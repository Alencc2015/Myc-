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
    public partial class frmWareDayRpt : Office2007Form
    {
        public frmWareDayRpt()
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
            string tosql = "select * , case when (cksl + pssl)=0 then 0 else convert(numeric(18,4),convert(numeric(18,4),pssl)/convert(numeric(18,4),(cksl + pssl))) end as psl from ({0}) as a ";
            string sql = "";
            if (date.Text.Trim() != "" )
            {
                sql = "select b.warename ,FGoodsName ,FMaterial,(select sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName and FMaterial = a.FMaterial and FDate<'{0}') as zrjc, " +
                             " (select sum(case when FType = 0 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName and FMaterial = a.FMaterial and FDate ='" + date.Text.Trim() + "') as rksl, (select sum(case when FType = 1 then ISNULL(FPSSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName  and FMaterial = a.FMaterial and FDate ='" + date.Text.Trim() + "') as pssl, (select sum(case when FType = 1 then ISNULL(FHGSL,0) else 0 end) from WareInOut where FWareID=a.FWareID and FGoodsName = a.FGoodsName and FMaterial = a.FMaterial and FDate ='" + date.Text.Trim() + "') as CKSL ," +
                             "  sum(case when FType = 0 then FHGSL else -(FHGSL + FPSSL) end) as JCSL" +
                             " from WareInOut a " +
                             " left join tb_warehouse b on a.FWareID = b.wareid " +
                             " where 1= 1 ";
                sql += string.Format(" and FDate <= '{0}'",date.Text.Trim());
                sql = string.Format(sql, date.Value);
            }

            if (tbgoodsname.Text.Trim() != "")
            {
                sql += " and a.FGoodsname = '" + tbgoodsname.Text.Trim() + "'";
            }
            if (cbwarehouse.Text.Trim() != "")
            {
                sql += " and a.FWareID = '" + cbwarehouse.SelectedValue.ToString() + "'";
            }
            sql += " group by a.FWareID, b.warename,FGoodsname,FMaterial ";
            //sql = string.Format(sql, date.Value.AddDays(-1), date.Value);
            tosql = string.Format(tosql, sql);
            ds = dbl.GetDataset(tosql, "WareInOut");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "WareInOut";

                int sl = 0;
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    sl += Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[i]["JCSL"].ToString()));

                }
                lblsl.Text = sl.ToString();
            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
                lblsl.Text = "";
            }
        }

        private void frmWareDayRpt_Load(object sender, EventArgs e)
        {
            date.Value = System.DateTime.Now;
            BindGoods();
            BindWareHouse();
            cbwarehouse.Text = "";
            FreshJch();
            InitializeGrid();
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

                ExcelHelper.superGridToExcel(superGridControl1, "库存日报表");
            }
        }
    }
}
