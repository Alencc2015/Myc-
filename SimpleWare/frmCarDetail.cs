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
using SimpleWare.BaseClass;
using System.Data.SqlClient;
using SimpleWare.DbMethod;
using SimpleWare.ClassInfo;
using DevComponents.DotNetBar.SuperGrid;
namespace SimpleWare
{
    public partial class frmCarDetail : Office2007Form
    {
        public frmCarDetail()
        {
            InitializeComponent();
        }
        //AutoSizeFormClass asc = new AutoSizeFormClass();
        DataSet ds = new DataSet();
        Dblink  dbl = new Dblink();
        tb_JCH jch = new tb_JCH();
        private void frmCarDetail_Load(object sender, EventArgs e)
        {
            //this.Resize += new EventHandler(frmCarDetail_Resize);
            //asc.Load(this);
            tb_BaseMgr.SetCombox("KilnNO", cmbkilnno);
            cmbkilnno.Text = "";
            DateTime d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            date.Value=d1;
            enddate.Value=d2;
            InitGoodinfo();
            InitializeGrid();
        }
        private void InitializeGrid()
        {
            GridPanel panel = superGridControl1.PrimaryGrid;

            GridColumn column2 = panel.Columns["JCMaterial"];
            column2.EditorType = typeof(MaterialComboxControl);

        }
        private void InitGoodinfo()
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
                    tbgood.AutoCompleteCustomSource.AddRange(myarr);
                    tbgood.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tbgood.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  
                }

            }
 
        }

        private void frmCarDetail_Resize(object sender, EventArgs e)
        {
            //asc.Resize(this);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            object dataSource = null;
            string tosql = "select *,case when (JCPSSL + JCKLSL + JCKHSL+CYHGSL)=0 then 0 else  convert(numeric(18,4),convert(numeric(18,4),(JCPSSL + JCKLSL + JCKHSL))/convert(numeric(18,4),(JCPSSL + JCKLSL + JCKHSL+CYHGSL))) end as bhgl from ({0}) as a ";
            string sql = "select JCDATE, JCGoodsName,JCMaterial,FKilnNO,sum(case when jctype =0 then JCHGSL else 0 end) as ZYHGSL ,SUM(JCKLSL) AS JCKLSL ," +
                        " sum(case when jctype =1 then JCHGSL else 0 end) as CYHGSL,sum(JCPSSL) as JCPSSL ," +
                        " sum(JCKHSL) as JCKHSL ,JCCarNO " +
                        " from tb_jch where 1=1 ";
            if (date.Text != "")
            {
                sql += " and  JCDate >='" + date.Text.Trim() + "'";
            }
            if (enddate.Text != "")
            {
                sql += " and  JCDate <='" + enddate.Text.Trim() + "'";
            }
            if (tbgood.Text != "")
            {
                sql += " and  JCGoodsName ='"+tbgood.Text.Trim()+"'";
            }
            if (tbcar.Text != "")
            {
                sql += "and Jccarno = '" + tbcar.Text.Trim() + "'";
            }
            if (cmbkilnno.Text.Trim() != "")
            {
                sql += "and FKilnNO = '" + cmbkilnno.SelectedValue.ToString().Trim() + "'";
            }
            sql += " group by JCDATE,JCGoodsName,JCCarNO,JCMaterial,FKilnNO ";
            tosql = string.Format(tosql, sql);
            ds = dbl.GetDataset(tosql, "TB_JCH");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                //context = dataSource;//((DataSet)dataSource).Tables[0];
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "TB_JCH";
            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
                //superGridControl1.PrimaryGrid.DataMember = "TB_JCH";
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)superGridControl1.PrimaryGrid.DataSource;
            if (ds != null)
            {

                ExcelHelper.superGridToExcel(superGridControl1, "装窑明细表");
            }
        }
    }
}
